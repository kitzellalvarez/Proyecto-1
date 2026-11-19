using System.Globalization;

namespace FitCRModels
{
    /// <summary>
    /// Rutina de entrenamiento asignada a un usuario por un entrenador.
    /// Los ejercicios se relacionan con esta rutina mediante Ejercicio.IdRutina.
    /// </summary>
    public class Rutina
    {
        /// <summary>
        /// Crea una rutina a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public Rutina(string id, string idUsuario, string idEntrenador, string nombre, string fechaInicio, string fechaFin)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.IdEntrenador = idEntrenador;
            this.Nombre = nombre;
            this.FechaInicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.FechaFin = DateTime.ParseExact(fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador de la rutina.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del usuario al que se asigna la rutina.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Identificador del entrenador que crea la rutina.
        /// </summary>
        public string IdEntrenador { get; set; }

        /// <summary>
        /// Nombre de la rutina, por ejemplo fuerza de piernas.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Fecha en la que empieza la rutina.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en la que termina la rutina.
        /// Sirve después para avisar al entrenador cuando esté por vencer.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Devuelve la fila CSV de esta rutina, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                this.IdEntrenador,
                this.Nombre,
                this.FechaInicio.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                this.FechaFin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
