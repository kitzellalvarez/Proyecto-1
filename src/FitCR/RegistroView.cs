using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Ventana para registrar un usuario básico.
    /// </summary>
    public partial class RegistroView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda el usuario.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UsuarioController UsuarioController { get; set; }

        /// <summary>
        /// Crea la ventana y recibe el controlador ya preparado.
        /// </summary>
        public RegistroView(UsuarioController usuarioController)
        {
            this.UsuarioController = usuarioController;
            InitializeComponent();
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var registrado = this.UsuarioController.Registrar(
                this.TxtNombre.Text,
                this.TxtApellidos.Text,
                this.TxtCorreo.Text,
                this.TxtUsuario.Text,
                this.TxtContrasena.Text,
                this.TxtFecha.Text,
                this.TxtPeso.Text,
                this.TxtAltura.Text);

            MessageBox.Show(this.UsuarioController.Mensaje, "Fit.CR");
            if (registrado)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
