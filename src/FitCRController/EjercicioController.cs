using System.Globalization;
using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Agrega ejercicios a una rutina del entrenador que inició sesión.
    /// </summary>
    public class EjercicioController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las rutinas y los ejercicios.
        /// </summary>
        public EjercicioController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están las rutinas y los ejercicios.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve los ejercicios de una rutina.
        /// </summary>
        public List<Ejercicio> ObtenerPorRutina(string idRutina)
        {
            var resultado = new List<Ejercicio>();
            foreach (var ejercicio in this.InformationService.Ejercicios)
            {
                if (ejercicio.IdRutina == idRutina)
                {
                    resultado.Add(ejercicio);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Crea un ejercicio dentro de la rutina indicada y lo guarda en el archivo.
        /// </summary>
        public bool Registrar(string idRutina, string nombre, string series, string repeticiones, string pesoRecomendado)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede agregar ejercicios.";
                return false;
            }

            if (!this.RutinaDelEntrenador(idRutina, entrenador.Id))
            {
                this.Mensaje = "Selecciona una rutina tuya.";
                return false;
            }

            nombre = nombre.Trim();
            series = series.Trim();
            repeticiones = repeticiones.Trim();
            var pesoTexto = pesoRecomendado.Trim().Replace(',', '.');

            if (nombre == string.Empty || series == string.Empty || repeticiones == string.Empty || pesoTexto == string.Empty)
            {
                this.Mensaje = "Completa el nombre, las series, las repeticiones y el peso.";
                return false;
            }

            if (nombre.Contains(','))
            {
                this.Mensaje = "El nombre no puede incluir comas.";
                return false;
            }

            if (!int.TryParse(series, out var cantidadSeries) || cantidadSeries <= 0)
            {
                this.Mensaje = "Las series deben ser un número entero mayor que cero.";
                return false;
            }

            if (!int.TryParse(repeticiones, out var cantidadRepeticiones) || cantidadRepeticiones <= 0)
            {
                this.Mensaje = "Las repeticiones deben ser un número entero mayor que cero.";
                return false;
            }

            if (!double.TryParse(pesoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var peso) || peso <= 0)
            {
                this.Mensaje = "El peso recomendado debe ser un número mayor que cero.";
                return false;
            }

            var nuevo = new Ejercicio(this.SiguienteId(), idRutina, nombre, cantidadSeries.ToString(CultureInfo.InvariantCulture), cantidadRepeticiones.ToString(CultureInfo.InvariantCulture), pesoTexto);
            this.InformationService.Ejercicios.Add(nuevo);

            if (!this.InformationService.GuardarEjercicios())
            {
                this.InformationService.Ejercicios.Remove(nuevo);
                this.Mensaje = "No se pudo guardar el ejercicio.";
                return false;
            }

            this.Mensaje = "Ejercicio agregado.";
            return true;
        }

        private bool RutinaDelEntrenador(string idRutina, string idEntrenador)
        {
            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.Id == idRutina && rutina.IdEntrenador == idEntrenador)
                {
                    return true;
                }
            }

            return false;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var ejercicio in this.InformationService.Ejercicios)
            {
                if (int.TryParse(ejercicio.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
