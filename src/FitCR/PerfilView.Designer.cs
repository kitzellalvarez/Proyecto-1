namespace FitCR
{
    partial class PerfilView
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
            this.LblIdentidad = new Label();
            this.LblCorreo = new Label();
            this.TxtCorreo = new TextBox();
            this.LblPeso = new Label();
            this.TxtPeso = new TextBox();
            this.LblAltura = new Label();
            this.TxtAltura = new TextBox();
            this.LblImc = new Label();
            this.BtnGuardar = new Button();
            this.BtnCerrar = new Button();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Mi perfil";

            this.LblIdentidad.AutoSize = true;
            this.LblIdentidad.Location = new Point(24, 58);
            this.LblIdentidad.Name = "LblIdentidad";
            this.LblIdentidad.Text = "Identidad";

            this.LblCorreo.AutoSize = true;
            this.LblCorreo.Location = new Point(24, 168);
            this.LblCorreo.Name = "LblCorreo";
            this.LblCorreo.Text = "Correo";

            this.TxtCorreo.Location = new Point(24, 188);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new Size(360, 23);
            this.TxtCorreo.TabIndex = 0;

            this.LblPeso.AutoSize = true;
            this.LblPeso.Location = new Point(24, 224);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Text = "Peso en kilogramos";

            this.TxtPeso.Location = new Point(24, 244);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new Size(360, 23);
            this.TxtPeso.TabIndex = 1;

            this.LblAltura.AutoSize = true;
            this.LblAltura.Location = new Point(24, 280);
            this.LblAltura.Name = "LblAltura";
            this.LblAltura.Text = "Estatura en centímetros";

            this.TxtAltura.Location = new Point(24, 300);
            this.TxtAltura.Name = "TxtAltura";
            this.TxtAltura.Size = new Size(360, 23);
            this.TxtAltura.TabIndex = 2;

            this.LblImc.AutoSize = true;
            this.LblImc.Location = new Point(24, 340);
            this.LblImc.Name = "LblImc";
            this.LblImc.Text = "IMC";

            this.BtnGuardar.Location = new Point(24, 380);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new Size(170, 36);
            this.BtnGuardar.TabIndex = 3;
            this.BtnGuardar.Text = "Guardar";

            this.BtnCerrar.DialogResult = DialogResult.Cancel;
            this.BtnCerrar.Location = new Point(214, 380);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(170, 36);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnGuardar;
            this.CancelButton = this.BtnCerrar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(410, 440);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblIdentidad);
            this.Controls.Add(this.LblCorreo);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.LblAltura);
            this.Controls.Add(this.TxtAltura);
            this.Controls.Add(this.LblImc);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PerfilView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblIdentidad;
        private Label LblCorreo;
        private TextBox TxtCorreo;
        private Label LblPeso;
        private TextBox TxtPeso;
        private Label LblAltura;
        private TextBox TxtAltura;
        private Label LblImc;
        private Button BtnGuardar;
        private Button BtnCerrar;
    }
}
