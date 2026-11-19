namespace FitCR
{
    partial class ConsultaRutinasView
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
            this.GrdRutinas = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdRutinas).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Mis rutinas";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 56);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay rutinas.";
            this.LblVacio.Visible = false;

            this.GrdRutinas.AllowUserToAddRows = false;
            this.GrdRutinas.AllowUserToDeleteRows = false;
            this.GrdRutinas.BackgroundColor = Color.White;
            this.GrdRutinas.Location = new Point(24, 88);
            this.GrdRutinas.MultiSelect = false;
            this.GrdRutinas.Name = "GrdRutinas";
            this.GrdRutinas.ReadOnly = true;
            this.GrdRutinas.RowHeadersVisible = false;
            this.GrdRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdRutinas.Size = new Size(520, 200);
            this.GrdRutinas.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 308);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(570, 364);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdRutinas);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConsultaRutinasView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdRutinas).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblVacio;
        private DataGridView GrdRutinas;
        private Button BtnCerrar;
    }
}
