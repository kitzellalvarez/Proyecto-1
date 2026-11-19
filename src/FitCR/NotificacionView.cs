using FitCRController;
using System.ComponentModel;

namespace FitCR
{
    /// <summary>
    /// Muestra los avisos de la persona que inició sesión. No permite modificarlos.
    /// </summary>
    public partial class NotificacionView : Form
    {
        /// <summary>
        /// Controlador que entrega los avisos y crea los de las insignias.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public NotificacionController NotificacionController { get; set; }

        /// <summary>
        /// Crea la ventana, genera los avisos que faltan y llena la tabla.
        /// </summary>
        public NotificacionView(NotificacionController notificacionController)
        {
            this.NotificacionController = notificacionController;
            InitializeComponent();
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.NotificacionController.AsegurarAvisosDeInsignias();
            this.NotificacionController.AsegurarAvisosDeIncumplimiento();
            this.NotificacionController.AsegurarAvisosDeRutinasPorVencer();
            this.NotificacionController.AsegurarAvisosDeMedicionesProximas();
            this.NotificacionController.AsegurarAvisoDeDescanso();
            this.CargarTabla();
        }

        private void CargarTabla()
        {
            this.GrdAvisos.Columns.Clear();
            this.GrdAvisos.Rows.Clear();
            this.GrdAvisos.Columns.Add("Fecha", "Fecha");
            this.GrdAvisos.Columns.Add("Tipo", "Tipo");
            this.GrdAvisos.Columns.Add("Mensaje", "Mensaje");
            this.GrdAvisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.GrdAvisos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.GrdAvisos.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.AjustarColumna("Fecha", 18);
            this.AjustarColumna("Tipo", 22);
            this.AjustarColumna("Mensaje", 60);

            var avisos = this.NotificacionController.ObtenerDelUsuarioActual();
            foreach (var aviso in avisos)
            {
                this.GrdAvisos.Rows.Add(
                    aviso.Fecha.ToString("yyyy-MM-dd"),
                    aviso.ObtenerNombre(),
                    aviso.Mensaje);
            }

            this.LblVacio.Visible = avisos.Count == 0;
        }

        private void AjustarColumna(string nombre, float peso)
        {
            var columna = this.GrdAvisos.Columns[nombre];
            if (columna != null)
            {
                columna.FillWeight = peso;
            }
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
