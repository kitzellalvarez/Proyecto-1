using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Crea rutinas, cambia su nombre y sus fechas, las elimina y permite consultar las de un usuario.
    /// </summary>
    public class RutinaController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las personas y las rutinas.
        /// </summary>
        public RutinaController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están los usuarios, los entrenadores y las rutinas.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve los usuarios que pueden recibir una rutina.
        /// </summary>
        public List<Usuario> ObtenerUsuariosBasicos()
        {
            var resultado = new List<Usuario>();
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (usuario.Rol == Rol.Basico)
                {
                    resultado.Add(usuario);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve las rutinas creadas por el entrenador que inició sesión.
        /// </summary>
        public List<Rutina> ObtenerRutinasDelEntrenador()
        {
            var resultado = new List<Rutina>();
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                return resultado;
            }

            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.IdEntrenador == entrenador.Id)
                {
                    resultado.Add(rutina);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve las últimas cinco rutinas de la persona que inició sesión.
        /// </summary>
        public List<Rutina> ObtenerDelUsuarioActual()
        {
            var resultado = new List<Rutina>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.IdUsuario == actual.Id)
                {
                    resultado.Add(rutina);
                }
            }

            while (resultado.Count > 5)
            {
                resultado.RemoveAt(0);
            }

            return resultado;
        }

        /// <summary>
        /// Devuelve el nombre del entrenador que asignó la rutina.
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
        /// Crea una rutina para el usuario indicado y la guarda en el archivo.
        /// El entrenador es la persona que inició sesión.
        /// </summary>
        public bool Registrar(string nombre, string idUsuario, string fechaInicio, string fechaFin)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede crear rutinas.";
                return false;
            }

            nombre = nombre.Trim();
            idUsuario = idUsuario.Trim();
            fechaInicio = fechaInicio.Trim();
            fechaFin = fechaFin.Trim();

            if (nombre == string.Empty || idUsuario == string.Empty || fechaInicio == string.Empty || fechaFin == string.Empty)
            {
                this.Mensaje = "Completa el nombre, el usuario y las dos fechas.";
                return false;
            }

            if (nombre.Contains(','))
            {
                this.Mensaje = "El nombre no puede incluir comas.";
                return false;
            }

            if (!this.ExisteUsuarioBasico(idUsuario))
            {
                this.Mensaje = "Selecciona un usuario básico.";
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

            var nueva = new Rutina(this.SiguienteId(), idUsuario, entrenador.Id, nombre, fechaInicio, fechaFin);
            this.InformationService.Rutinas.Add(nueva);

            if (!this.InformationService.GuardarRutinas())
            {
                this.InformationService.Rutinas.Remove(nueva);
                this.Mensaje = "No se pudo guardar la rutina.";
                return false;
            }

            var avisos = new NotificacionController(this.InformationService);
            avisos.AvisarRutinaNueva(nueva);
            this.Mensaje = "Rutina registrada.";
            return true;
        }

        /// <summary>
        /// Cambia el nombre y las fechas de una rutina del entrenador que inició sesión.
        /// El usuario y el entrenador de la rutina se mantienen.
        /// </summary>
        public bool Actualizar(string idRutina, string nombre, string fechaInicio, string fechaFin)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede modificar rutinas.";
                return false;
            }

            var rutina = this.BuscarPropia(idRutina, entrenador.Id);
            if (rutina == null)
            {
                this.Mensaje = "Selecciona una rutina tuya.";
                return false;
            }

            nombre = nombre.Trim();
            fechaInicio = fechaInicio.Trim();
            fechaFin = fechaFin.Trim();

            if (nombre == string.Empty || fechaInicio == string.Empty || fechaFin == string.Empty)
            {
                this.Mensaje = "Completa el nombre y las dos fechas.";
                return false;
            }

            if (nombre.Contains(','))
            {
                this.Mensaje = "El nombre no puede incluir comas.";
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

            var nombreAnterior = rutina.Nombre;
            var inicioAnterior = rutina.FechaInicio;
            var finAnterior = rutina.FechaFin;
            rutina.Nombre = nombre;
            rutina.FechaInicio = inicio;
            rutina.FechaFin = fin;

            if (!this.InformationService.GuardarRutinas())
            {
                rutina.Nombre = nombreAnterior;
                rutina.FechaInicio = inicioAnterior;
                rutina.FechaFin = finAnterior;
                this.Mensaje = "No se pudo guardar la rutina.";
                return false;
            }

            this.Mensaje = "Rutina actualizada.";
            return true;
        }

        /// <summary>
        /// Elimina una rutina del entrenador que inició sesión, sus ejercicios y el progreso de esos ejercicios.
        /// </summary>
        public bool Eliminar(string idRutina)
        {
            var entrenador = this.InformationService.UsuarioActual as Entrenador;
            if (entrenador == null)
            {
                this.Mensaje = "Solo un entrenador puede eliminar rutinas.";
                return false;
            }

            var rutina = this.BuscarPropia(idRutina, entrenador.Id);
            if (rutina == null)
            {
                this.Mensaje = "Selecciona una rutina tuya.";
                return false;
            }

            var ejercicios = new List<Ejercicio>();
            foreach (var ejercicio in this.InformationService.Ejercicios)
            {
                if (ejercicio.IdRutina == rutina.Id)
                {
                    ejercicios.Add(ejercicio);
                }
            }

            var progresos = new List<ProgresoEjercicio>();
            foreach (var ejercicio in ejercicios)
            {
                foreach (var progreso in this.InformationService.Progresos)
                {
                    if (progreso.IdEjercicio == ejercicio.Id)
                    {
                        progresos.Add(progreso);
                    }
                }
            }

            this.InformationService.Rutinas.Remove(rutina);
            foreach (var ejercicio in ejercicios)
            {
                this.InformationService.Ejercicios.Remove(ejercicio);
            }

            foreach (var progreso in progresos)
            {
                this.InformationService.Progresos.Remove(progreso);
            }

            if (!this.InformationService.GuardarRutinas() || !this.InformationService.GuardarEjercicios() || !this.InformationService.GuardarProgresos())
            {
                this.InformationService.Rutinas.Add(rutina);
                foreach (var ejercicio in ejercicios)
                {
                    this.InformationService.Ejercicios.Add(ejercicio);
                }

                foreach (var progreso in progresos)
                {
                    this.InformationService.Progresos.Add(progreso);
                }

                this.InformationService.GuardarRutinas();
                this.InformationService.GuardarEjercicios();
                this.InformationService.GuardarProgresos();
                this.Mensaje = "No se pudo eliminar la rutina.";
                return false;
            }

            this.Mensaje = "Rutina eliminada.";
            return true;
        }

        private Rutina? BuscarPropia(string idRutina, string idEntrenador)
        {
            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.Id == idRutina && rutina.IdEntrenador == idEntrenador)
                {
                    return rutina;
                }
            }

            return null;
        }

        private bool ExisteUsuarioBasico(string idUsuario)
        {
            foreach (var usuario in this.ObtenerUsuariosBasicos())
            {
                if (usuario.Id == idUsuario)
                {
                    return true;
                }
            }

            return false;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (int.TryParse(rutina.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
