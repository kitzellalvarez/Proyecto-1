using FitCRController;
using FitCRModels;

namespace FitCR
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada de Fit.CR.
        /// Prepara el archivo, el servicio, el controlador y abre la ventana de ingreso.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var datosUsuarios = new FileHandler<Usuario>();
            var datosEntrenadores = new FileHandler<Entrenador>();
            var datosRutinas = new FileHandler<Rutina>();
            var datosEjercicios = new FileHandler<Ejercicio>();
            var datosProgresos = new FileHandler<ProgresoEjercicio>();
            var datosVisitas = new FileHandler<VisitaGimnasio>();
            var datosMediciones = new FileHandler<MedicionFisica>();
            var datosObjetivos = new FileHandler<Objetivo>();
            var datosInsignias = new FileHandler<Insignia>();
            var datosClases = new FileHandler<ClaseGimnasio>();
            var datosNotificaciones = new FileHandler<Notificacion>();
            var servicio = new InformationService(datosUsuarios, Configuration.RutaUsuarios, datosEntrenadores, Configuration.RutaEntrenadores, datosRutinas, Configuration.RutaRutinas, datosEjercicios, Configuration.RutaEjercicios, datosProgresos, Configuration.RutaProgresos, datosVisitas, Configuration.RutaVisitas, datosMediciones, Configuration.RutaMediciones, datosObjetivos, Configuration.RutaObjetivos, datosInsignias, Configuration.RutaInsignias, datosClases, Configuration.RutaClases, datosNotificaciones, Configuration.RutaNotificaciones);
            var login = new LoginController(servicio);
            Application.Run(new LoginView(login));
        }
    }
}
