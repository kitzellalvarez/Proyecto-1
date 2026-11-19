using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Ventana de ingreso al sistema.
    /// </summary>
    public partial class LoginView : Form
    {
        /// <summary>
        /// Controlador que revisa el usuario y la contraseña.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public LoginController LoginController { get; set; }

        /// <summary>
        /// Crea la ventana y recibe el controlador ya preparado.
        /// </summary>
        public LoginView(LoginController loginController)
        {
            this.LoginController = loginController;
            InitializeComponent();
            this.BtnIngresar.Click += this.BtnIngresar_Click;
            this.BtnRegistrarse.Click += this.BtnRegistrarse_Click;
            this.BtnRegistrarEntrenador.Click += this.BtnRegistrarEntrenador_Click;
        }

        private void BtnIngresar_Click(object? sender, EventArgs e)
        {
            var mensajeError = this.LoginController.InformationService.MensajeError;
            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError, "Fit.CR");
                return;
            }

            var nombreUsuario = this.TxtUsuario.Text;
            var contrasena = this.TxtContrasena.Text;
            var ingresoCorrecto = this.LoginController.Ingresar(nombreUsuario, contrasena);

            var actual = this.LoginController.InformationService.UsuarioActual;
            if (ingresoCorrecto && actual != null)
            {
                this.AbrirMenu();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Fit.CR");
            }
        }

        private void BtnRegistrarse_Click(object? sender, EventArgs e)
        {
            var controlador = new UsuarioController(this.LoginController.InformationService);
            var ventana = new RegistroView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnRegistrarEntrenador_Click(object? sender, EventArgs e)
        {
            var controlador = new EntrenadorController(this.LoginController.InformationService);
            var ventana = new RegistroEntrenadorView(controlador);
            ventana.ShowDialog(this);
        }

        private void AbrirMenu()
        {
            this.Hide();
            var menu = new MainMenuView(this.LoginController.InformationService);
            menu.FormClosed += this.Menu_FormClosed;
            menu.Show();
        }

        private void Menu_FormClosed(object? sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
