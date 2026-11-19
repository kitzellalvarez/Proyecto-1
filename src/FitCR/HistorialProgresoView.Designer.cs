namespace FitCR
{
    partial class HistorialProgresoView
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
            this.GrdProgreso = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdProgreso).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Mi progreso";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 56);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay progreso anotado.";
            this.LblVacio.Visible = false;

            this.GrdProgreso.AllowUserToAddRows = false;
            this.GrdProgreso.AllowUserToDeleteRows = false;
            this.GrdProgreso.BackgroundColor = Color.White;
            this.GrdProgreso.Location = new Point(24, 88);
            this.GrdProgreso.MultiSelect = false;
            this.GrdProgreso.Name = "GrdProgreso";
            this.GrdProgreso.ReadOnly = true;
            this.GrdProgreso.RowHeadersVisible = false;
            this.GrdProgreso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdProgreso.Size = new Size(680, 240);
            this.GrdProgreso.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 348);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(730, 404);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdProgreso);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HistorialProgresoView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdProgreso).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblVacio;
        private DataGridView GrdProgreso;
        private Button BtnCerrar;
    }
}
