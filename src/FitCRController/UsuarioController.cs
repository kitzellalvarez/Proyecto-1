using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Registra usuarios básicos y actualiza el perfil de quien inició sesión.
    /// </summary>
    public class UsuarioController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene los usuarios.
        /// </summary>
        public UsuarioController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde está la lista de usuarios.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica por qué el registro no se pudo hacer, o confirma que sí se guardó.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Valida los datos, crea el usuario y lo escribe en el CSV.
        /// El rol siempre es básico. El registro de entrenadores se hará aparte.
        /// </summary>
        public bool Registrar(string nombre, string apellidos, string correo, string nombreUsuario, string contrasena, string fechaNacimiento, string peso, string altura)
        {
            nombre = nombre.Trim();
            apellidos = apellidos.Trim();
            correo = correo.Trim();
            nombreUsuario = nombreUsuario.Trim();
            contrasena = contrasena.Trim();
            fechaNacimiento = fechaNacimiento.Trim();
            var pesoTexto = peso.Trim().Replace(',', '.');
            var alturaTexto = altura.Trim().Replace(',', '.');

            if (nombre == string.Empty || apellidos == string.Empty || correo == string.Empty || nombreUsuario == string.Empty || contrasena == string.Empty || fechaNacimiento == string.Empty || pesoTexto == string.Empty || alturaTexto == string.Empty)
            {
                this.Mensaje = "Completa todos los datos.";
                return false;
            }

            if (nombre.Contains(',') || apellidos.Contains(',') || correo.Contains(',') || nombreUsuario.Contains(',') || contrasena.Contains(','))
            {
                this.Mensaje = "Los datos no pueden incluir comas.";
                return false;
            }

            if (!correo.Contains('@') || !correo.Contains('.'))
            {
                this.Mensaje = "Escribe un correo válido.";
                return false;
            }

            if (!DateTime.TryParseExact(fechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha) || fecha.Date > DateTime.Today)
            {
                this.Mensaje = "La fecha debe tener el formato aaaa-mm-dd y no puede ser futura.";
                return false;
            }

            if (!double.TryParse(pesoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var pesoNumero) || pesoNumero <= 0)
            {
                this.Mensaje = "El peso debe ser un número mayor que cero.";
                return false;
            }

            if (!double.TryParse(alturaTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var alturaNumero) || alturaNumero <= 0)
            {
                this.Mensaje = "La estatura debe ser un número mayor que cero, en centímetros.";
                return false;
            }

            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (string.Equals(usuario.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    this.Mensaje = "Ese nombre de usuario ya existe.";
                    return false;
                }

                if (string.Equals(usuario.Correo, correo, StringComparison.OrdinalIgnoreCase))
                {
                    this.Mensaje = "Ese correo ya está registrado.";
                    return false;
                }
            }

            foreach (var entrenador in this.InformationService.Entrenadores)
            {
                if (string.Equals(entrenador.NombreUsuario, nombreUsuario, StringComparison.OrdinalIgnoreCase))
                {
                    this.Mensaje = "Ese nombre de usuario ya existe.";
                    return false;
                }

                if (string.Equals(entrenador.Correo, correo, StringComparison.OrdinalIgnoreCase))
                {
                    this.Mensaje = "Ese correo ya está registrado.";
                    return false;
                }
            }

            var nuevo = new Usuario(this.SiguienteId(), nombre, apellidos, correo, nombreUsuario, contrasena, fechaNacimiento, pesoTexto, alturaTexto, ((int)Rol.Basico).ToString());
            this.InformationService.Usuarios.Add(nuevo);

            if (!this.InformationService.GuardarUsuarios())
            {
                this.InformationService.Usuarios.Remove(nuevo);
                this.Mensaje = "No se pudo guardar el usuario.";
                return false;
            }

            this.Mensaje = "Usuario registrado.";
            return true;
        }

        /// <summary>
        /// Actualiza el correo, el peso y la estatura de la persona que inició sesión.
        /// El nombre, el usuario, la contraseña y la fecha de nacimiento no se cambian aquí.
        /// </summary>
        public bool ActualizarPerfil(string correo, string peso, string altura)
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null)
            {
                this.Mensaje = "No hay una sesión activa.";
                return false;
            }

            correo = correo.Trim();
            var pesoTexto = peso.Trim().Replace(',', '.');
            var alturaTexto = altura.Trim().Replace(',', '.');

            if (correo == string.Empty || pesoTexto == string.Empty || alturaTexto == string.Empty)
            {
                this.Mensaje = "Completa el correo, el peso y la estatura.";
                return false;
            }

            if (correo.Contains(',') || !correo.Contains('@') || !correo.Contains('.'))
            {
                this.Mensaje = "Escribe un correo válido, sin comas.";
                return false;
            }

            if (!double.TryParse(pesoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var pesoNumero) || pesoNumero <= 0)
            {
                this.Mensaje = "El peso debe ser un número mayor que cero.";
                return false;
            }

            if (!double.TryParse(alturaTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var alturaNumero) || alturaNumero <= 0)
            {
                this.Mensaje = "La estatura debe ser un número mayor que cero, en centímetros.";
                return false;
            }

            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (usuario.Id != actual.Id && string.Equals(usuario.Correo, correo, StringComparison.OrdinalIgnoreCase))
                {
                    this.Mensaje = "Ese correo ya está registrado.";
                    return false;
                }
            }

            var correoAnterior = actual.Correo;
            var pesoAnterior = actual.Peso;
            var alturaAnterior = actual.Altura;
            actual.Correo = correo;
            actual.Peso = pesoNumero;
            actual.Altura = alturaNumero;

            if (!this.InformationService.GuardarUsuarios())
            {
                actual.Correo = correoAnterior;
                actual.Peso = pesoAnterior;
                actual.Altura = alturaAnterior;
                this.Mensaje = "No se pudo guardar el perfil.";
                return false;
            }

            this.Mensaje = "Perfil actualizado.";
            return true;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (int.TryParse(usuario.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
