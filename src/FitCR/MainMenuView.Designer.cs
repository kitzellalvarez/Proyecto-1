namespace FitCR
{
    partial class MainMenuView
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
            this.LblBienvenida = new Label();
            this.LblDetalle = new Label();
            this.BtnPerfil = new Button();
            this.BtnEntrenadores = new Button();
            this.BtnNuevaRutina = new Button();
            this.BtnClase = new Button();
            this.BtnMiProgreso = new Button();
            this.BtnVisita = new Button();
            this.BtnMedicion = new Button();
            this.BtnMeta = new Button();
            this.BtnInsignias = new Button();
            this.BtnConsultaClases = new Button();
            this.BtnAvisos = new Button();
            this.BtnMisRutinas = new Button();
            this.BtnHistorialPeso = new Button();
            this.BtnEstadisticas = new Button();
            this.BtnSalir = new Button();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(36, 28);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new Size(92, 32);
            this.LblTitulo.Text = "Fit.CR";

            this.LblBienvenida.AutoSize = true;
            this.LblBienvenida.Font = new Font("Segoe UI", 14F);
            this.LblBienvenida.Location = new Point(38, 84);
            this.LblBienvenida.Name = "LblBienvenida";
            this.LblBienvenida.Size = new Size(70, 25);
            this.LblBienvenida.Text = "Hola";

            this.LblDetalle.AutoSize = true;
            this.LblDetalle.Location = new Point(38, 124);
            this.LblDetalle.Name = "LblDetalle";
            this.LblDetalle.Size = new Size(38, 15);
            this.LblDetalle.Text = "Detalle";

            this.BtnPerfil.Location = new Point(38, 188);
            this.BtnPerfil.Name = "BtnPerfil";
            this.BtnPerfil.Size = new Size(320, 36);
            this.BtnPerfil.TabIndex = 0;
            this.BtnPerfil.Text = "Mi perfil";

            this.BtnEntrenadores.Location = new Point(38, 232);
            this.BtnEntrenadores.Name = "BtnEntrenadores";
            this.BtnEntrenadores.Size = new Size(320, 36);
            this.BtnEntrenadores.TabIndex = 1;
            this.BtnEntrenadores.Text = "Entrenadores";

            this.BtnNuevaRutina.Location = new Point(38, 276);
            this.BtnNuevaRutina.Name = "BtnNuevaRutina";
            this.BtnNuevaRutina.Size = new Size(320, 36);
            this.BtnNuevaRutina.TabIndex = 2;
            this.BtnNuevaRutina.Text = "Nueva rutina";
            this.BtnNuevaRutina.Visible = false;

            this.BtnClase.Location = new Point(38, 320);
            this.BtnClase.Name = "BtnClase";
            this.BtnClase.Size = new Size(320, 36);
            this.BtnClase.TabIndex = 8;
            this.BtnClase.Text = "Nueva clase";
            this.BtnClase.Visible = false;

            this.BtnMiProgreso.Location = new Point(38, 276);
            this.BtnMiProgreso.Name = "BtnMiProgreso";
            this.BtnMiProgreso.Size = new Size(320, 36);
            this.BtnMiProgreso.TabIndex = 3;
            this.BtnMiProgreso.Text = "Mi progreso";
            this.BtnMiProgreso.Visible = false;

            this.BtnVisita.Location = new Point(38, 320);
            this.BtnVisita.Name = "BtnVisita";
            this.BtnVisita.Size = new Size(320, 36);
            this.BtnVisita.TabIndex = 4;
            this.BtnVisita.Text = "Registrar visita";
            this.BtnVisita.Visible = false;

            this.BtnMedicion.Location = new Point(38, 364);
            this.BtnMedicion.Name = "BtnMedicion";
            this.BtnMedicion.Size = new Size(320, 36);
            this.BtnMedicion.TabIndex = 5;
            this.BtnMedicion.Text = "Registrar medición";
            this.BtnMedicion.Visible = false;

            this.BtnMeta.Location = new Point(38, 408);
            this.BtnMeta.Name = "BtnMeta";
            this.BtnMeta.Size = new Size(320, 36);
            this.BtnMeta.TabIndex = 6;
            this.BtnMeta.Text = "Registrar meta";
            this.BtnMeta.Visible = false;

            this.BtnInsignias.Location = new Point(38, 452);
            this.BtnInsignias.Name = "BtnInsignias";
            this.BtnInsignias.Size = new Size(320, 36);
            this.BtnInsignias.TabIndex = 7;
            this.BtnInsignias.Text = "Mis insignias";
            this.BtnInsignias.Visible = false;

            this.BtnConsultaClases.Location = new Point(38, 496);
            this.BtnConsultaClases.Name = "BtnConsultaClases";
            this.BtnConsultaClases.Size = new Size(320, 36);
            this.BtnConsultaClases.TabIndex = 9;
            this.BtnConsultaClases.Text = "Clases";
            this.BtnConsultaClases.Visible = false;

            this.BtnAvisos.Location = new Point(38, 540);
            this.BtnAvisos.Name = "BtnAvisos";
            this.BtnAvisos.Size = new Size(320, 36);
            this.BtnAvisos.TabIndex = 10;
            this.BtnAvisos.Text = "Mis avisos";
            this.BtnAvisos.Visible = false;

            this.BtnMisRutinas.Location = new Point(38, 584);
            this.BtnMisRutinas.Name = "BtnMisRutinas";
            this.BtnMisRutinas.Size = new Size(320, 36);
            this.BtnMisRutinas.TabIndex = 11;
            this.BtnMisRutinas.Text = "Mis rutinas";
            this.BtnMisRutinas.Visible = false;

            this.BtnHistorialPeso.Location = new Point(38, 628);
            this.BtnHistorialPeso.Name = "BtnHistorialPeso";
            this.BtnHistorialPeso.Size = new Size(320, 36);
            this.BtnHistorialPeso.TabIndex = 12;
            this.BtnHistorialPeso.Text = "Historial de peso";
            this.BtnHistorialPeso.Visible = false;

            this.BtnEstadisticas.Location = new Point(38, 672);
            this.BtnEstadisticas.Name = "BtnEstadisticas";
            this.BtnEstadisticas.Size = new Size(320, 36);
            this.BtnEstadisticas.TabIndex = 13;
            this.BtnEstadisticas.Text = "Estadísticas";
            this.BtnEstadisticas.Visible = false;

            this.BtnSalir.Location = new Point(38, 320);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new Size(320, 36);
            this.BtnSalir.TabIndex = 0;
            this.BtnSalir.Text = "Salir";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(400, 380);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblBienvenida);
            this.Controls.Add(this.LblDetalle);
            this.Controls.Add(this.BtnPerfil);
            this.Controls.Add(this.BtnEntrenadores);
            this.Controls.Add(this.BtnNuevaRutina);
            this.Controls.Add(this.BtnClase);
            this.Controls.Add(this.BtnMiProgreso);
            this.Controls.Add(this.BtnVisita);
            this.Controls.Add(this.BtnMedicion);
            this.Controls.Add(this.BtnMeta);
            this.Controls.Add(this.BtnInsignias);
            this.Controls.Add(this.BtnConsultaClases);
            this.Controls.Add(this.BtnAvisos);
            this.Controls.Add(this.BtnMisRutinas);
            this.Controls.Add(this.BtnHistorialPeso);
            this.Controls.Add(this.BtnEstadisticas);
            this.Controls.Add(this.BtnSalir);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenuView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblBienvenida;
        private Label LblDetalle;
        private Button BtnPerfil;
        private Button BtnEntrenadores;
        private Button BtnNuevaRutina;
        private Button BtnClase;
        private Button BtnMiProgreso;
        private Button BtnVisita;
        private Button BtnMedicion;
        private Button BtnMeta;
        private Button BtnInsignias;
        private Button BtnConsultaClases;
        private Button BtnAvisos;
        private Button BtnMisRutinas;
        private Button BtnHistorialPeso;
        private Button BtnEstadisticas;
        private Button BtnSalir;
    }
}
