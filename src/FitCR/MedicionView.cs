using FitCRController;
using System.ComponentModel;
using System.Globalization;

namespace FitCR
{
    /// <summary>
    /// Registra una medición física y muestra las que ya tiene la persona.
    /// </summary>
    public partial class MedicionView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda la medición.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MedicionController MedicionController { get; set; }

        /// <summary>
        /// Crea la ventana y muestra las mediciones ya registradas.
        /// </summary>
        public MedicionView(MedicionController medicionController)
        {
            this.MedicionController = medicionController;
            InitializeComponent();
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdMediciones.Columns.Clear();
            this.GrdMediciones.Rows.Clear();
            this.GrdMediciones.Columns.Add("Fecha", "Fecha");
            this.GrdMediciones.Columns.Add("Peso", "Peso kg");
            this.GrdMediciones.Columns.Add("Altura", "Altura cm");
            this.GrdMediciones.Columns.Add("Grasa", "Grasa %");
            this.GrdMediciones.Columns.Add("Musculatura", "Musculatura kg");
            this.GrdMediciones.Columns.Add("Imc", "IMC");

            var mediciones = this.MedicionController.ObtenerDelUsuarioActual();
            foreach (var medicion in mediciones)
            {
                this.GrdMediciones.Rows.Add(
                    medicion.Fecha.ToString("yyyy-MM-dd"),
                    medicion.Peso.ToString(CultureInfo.InvariantCulture),
                    medicion.Altura.ToString(CultureInfo.InvariantCulture),
                    medicion.Grasa.ToString(CultureInfo.InvariantCulture),
                    medicion.Musculatura.ToString(CultureInfo.InvariantCulture),
                    medicion.Imc.ToString("0.00", CultureInfo.InvariantCulture));
            }

            this.LblVacio.Visible = mediciones.Count == 0;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var registrada = this.MedicionController.Registrar(
                this.TxtFecha.Text,
                this.TxtPeso.Text,
                this.TxtAltura.Text,
                this.TxtGrasa.Text,
                this.TxtMusculatura.Text);

            MessageBox.Show(this.MedicionController.Mensaje, "Fit.CR");
            if (registrada)
            {
                this.TxtFecha.Clear();
                this.TxtPeso.Clear();
                this.TxtAltura.Clear();
                this.TxtGrasa.Clear();
                this.TxtMusculatura.Clear();
                this.CargarTabla();
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
