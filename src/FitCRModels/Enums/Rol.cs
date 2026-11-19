namespace FitCRModels.Enums
{
    /// <summary>
    /// Define los dos roles que pueden ingresar a Fit.CR.
    /// </summary>
    public enum Rol
    {
        /// <summary>
        /// Usuario que entrena en el gimnasio.
        /// Las estadísticas solo consideran este rol.
        /// </summary>
        Basico = 0,

        /// <summary>
        /// Entrenador del gimnasio.
        /// </summary>
        Entrenador = 1
    }
}
