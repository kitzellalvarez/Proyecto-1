using FitCRController;
using FitCRModels;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Permite a un entrenador crear una rutina, cambiar su nombre y sus fechas, eliminarla y ver las que ya asignó.
    /// </summary>
    public partial class RutinaView : Form
    {
        private readonly List<Usuario> usuarios = new List<Usuario>();

        /// <summary>
        /// Controlador que valida y guarda la rutina.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RutinaController RutinaController { get; set; }

        /// <summary>
        /// Crea la ventana, llena la lista de usuarios y muestra las rutinas existentes.
        /// </summary>
        public RutinaView(RutinaController rutinaController)
        {
            this.RutinaController = rutinaController;
            InitializeComponent();
            this.BtnGuardar.Click += this.BtnGuardar_Click;
            this.BtnActualizar.Click += this.BtnActualizar_Click;
            this.GrdRutinas.CellClick += this.GrdRutinas_CellClick;
            this.BtnEjercicios.Click += this.BtnEjercicios_Click;
            this.BtnEliminar.Click += this.BtnEliminar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarUsuarios();
            this.CargarTabla();
        }

        private void CargarUsuarios()
        {
            this.usuarios.Clear();
            this.CmbUsuario.Items.Clear();
            foreach (var usuario in this.RutinaController.ObtenerUsuariosBasicos())
            {
                this.usuarios.Add(usuario);
                this.CmbUsuario.Items.Add(usuario.Nombre + " " + usuario.Apellidos);
            }
        }

        private void CargarTabla()
        {
            this.GrdRutinas.Columns.Clear();
            this.GrdRutinas.Rows.Clear();
            this.GrdRutinas.Columns.Add("Nombre", "Nombre");
            this.GrdRutinas.Columns.Add("Usuario", "Usuario");
            this.GrdRutinas.Columns.Add("Inicio", "Inicio");
            this.GrdRutinas.Columns.Add("Fin", "Fin");

            foreach (var rutina in this.RutinaController.ObtenerRutinasDelEntrenador())
            {
                var indice = this.GrdRutinas.Rows.Add(
                    rutina.Nombre,
                    this.NombreDelUsuario(rutina.IdUsuario),
                    rutina.FechaInicio.ToString("yyyy-MM-dd"),
                    rutina.FechaFin.ToString("yyyy-MM-dd"));
                this.GrdRutinas.Rows[indice].Tag = rutina;
            }
        }

        private string NombreDelUsuario(string idUsuario)
        {
            foreach (var usuario in this.usuarios)
            {
                if (usuario.Id == idUsuario)
                {
                    return usuario.Nombre + " " + usuario.Apellidos;
                }
            }

            return idUsuario;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            var idUsuario = string.Empty;
            if (this.CmbUsuario.SelectedIndex >= 0)
            {
                idUsuario = this.usuarios[this.CmbUsuario.SelectedIndex].Id;
            }

            var registrada = this.RutinaController.Registrar(this.TxtNombre.Text, idUsuario, this.TxtInicio.Text, this.TxtFin.Text);
            MessageBox.Show(this.RutinaController.Mensaje, "Fit.CR");
            if (registrada)
            {
                this.CargarTabla();
            }
        }

        private void GrdRutinas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rutina = this.GrdRutinas.Rows[e.RowIndex].Tag as Rutina;
            if (rutina == null)
            {
                return;
            }

            this.TxtNombre.Text = rutina.Nombre;
            this.TxtInicio.Text = rutina.FechaInicio.ToString("yyyy-MM-dd");
            this.TxtFin.Text = rutina.FechaFin.ToString("yyyy-MM-dd");
            this.SeleccionarUsuario(rutina.IdUsuario);
        }

        private void SeleccionarUsuario(string idUsuario)
        {
            for (var i = 0; i < this.usuarios.Count; i++)
            {
                if (this.usuarios[i].Id == idUsuario)
                {
                    this.CmbUsuario.SelectedIndex = i;
                    return;
                }
            }
        }

        private void BtnActualizar_Click(object? sender, EventArgs e)
        {
            if (this.GrdRutinas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }

            var rutina = this.GrdRutinas.SelectedRows[0].Tag as Rutina;
            if (rutina == null)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }

            var actualizada = this.RutinaController.Actualizar(rutina.Id, this.TxtNombre.Text, this.TxtInicio.Text, this.TxtFin.Text);
            MessageBox.Show(this.RutinaController.Mensaje, "Fit.CR");
            if (actualizada)
            {
                this.CargarTabla();
            }
        }

        private void BtnEjercicios_Click(object? sender, EventArgs e)
        {
            if (this.GrdRutinas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }

            var rutina = this.GrdRutinas.SelectedRows[0].Tag as Rutina;
            if (rutina == null)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }
            var controlador = new EjercicioController(this.RutinaController.InformationService);
            var ventana = new EjercicioView(controlador, rutina);
            ventana.ShowDialog(this);
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (this.GrdRutinas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }

            var rutina = this.GrdRutinas.SelectedRows[0].Tag as Rutina;
            if (rutina == null)
            {
                MessageBox.Show("Selecciona una rutina.", "Fit.CR");
                return;
            }

            var respuesta = MessageBox.Show("¿Eliminar esta rutina y sus ejercicios?", "Fit.CR", MessageBoxButtons.YesNo);
            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            var eliminada = this.RutinaController.Eliminar(rutina.Id);
            MessageBox.Show(this.RutinaController.Mensaje, "Fit.CR");
            if (eliminada)
            {
                this.TxtNombre.Clear();
                this.TxtInicio.Clear();
                this.TxtFin.Clear();
                this.CargarTabla();
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
