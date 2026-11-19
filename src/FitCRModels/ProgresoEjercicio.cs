using System.Globalization;

namespace FitCRModels
{
    /// <summary>
    /// Registro de lo que un usuario realizó en un ejercicio en una fecha.
    /// Cada avance genera un registro nuevo, para no borrar el historial.
    /// </summary>
    public class ProgresoEjercicio
    {
        /// <summary>
        /// Crea un progreso a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public ProgresoEjercicio(string id, string idEjercicio, string idUsuario, string fecha, string peso, string repeticiones)
        {
            this.Id = id;
            this.IdEjercicio = idEjercicio;
            this.IdUsuario = idUsuario;
            this.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Peso = double.Parse(peso, CultureInfo.InvariantCulture);
            this.Repeticiones = int.Parse(repeticiones);
        }

        /// <summary>
        /// Identificador de este registro de progreso.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del ejercicio realizado.
        /// </summary>
        public string IdEjercicio { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó el ejercicio.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Fecha en la que se registró el avance.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Peso realmente levantado, en kilogramos.
        /// Es distinto del peso recomendado que guarda Ejercicio.
        /// </summary>
        public double Peso { get; set; }

        /// <summary>
        /// Repeticiones realmente realizadas.
        /// </summary>
        public int Repeticiones { get; set; }

        /// <summary>
        /// Devuelve la fila CSV de este progreso, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdEjercicio,
                this.IdUsuario,
                this.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                this.Peso.ToString(CultureInfo.InvariantCulture),
                this.Repeticiones.ToString(CultureInfo.InvariantCulture));
        }
    }
}
