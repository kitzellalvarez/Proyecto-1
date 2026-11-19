using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Registra una meta, dice si ya se cumplió y la consulta dentro de un período.
    /// </summary>
    public class ObjetivoController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las metas.
        /// </summary>
        public ObjetivoController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están las metas y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve las metas de la persona que inició sesión.
        /// </summary>
        public List<Objetivo> ObtenerDelUsuarioActual()
        {
            var resultado = new List<Objetivo>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var objetivo in this.InformationService.Objetivos)
            {
                if (objetivo.IdUsuario == actual.Id)
                {
                    resultado.Add(objetivo);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve las metas cuyo período toca las fechas consultadas.
        /// </summary>
        public List<Objetivo> ObtenerEnRango(DateTime inicio, DateTime fin)
        {
            var resultado = new List<Objetivo>();
            foreach (var objetivo in this.ObtenerDelUsuarioActual())
            {
                if (objetivo.FechaInicio.Date <= fin.Date && objetivo.FechaFin.Date >= inicio.Date)
                {
                    resultado.Add(objetivo);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Texto del valor de la meta dentro de las fechas consultadas.
        /// </summary>
        public string TextoValorEnRango(Objetivo objetivo, DateTime inicio, DateTime fin)
        {
            if (objetivo.Tipo == TipoObjetivo.Visitas)
            {
                return this.ContarVisitasEntre(objetivo, inicio, fin).ToString(CultureInfo.InvariantCulture);
            }

            if (this.UltimaMedicionEntre(objetivo, inicio, fin) == null)
            {
                return "-";
            }

            return this.ValorEnRango(objetivo, inicio, fin).ToString("0.##", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Devuelve Cumplida o Pendiente usando solo lo ocurrido en las fechas consultadas.
        /// </summary>
        public string EstadoEnRango(Objetivo objetivo, DateTime inicio, DateTime fin)
        {
            if (objetivo.Tipo != TipoObjetivo.Visitas && this.UltimaMedicionEntre(objetivo, inicio, fin) == null)
            {
                return "Pendiente";
            }

            if (objetivo.EstaCumplido(this.ValorEnRango(objetivo, inicio, fin)))
            {
                return "Cumplida";
            }

            return "Pendiente";
        }

        private double ValorEnRango(Objetivo objetivo, DateTime inicio, DateTime fin)
        {
            if (objetivo.Tipo == TipoObjetivo.Visitas)
            {
                return this.ContarVisitasEntre(objetivo, inicio, fin);
            }

            var medicion = this.UltimaMedicionEntre(objetivo, inicio, fin);
            if (medicion == null)
            {
                return 0;
            }

            if (objetivo.Tipo == TipoObjetivo.Grasa)
            {
                return medicion.Grasa;
            }

            return medicion.Musculatura;
        }

        private MedicionFisica? UltimaMedicionEntre(Objetivo objetivo, DateTime inicio, DateTime fin)
        {
            var desde = objetivo.FechaInicio.Date > inicio.Date ? objetivo.FechaInicio.Date : inicio.Date;
            var hasta = objetivo.FechaFin.Date < fin.Date ? objetivo.FechaFin.Date : fin.Date;
            MedicionFisica? ultima = null;
            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (medicion.IdUsuario != objetivo.IdUsuario)
                {
                    continue;
                }

                if (medicion.Fecha.Date < desde || medicion.Fecha.Date > hasta)
                {
                    continue;
                }

                if (ultima == null || medicion.Fecha.Date > ultima.Fecha.Date)
                {
                    ultima = medicion;
                }
            }

            return ultima;
        }

        private int ContarVisitasEntre(Objetivo objetivo, DateTime inicio, DateTime fin)
        {
            var desde = objetivo.FechaInicio.Date > inicio.Date ? objetivo.FechaInicio.Date : inicio.Date;
            var hasta = objetivo.FechaFin.Date < fin.Date ? objetivo.FechaFin.Date : fin.Date;
            var cantidad = 0;
            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario != objetivo.IdUsuario)
                {
                    continue;
                }

                if (visita.Fecha.Date >= desde && visita.Fecha.Date <= hasta)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        /// <summary>
        /// Devuelve el valor con el que se compara la meta.
        /// En grasa y musculatura es la última medición del período. En visitas es la cantidad de asistencias.
        /// </summary>
        public double ValorActual(Objetivo objetivo)
        {
            if (objetivo.Tipo == TipoObjetivo.Visitas)
            {
                return this.ContarVisitas(objetivo);
            }

            var medicion = this.UltimaMedicion(objetivo);
            if (medicion == null)
            {
                return 0;
            }

            if (objetivo.Tipo == TipoObjetivo.Grasa)
            {
                return medicion.Grasa;
            }

            return medicion.Musculatura;
        }

        /// <summary>
        /// Texto del valor actual. Un guion indica que en ese período no hay medición.
        /// </summary>
        public string TextoValorActual(Objetivo objetivo)
        {
            if (objetivo.Tipo != TipoObjetivo.Visitas && this.UltimaMedicion(objetivo) == null)
            {
                return "-";
            }

            return this.ValorActual(objetivo).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Devuelve Cumplida o Pendiente.
        /// La grasa se cumple al bajar hasta la meta. La musculatura y las visitas se cumplen al alcanzarla.
        /// </summary>
        public string EstadoDe(Objetivo objetivo)
        {
            if (objetivo.Tipo != TipoObjetivo.Visitas && this.UltimaMedicion(objetivo) == null)
            {
                return "Pendiente";
            }

            if (objetivo.EstaCumplido(this.ValorActual(objetivo)))
            {
                return "Cumplida";
            }

            return "Pendiente";
        }

        private MedicionFisica? UltimaMedicion(Objetivo objetivo)
        {
            MedicionFisica? ultima = null;
            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (medicion.IdUsuario != objetivo.IdUsuario)
                {
                    continue;
                }

                if (medicion.Fecha.Date < objetivo.FechaInicio.Date || medicion.Fecha.Date > objetivo.FechaFin.Date)
                {
                    continue;
                }

                if (ultima == null || medicion.Fecha.Date > ultima.Fecha.Date)
                {
                    ultima = medicion;
                }
            }

            return ultima;
        }

        private int ContarVisitas(Objetivo objetivo)
        {
            var cantidad = 0;
            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario != objetivo.IdUsuario)
                {
                    continue;
                }

                if (visita.Fecha.Date >= objetivo.FechaInicio.Date && visita.Fecha.Date <= objetivo.FechaFin.Date)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        /// <summary>
        /// Anota el tipo, el valor y las fechas de una meta.
        /// </summary>
        public bool Registrar(string tipo, string valor, string fechaInicio, string fechaFin)
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                this.Mensaje = "Solo un usuario básico puede registrar su meta.";
                return false;
            }

            tipo = tipo.Trim();
            fechaInicio = fechaInicio.Trim();
            fechaFin = fechaFin.Trim();
            var valorTexto = valor.Trim().Replace(',', '.');

            if (tipo == string.Empty || valorTexto == string.Empty || fechaInicio == string.Empty || fechaFin == string.Empty)
            {
                this.Mensaje = "Completa el tipo, el valor y las dos fechas.";
                return false;
            }

            if (!int.TryParse(tipo, out var tipoNumero) || tipoNumero < 0 || tipoNumero > 2)
            {
                this.Mensaje = "Selecciona el tipo de meta.";
                return false;
            }

            var tipoMeta = (TipoObjetivo)tipoNumero;
            if (tipoMeta == TipoObjetivo.Visitas)
            {
                if (!int.TryParse(valorTexto, out var visitas) || visitas <= 0)
                {
                    this.Mensaje = "Las visitas deben ser un número entero mayor que cero.";
                    return false;
                }
            }
            else if (!double.TryParse(valorTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var cantidad) || cantidad <= 0)
            {
                this.Mensaje = "El valor de la meta debe ser un número mayor que cero.";
                return false;
            }
            else if (tipoMeta == TipoObjetivo.Grasa && cantidad > 100)
            {
                this.Mensaje = "La grasa no puede ser mayor que 100.";
                return false;
            }

            if (!DateTime.TryParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var inicio) || !DateTime.TryParseExact(fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fin))
            {
                this.Mensaje = "Las fechas deben tener el formato aaaa-mm-dd.";
                return false;
            }

            if (fin.Date < inicio.Date)
            {
                this.Mensaje = "La fecha de fin no puede ser anterior a la de inicio.";
                return false;
            }

            var nuevo = new Objetivo(this.SiguienteId(), actual.Id, tipo, valorTexto, fechaInicio, fechaFin);
            this.InformationService.Objetivos.Add(nuevo);

            if (!this.InformationService.GuardarObjetivos())
            {
                this.InformationService.Objetivos.Remove(nuevo);
                this.Mensaje = "No se pudo guardar la meta.";
                return false;
            }

            this.Mensaje = "Meta registrada.";
            return true;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var objetivo in this.InformationService.Objetivos)
            {
                if (int.TryParse(objetivo.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
