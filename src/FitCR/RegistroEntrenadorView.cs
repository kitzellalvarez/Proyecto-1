using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Ventana para registrar un entrenador personal o general.
    /// </summary>
    public partial class RegistroEntrenadorView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda el entrenador.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntrenadorController EntrenadorController { get; set; }

        /// <summary>
        /// Crea la ventana y recibe el controlador ya preparado.
        /// </summary>
        public RegistroEntrenadorView(EntrenadorController entrenadorController)
        {
            this.EntrenadorController = entrenadorController;
            InitializeComponent();
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var registrado = this.EntrenadorController.Registrar(
                this.TxtNombre.Text,
                this.TxtApellidos.Text,
                this.TxtCorreo.Text,
                this.TxtUsuario.Text,
                this.TxtContrasena.Text,
                this.TxtFecha.Text,
                this.TxtPeso.Text,
                this.TxtAltura.Text,
                this.CmbTipo.SelectedIndex);

            MessageBox.Show(this.EntrenadorController.Mensaje, "Fit.CR");
            if (registrado)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
