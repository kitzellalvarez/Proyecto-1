using System.Globalization;

namespace FitCRModels
{
    /// <summary>
    /// Ejercicio que forma parte de una rutina.
    /// Guarda las series, las repeticiones y el peso recomendado.
    /// </summary>
    public class Ejercicio
    {
        /// <summary>
        /// Crea un ejercicio a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public Ejercicio(string id, string idRutina, string nombre, string series, string repeticiones, string pesoRecomendado)
        {
            this.Id = id;
            this.IdRutina = idRutina;
            this.Nombre = nombre;
            this.Series = int.Parse(series);
            this.Repeticiones = int.Parse(repeticiones);
            this.PesoRecomendado = double.Parse(pesoRecomendado, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador del ejercicio.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador de la rutina a la que pertenece este ejercicio.
        /// </summary>
        public string IdRutina { get; set; }

        /// <summary>
        /// Nombre del ejercicio, por ejemplo sentadilla o press de banca.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad de series recomendadas.
        /// </summary>
        public int Series { get; set; }

        /// <summary>
        /// Cantidad de repeticiones recomendadas en cada serie.
        /// </summary>
        public int Repeticiones { get; set; }

        /// <summary>
        /// Peso recomendado, en kilogramos.
        /// El peso que la persona realmente levanta se guardará aparte, en el progreso.
        /// </summary>
        public double PesoRecomendado { get; set; }

        /// <summary>
        /// Devuelve la fila CSV de este ejercicio, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdRutina,
                this.Nombre,
                this.Series.ToString(CultureInfo.InvariantCulture),
                this.Repeticiones.ToString(CultureInfo.InvariantCulture),
                this.PesoRecomendado.ToString(CultureInfo.InvariantCulture));
        }
    }
}
