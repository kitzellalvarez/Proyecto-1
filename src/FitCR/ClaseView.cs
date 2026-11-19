using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Registra una clase del gimnasio y muestra las del entrenador que inició sesión.
    /// </summary>
    public partial class ClaseView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda la clase.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ClaseController ClaseController { get; set; }

        /// <summary>
        /// Crea la ventana y muestra las clases ya registradas.
        /// </summary>
        public ClaseView(ClaseController claseController)
        {
            this.ClaseController = claseController;
            InitializeComponent();
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CmbTipo.SelectedIndex = 0;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdClases.Columns.Clear();
            this.GrdClases.Rows.Clear();
            this.GrdClases.Columns.Add("Clase", "Clase");
            this.GrdClases.Columns.Add("Horario", "Horario");

            var clases = this.ClaseController.ObtenerDelEntrenadorActual();
            foreach (var clase in clases)
            {
                this.GrdClases.Rows.Add(clase.ObtenerNombre(), clase.Horario);
            }

            this.LblVacio.Visible = clases.Count == 0;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var tipo = this.CmbTipo.SelectedIndex < 0 ? string.Empty : this.CmbTipo.SelectedIndex.ToString();
            var registrada = this.ClaseController.Registrar(tipo, this.TxtHorario.Text);
            MessageBox.Show(this.ClaseController.Mensaje, "Fit.CR");
            if (registrada)
            {
                this.TxtHorario.Clear();
                this.CargarTabla();
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
