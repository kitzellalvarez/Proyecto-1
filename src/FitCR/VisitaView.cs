using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Registra una visita al gimnasio, muestra las que ya tiene la persona y cuenta las de esta semana.
    /// </summary>
    public partial class VisitaView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda la visita.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VisitaController VisitaController { get; set; }

        /// <summary>
        /// Crea la ventana y muestra las visitas ya registradas.
        /// </summary>
        public VisitaView(VisitaController visitaController)
        {
            this.VisitaController = visitaController;
            InitializeComponent();
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdVisitas.Columns.Clear();
            this.GrdVisitas.Rows.Clear();
            this.GrdVisitas.Columns.Add("Fecha", "Fecha");

            var visitas = this.VisitaController.ObtenerDelUsuarioActual();
            foreach (var visita in visitas)
            {
                this.GrdVisitas.Rows.Add(visita.Fecha.ToString("yyyy-MM-dd"));
            }

            this.LblVacio.Visible = visitas.Count == 0;
            this.LblSemana.Text = this.VisitaController.TextoDeLaSemana();
            this.LblSemana.ForeColor = this.VisitaController.ContarSemanaActual() >= 5 ? Color.DarkRed : Color.Black;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var registrada = this.VisitaController.Registrar(this.TxtFecha.Text);
            MessageBox.Show(this.VisitaController.Mensaje, "Fit.CR");
            if (registrada)
            {
                this.TxtFecha.Clear();
                this.CargarTabla();
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
