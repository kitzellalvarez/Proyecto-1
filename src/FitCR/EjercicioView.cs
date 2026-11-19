using FitCRController;
using FitCRModels;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Agrega ejercicios a una rutina y muestra los que ya tiene.
    /// </summary>
    public partial class EjercicioView : Form
    {
        private Rutina Rutina { get; set; }

        /// <summary>
        /// Controlador que valida y guarda el ejercicio.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EjercicioController EjercicioController { get; set; }

        /// <summary>
        /// Crea la ventana para la rutina seleccionada.
        /// </summary>
        public EjercicioView(EjercicioController ejercicioController, Rutina rutina)
        {
            this.EjercicioController = ejercicioController;
            this.Rutina = rutina;
            InitializeComponent();
            this.LblTitulo.Text = "Ejercicios de " + rutina.Nombre;
            this.BtnAgregar.Click += this.BtnAgregar_Click;
            this.BtnProgreso.Click += this.BtnProgreso_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdEjercicios.Columns.Clear();
            this.GrdEjercicios.Rows.Clear();
            this.GrdEjercicios.Columns.Add("Nombre", "Nombre");
            this.GrdEjercicios.Columns.Add("Series", "Series");
            this.GrdEjercicios.Columns.Add("Repeticiones", "Repeticiones");
            this.GrdEjercicios.Columns.Add("Peso", "Peso recomendado");

            foreach (var ejercicio in this.EjercicioController.ObtenerPorRutina(this.Rutina.Id))
            {
                var indice = this.GrdEjercicios.Rows.Add(
                    ejercicio.Nombre,
                    ejercicio.Series,
                    ejercicio.Repeticiones,
                    ejercicio.PesoRecomendado.ToString(System.Globalization.CultureInfo.InvariantCulture));
                this.GrdEjercicios.Rows[indice].Tag = ejercicio;
            }
        }

        private void BtnAgregar_Click(object? sender, EventArgs e)
        {
            var agregado = this.EjercicioController.Registrar(
                this.Rutina.Id,
                this.TxtNombre.Text,
                this.TxtSeries.Text,
                this.TxtRepeticiones.Text,
                this.TxtPeso.Text);

            MessageBox.Show(this.EjercicioController.Mensaje, "Fit.CR");
            if (agregado)
            {
                this.TxtNombre.Clear();
                this.TxtSeries.Clear();
                this.TxtRepeticiones.Clear();
                this.TxtPeso.Clear();
                this.CargarTabla();
            }
        }

        private void BtnProgreso_Click(object? sender, EventArgs e)
        {
            if (this.GrdEjercicios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un ejercicio.", "Fit.CR");
                return;
            }

            var ejercicio = this.GrdEjercicios.SelectedRows[0].Tag as Ejercicio;
            if (ejercicio == null)
            {
                MessageBox.Show("Selecciona un ejercicio.", "Fit.CR");
                return;
            }

            var controlador = new ProgresoController(this.EjercicioController.InformationService);
            var ventana = new ProgresoView(controlador, ejercicio);
            ventana.ShowDialog(this);
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
