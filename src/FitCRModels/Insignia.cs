using System.Globalization;
using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Insignia asignada a un usuario en una fecha.
    /// El controlador decide cuándo crearla. Esta clase solo la representa.
    /// </summary>
    public class Insignia
    {
        /// <summary>
        /// Crea una insignia a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public Insignia(string id, string idUsuario, string tipo, string fecha)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Tipo = (TipoInsignia)int.Parse(tipo);
            this.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador de la insignia.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del usuario que la recibió.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Tipo de insignia, de cumplimiento o de incumplimiento.
        /// </summary>
        public TipoInsignia Tipo { get; set; }

        /// <summary>
        /// Fecha en la que se asignó.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Indica si es una insignia de incumplimiento.
        /// </summary>
        public bool EsDeIncumplimiento()
        {
            return this.Tipo == TipoInsignia.PocasVisitas
                || this.Tipo == TipoInsignia.SinProgreso
                || this.Tipo == TipoInsignia.MetaIncumplida;
        }

        /// <summary>
        /// Devuelve el nombre de la insignia en un texto listo para mostrar.
        /// </summary>
        public string ObtenerNombre()
        {
            if (this.Tipo == TipoInsignia.MetaMusculatura)
            {
                return "Meta de musculatura";
            }

            if (this.Tipo == TipoInsignia.MetaGrasa)
            {
                return "Meta de grasa";
            }

            if (this.Tipo == TipoInsignia.MetaVisitas)
            {
                return "Meta de visitas";
            }

            if (this.Tipo == TipoInsignia.PocasVisitas)
            {
                return "Pocas visitas";
            }

            if (this.Tipo == TipoInsignia.SinProgreso)
            {
                return "Sin progreso";
            }

            return "Meta incumplida";
        }

        /// <summary>
        /// Devuelve la fila CSV de esta insignia, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                ((int)this.Tipo).ToString(CultureInfo.InvariantCulture),
                this.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
