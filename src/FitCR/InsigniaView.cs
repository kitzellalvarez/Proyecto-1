using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra las insignias de la persona que inició sesión. No permite modificarlas.
    /// </summary>
    public partial class InsigniaView : Form
    {
        /// <summary>
        /// Controlador que entrega las insignias y crea las que correspondan.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public InsigniaController InsigniaController { get; set; }

        /// <summary>
        /// Crea la ventana, otorga las insignias pendientes y llena la tabla.
        /// </summary>
        public InsigniaView(InsigniaController insigniaController)
        {
            this.InsigniaController = insigniaController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.InsigniaController.OtorgarMetasCumplidas();
            this.InsigniaController.OtorgarPocasVisitas();
            this.InsigniaController.OtorgarSinProgreso();
            this.InsigniaController.OtorgarMetasIncumplidas();
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdInsignias.Columns.Clear();
            this.GrdInsignias.Rows.Clear();
            this.GrdInsignias.Columns.Add("Nombre", "Insignia");
            this.GrdInsignias.Columns.Add("Fecha", "Fecha");

            var insignias = this.InsigniaController.ObtenerDelUsuarioActual();
            foreach (var insignia in insignias)
            {
                this.GrdInsignias.Rows.Add(insignia.ObtenerNombre(), insignia.Fecha.ToString("yyyy-MM-dd"));
            }

            this.LblVacio.Visible = insignias.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
