using FitCRController;
using FitCRModels;
using System.ComponentModel;
using System.Globalization;

namespace FitCR
{
    /// <summary>
    /// Anota el peso y las repeticiones hechas en un ejercicio y muestra el historial.
    /// </summary>
    public partial class ProgresoView : Form
    {
        private Ejercicio Ejercicio { get; set; }

        /// <summary>
        /// Controlador que valida y guarda el progreso.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProgresoController ProgresoController { get; set; }

        /// <summary>
        /// Crea la ventana para el ejercicio seleccionado.
        /// </summary>
        public ProgresoView(ProgresoController progresoController, Ejercicio ejercicio)
        {
            this.ProgresoController = progresoController;
            this.Ejercicio = ejercicio;
            InitializeComponent();
            this.LblTitulo.Text = "Progreso de " + ejercicio.Nombre;
            this.BtnAnotar.Click += this.BtnAnotar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdProgreso.Columns.Clear();
            this.GrdProgreso.Rows.Clear();
            this.GrdProgreso.Columns.Add("Fecha", "Fecha");
            this.GrdProgreso.Columns.Add("Peso", "Peso en kg");
            this.GrdProgreso.Columns.Add("Repeticiones", "Repeticiones");

            foreach (var progreso in this.ProgresoController.ObtenerPorEjercicio(this.Ejercicio.Id))
            {
                this.GrdProgreso.Rows.Add(
                    progreso.Fecha.ToString("yyyy-MM-dd"),
                    progreso.Peso.ToString(CultureInfo.InvariantCulture),
                    progreso.Repeticiones);
            }
        }

        private void BtnAnotar_Click(object? sender, EventArgs e)
        {
            var anotado = this.ProgresoController.Registrar(
                this.Ejercicio.Id,
                this.TxtFecha.Text,
                this.TxtPeso.Text,
                this.TxtRepeticiones.Text);

            MessageBox.Show(this.ProgresoController.Mensaje, "Fit.CR");
            if (anotado)
            {
                this.TxtFecha.Clear();
                this.TxtPeso.Clear();
                this.TxtRepeticiones.Clear();
                this.CargarTabla();
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
