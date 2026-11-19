using System.Globalization;
using FitCRModels.Enums;

namespace FitCRModels
{
    /// <summary>
    /// Usuario del gimnasio. Hereda los datos comunes de Persona.
    /// </summary>
    public class Usuario : Persona
    {
        /// <summary>
        /// Crea un usuario a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public Usuario(string id, string nombre, string apellidos, string correo, string nombreUsuario, string contrasena, string fechaNacimiento, string peso, string altura, string rol)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Correo = correo;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.FechaNacimiento = DateTime.ParseExact(fechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Peso = double.Parse(peso, CultureInfo.InvariantCulture);
            this.Altura = double.Parse(altura, CultureInfo.InvariantCulture);
            this.Rol = (Rol)int.Parse(rol);
        }

        /// <summary>
        /// Nombre con el que la persona inicia sesión.
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Contraseña de acceso.
        /// </summary>
        public string Contrasena { get; set; }

        /// <summary>
        /// Fecha de nacimiento. La edad se calcula a partir de este dato.
        /// </summary>
        public DateTime? FechaNacimiento { get; set; }

        /// <summary>
        /// Peso actual, en kilogramos.
        /// </summary>
        public double Peso { get; set; }

        /// <summary>
        /// Estatura, en centímetros.
        /// </summary>
        public double Altura { get; set; }

        /// <summary>
        /// Rol usado para distinguir a un usuario básico de un entrenador.
        /// </summary>
        public Rol Rol { get; set; }

        /// <summary>
        /// Edad en años. Devuelve 0 si no hay fecha de nacimiento.
        /// </summary>
        public int Edad
        {
            get
            {
                if (FechaNacimiento.HasValue)
                {
                    var hoy = DateTime.Today;
                    var edad = hoy.Year - FechaNacimiento.Value.Year;
                    if (FechaNacimiento.Value.Date > hoy.AddYears(-edad))
                    {
                        edad--;
                    }

                    return edad;
                }

                return 0;
            }
        }

        /// <summary>
        /// Índice de masa corporal. La estatura se pasa de centímetros a metros.
        /// Devuelve 0 si la estatura no permite hacer el cálculo.
        /// </summary>
        public double Imc
        {
            get
            {
                if (Altura <= 0)
                {
                    return 0;
                }

                var alturaMetros = Altura / 100;
                return Peso / (alturaMetros * alturaMetros);
            }
        }

        /// <summary>
        /// Describe el rol de esta persona.
        /// Entrenador reemplaza este texto con su tipo.
        /// </summary>
        public virtual string DescribirRol()
        {
            return "Usuario básico";
        }

        /// <summary>
        /// Devuelve la fila CSV de este usuario, en el mismo orden del constructor.
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
                ((int)this.Rol).ToString());
        }
    }
}
