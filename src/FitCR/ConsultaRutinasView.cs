using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra las rutinas de la persona que inició sesión. No permite modificarlas.
    /// </summary>
    public partial class ConsultaRutinasView : Form
    {
        /// <summary>
        /// Controlador que entrega las rutinas.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RutinaController RutinaController { get; set; }

        /// <summary>
        /// Crea la ventana y llena la tabla.
        /// </summary>
        public ConsultaRutinasView(RutinaController rutinaController)
        {
            this.RutinaController = rutinaController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdRutinas.Columns.Clear();
            this.GrdRutinas.Rows.Clear();
            this.GrdRutinas.Columns.Add("Nombre", "Nombre");
            this.GrdRutinas.Columns.Add("Entrenador", "Entrenador");
            this.GrdRutinas.Columns.Add("Inicio", "Inicio");
            this.GrdRutinas.Columns.Add("Fin", "Fin");

            var rutinas = this.RutinaController.ObtenerDelUsuarioActual();
            foreach (var rutina in rutinas)
            {
                this.GrdRutinas.Rows.Add(
                    rutina.Nombre,
                    this.RutinaController.NombreDelEntrenador(rutina.IdEntrenador),
                    rutina.FechaInicio.ToString("yyyy-MM-dd"),
                    rutina.FechaFin.ToString("yyyy-MM-dd"));
            }

            this.LblVacio.Visible = rutinas.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
