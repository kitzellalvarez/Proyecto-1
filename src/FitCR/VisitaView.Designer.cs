namespace FitCR
{
    partial class VisitaView
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
            this.LblFecha = new Label();
            this.TxtFecha = new TextBox();
            this.BtnRegistrar = new Button();
            this.LblSemana = new Label();
            this.LblVacio = new Label();
            this.GrdVisitas = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdVisitas).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Registrar visita";

            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new Point(24, 58);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Text = "Fecha (aaaa-mm-dd)";

            this.TxtFecha.Location = new Point(24, 78);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.PlaceholderText = "2026-11-16";
            this.TxtFecha.Size = new Size(200, 23);
            this.TxtFecha.TabIndex = 0;

            this.BtnRegistrar.Location = new Point(24, 116);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new Size(160, 36);
            this.BtnRegistrar.TabIndex = 1;
            this.BtnRegistrar.Text = "Registrar";

            this.LblSemana.AutoSize = true;
            this.LblSemana.Location = new Point(24, 164);
            this.LblSemana.MaximumSize = new Size(320, 0);
            this.LblSemana.Name = "LblSemana";
            this.LblSemana.Text = "Visitas de esta semana: 0.";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 210);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay visitas.";
            this.LblVacio.Visible = false;

            this.GrdVisitas.AllowUserToAddRows = false;
            this.GrdVisitas.AllowUserToDeleteRows = false;
            this.GrdVisitas.BackgroundColor = Color.White;
            this.GrdVisitas.Location = new Point(24, 236);
            this.GrdVisitas.MultiSelect = false;
            this.GrdVisitas.Name = "GrdVisitas";
            this.GrdVisitas.ReadOnly = true;
            this.GrdVisitas.RowHeadersVisible = false;
            this.GrdVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdVisitas.Size = new Size(320, 140);
            this.GrdVisitas.TabIndex = 2;

            this.BtnCerrar.Location = new Point(24, 392);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 3;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnRegistrar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(370, 448);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblSemana);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdVisitas);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VisitaView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdVisitas).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblFecha;
        private TextBox TxtFecha;
        private Button BtnRegistrar;
        private Label LblSemana;
        private Label LblVacio;
        private DataGridView GrdVisitas;
        private Button BtnCerrar;
    }
}
