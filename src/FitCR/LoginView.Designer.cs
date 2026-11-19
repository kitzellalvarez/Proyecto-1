namespace FitCR
{
    partial class LoginView
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
            this.LblUsuario = new Label();
            this.TxtUsuario = new TextBox();
            this.LblContrasena = new Label();
            this.TxtContrasena = new TextBox();
            this.BtnIngresar = new Button();
            this.BtnRegistrarse = new Button();
            this.BtnRegistrarEntrenador = new Button();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(36, 28);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new Size(92, 32);
            this.LblTitulo.Text = "Fit.CR";

            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new Point(38, 88);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new Size(118, 15);
            this.LblUsuario.Text = "Usuario o correo";

            this.TxtUsuario.Location = new Point(38, 112);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new Size(320, 23);
            this.TxtUsuario.TabIndex = 0;

            this.LblContrasena.AutoSize = true;
            this.LblContrasena.Location = new Point(38, 152);
            this.LblContrasena.Name = "LblContrasena";
            this.LblContrasena.Size = new Size(73, 15);
            this.LblContrasena.Text = "Contraseña";

            this.TxtContrasena.Location = new Point(38, 176);
            this.TxtContrasena.Name = "TxtContrasena";
            this.TxtContrasena.Size = new Size(320, 23);
            this.TxtContrasena.TabIndex = 1;
            this.TxtContrasena.UseSystemPasswordChar = true;

            this.BtnIngresar.Location = new Point(38, 220);
            this.BtnIngresar.Name = "BtnIngresar";
            this.BtnIngresar.Size = new Size(320, 36);
            this.BtnIngresar.TabIndex = 2;
            this.BtnIngresar.Text = "Ingresar";

            this.BtnRegistrarse.Location = new Point(38, 264);
            this.BtnRegistrarse.Name = "BtnRegistrarse";
            this.BtnRegistrarse.Size = new Size(320, 36);
            this.BtnRegistrarse.TabIndex = 3;
            this.BtnRegistrarse.Text = "Registrarse";

            this.BtnRegistrarEntrenador.Location = new Point(38, 308);
            this.BtnRegistrarEntrenador.Name = "BtnRegistrarEntrenador";
            this.BtnRegistrarEntrenador.Size = new Size(320, 36);
            this.BtnRegistrarEntrenador.TabIndex = 4;
            this.BtnRegistrarEntrenador.Text = "Registrar entrenador";

            this.AcceptButton = this.BtnIngresar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 370);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblContrasena);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.BtnIngresar);
            this.Controls.Add(this.BtnRegistrarse);
            this.Controls.Add(this.BtnRegistrarEntrenador);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblUsuario;
        private TextBox TxtUsuario;
        private Label LblContrasena;
        private TextBox TxtContrasena;
        private Button BtnIngresar;
        private Button BtnRegistrarse;
        private Button BtnRegistrarEntrenador;
    }
}
