namespace FitCRModels.Enums
{
    /// <summary>
    /// Mensajes que aparecen en el historial de una persona.
    /// </summary>
    public enum TipoNotificacion
    {
        /// <summary>
        /// El usuario obtuvo una insignia por cumplir una meta.
        /// </summary>
        InsigniaObtenida = 0,

        /// <summary>
        /// Se le asignó una rutina nueva.
        /// </summary>
        RutinaNueva = 1,

        /// <summary>
        /// Acumuló cinco visitas en la misma semana y debe descansar.
        /// </summary>
        DescansoSemanal = 2,

        /// <summary>
        /// Recibió una insignia de incumplimiento.
        /// </summary>
        InsigniaIncumplimiento = 3,

        /// <summary>
        /// Aviso al entrenador: una rutina está por vencer.
        /// </summary>
        RutinaPorVencer = 4,

        /// <summary>
        /// Aviso al entrenador: se acerca una medición.
        /// </summary>
        MedicionProxima = 5
    }
}
