using System.Globalization;
using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Anota el peso y las repeticiones de un ejercicio, y compara cada marca con la anterior.
    /// </summary>
    public class ProgresoController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene los ejercicios y el progreso.
        /// </summary>
        public ProgresoController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están las rutinas, los ejercicios y el progreso.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve el historial de un ejercicio, en el orden en que fue anotado.
        /// </summary>
        public List<ProgresoEjercicio> ObtenerPorEjercicio(string idEjercicio)
        {
            var resultado = new List<ProgresoEjercicio>();
            foreach (var progreso in this.InformationService.Progresos)
            {
                if (progreso.IdEjercicio == idEjercicio)
                {
                    resultado.Add(progreso);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve el progreso de la persona que inició sesión.
        /// Un entrenador no recibe filas por aquí, porque su consulta está en cada ejercicio.
        /// </summary>
        public List<ProgresoEjercicio> ObtenerDelUsuarioActual()
        {
            var resultado = new List<ProgresoEjercicio>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var progreso in this.InformationService.Progresos)
            {
                if (progreso.IdUsuario == actual.Id)
                {
                    resultado.Add(progreso);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve el nombre del ejercicio. Si ya no existe, devuelve su identificador.
        /// </summary>
        public string NombreDelEjercicio(string idEjercicio)
        {
            foreach (var ejercicio in this.InformationService.Ejercicios)
            {
                if (ejercicio.Id == idEjercicio)
                {
                    return ejercicio.Nombre;
                }
            }

            return idEjercicio;
        }

        /// <summary>
        /// Devuelve el nombre de la rutina a la que pertenece el ejercicio.
        /// </summary>
        public string NombreDeLaRutina(string idEjercicio)
        {
            var idRutina = string.Empty;
            foreach (var ejercicio in this.InformationService.Ejercicios)
            {
                if (ejercicio.Id == idEjercicio)
                {
                    idRutina = ejercicio.IdRutina;
                    break;
                }
            }

            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.Id == idRutina)
                {
                    return rutina.Nombre;
                }
            }

            return idRutina;
        }

        /// <summary>
        /// Compara el peso de una marca con la marca anterior del mismo ejercicio.
        /// </summary>
        public string TextoDeAumento(List<ProgresoEjercicio> historial, int posicion)
        {
            if (historial == null || posicion <= 0 || posicion >= historial.Count)
            {
                return "Primera";
            }

            var marca = historial[posicion];
            ProgresoEjercicio? anterior = null;
            for (var i = 0; i < posicion; i++)
            {
                if (historial[i].IdEjercicio == marca.IdEjercicio)
                {
                    anterior = historial[i];
                }
            }

            if (anterior == null)
            {
                return "Primera";
            }

            var diferencia = marca.Peso - anterior.Peso;
            var texto = diferencia.ToString("0.##", CultureInfo.InvariantCulture);
            if (diferencia > 0)
            {
                return "+" + texto;
            }

            return texto;
        }

        /// <summary>
        /// Agrega un registro de progreso al ejercicio indicado y lo guarda en el archivo.
        /// El usuario del registro es la persona dueña de la rutina.
        /// </summary>
        public bool Registrar(string idEjercicio, string fecha, string peso, string repeticiones)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede anotar el progreso.";
                return false;
            }

            var rutina = this.RutinaDelEjercicio(idEjercicio, entrenador.Id);
            if (rutina == null)
            {
                this.Mensaje = "Selecciona un ejercicio de una rutina tuya.";
                return false;
            }

            fecha = fecha.Trim();
            repeticiones = repeticiones.Trim();
            var pesoTexto = peso.Trim().Replace(',', '.');

            if (fecha == string.Empty || pesoTexto == string.Empty || repeticiones == string.Empty)
            {
                this.Mensaje = "Completa la fecha, el peso y las repeticiones.";
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

            if (!double.TryParse(pesoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var kilos) || kilos <= 0)
            {
                this.Mensaje = "El peso debe ser un número mayor que cero.";
                return false;
            }

            if (!int.TryParse(repeticiones, out var cantidad) || cantidad <= 0)
            {
                this.Mensaje = "Las repeticiones deben ser un número entero mayor que cero.";
                return false;
            }

            var nuevo = new ProgresoEjercicio(this.SiguienteId(), idEjercicio, rutina.IdUsuario, fecha, pesoTexto, cantidad.ToString(CultureInfo.InvariantCulture));
            this.InformationService.Progresos.Add(nuevo);

            if (!this.InformationService.GuardarProgresos())
            {
                this.InformationService.Progresos.Remove(nuevo);
                this.Mensaje = "No se pudo guardar el progreso.";
                return false;
            }

            this.Mensaje = "Progreso anotado.";
            return true;
        }

        private Rutina? RutinaDelEjercicio(string idEjercicio, string idEntrenador)
        {
            Ejercicio? ejercicio = null;
            foreach (var actual in this.InformationService.Ejercicios)
            {
                if (actual.Id == idEjercicio)
                {
                    ejercicio = actual;
                    break;
                }
            }

            if (ejercicio == null)
            {
                return null;
            }

            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.Id == ejercicio.IdRutina && rutina.IdEntrenador == idEntrenador)
                {
                    return rutina;
                }
            }

            return null;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var progreso in this.InformationService.Progresos)
            {
                if (int.TryParse(progreso.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
