namespace FitCR
{
    partial class ProgresoView
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
            this.LblPeso = new Label();
            this.TxtPeso = new TextBox();
            this.LblRepeticiones = new Label();
            this.TxtRepeticiones = new TextBox();
            this.BtnAnotar = new Button();
            this.GrdProgreso = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdProgreso).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Progreso";

            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new Point(24, 58);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Text = "Fecha (aaaa-mm-dd)";

            this.TxtFecha.Location = new Point(24, 78);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.PlaceholderText = "2026-11-16";
            this.TxtFecha.Size = new Size(200, 23);
            this.TxtFecha.TabIndex = 0;

            this.LblPeso.AutoSize = true;
            this.LblPeso.Location = new Point(244, 58);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Text = "Peso en kg";

            this.TxtPeso.Location = new Point(244, 78);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new Size(200, 23);
            this.TxtPeso.TabIndex = 1;

            this.LblRepeticiones.AutoSize = true;
            this.LblRepeticiones.Location = new Point(24, 112);
            this.LblRepeticiones.Name = "LblRepeticiones";
            this.LblRepeticiones.Text = "Repeticiones hechas";

            this.TxtRepeticiones.Location = new Point(24, 132);
            this.TxtRepeticiones.Name = "TxtRepeticiones";
            this.TxtRepeticiones.Size = new Size(200, 23);
            this.TxtRepeticiones.TabIndex = 2;

            this.BtnAnotar.Location = new Point(24, 172);
            this.BtnAnotar.Name = "BtnAnotar";
            this.BtnAnotar.Size = new Size(160, 36);
            this.BtnAnotar.TabIndex = 3;
            this.BtnAnotar.Text = "Anotar";

            this.GrdProgreso.AllowUserToAddRows = false;
            this.GrdProgreso.AllowUserToDeleteRows = false;
            this.GrdProgreso.BackgroundColor = Color.White;
            this.GrdProgreso.Location = new Point(24, 224);
            this.GrdProgreso.MultiSelect = false;
            this.GrdProgreso.Name = "GrdProgreso";
            this.GrdProgreso.ReadOnly = true;
            this.GrdProgreso.RowHeadersVisible = false;
            this.GrdProgreso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdProgreso.Size = new Size(420, 160);
            this.GrdProgreso.TabIndex = 4;

            this.BtnCerrar.Location = new Point(24, 400);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 5;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnAnotar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(470, 456);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.LblRepeticiones);
            this.Controls.Add(this.TxtRepeticiones);
            this.Controls.Add(this.BtnAnotar);
            this.Controls.Add(this.GrdProgreso);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProgresoView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdProgreso).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblFecha;
        private TextBox TxtFecha;
        private Label LblPeso;
        private TextBox TxtPeso;
        private Label LblRepeticiones;
        private TextBox TxtRepeticiones;
        private Button BtnAnotar;
        private DataGridView GrdProgreso;
        private Button BtnCerrar;
    }
}
