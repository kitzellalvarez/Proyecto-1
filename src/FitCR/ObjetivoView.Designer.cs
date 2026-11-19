namespace FitCR
{
    partial class ObjetivoView
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
            this.LblValor = new Label();
            this.TxtValor = new TextBox();
            this.LblInicio = new Label();
            this.TxtInicio = new TextBox();
            this.LblFin = new Label();
            this.TxtFin = new TextBox();
            this.BtnRegistrar = new Button();
            this.LblVacio = new Label();
            this.GrdObjetivos = new DataGridView();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdObjetivos).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Registrar meta";

            this.LblTipo.AutoSize = true;
            this.LblTipo.Location = new Point(24, 58);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Text = "Tipo";

            this.CmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbTipo.Items.AddRange(new object[] { "Aumentar musculatura", "Reducir grasa", "Visitas al gimnasio" });
            this.CmbTipo.Location = new Point(24, 78);
            this.CmbTipo.Name = "CmbTipo";
            this.CmbTipo.Size = new Size(420, 23);
            this.CmbTipo.TabIndex = 0;

            this.LblValor.AutoSize = true;
            this.LblValor.Location = new Point(24, 112);
            this.LblValor.Name = "LblValor";
            this.LblValor.Text = "Valor de la meta";

            this.TxtValor.Location = new Point(24, 132);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.PlaceholderText = "25";
            this.TxtValor.Size = new Size(200, 23);
            this.TxtValor.TabIndex = 1;

            this.LblInicio.AutoSize = true;
            this.LblInicio.Location = new Point(24, 166);
            this.LblInicio.Name = "LblInicio";
            this.LblInicio.Text = "Fecha de inicio (aaaa-mm-dd)";

            this.TxtInicio.Location = new Point(24, 186);
            this.TxtInicio.Name = "TxtInicio";
            this.TxtInicio.PlaceholderText = "2026-11-01";
            this.TxtInicio.Size = new Size(200, 23);
            this.TxtInicio.TabIndex = 2;

            this.LblFin.AutoSize = true;
            this.LblFin.Location = new Point(244, 166);
            this.LblFin.Name = "LblFin";
            this.LblFin.Text = "Fecha de fin (aaaa-mm-dd)";

            this.TxtFin.Location = new Point(244, 186);
            this.TxtFin.Name = "TxtFin";
            this.TxtFin.PlaceholderText = "2026-12-15";
            this.TxtFin.Size = new Size(200, 23);
            this.TxtFin.TabIndex = 3;

            this.BtnRegistrar.Location = new Point(24, 226);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new Size(160, 36);
            this.BtnRegistrar.TabIndex = 4;
            this.BtnRegistrar.Text = "Registrar";

            this.LblVacio.AutoSize = true;
            this.LblVacio.Location = new Point(24, 276);
            this.LblVacio.Name = "LblVacio";
            this.LblVacio.Text = "Todavía no hay metas.";
            this.LblVacio.Visible = false;

            this.GrdObjetivos.AllowUserToAddRows = false;
            this.GrdObjetivos.AllowUserToDeleteRows = false;
            this.GrdObjetivos.BackgroundColor = Color.White;
            this.GrdObjetivos.Location = new Point(24, 304);
            this.GrdObjetivos.MultiSelect = false;
            this.GrdObjetivos.Name = "GrdObjetivos";
            this.GrdObjetivos.ReadOnly = true;
            this.GrdObjetivos.RowHeadersVisible = false;
            this.GrdObjetivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdObjetivos.Size = new Size(620, 160);
            this.GrdObjetivos.TabIndex = 5;

            this.BtnCerrar.Location = new Point(24, 480);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(160, 36);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnRegistrar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(670, 536);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblTipo);
            this.Controls.Add(this.CmbTipo);
            this.Controls.Add(this.LblValor);
            this.Controls.Add(this.TxtValor);
            this.Controls.Add(this.LblInicio);
            this.Controls.Add(this.TxtInicio);
            this.Controls.Add(this.LblFin);
            this.Controls.Add(this.TxtFin);
            this.Controls.Add(this.BtnRegistrar);
            this.Controls.Add(this.LblVacio);
            this.Controls.Add(this.GrdObjetivos);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ObjetivoView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdObjetivos).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblTipo;
        private ComboBox CmbTipo;
        private Label LblValor;
        private TextBox TxtValor;
        private Label LblInicio;
        private TextBox TxtInicio;
        private Label LblFin;
        private TextBox TxtFin;
        private Button BtnRegistrar;
        private Label LblVacio;
        private DataGridView GrdObjetivos;
        private Button BtnCerrar;
    }
}
