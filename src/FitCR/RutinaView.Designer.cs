namespace FitCR
{
    partial class RutinaView
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
            this.LblUsuario = new Label();
            this.CmbUsuario = new ComboBox();
            this.LblInicio = new Label();
            this.TxtInicio = new TextBox();
            this.LblFin = new Label();
            this.TxtFin = new TextBox();
            this.BtnGuardar = new Button();
            this.BtnActualizar = new Button();
            this.LblLista = new Label();
            this.GrdRutinas = new DataGridView();
            this.BtnEjercicios = new Button();
            this.BtnEliminar = new Button();
            this.BtnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)this.GrdRutinas).BeginInit();
            this.SuspendLayout();

            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.LblTitulo.Location = new Point(24, 16);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Text = "Nueva rutina";

            this.LblNombre.AutoSize = true;
            this.LblNombre.Location = new Point(24, 58);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Text = "Nombre";

            this.TxtNombre.Location = new Point(24, 78);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new Size(420, 23);
            this.TxtNombre.TabIndex = 0;

            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new Point(24, 112);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Text = "Usuario";

            this.CmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CmbUsuario.Location = new Point(24, 132);
            this.CmbUsuario.Name = "CmbUsuario";
            this.CmbUsuario.Size = new Size(420, 23);
            this.CmbUsuario.TabIndex = 1;

            this.LblInicio.AutoSize = true;
            this.LblInicio.Location = new Point(24, 168);
            this.LblInicio.Name = "LblInicio";
            this.LblInicio.Text = "Fecha de inicio (aaaa-mm-dd)";

            this.TxtInicio.Location = new Point(24, 188);
            this.TxtInicio.Name = "TxtInicio";
            this.TxtInicio.PlaceholderText = "2026-11-01";
            this.TxtInicio.Size = new Size(200, 23);
            this.TxtInicio.TabIndex = 2;

            this.LblFin.AutoSize = true;
            this.LblFin.Location = new Point(244, 168);
            this.LblFin.Name = "LblFin";
            this.LblFin.Text = "Fecha de fin (aaaa-mm-dd)";

            this.TxtFin.Location = new Point(244, 188);
            this.TxtFin.Name = "TxtFin";
            this.TxtFin.PlaceholderText = "2026-12-01";
            this.TxtFin.Size = new Size(200, 23);
            this.TxtFin.TabIndex = 3;

            this.BtnGuardar.Location = new Point(24, 228);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new Size(160, 36);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar";

            this.BtnActualizar.Location = new Point(200, 228);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new Size(160, 36);
            this.BtnActualizar.TabIndex = 8;
            this.BtnActualizar.Text = "Actualizar";

            this.LblLista.AutoSize = true;
            this.LblLista.Location = new Point(24, 280);
            this.LblLista.Name = "LblLista";
            this.LblLista.Text = "Rutinas de este entrenador";

            this.GrdRutinas.AllowUserToAddRows = false;
            this.GrdRutinas.AllowUserToDeleteRows = false;
            this.GrdRutinas.BackgroundColor = Color.White;
            this.GrdRutinas.Location = new Point(24, 304);
            this.GrdRutinas.MultiSelect = false;
            this.GrdRutinas.Name = "GrdRutinas";
            this.GrdRutinas.ReadOnly = true;
            this.GrdRutinas.RowHeadersVisible = false;
            this.GrdRutinas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.GrdRutinas.Size = new Size(420, 160);
            this.GrdRutinas.TabIndex = 5;

            this.BtnEjercicios.Location = new Point(166, 480);
            this.BtnEjercicios.Name = "BtnEjercicios";
            this.BtnEjercicios.Size = new Size(130, 36);
            this.BtnEjercicios.TabIndex = 7;
            this.BtnEjercicios.Text = "Ejercicios";

            this.BtnEliminar.Location = new Point(308, 480);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new Size(136, 36);
            this.BtnEliminar.TabIndex = 9;
            this.BtnEliminar.Text = "Eliminar";

            this.BtnCerrar.Location = new Point(24, 480);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new Size(130, 36);
            this.BtnCerrar.TabIndex = 6;
            this.BtnCerrar.Text = "Cerrar";

            this.AcceptButton = this.BtnGuardar;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(470, 536);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.LblNombre);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.CmbUsuario);
            this.Controls.Add(this.LblInicio);
            this.Controls.Add(this.TxtInicio);
            this.Controls.Add(this.LblFin);
            this.Controls.Add(this.TxtFin);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.LblLista);
            this.Controls.Add(this.GrdRutinas);
            this.Controls.Add(this.BtnEjercicios);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "RutinaView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Fit.CR";
            ((System.ComponentModel.ISupportInitialize)this.GrdRutinas).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label LblTitulo;
        private Label LblNombre;
        private TextBox TxtNombre;
        private Label LblUsuario;
        private ComboBox CmbUsuario;
        private Label LblInicio;
        private TextBox TxtInicio;
        private Label LblFin;
        private TextBox TxtFin;
        private Button BtnGuardar;
        private Button BtnActualizar;
        private Label LblLista;
        private DataGridView GrdRutinas;
        private Button BtnEjercicios;
        private Button BtnEliminar;
        private Button BtnCerrar;
    }
}
