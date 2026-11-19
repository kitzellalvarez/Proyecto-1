using FitCRController.Abstractions;
using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Guarda en memoria los datos que las ventanas necesitan compartir.
    /// Conserva los usuarios, los entrenadores, las rutinas, los ejercicios, el progreso, las visitas, las mediciones, las metas, las insignias, las clases, los avisos y la persona que inició sesión.
    /// </summary>
    public class InformationService
    {
        /// <summary>
        /// Encabezado del archivo de usuarios. Debe coincidir con el orden del constructor de Usuario.
        /// </summary>
        public const string EncabezadoUsuarios = "id,nombre,apellidos,correo,nombreUsuario,contrasena,fechaNacimiento,peso,altura,rol";

        /// <summary>
        /// Encabezado del archivo de entrenadores. La última columna es el tipo.
        /// </summary>
        public const string EncabezadoEntrenadores = "id,nombre,apellidos,correo,nombreUsuario,contrasena,fechaNacimiento,peso,altura,tipo";

        /// <summary>
        /// Encabezado del archivo de rutinas.
        /// </summary>
        public const string EncabezadoRutinas = "id,idUsuario,idEntrenador,nombre,fechaInicio,fechaFin";

        /// <summary>
        /// Encabezado del archivo de ejercicios.
        /// </summary>
        public const string EncabezadoEjercicios = "id,idRutina,nombre,series,repeticiones,pesoRecomendado";

        /// <summary>
        /// Encabezado del archivo de progreso de los ejercicios.
        /// </summary>
        public const string EncabezadoProgresos = "id,idEjercicio,idUsuario,fecha,peso,repeticiones";

        /// <summary>
        /// Encabezado del archivo de visitas.
        /// </summary>
        public const string EncabezadoVisitas = "id,idUsuario,fecha";

        /// <summary>
        /// Encabezado del archivo de mediciones. El IMC no va en el archivo.
        /// </summary>
        public const string EncabezadoMediciones = "id,idUsuario,fecha,peso,altura,grasa,musculatura";

        /// <summary>
        /// Encabezado del archivo de metas.
        /// </summary>
        public const string EncabezadoObjetivos = "id,idUsuario,tipo,valorMeta,fechaInicio,fechaFin";

        /// <summary>
        /// Encabezado del archivo de insignias.
        /// </summary>
        public const string EncabezadoInsignias = "id,idUsuario,tipo,fecha";

        /// <summary>
        /// Encabezado del archivo de clases del gimnasio.
        /// </summary>
        public const string EncabezadoClases = "id,tipo,horario,idEntrenador";

        /// <summary>
        /// Encabezado del archivo de avisos.
        /// </summary>
        public const string EncabezadoNotificaciones = "id,idUsuario,tipo,fecha,mensaje";

        /// <summary>
        /// Carga los usuarios y los entrenadores.
        /// Si un archivo falla, su lista queda vacía y el texto queda en MensajeError.
        /// </summary>
        public InformationService(IDataHandler<Usuario> usuariosHandler, string rutaUsuarios, IDataHandler<Entrenador> entrenadoresHandler, string rutaEntrenadores, IDataHandler<Rutina> rutinasHandler, string rutaRutinas, IDataHandler<Ejercicio> ejerciciosHandler, string rutaEjercicios, IDataHandler<ProgresoEjercicio> progresosHandler, string rutaProgresos, IDataHandler<VisitaGimnasio> visitasHandler, string rutaVisitas, IDataHandler<MedicionFisica> medicionesHandler, string rutaMediciones, IDataHandler<Objetivo> objetivosHandler, string rutaObjetivos, IDataHandler<Insignia> insigniasHandler, string rutaInsignias, IDataHandler<ClaseGimnasio> clasesHandler, string rutaClases, IDataHandler<Notificacion> notificacionesHandler, string rutaNotificaciones)
        {
            this.UsuariosHandler = usuariosHandler;
            this.RutaUsuarios = rutaUsuarios;
            this.EntrenadoresHandler = entrenadoresHandler;
            this.RutaEntrenadores = rutaEntrenadores;
            this.RutinasHandler = rutinasHandler;
            this.RutaRutinas = rutaRutinas;
            this.EjerciciosHandler = ejerciciosHandler;
            this.RutaEjercicios = rutaEjercicios;
            this.ProgresosHandler = progresosHandler;
            this.RutaProgresos = rutaProgresos;
            this.VisitasHandler = visitasHandler;
            this.RutaVisitas = rutaVisitas;
            this.MedicionesHandler = medicionesHandler;
            this.RutaMediciones = rutaMediciones;
            this.ObjetivosHandler = objetivosHandler;
            this.RutaObjetivos = rutaObjetivos;
            this.InsigniasHandler = insigniasHandler;
            this.RutaInsignias = rutaInsignias;
            this.ClasesHandler = clasesHandler;
            this.RutaClases = rutaClases;
            this.NotificacionesHandler = notificacionesHandler;
            this.RutaNotificaciones = rutaNotificaciones;
            this.MensajeError = string.Empty;

            try
            {
                this.Usuarios = this.UsuariosHandler.LoadData(rutaUsuarios);
            }
            catch (Exception ex)
            {
                this.Usuarios = new List<Usuario>();
                this.MensajeError = ex.Message;
            }

            try
            {
                this.Entrenadores = this.EntrenadoresHandler.LoadData(rutaEntrenadores);
            }
            catch (Exception ex)
            {
                this.Entrenadores = new List<Entrenador>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Rutinas = this.RutinasHandler.LoadData(rutaRutinas);
            }
            catch (Exception ex)
            {
                this.Rutinas = new List<Rutina>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Ejercicios = this.EjerciciosHandler.LoadData(rutaEjercicios);
            }
            catch (Exception ex)
            {
                this.Ejercicios = new List<Ejercicio>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Progresos = this.ProgresosHandler.LoadData(rutaProgresos);
            }
            catch (Exception ex)
            {
                this.Progresos = new List<ProgresoEjercicio>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Visitas = this.VisitasHandler.LoadData(rutaVisitas);
            }
            catch (Exception ex)
            {
                this.Visitas = new List<VisitaGimnasio>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Mediciones = this.MedicionesHandler.LoadData(rutaMediciones);
            }
            catch (Exception ex)
            {
                this.Mediciones = new List<MedicionFisica>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Objetivos = this.ObjetivosHandler.LoadData(rutaObjetivos);
            }
            catch (Exception ex)
            {
                this.Objetivos = new List<Objetivo>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Insignias = this.InsigniasHandler.LoadData(rutaInsignias);
            }
            catch (Exception ex)
            {
                this.Insignias = new List<Insignia>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Clases = this.ClasesHandler.LoadData(rutaClases);
            }
            catch (Exception ex)
            {
                this.Clases = new List<ClaseGimnasio>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }

            try
            {
                this.Notificaciones = this.NotificacionesHandler.LoadData(rutaNotificaciones);
            }
            catch (Exception ex)
            {
                this.Notificaciones = new List<Notificacion>();
                if (this.MensajeError == string.Empty)
                {
                    this.MensajeError = ex.Message;
                }
            }
        }

        /// <summary>
        /// Lector y escritor del archivo de usuarios.
        /// </summary>
        public IDataHandler<Usuario> UsuariosHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de usuarios.
        /// </summary>
        public string RutaUsuarios { get; set; }

        /// <summary>
        /// Usuarios cargados desde el archivo.
        /// </summary>
        public List<Usuario> Usuarios { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de entrenadores.
        /// </summary>
        public IDataHandler<Entrenador> EntrenadoresHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de entrenadores.
        /// </summary>
        public string RutaEntrenadores { get; set; }

        /// <summary>
        /// Entrenadores cargados desde su archivo.
        /// </summary>
        public List<Entrenador> Entrenadores { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de rutinas.
        /// </summary>
        public IDataHandler<Rutina> RutinasHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de rutinas.
        /// </summary>
        public string RutaRutinas { get; set; }

        /// <summary>
        /// Rutinas cargadas desde el archivo.
        /// </summary>
        public List<Rutina> Rutinas { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de ejercicios.
        /// </summary>
        public IDataHandler<Ejercicio> EjerciciosHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de ejercicios.
        /// </summary>
        public string RutaEjercicios { get; set; }

        /// <summary>
        /// Ejercicios cargados desde el archivo.
        /// </summary>
        public List<Ejercicio> Ejercicios { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de progreso.
        /// </summary>
        public IDataHandler<ProgresoEjercicio> ProgresosHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de progreso.
        /// </summary>
        public string RutaProgresos { get; set; }

        /// <summary>
        /// Progresos cargados desde el archivo.
        /// </summary>
        public List<ProgresoEjercicio> Progresos { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de visitas.
        /// </summary>
        public IDataHandler<VisitaGimnasio> VisitasHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de visitas.
        /// </summary>
        public string RutaVisitas { get; set; }

        /// <summary>
        /// Visitas cargadas desde el archivo.
        /// </summary>
        public List<VisitaGimnasio> Visitas { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de mediciones.
        /// </summary>
        public IDataHandler<MedicionFisica> MedicionesHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de mediciones.
        /// </summary>
        public string RutaMediciones { get; set; }

        /// <summary>
        /// Mediciones cargadas desde el archivo.
        /// </summary>
        public List<MedicionFisica> Mediciones { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de metas.
        /// </summary>
        public IDataHandler<Objetivo> ObjetivosHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de metas.
        /// </summary>
        public string RutaObjetivos { get; set; }

        /// <summary>
        /// Metas cargadas desde el archivo.
        /// </summary>
        public List<Objetivo> Objetivos { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de insignias.
        /// </summary>
        public IDataHandler<Insignia> InsigniasHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de insignias.
        /// </summary>
        public string RutaInsignias { get; set; }

        /// <summary>
        /// Insignias cargadas desde el archivo.
        /// </summary>
        public List<Insignia> Insignias { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de clases.
        /// </summary>
        public IDataHandler<ClaseGimnasio> ClasesHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de clases.
        /// </summary>
        public string RutaClases { get; set; }

        /// <summary>
        /// Clases cargadas desde el archivo.
        /// </summary>
        public List<ClaseGimnasio> Clases { get; set; }

        /// <summary>
        /// Lector y escritor del archivo de avisos.
        /// </summary>
        public IDataHandler<Notificacion> NotificacionesHandler { get; set; }

        /// <summary>
        /// Ruta del archivo CSV de avisos.
        /// </summary>
        public string RutaNotificaciones { get; set; }

        /// <summary>
        /// Avisos cargados desde el archivo.
        /// </summary>
        public List<Notificacion> Notificaciones { get; set; }

        /// <summary>
        /// Persona que inició sesión. Está vacía hasta que el ingreso sea correcto.
        /// </summary>
        public Usuario? UsuarioActual { get; set; }

        /// <summary>
        /// Texto del problema encontrado al leer el archivo. Queda vacío si la lectura fue correcta.
        /// </summary>
        public string MensajeError { get; set; }

        /// <summary>
        /// Escribe la lista actual de usuarios en el archivo CSV.
        /// </summary>
        public bool GuardarUsuarios()
        {
            return this.UsuariosHandler.SaveData(this.RutaUsuarios, EncabezadoUsuarios, this.Usuarios);
        }

        /// <summary>
        /// Escribe la lista actual de entrenadores en su archivo CSV.
        /// </summary>
        public bool GuardarEntrenadores()
        {
            return this.EntrenadoresHandler.SaveData(this.RutaEntrenadores, EncabezadoEntrenadores, this.Entrenadores);
        }

        /// <summary>
        /// Escribe la lista actual de rutinas en el archivo CSV.
        /// </summary>
        public bool GuardarRutinas()
        {
            return this.RutinasHandler.SaveData(this.RutaRutinas, EncabezadoRutinas, this.Rutinas);
        }

        /// <summary>
        /// Escribe la lista actual de ejercicios en el archivo CSV.
        /// </summary>
        public bool GuardarEjercicios()
        {
            return this.EjerciciosHandler.SaveData(this.RutaEjercicios, EncabezadoEjercicios, this.Ejercicios);
        }

        /// <summary>
        /// Escribe la lista actual de progresos en el archivo CSV.
        /// </summary>
        public bool GuardarProgresos()
        {
            return this.ProgresosHandler.SaveData(this.RutaProgresos, EncabezadoProgresos, this.Progresos);
        }

        /// <summary>
        /// Escribe la lista actual de visitas en el archivo CSV.
        /// </summary>
        public bool GuardarVisitas()
        {
            return this.VisitasHandler.SaveData(this.RutaVisitas, EncabezadoVisitas, this.Visitas);
        }

        /// <summary>
        /// Escribe la lista actual de mediciones en el archivo CSV.
        /// </summary>
        public bool GuardarMediciones()
        {
            return this.MedicionesHandler.SaveData(this.RutaMediciones, EncabezadoMediciones, this.Mediciones);
        }

        /// <summary>
        /// Escribe la lista actual de metas en el archivo CSV.
        /// </summary>
        public bool GuardarObjetivos()
        {
            return this.ObjetivosHandler.SaveData(this.RutaObjetivos, EncabezadoObjetivos, this.Objetivos);
        }

        /// <summary>
        /// Escribe la lista actual de insignias en el archivo CSV.
        /// </summary>
        public bool GuardarInsignias()
        {
            return this.InsigniasHandler.SaveData(this.RutaInsignias, EncabezadoInsignias, this.Insignias);
        }

        /// <summary>
        /// Escribe la lista actual de clases en el archivo CSV.
        /// </summary>
        public bool GuardarClases()
        {
            return this.ClasesHandler.SaveData(this.RutaClases, EncabezadoClases, this.Clases);
        }

        /// <summary>
        /// Escribe la lista actual de avisos en el archivo CSV.
        /// </summary>
        public bool GuardarNotificaciones()
        {
            return this.NotificacionesHandler.SaveData(this.RutaNotificaciones, EncabezadoNotificaciones, this.Notificaciones);
        }
    }
}
