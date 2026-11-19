namespace FitCRModels
{
    /// <summary>
    /// Datos comunes de cualquier persona del gimnasio.
    /// Es abstracta porque en el sistema una persona es un usuario o un entrenador.
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Identificador con el que se relaciona esta persona en los archivos.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellidos de la persona.
        /// </summary>
        public string Apellidos { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico.
        /// </summary>
        public string Correo { get; set; } = string.Empty;
    }
}
