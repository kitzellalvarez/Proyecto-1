namespace FitCR
{
    partial class EntrenadoresView
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
            this.GrdEntrenadores = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdEntrenadores).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Entrenadores";

            this.GrdEntrenadores.AllowUserToAddRows = false;
            this.GrdEntrenadores.AllowUserToDeleteRows = false;
            this.GrdEntrenadores.BackgroundColor = Color.White;
            this.GrdEntrenadores.Location = new Point(24, 58);
            this.GrdEntrenadores.MultiSelect = false;
            this.GrdEntrenadores.Name = "GrdEntrenadores";
            this.GrdEntrenadores.ReadOnly = true;
            this.GrdEntrenadores.RowHeadersVisible = false;
            this.GrdEntrenadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdEntrenadores.Size = new Size(640, 240);
            this.GrdEntrenadores.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 316);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(688, 370);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.GrdEntrenadores);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EntrenadoresView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdEntrenadores).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private DataGridView GrdEntrenadores;
        private Button BtnCerrar;
    }
}
