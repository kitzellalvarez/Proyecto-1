namespace FitCRModels.Enums
{
    /// <summary>
    /// Insignias que puede recibir un usuario.
    /// Las tres primeras reconocen una meta cumplida.
    /// Las tres últimas corresponden a un incumplimiento.
    /// </summary>
    public enum TipoInsignia
    {
        /// <summary>
        /// Cumplió la meta de musculatura.
        /// </summary>
        MetaMusculatura = 0,

        /// <summary>
        /// Cumplió la meta de grasa.
        /// </summary>
        MetaGrasa = 1,

        /// <summary>
        /// Cumplió la meta de visitas.
        /// </summary>
        MetaVisitas = 2,

        /// <summary>
        /// Está entre los diez usuarios con menos visitas.
        /// </summary>
        PocasVisitas = 3,

        /// <summary>
        /// No registró su progreso.
        /// </summary>
        SinProgreso = 4,

        /// <summary>
        /// No cumplió un objetivo.
        /// </summary>
        MetaIncumplida = 5
    }
}
