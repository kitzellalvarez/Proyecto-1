namespace FitCR
{
    partial class EstadisticasVisitasView
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
            this.LblInicio = new Label();
            this.TxtInicio = new TextBox();
            this.LblFin = new Label();
            this.TxtFin = new TextBox();
            this.BtnConsultar = new Button();
            this.LblPeso = new Label();
            this.LblVacio = new Label();
            this.LblMas = new Label();
            this.GrdRanking = new DataGridView();
            this.LblMenos = new Label();
            this.GrdAusentes = new DataGridView();
            this.LblMetas = new Label();
            this.LblSinMetas = new Label();
            this.GrdMetas = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdRanking).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.GrdAusentes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.GrdMetas).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Estadísticas";

            this.LblInicio.AutoSize = true;
            this.LblInicio.Location = new Point(24, 58);
            this.LblInicio.Name = "LblInicio";
            this.LblInicio.Text = "Inicio (aaaa-mm-dd)";

            this.TxtInicio.Location = new Point(24, 78);
            this.TxtInicio.Name = "TxtInicio";
            this.TxtInicio.PlaceholderText = "2016-11-16";
            this.TxtInicio.Size = new Size(160, 23);
            this.TxtInicio.TabIndex = 0;

            this.LblFin.AutoSize = true;
            this.LblFin.Location = new Point(200, 58);
            this.LblFin.Name = "LblFin";
            this.LblFin.Text = "Fin (aaaa-mm-dd)";

            this.TxtFin.Location = new Point(200, 78);
            this.TxtFin.Name = "TxtFin";
            this.TxtFin.PlaceholderText = "2026-11-16";
            this.TxtFin.Size = new Size(160, 23);
            this.TxtFin.TabIndex = 1;

            this.BtnConsultar.Location = new Point(24, 116);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new Size(160, 36);
            this.BtnConsultar.TabIndex = 2;
            this.BtnConsultar.Text = "Consultar";

            this.LblPeso.AutoSize = true;
            this.LblPeso.Location = new Point(24, 164);
            this.LblPeso.MaximumSize = new Size(470, 0);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Text = "Tu cambio de peso aparece aquí.";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 196);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "No hay usuarios básicos.";
            this.LblVacio.Visible = false;

            this.GrdRanking.AllowUserToAddRows = false;
            this.GrdRanking.AllowUserToDeleteRows = false;
            this.GrdRanking.BackgroundColor = Color.White;
            this.LblMas.AutoSize = true;
            this.LblMas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.LblMas.Location = new Point(24, 200);
            this.LblMas.Name = "LblMas";
            this.LblMas.Text = "Más visitas";

            this.GrdRanking.Location = new Point(24, 228);
            this.GrdRanking.MultiSelect = false;
            this.GrdRanking.Name = "GrdRanking";
            this.GrdRanking.ReadOnly = true;
            this.GrdRanking.RowHeadersVisible = false;
            this.GrdRanking.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdRanking.Size = new Size(400, 110);
            this.GrdRanking.TabIndex = 3;

            this.LblMenos.AutoSize = true;
            this.LblMenos.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.LblMenos.Location = new Point(448, 200);
            this.LblMenos.Name = "LblMenos";
            this.LblMenos.Text = "Menos visitas";

            this.GrdAusentes.AllowUserToAddRows = false;
            this.GrdAusentes.AllowUserToDeleteRows = false;
            this.GrdAusentes.BackgroundColor = Color.White;
            this.GrdAusentes.Location = new Point(448, 228);
            this.GrdAusentes.MultiSelect = false;
            this.GrdAusentes.Name = "GrdAusentes";
            this.GrdAusentes.ReadOnly = true;
            this.GrdAusentes.RowHeadersVisible = false;
            this.GrdAusentes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdAusentes.Size = new Size(400, 110);
            this.GrdAusentes.TabIndex = 5;

            this.LblMetas.AutoSize = true;
            this.LblMetas.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.LblMetas.Location = new Point(24, 360);
            this.LblMetas.Name = "LblMetas";
            this.LblMetas.Text = "Metas del período";

            this.LblSinMetas.AutoSize = true;
            this.LblSinMetas.Location = new Point(24, 388);
            this.LblSinMetas.Name = "LblSinMetas";
            this.LblSinMetas.Text = "No hay metas en ese período.";
            this.LblSinMetas.Visible = false;

            this.GrdMetas.AllowUserToAddRows = false;
            this.GrdMetas.AllowUserToDeleteRows = false;
            this.GrdMetas.BackgroundColor = Color.White;
            this.GrdMetas.Location = new Point(24, 412);
            this.GrdMetas.MultiSelect = false;
            this.GrdMetas.Name = "GrdMetas";
            this.GrdMetas.ReadOnly = true;
            this.GrdMetas.RowHeadersVisible = false;
            this.GrdMetas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdMetas.Size = new Size(824, 110);
            this.GrdMetas.TabIndex = 4;

            this.BtnCerrar.Location = new Point(24, 536);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnConsultar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(872, 592);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblInicio);
            this.Controls.Add(this.TxtInicio);
            this.Controls.Add(this.LblFin);
            this.Controls.Add(this.TxtFin);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.LblMas);
            this.Controls.Add(this.GrdRanking);
            this.Controls.Add(this.LblMenos);
            this.Controls.Add(this.GrdAusentes);
            this.Controls.Add(this.LblMetas);
            this.Controls.Add(this.LblSinMetas);
            this.Controls.Add(this.GrdMetas);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EstadisticasVisitasView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdRanking).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.GrdAusentes).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.GrdMetas).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblInicio;
        private TextBox TxtInicio;
        private Label LblFin;
        private TextBox TxtFin;
        private Button BtnConsultar;
        private Label LblPeso;
        private Label LblVacio;
        private Label LblMas;
        private DataGridView GrdRanking;
        private Label LblMenos;
        private DataGridView GrdAusentes;
        private Label LblMetas;
        private Label LblSinMetas;
        private DataGridView GrdMetas;
        private Button BtnCerrar;
    }
}
