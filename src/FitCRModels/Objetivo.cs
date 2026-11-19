using System.Globalization;
using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Meta personal de un usuario durante un período.
    /// El cumplimiento se calcula; no se guarda como un dato fijo.
    /// </summary>
    public class Objetivo
    {
        /// <summary>
        /// Crea un objetivo a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public Objetivo(string id, string idUsuario, string tipo, string valorMeta, string fechaInicio, string fechaFin)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Tipo = (TipoObjetivo)int.Parse(tipo);
            this.ValorMeta = double.Parse(valorMeta, CultureInfo.InvariantCulture);
            this.FechaInicio = DateTime.ParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.FechaFin = DateTime.ParseExact(fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador del objetivo.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del usuario dueño de la meta.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Tipo de meta: musculatura, grasa o visitas.
        /// </summary>
        public TipoObjetivo Tipo { get; set; }

        /// <summary>
        /// Valor que se quiere alcanzar.
        /// En musculatura son kilogramos, en grasa es un porcentaje y en visitas es una cantidad.
        /// </summary>
        public double ValorMeta { get; set; }

        /// <summary>
        /// Fecha en la que empieza el período de la meta.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en la que termina el período de la meta.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Indica si el valor actual ya alcanza la meta.
        /// La grasa se cumple al bajar hasta la meta. Las otras dos se cumplen al llegar o superar la meta.
        /// </summary>
        public bool EstaCumplido(double valorActual)
        {
            if (this.Tipo == TipoObjetivo.Grasa)
            {
                return valorActual <= this.ValorMeta;
            }

            return valorActual >= this.ValorMeta;
        }

        /// <summary>
        /// Devuelve el nombre de la meta en un texto listo para mostrar.
        /// </summary>
        public string ObtenerNombre()
        {
            if (this.Tipo == TipoObjetivo.Musculatura)
            {
                return "Aumentar musculatura";
            }

            if (this.Tipo == TipoObjetivo.Grasa)
            {
                return "Reducir grasa";
            }

            return "Visitas al gimnasio";
        }

        /// <summary>
        /// Devuelve la fila CSV de esta meta, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                ((int)this.Tipo).ToString(CultureInfo.InvariantCulture),
                this.ValorMeta.ToString(CultureInfo.InvariantCulture),
                this.FechaInicio.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                this.FechaFin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
        }
    }
}
