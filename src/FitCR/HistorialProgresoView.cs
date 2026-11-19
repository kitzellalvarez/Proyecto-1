using FitCRController;
using System.ComponentModel;
using System.Globalization;

namespace FitCR
{
    /// <summary>
    /// Muestra el progreso de la persona y cuánto cambió el peso de cada ejercicio.
    /// </summary>
    public partial class HistorialProgresoView : Form
    {
        /// <summary>
        /// Controlador que entrega el historial.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProgresoController ProgresoController { get; set; }

        /// <summary>
        /// Crea la ventana y llena la tabla.
        /// </summary>
        public HistorialProgresoView(ProgresoController progresoController)
        {
            this.ProgresoController = progresoController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdProgreso.Columns.Clear();
            this.GrdProgreso.Rows.Clear();
            this.GrdProgreso.Columns.Add("Rutina", "Rutina");
            this.GrdProgreso.Columns.Add("Ejercicio", "Ejercicio");
            this.GrdProgreso.Columns.Add("Fecha", "Fecha");
            this.GrdProgreso.Columns.Add("Peso", "Peso en kg");
            this.GrdProgreso.Columns.Add("Aumento", "Aumento kg");
            this.GrdProgreso.Columns.Add("Repeticiones", "Repeticiones");
            this.GrdProgreso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            var progresos = this.ProgresoController.ObtenerDelUsuarioActual();
            for (var i = 0; i < progresos.Count; i++)
            {
                var progreso = progresos[i];
                this.GrdProgreso.Rows.Add(
                    this.ProgresoController.NombreDeLaRutina(progreso.IdEjercicio),
                    this.ProgresoController.NombreDelEjercicio(progreso.IdEjercicio),
                    progreso.Fecha.ToString("yyyy-MM-dd"),
                    progreso.Peso.ToString(CultureInfo.InvariantCulture),
                    this.ProgresoController.TextoDeAumento(progresos, i),
                    progreso.Repeticiones);
            }

            this.LblVacio.Visible = progresos.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
