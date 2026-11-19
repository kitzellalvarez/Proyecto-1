namespace FitCR
{
    partial class HistorialPesoView
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
            this.LblVacio = new Label();
            this.GrdPesos = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdPesos).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Historial de peso";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 56);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay mediciones.";
            this.LblVacio.Visible = false;

            this.GrdPesos.AllowUserToAddRows = false;
            this.GrdPesos.AllowUserToDeleteRows = false;
            this.GrdPesos.BackgroundColor = Color.White;
            this.GrdPesos.Location = new Point(24, 88);
            this.GrdPesos.MultiSelect = false;
            this.GrdPesos.Name = "GrdPesos";
            this.GrdPesos.ReadOnly = true;
            this.GrdPesos.RowHeadersVisible = false;
            this.GrdPesos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdPesos.Size = new Size(380, 160);
            this.GrdPesos.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 268);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(430, 324);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdPesos);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HistorialPesoView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdPesos).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblVacio;
        private DataGridView GrdPesos;
        private Button BtnCerrar;
    }
}
