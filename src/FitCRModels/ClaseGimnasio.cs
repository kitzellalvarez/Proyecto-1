using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Actividad ofrecida por el gimnasio, con horario y entrenador encargado.
    /// Se llama ClaseGimnasio para no confundirla con una clase de C#.
    /// </summary>
    public class ClaseGimnasio
    {
        /// <summary>
        /// Crea una clase a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public ClaseGimnasio(string id, string tipo, string horario, string idEntrenador)
        {
            this.Id = id;
            this.Tipo = (TipoClase)int.Parse(tipo);
            this.Horario = horario;
            this.IdEntrenador = idEntrenador;
        }

        /// <summary>
        /// Identificador de la clase.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Tipo de actividad: yoga, gimnasio abierto, crossfit, zumba o spinning.
        /// </summary>
        public TipoClase Tipo { get; set; }

        /// <summary>
        /// Horario de la clase. No debe incluir comas, porque la coma separa las columnas del CSV.
        /// </summary>
        public string Horario { get; set; }

        /// <summary>
        /// Identificador del entrenador encargado.
        /// </summary>
        public string IdEntrenador { get; set; }

        /// <summary>
        /// Devuelve el nombre de la actividad en un texto listo para mostrar.
        /// </summary>
        public string ObtenerNombre()
        {
            if (this.Tipo == TipoClase.GimnasioAbierto)
            {
                return "Gimnasio abierto";
            }

            return this.Tipo.ToString();
        }

        /// <summary>
        /// Devuelve la fila CSV de esta clase, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                ((int)this.Tipo).ToString(),
                this.Horario,
                this.IdEntrenador);
        }
    }
}
