using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Registra una clase del gimnasio y permite consultarla.
    /// </summary>
    public class ClaseController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las clases.
        /// </summary>
        public ClaseController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están las clases y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve las clases del entrenador que inició sesión.
        /// </summary>
        public List<ClaseGimnasio> ObtenerDelEntrenadorActual()
        {
            var resultado = new List<ClaseGimnasio>();
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                return resultado;
            }

            foreach (var clase in this.InformationService.Clases)
            {
                if (clase.IdEntrenador == entrenador.Id)
                {
                    resultado.Add(clase);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve todas las clases del gimnasio, para que un usuario pueda consultarlas.
        /// </summary>
        public List<ClaseGimnasio> ObtenerTodas()
        {
            var resultado = new List<ClaseGimnasio>();
            foreach (var clase in this.InformationService.Clases)
            {
                resultado.Add(clase);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve el nombre del entrenador encargado. Si ya no existe, devuelve su identificador.
        /// </summary>
        public string NombreDelEntrenador(string idEntrenador)
        {
            foreach (var entrenador in this.InformationService.Entrenadores)
            {
                if (entrenador.Id == idEntrenador)
                {
                    return entrenador.Nombre + " " + entrenador.Apellidos;
                }
            }

            return idEntrenador;
        }

        /// <summary>
        /// Anota el tipo y el horario de una clase. El entrenador es quien inició sesión.
        /// </summary>
        public bool Registrar(string tipo, string horario)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede registrar una clase.";
                return false;
            }

            tipo = tipo.Trim();
            horario = horario.Trim();
            if (tipo == string.Empty || horario == string.Empty)
            {
                this.Mensaje = "Selecciona el tipo y escribe el horario.";
                return false;
            }

            if (horario.Contains(','))
            {
                this.Mensaje = "El horario no puede incluir comas.";
                return false;
            }

            if (!int.TryParse(tipo, out var tipoNumero) || tipoNumero < 0 || tipoNumero > 4)
            {
                this.Mensaje = "Selecciona el tipo de clase.";
                return false;
            }

            var tipoClase = (TipoClase)tipoNumero;
            foreach (var clase in this.InformationService.Clases)
            {
                if (clase.IdEntrenador == entrenador.Id && clase.Tipo == tipoClase && clase.Horario == horario)
                {
                    this.Mensaje = "Ya registraste esa clase en ese horario.";
                    return false;
                }
            }

            var nueva = new ClaseGimnasio(this.SiguienteId(), tipo, horario, entrenador.Id);
            this.InformationService.Clases.Add(nueva);

            if (!this.InformationService.GuardarClases())
            {
                this.InformationService.Clases.Remove(nueva);
                this.Mensaje = "No se pudo guardar la clase.";
                return false;
            }

            this.Mensaje = "Clase registrada.";
            return true;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var clase in this.InformationService.Clases)
            {
                if (int.TryParse(clase.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
