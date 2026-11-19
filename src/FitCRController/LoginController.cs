using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Revisa el ingreso de una persona al sistema.
    /// </summary>
    public class LoginController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene los usuarios.
        /// </summary>
        public LoginController(InformationService informationService)
        {
            this.InformationService = informationService;
        }

        /// <summary>
        /// Servicio donde está la lista de usuarios y la persona que inicia sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Comprueba el nombre de usuario, o el correo, y la contraseña.
        /// Si son correctos, guarda a esa persona como usuario actual.
        /// </summary>
        public bool Ingresar(string nombreUsuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                return false;
            }

            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (this.Coincide(usuario, nombreUsuario, contrasena))
                {
                    this.InformationService.UsuarioActual = usuario;
                    return true;
                }
            }

            foreach (var entrenador in this.InformationService.Entrenadores)
            {
                if (this.Coincide(entrenador, nombreUsuario, contrasena))
                {
                    this.InformationService.UsuarioActual = entrenador;
                    return true;
                }
            }

            return false;
        }

        private bool Coincide(Usuario persona, string nombreUsuario, string contrasena)
        {
            var usuarioCoincide = persona.NombreUsuario == nombreUsuario || persona.Correo == nombreUsuario;
            return usuarioCoincide && persona.Contrasena == contrasena;
        }
    }
}
