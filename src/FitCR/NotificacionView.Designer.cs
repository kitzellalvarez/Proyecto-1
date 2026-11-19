namespace FitCR
{
    partial class NotificacionView
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
            this.GrdAvisos = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdAvisos).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Mis avisos";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 56);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay avisos.";
            this.LblVacio.Visible = false;

            this.GrdAvisos.AllowUserToAddRows = false;
            this.GrdAvisos.AllowUserToDeleteRows = false;
            this.GrdAvisos.BackgroundColor = Color.White;
            this.GrdAvisos.Location = new Point(24, 88);
            this.GrdAvisos.MultiSelect = false;
            this.GrdAvisos.Name = "GrdAvisos";
            this.GrdAvisos.ReadOnly = true;
            this.GrdAvisos.RowHeadersVisible = false;
            this.GrdAvisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdAvisos.Size = new Size(740, 200);
            this.GrdAvisos.TabIndex = 0;

            this.BtnCerrar.Location = new Point(24, 308);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 1;
            this.BtnCerrar.Text = "Cerrar";

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(790, 364);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdAvisos);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "NotificacionView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdAvisos).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblVacio;
        private DataGridView GrdAvisos;
        private Button BtnCerrar;
    }
}
