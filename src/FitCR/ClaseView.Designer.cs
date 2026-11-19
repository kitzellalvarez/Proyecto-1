namespace FitCR
{
    partial class ClaseView
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
            this.LblTipo = new Label();
            this.CmbTipo = new ComboBox();
            this.LblHorario = new Label();
            this.TxtHorario = new TextBox();
            this.BtnRegistrar = new Button();
            this.LblVacio = new Label();
            this.GrdClases = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdClases).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Nueva clase";

            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new Point(24, 58);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Text = "Tipo";

            this.CmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbTipo.Items.AddRange(new object[] { "Yoga", "Gimnasio abierto", "Crossfit", "Zumba", "Spinning" });
            this.CmbTipo.Location = new Point(24, 78);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new Size(420, 23);
            this.CmbTipo.TabIndex = 0;

            this.LblHorario.AutoSize = true;
            this.LblHorario.Location = new Point(24, 112);
            this.LblHorario.Name = "LblHorario";
            this.LblHorario.Text = "Horario";

            this.TxtHorario.Location = new Point(24, 132);
            this.TxtHorario.Name = "TxtHorario";
            this.TxtHorario.PlaceholderText = "Lunes 18:00";
            this.TxtHorario.Size = new Size(420, 23);
            this.TxtHorario.TabIndex = 1;

            this.BtnRegistrar.Location = new Point(24, 172);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new Size(160, 36);
            this.BtnRegistrar.TabIndex = 2;
            this.BtnRegistrar.Text = "Registrar";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 224);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay clases.";
            this.LblVacio.Visible = false;

            this.GrdClases.AllowUserToAddRows = false;
            this.GrdClases.AllowUserToDeleteRows = false;
            this.GrdClases.BackgroundColor = Color.White;
            this.GrdClases.Location = new Point(24, 252);
            this.GrdClases.MultiSelect = false;
            this.GrdClases.Name = "GrdClases";
            this.GrdClases.ReadOnly = true;
            this.GrdClases.RowHeadersVisible = false;
            this.GrdClases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdClases.Size = new Size(420, 160);
            this.GrdClases.TabIndex = 3;

            this.BtnCerrar.Location = new Point(24, 428);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnRegistrar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(470, 484);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.LblHorario);
            this.Controls.Add(this.TxtHorario);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdClases);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ClaseView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdClases).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblTipo;
        private ComboBox CmbTipo;
        private Label LblHorario;
        private TextBox TxtHorario;
        private Button BtnRegistrar;
        private Label LblVacio;
        private DataGridView GrdClases;
        private Button BtnCerrar;
    }
}
