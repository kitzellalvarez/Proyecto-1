using System.Globalization;

namespace FitCRModels
{
    /// <summary>
    /// Una visita de un usuario al gimnasio en una fecha.
    /// Cada asistencia genera un registro nuevo, para conservar el historial.
    /// </summary>
    public class VisitaGimnasio
    {
        /// <summary>
        /// Crea una visita a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public VisitaGimnasio(string id, string idUsuario, string fecha)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador de la visita.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del usuario que asistió.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Fecha de la visita.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Devuelve la fila CSV de esta visita, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                this.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
