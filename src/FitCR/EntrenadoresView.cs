using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra los entrenadores registrados. No permite modificarlos.
    /// </summary>
    public partial class EntrenadoresView : Form
    {
        /// <summary>
        /// Controlador que entrega la lista de entrenadores.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EntrenadorController EntrenadorController { get; set; }

        /// <summary>
        /// Crea la ventana y llena la tabla.
        /// </summary>
        public EntrenadoresView(EntrenadorController entrenadorController)
        {
            this.EntrenadorController = entrenadorController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdEntrenadores.Columns.Clear();
            this.GrdEntrenadores.Rows.Clear();
            this.GrdEntrenadores.Columns.Add("Nombre", "Nombre");
            this.GrdEntrenadores.Columns.Add("Apellidos", "Apellidos");
            this.GrdEntrenadores.Columns.Add("Correo", "Correo");
            this.GrdEntrenadores.Columns.Add("Usuario", "Usuario");
            this.GrdEntrenadores.Columns.Add("Tipo", "Tipo");

            var entrenadores = this.EntrenadorController.ObtenerEntrenadores();
            foreach (var entrenador in entrenadores)
            {
                this.GrdEntrenadores.Rows.Add(
                    entrenador.Nombre,
                    entrenador.Apellidos,
                    entrenador.Correo,
                    entrenador.NombreUsuario,
                    entrenador.DescribirRol());
            }

            if (entrenadores.Count == 0)
            {
                MessageBox.Show("No hay entrenadores registrados.", "Fit.CR");
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
