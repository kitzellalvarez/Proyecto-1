namespace FitCRController
{
    /// <summary>
    /// Indica dónde están los archivos CSV.
    /// Busca la carpeta Files subiendo desde la carpeta donde se ejecuta el programa.
    /// </summary>
    public static class Configuration
    {
        /// <summary>
        /// Ruta del archivo de usuarios.
        /// </summary>
        public static string RutaUsuarios => Path.Combine(DirectorioFiles(), "usuarios.csv");

        /// <summary>
        /// Ruta del archivo de entrenadores.
        /// </summary>
        public static string RutaEntrenadores => Path.Combine(DirectorioFiles(), "entrenadores.csv");

        /// <summary>
        /// Ruta del archivo de rutinas.
        /// </summary>
        public static string RutaRutinas => Path.Combine(DirectorioFiles(), "rutinas.csv");

        /// <summary>
        /// Ruta del archivo de ejercicios.
        /// </summary>
        public static string RutaEjercicios => Path.Combine(DirectorioFiles(), "ejercicios.csv");

        /// <summary>
        /// Ruta del archivo de progreso de los ejercicios.
        /// </summary>
        public static string RutaProgresos => Path.Combine(DirectorioFiles(), "progresos.csv");

        /// <summary>
        /// Ruta del archivo de visitas al gimnasio.
        /// </summary>
        public static string RutaVisitas => Path.Combine(DirectorioFiles(), "visitas.csv");

        /// <summary>
        /// Ruta del archivo de mediciones físicas.
        /// </summary>
        public static string RutaMediciones => Path.Combine(DirectorioFiles(), "mediciones.csv");

        /// <summary>
        /// Ruta del archivo de metas.
        /// </summary>
        public static string RutaObjetivos => Path.Combine(DirectorioFiles(), "objetivos.csv");

        /// <summary>
        /// Ruta del archivo de insignias.
        /// </summary>
        public static string RutaInsignias => Path.Combine(DirectorioFiles(), "insignias.csv");

        /// <summary>
        /// Ruta del archivo de clases del gimnasio.
        /// </summary>
        public static string RutaClases => Path.Combine(DirectorioFiles(), "clases.csv");

        /// <summary>
        /// Ruta del archivo de avisos.
        /// </summary>
        public static string RutaNotificaciones => Path.Combine(DirectorioFiles(), "notificaciones.csv");

        private static string DirectorioFiles()
        {
            var directorio = new DirectoryInfo(AppContext.BaseDirectory);

            while (directorio != null)
            {
                var files = Path.Combine(directorio.FullName, "Files");
                if (Directory.Exists(files))
                {
                    return files;
                }

                directorio = directorio.Parent;
            }

            return Path.Combine(AppContext.BaseDirectory, "Files");
        }
    }
}
