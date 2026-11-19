namespace FitCR
{
    partial class EjercicioView
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
            this.LblSeries = new Label();
            this.TxtSeries = new TextBox();
            this.LblRepeticiones = new Label();
            this.TxtRepeticiones = new TextBox();
            this.LblPeso = new Label();
            this.TxtPeso = new TextBox();
            this.BtnAgregar = new Button();
            this.GrdEjercicios = new DataGridView();
            this.BtnProgreso = new Button();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdEjercicios).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Ejercicios";

            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new Point(24, 58);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Text = "Nombre";

            this.TxtNombre.Location = new Point(24, 78);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new Size(420, 23);
            this.TxtNombre.TabIndex = 0;

            this.LblSeries.AutoSize = true;
            this.LblSeries.Location = new Point(24, 112);
            this.LblSeries.Name = "LblSeries";
            this.LblSeries.Text = "Series";

            this.TxtSeries.Location = new Point(24, 132);
            this.TxtSeries.Name = "TxtSeries";
            this.TxtSeries.Size = new Size(120, 23);
            this.TxtSeries.TabIndex = 1;

            this.LblRepeticiones.AutoSize = true;
            this.LblRepeticiones.Location = new Point(164, 112);
            this.LblRepeticiones.Name = "LblRepeticiones";
            this.LblRepeticiones.Text = "Repeticiones";

            this.TxtRepeticiones.Location = new Point(164, 132);
            this.TxtRepeticiones.Name = "TxtRepeticiones";
            this.TxtRepeticiones.Size = new Size(120, 23);
            this.TxtRepeticiones.TabIndex = 2;

            this.LblPeso.AutoSize = true;
            this.LblPeso.Location = new Point(304, 112);
            this.LblPeso.Name = "LblPeso";
            this.LblPeso.Text = "Peso en kg";

            this.TxtPeso.Location = new Point(304, 132);
            this.TxtPeso.Name = "TxtPeso";
            this.TxtPeso.Size = new Size(140, 23);
            this.TxtPeso.TabIndex = 3;

            this.BtnAgregar.Location = new Point(24, 172);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new Size(160, 36);
            this.BtnAgregar.TabIndex = 4;
            this.BtnAgregar.Text = "Agregar";

            this.GrdEjercicios.AllowUserToAddRows = false;
            this.GrdEjercicios.AllowUserToDeleteRows = false;
            this.GrdEjercicios.BackgroundColor = Color.White;
            this.GrdEjercicios.Location = new Point(24, 224);
            this.GrdEjercicios.MultiSelect = false;
            this.GrdEjercicios.Name = "GrdEjercicios";
            this.GrdEjercicios.ReadOnly = true;
            this.GrdEjercicios.RowHeadersVisible = false;
            this.GrdEjercicios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdEjercicios.Size = new Size(420, 180);
            this.GrdEjercicios.TabIndex = 5;

            this.BtnProgreso.Location = new Point(200, 420);
            this.BtnProgreso.Name = "BtnProgreso";
            this.BtnProgreso.Size = new Size(160, 36);
            this.BtnProgreso.TabIndex = 7;
            this.BtnProgreso.Text = "Progreso";

            this.BtnCerrar.Location = new Point(24, 420);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnAgregar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(470, 476);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblSeries);
            this.Controls.Add(this.TxtSeries);
            this.Controls.Add(this.LblRepeticiones);
            this.Controls.Add(this.TxtRepeticiones);
            this.Controls.Add(this.LblPeso);
            this.Controls.Add(this.TxtPeso);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.GrdEjercicios);
            this.Controls.Add(this.BtnProgreso);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EjercicioView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdEjercicios).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblNombre;
        private TextBox TxtNombre;
        private Label LblSeries;
        private TextBox TxtSeries;
        private Label LblRepeticiones;
        private TextBox TxtRepeticiones;
        private Label LblPeso;
        private TextBox TxtPeso;
        private Button BtnAgregar;
        private DataGridView GrdEjercicios;
        private Button BtnProgreso;
        private Button BtnCerrar;
    }
}
