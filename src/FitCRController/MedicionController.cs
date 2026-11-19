using System.Globalization;
using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Registra una medición física y permite consultar el historial de peso.
    /// </summary>
    public class MedicionController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las mediciones.
        /// </summary>
        public MedicionController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están las mediciones y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve las mediciones de la persona que inició sesión.
        /// </summary>
        public List<MedicionFisica> ObtenerDelUsuarioActual()
        {
            var resultado = new List<MedicionFisica>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (medicion.IdUsuario == actual.Id)
                {
                    resultado.Add(medicion);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve las mediciones de la persona, de la más antigua a la más reciente.
        /// </summary>
        public List<MedicionFisica> ObtenerHistorialDePeso()
        {
            var resultado = this.ObtenerDelUsuarioActual();
            for (var i = 0; i < resultado.Count; i++)
            {
                for (var j = i + 1; j < resultado.Count; j++)
                {
                    if (resultado[j].Fecha < resultado[i].Fecha)
                    {
                        var temporal = resultado[i];
                        resultado[i] = resultado[j];
                        resultado[j] = temporal;
                    }
                }
            }

            return resultado;
        }

        /// <summary>
        /// Compara el peso de una fila con el de la medición anterior.
        /// </summary>
        public string TextoDeAumento(int posicion, List<MedicionFisica> historial)
        {
            if (posicion <= 0 || historial == null || posicion >= historial.Count)
            {
                return "Primera";
            }

            var diferencia = historial[posicion].Peso - historial[posicion - 1].Peso;
            var texto = diferencia.ToString("0.##", CultureInfo.InvariantCulture);
            if (diferencia > 0)
            {
                return "+" + texto;
            }

            return texto;
        }

        /// <summary>
        /// Compara el primer peso y el último de la persona dentro de un período.
        /// </summary>
        public string TextoDeAumentoEnRango(DateTime inicio, DateTime fin)
        {
            var enRango = new List<MedicionFisica>();
            foreach (var medicion in this.ObtenerHistorialDePeso())
            {
                if (medicion.Fecha.Date >= inicio.Date && medicion.Fecha.Date <= fin.Date)
                {
                    enRango.Add(medicion);
                }
            }

            if (enRango.Count == 0)
            {
                return "No hay mediciones en ese período.";
            }

            var ultima = enRango[enRango.Count - 1];
            var fecha = ultima.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            var peso = ultima.Peso.ToString("0.##", CultureInfo.InvariantCulture);
            if (enRango.Count == 1)
            {
                return "Peso del " + fecha + ": " + peso + " kg. Aumento: Primera.";
            }

            var diferencia = ultima.Peso - enRango[0].Peso;
            var aumento = diferencia.ToString("0.##", CultureInfo.InvariantCulture);
            if (diferencia > 0)
            {
                aumento = "+" + aumento;
            }

            return "Peso del " + fecha + ": " + peso + " kg. Aumento: " + aumento + ".";
        }

        /// <summary>
        /// Anota peso, altura, grasa y musculatura de la persona que inició sesión.
        /// </summary>
        public bool Registrar(string fecha, string peso, string altura, string grasa, string musculatura)
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                this.Mensaje = "Solo un usuario básico puede registrar su medición.";
                return false;
            }

            fecha = fecha.Trim();
            if (fecha == string.Empty)
            {
                this.Mensaje = "Escribe la fecha de la medición.";
                return false;
            }

            if (!DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dia))
            {
                this.Mensaje = "La fecha debe tener el formato aaaa-mm-dd.";
                return false;
            }

            if (dia.Date > DateTime.Today)
            {
                this.Mensaje = "La fecha no puede ser posterior a hoy.";
                return false;
            }

            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (medicion.IdUsuario == actual.Id && medicion.Fecha.Date == dia.Date)
                {
                    this.Mensaje = "Ya registraste una medición en esa fecha.";
                    return false;
                }
            }

            if (!this.LeerObligatorio(peso, "El peso", out var pesoTexto) || !this.LeerObligatorio(altura, "La altura", out var alturaTexto))
            {
                return false;
            }

            if (!this.LeerOpcional(grasa, "La grasa", 100, out var grasaTexto) || !this.LeerOpcional(musculatura, "La musculatura", 0, out var musculaturaTexto))
            {
                return false;
            }

            var nueva = new MedicionFisica(this.SiguienteId(), actual.Id, fecha, pesoTexto, alturaTexto, grasaTexto, musculaturaTexto);
            this.InformationService.Mediciones.Add(nueva);

            if (!this.InformationService.GuardarMediciones())
            {
                this.InformationService.Mediciones.Remove(nueva);
                this.Mensaje = "No se pudo guardar la medición.";
                return false;
            }

            this.Mensaje = "Medición registrada.";
            return true;
        }

        private bool LeerObligatorio(string texto, string nombre, out string normalizado)
        {
            normalizado = texto.Trim().Replace(',', '.');
            if (normalizado == string.Empty)
            {
                this.Mensaje = nombre + " es obligatorio.";
                return false;
            }

            if (!double.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out var valor) || valor <= 0)
            {
                this.Mensaje = nombre + " debe ser un número mayor que cero.";
                return false;
            }

            return true;
        }

        private bool LeerOpcional(string texto, string nombre, double maximo, out string normalizado)
        {
            normalizado = texto.Trim().Replace(',', '.');
            if (normalizado == string.Empty)
            {
                normalizado = "0";
                return true;
            }

            if (!double.TryParse(normalizado, NumberStyles.Number, CultureInfo.InvariantCulture, out var valor) || valor < 0)
            {
                this.Mensaje = nombre + " debe ser un número igual o mayor que cero.";
                return false;
            }

            if (maximo > 0 && valor > maximo)
            {
                this.Mensaje = nombre + " no puede ser mayor que " + maximo.ToString(CultureInfo.InvariantCulture) + ".";
                return false;
            }

            return true;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (int.TryParse(medicion.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
