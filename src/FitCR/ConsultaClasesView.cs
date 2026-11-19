using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra las clases del gimnasio. No permite modificarlas.
    /// </summary>
    public partial class ConsultaClasesView : Form
    {
        /// <summary>
        /// Controlador que entrega las clases.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ClaseController ClaseController { get; set; }

        /// <summary>
        /// Crea la ventana y llena la tabla.
        /// </summary>
        public ConsultaClasesView(ClaseController claseController)
        {
            this.ClaseController = claseController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdClases.Columns.Clear();
            this.GrdClases.Rows.Clear();
            this.GrdClases.Columns.Add("Clase", "Clase");
            this.GrdClases.Columns.Add("Horario", "Horario");
            this.GrdClases.Columns.Add("Entrenador", "Entrenador");

            var clases = this.ClaseController.ObtenerTodas();
            foreach (var clase in clases)
            {
                this.GrdClases.Rows.Add(
                    clase.ObtenerNombre(),
                    clase.Horario,
                    this.ClaseController.NombreDelEntrenador(clase.IdEntrenador));
            }

            this.LblVacio.Visible = clases.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
