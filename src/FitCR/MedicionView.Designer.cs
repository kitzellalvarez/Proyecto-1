namespace FitCR
{
    partial class MedicionView
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
            this.LblAltura = new Label();
            this.TxtAltura = new TextBox();
            this.LblGrasa = new Label();
            this.TxtGrasa = new TextBox();
            this.LblMusculatura = new Label();
            this.TxtMusculatura = new TextBox();
            this.BtnRegistrar = new Button();
            this.LblVacio = new Label();
            this.GrdMediciones = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdMediciones).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Registrar medición";

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
            this.LblPeso.Location = new Point(24, 112);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Text = "Peso en kg";

            this.TxtPeso.Location = new Point(24, 132);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.PlaceholderText = "72";
            this.TxtPeso.Size = new Size(200, 23);
            this.TxtPeso.TabIndex = 1;

            this.LblAltura.AutoSize = true;
            this.LblAltura.Location = new Point(244, 112);
            this.LblAltura.Name = "LblAltura";
            this.LblAltura.Text = "Altura en cm";

            this.TxtAltura.Location = new Point(244, 132);
            this.TxtAltura.Name = "TxtAltura";
            this.TxtAltura.PlaceholderText = "170";
            this.TxtAltura.Size = new Size(200, 23);
            this.TxtAltura.TabIndex = 2;

            this.LblGrasa.AutoSize = true;
            this.LblGrasa.Location = new Point(24, 166);
            this.LblGrasa.Name = "LblGrasa";
            this.LblGrasa.Text = "Grasa en %";

            this.TxtGrasa.Location = new Point(24, 186);
            this.TxtGrasa.Name = "TxtGrasa";
            this.TxtGrasa.PlaceholderText = "28";
            this.TxtGrasa.Size = new Size(200, 23);
            this.TxtGrasa.TabIndex = 3;

            this.LblMusculatura.AutoSize = true;
            this.LblMusculatura.Location = new Point(244, 166);
            this.LblMusculatura.Name = "LblMusculatura";
            this.LblMusculatura.Text = "Musculatura en kg";

            this.TxtMusculatura.Location = new Point(244, 186);
            this.TxtMusculatura.Name = "TxtMusculatura";
            this.TxtMusculatura.PlaceholderText = "25";
            this.TxtMusculatura.Size = new Size(200, 23);
            this.TxtMusculatura.TabIndex = 4;

            this.BtnRegistrar.Location = new Point(24, 226);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new Size(160, 36);
            this.BtnRegistrar.TabIndex = 5;
            this.BtnRegistrar.Text = "Registrar";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 276);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay mediciones.";
            this.LblVacio.Visible = false;

            this.GrdMediciones.AllowUserToAddRows = false;
            this.GrdMediciones.AllowUserToDeleteRows = false;
            this.GrdMediciones.BackgroundColor = Color.White;
            this.GrdMediciones.Location = new Point(24, 304);
            this.GrdMediciones.MultiSelect = false;
            this.GrdMediciones.Name = "GrdMediciones";
            this.GrdMediciones.ReadOnly = true;
            this.GrdMediciones.RowHeadersVisible = false;
            this.GrdMediciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdMediciones.Size = new Size(620, 160);
            this.GrdMediciones.TabIndex = 6;

            this.BtnCerrar.Location = new Point(24, 480);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 7;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnRegistrar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(670, 536);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblFecha);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.LblAltura);
            this.Controls.Add(this.TxtAltura);
            this.Controls.Add(this.LblGrasa);
            this.Controls.Add(this.TxtGrasa);
            this.Controls.Add(this.LblMusculatura);
            this.Controls.Add(this.TxtMusculatura);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdMediciones);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MedicionView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdMediciones).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblFecha;
        private TextBox TxtFecha;
        private Label LblPeso;
        private TextBox TxtPeso;
        private Label LblAltura;
        private TextBox TxtAltura;
        private Label LblGrasa;
        private TextBox TxtGrasa;
        private Label LblMusculatura;
        private TextBox TxtMusculatura;
        private Button BtnRegistrar;
        private Label LblVacio;
        private DataGridView GrdMediciones;
        private Button BtnCerrar;
    }
}
