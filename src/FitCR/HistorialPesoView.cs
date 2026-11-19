using System.ComponentModel;
using System.Globalization;
using FitCRController;

namespace FitCR
{
    /// <summary>
    /// Muestra la fecha, el peso y cuánto cambió respecto a la medición anterior.
    /// </summary>
    public partial class HistorialPesoView : Form
    {
        /// <summary>
        /// Controlador que entrega las mediciones.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MedicionController MedicionController { get; set; }

        /// <summary>
        /// Crea la ventana y llena la tabla.
        /// </summary>
        public HistorialPesoView(MedicionController medicionController)
        {
            this.MedicionController = medicionController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdPesos.Columns.Clear();
            this.GrdPesos.Rows.Clear();
            this.GrdPesos.Columns.Add("Fecha", "Fecha");
            this.GrdPesos.Columns.Add("Peso", "Peso kg");
            this.GrdPesos.Columns.Add("Aumento", "Aumento kg");

            var mediciones = this.MedicionController.ObtenerHistorialDePeso();
            for (var i = 0; i < mediciones.Count; i++)
            {
                var medicion = mediciones[i];
                this.GrdPesos.Rows.Add(
                    medicion.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    medicion.Peso.ToString("0.##", CultureInfo.InvariantCulture),
                    this.MedicionController.TextoDeAumento(i, mediciones));
            }

            this.LblVacio.Visible = mediciones.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
