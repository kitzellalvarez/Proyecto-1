using System.Globalization;
using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Mensaje del historial de un usuario o de un entrenador.
    /// El controlador crea el mensaje cuando ocurre la condición.
    /// </summary>
    public class Notificacion
    {
        /// <summary>
        /// Crea una notificación a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// El mensaje no debe contener comas, porque la coma separa las columnas.
        /// </summary>
        public Notificacion(string id, string idUsuario, string tipo, string fecha, string mensaje)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Tipo = (TipoNotificacion)int.Parse(tipo);
            this.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Mensaje = mensaje;
        }

        /// <summary>
        /// Identificador de la notificación.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Persona que recibe el mensaje. Puede ser un usuario básico o un entrenador.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Tipo de mensaje.
        /// </summary>
        public TipoNotificacion Tipo { get; set; }

        /// <summary>
        /// Fecha del mensaje.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Texto que se muestra en el historial.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Indica si el mensaje corresponde a un entrenador.
        /// </summary>
        public bool EsParaEntrenador()
        {
            return this.Tipo == TipoNotificacion.RutinaPorVencer
                || this.Tipo == TipoNotificacion.MedicionProxima;
        }

        /// <summary>
        /// Devuelve el nombre del tipo en un texto listo para mostrar.
        /// </summary>
        public string ObtenerNombre()
        {
            if (this.Tipo == TipoNotificacion.InsigniaObtenida)
            {
                return "Insignia obtenida";
            }

            if (this.Tipo == TipoNotificacion.RutinaNueva)
            {
                return "Rutina nueva";
            }

            if (this.Tipo == TipoNotificacion.DescansoSemanal)
            {
                return "Descanso semanal";
            }

            if (this.Tipo == TipoNotificacion.InsigniaIncumplimiento)
            {
                return "Insignia de incumplimiento";
            }

            if (this.Tipo == TipoNotificacion.RutinaPorVencer)
            {
                return "Rutina por vencer";
            }

            return "Medición próxima";
        }

        /// <summary>
        /// Devuelve la fila CSV de este aviso, en el mismo orden del constructor.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                ((int)this.Tipo).ToString(CultureInfo.InvariantCulture),
                this.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                this.Mensaje);
        }
    }
}
