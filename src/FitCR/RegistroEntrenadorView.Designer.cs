namespace FitCR
{
    partial class RegistroEntrenadorView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.LblTitulo = new Label();
            this.LblNombre = new Label();
            this.TxtNombre = new TextBox();
            this.LblApellidos = new Label();
            this.TxtApellidos = new TextBox();
            this.LblCorreo = new Label();
            this.TxtCorreo = new TextBox();
            this.LblUsuario = new Label();
            this.TxtUsuario = new TextBox();
            this.LblContrasena = new Label();
            this.TxtContrasena = new TextBox();
            this.LblFecha = new Label();
            this.TxtFecha = new TextBox();
            this.LblPeso = new Label();
            this.TxtPeso = new TextBox();
            this.LblAltura = new Label();
            this.TxtAltura = new TextBox();
            this.LblTipo = new Label();
            this.CmbTipo = new ComboBox();
            this.BtnRegistrar = new Button();
            this.BtnCancelar = new Button();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Registro de entrenador";

            this.CrearEtiqueta(this.LblNombre, "Nombre", 56);
            this.CrearCaja(this.TxtNombre, 76, 1);
            this.CrearEtiqueta(this.LblApellidos, "Apellidos", 108);
            this.CrearCaja(this.TxtApellidos, 128, 2);
            this.CrearEtiqueta(this.LblCorreo, "Correo", 160);
            this.CrearCaja(this.TxtCorreo, 180, 3);
            this.CrearEtiqueta(this.LblUsuario, "Usuario", 212);
            this.CrearCaja(this.TxtUsuario, 232, 4);
            this.CrearEtiqueta(this.LblContrasena, "Contraseña", 264);
            this.CrearCaja(this.TxtContrasena, 284, 5);
            this.TxtContrasena.UseSystemPasswordChar = true;
            this.CrearEtiqueta(this.LblFecha, "Fecha de nacimiento (aaaa-mm-dd)", 316);
            this.CrearCaja(this.TxtFecha, 336, 6);
            this.TxtFecha.PlaceholderText = "1998-04-02";
            this.CrearEtiqueta(this.LblPeso, "Peso en kilogramos (0 si no aplica)", 368);
            this.CrearCaja(this.TxtPeso, 388, 7);
            this.TxtPeso.PlaceholderText = "0";
            this.CrearEtiqueta(this.LblAltura, "Estatura en centímetros (0 si no aplica)", 420);
            this.CrearCaja(this.TxtAltura, 440, 8);
            this.TxtAltura.PlaceholderText = "0";
            this.CrearEtiqueta(this.LblTipo, "Tipo de entrenador", 472);

            this.CmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbTipo.Items.Add("Personal");
            this.CmbTipo.Items.Add("General");
            this.CmbTipo.Location = new Point(24, 492);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new Size(376, 23);
            this.CmbTipo.TabIndex = 9;
            this.CmbTipo.SelectedIndex = 0;

            this.BtnRegistrar.Location = new Point(24, 536);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new Size(180, 36);
            this.BtnRegistrar.TabIndex = 10;
            this.BtnRegistrar.Text = "Registrar";

            this.BtnCancelar.DialogResult = DialogResult.Cancel;
            this.BtnCancelar.Location = new Point(220, 536);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new Size(180, 36);
            this.BtnCancelar.TabIndex = 11;
            this.BtnCancelar.Text = "Cancelar";

            this.AcceptButton = this.BtnRegistrar;
            this.CancelButton = this.BtnCancelar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(430, 592);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblApellidos);
            this.Controls.Add(this.TxtApellidos);
            this.Controls.Add(this.LblCorreo);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblContrasena);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.LblAltura);
            this.Controls.Add(this.TxtAltura);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.BtnCancelar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RegistroEntrenadorView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CrearEtiqueta(Label etiqueta, string texto, int y)
        {
            etiqueta.AutoSize = true;
            etiqueta.Location = new Point(24, y);
            etiqueta.Text = texto;
        }

        private void CrearCaja(TextBox caja, int y, int tabIndex)
        {
            caja.Location = new Point(24, y);
            caja.Size = new Size(376, 23);
            caja.TabIndex = tabIndex;
        }

        private Label LblTitulo;
        private Label LblNombre;
        private TextBox TxtNombre;
        private Label LblApellidos;
        private TextBox TxtApellidos;
        private Label LblCorreo;
        private TextBox TxtCorreo;
        private Label LblUsuario;
        private TextBox TxtUsuario;
        private Label LblContrasena;
        private TextBox TxtContrasena;
        private Label LblFecha;
        private TextBox TxtFecha;
        private Label LblPeso;
        private TextBox TxtPeso;
        private Label LblAltura;
        private TextBox TxtAltura;
        private Label LblTipo;
        private ComboBox CmbTipo;
        private Button BtnRegistrar;
        private Button BtnCancelar;
    }
}
