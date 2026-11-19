using System.Globalization;
using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra el perfil de quien inició sesión y permite actualizar los datos autorizados.
    /// </summary>
    public partial class PerfilView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda el perfil.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UsuarioController UsuarioController { get; set; }

        /// <summary>
        /// Crea la ventana con los datos de la persona activa.
        /// </summary>
        public PerfilView(UsuarioController usuarioController)
        {
            this.UsuarioController = usuarioController;
            InitializeComponent();
            this.BtnGuardar.Click += this.BtnGuardar_Click;
            this.MostrarDatos();
        }

        private void MostrarDatos()
        {
            var actual = this.UsuarioController.InformationService.UsuarioActual;
            if (actual == null)
            {
                this.LblIdentidad.Text = "No hay una sesión activa.";
                return;
            }

            var fecha = actual.FechaNacimiento?.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.LblIdentidad.Text = $"{actual.Nombre} {actual.Apellidos}{Environment.NewLine}" +
                $"Usuario: {actual.NombreUsuario}{Environment.NewLine}" +
                $"Nacimiento: {fecha}{Environment.NewLine}" +
                $"Edad: {actual.Edad}{Environment.NewLine}" +
                $"{actual.DescribirRol()}";
            this.TxtCorreo.Text = actual.Correo;
            this.TxtPeso.Text = actual.Peso.ToString(CultureInfo.InvariantCulture);
            this.TxtAltura.Text = actual.Altura.ToString(CultureInfo.InvariantCulture);
            this.LblImc.Text = $"IMC: {actual.Imc.ToString("0.00", CultureInfo.InvariantCulture)}";
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            var actualizado = this.UsuarioController.ActualizarPerfil(this.TxtCorreo.Text, this.TxtPeso.Text, this.TxtAltura.Text);
            MessageBox.Show(this.UsuarioController.Mensaje, "Fit.CR");
            if (actualizado)
            {
                this.MostrarDatos();
            }
        }
    }
}
