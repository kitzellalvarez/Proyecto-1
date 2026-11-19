namespace FitCR
{
    partial class InsigniaView
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
            this.GrdInsignias = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdInsignias).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Mis insignias";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 56);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay insignias.";
            this.LblVacio.Visible = false;

            this.GrdInsignias.AllowUserToAddRows = false;
            this.GrdInsignias.AllowUserToDeleteRows = false;
            this.GrdInsignias.BackgroundColor = Color.White;
            this.GrdInsignias.Location = new Point(24, 88);
            this.GrdInsignias.MultiSelect = false;
            this.GrdInsignias.Name = "GrdInsignias";
            this.GrdInsignias.ReadOnly = true;
            this.GrdInsignias.RowHeadersVisible = false;
            this.GrdInsignias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdInsignias.Size = new Size(420, 200);
            this.GrdInsignias.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 308);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(470, 364);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdInsignias);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InsigniaView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdInsignias).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblVacio;
        private DataGridView GrdInsignias;
        private Button BtnCerrar;
    }
}
