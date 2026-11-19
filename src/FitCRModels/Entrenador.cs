using System.Globalization;
using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Entrenador del gimnasio. Es un usuario con un tipo adicional.
    /// </summary>
    public class Entrenador : Usuario
    {
        /// <summary>
        /// Crea un entrenador a partir de los textos de una fila CSV.
        /// El rol siempre queda como entrenador, para excluirlo de las estadísticas del usuario básico.
        /// </summary>
        public Entrenador(string id, string nombre, string apellidos, string correo, string nombreUsuario, string contrasena, string fechaNacimiento, string peso, string altura, string tipo)
            : base(id, nombre, apellidos, correo, nombreUsuario, contrasena, fechaNacimiento, peso, altura, ((int)Rol.Entrenador).ToString())
        {
            this.Tipo = (TipoEntrenador)int.Parse(tipo);
        }

        /// <summary>
        /// Indica si es entrenador personal o general.
        /// </summary>
        public TipoEntrenador Tipo { get; set; }

        /// <summary>
        /// Reemplaza la descripción del usuario básico con el tipo de entrenador.
        /// </summary>
        public override string DescribirRol()
        {
            if (this.Tipo == TipoEntrenador.Personal)
            {
                return "Entrenador personal";
            }

            return "Entrenador general";
        }

        /// <summary>
        /// Devuelve la fila CSV de este entrenador.
        /// La última columna es el tipo, no el rol.
        /// </summary>
        public override string ToString()
        {
            var fecha = this.FechaNacimiento?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            return string.Join(",",
                this.Id,
                this.Nombre,
                this.Apellidos,
                this.Correo,
                this.NombreUsuario,
                this.Contrasena,
                fecha,
                this.Peso.ToString(CultureInfo.InvariantCulture),
                this.Altura.ToString(CultureInfo.InvariantCulture),
                ((int)this.Tipo).ToString());
        }
    }
}
