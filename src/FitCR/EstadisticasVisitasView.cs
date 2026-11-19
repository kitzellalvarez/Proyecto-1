using System.ComponentModel;
using System.Globalization;
using FitCRController;

namespace FitCR
{
    /// <summary>
    /// Muestra visitas, ausentes, cambio de peso y metas entre dos fechas.
    /// </summary>
    public partial class EstadisticasVisitasView : Form
    {
        /// <summary>
        /// Controlador que arma el ranking.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VisitaController VisitaController { get; set; }

        /// <summary>
        /// Controlador que calcula el cambio de peso.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public MedicionController MedicionController { get; set; }

        /// <summary>
        /// Controlador que dice cómo van las metas.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObjetivoController ObjetivoController { get; set; }

        /// <summary>
        /// Crea la ventana de estadísticas.
        /// </summary>
        public EstadisticasVisitasView(VisitaController visitaController, MedicionController medicionController, ObjetivoController objetivoController)
        {
            this.VisitaController = visitaController;
            this.MedicionController = medicionController;
            this.ObjetivoController = objetivoController;
            InitializeComponent();
            this.BtnConsultar.Click += this.BtnConsultar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
        }

        private void BtnConsultar_Click(object? sender, EventArgs e)
        {
            var lista = this.VisitaController.ConsultarRanking(this.TxtInicio.Text, this.TxtFin.Text);
            if (!lista)
            {
                MessageBox.Show(this.VisitaController.Mensaje, "Fit.CR");
                return;
            }

            this.CargarTabla();
            this.LblPeso.Text = this.MedicionController.TextoDeAumentoEnRango(
                this.VisitaController.InicioConsultado,
                this.VisitaController.FinConsultado);
            this.CargarMetas();
        }

        private void CargarTabla()
        {
            this.GrdRanking.Columns.Clear();
            this.GrdRanking.Rows.Clear();
            this.GrdRanking.Columns.Add("Nombre", "Nombre");
            this.GrdRanking.Columns.Add("Visitas", "Visitas");

            foreach (var persona in this.VisitaController.Ranking)
            {
                var visitas = this.VisitaController.ContarDe(
                    persona.Id,
                    this.VisitaController.InicioConsultado,
                    this.VisitaController.FinConsultado);
                this.GrdRanking.Rows.Add(persona.Nombre + " " + persona.Apellidos, visitas.ToString());
            }

            this.LblVacio.Visible = this.VisitaController.Ranking.Count == 0;

            this.GrdAusentes.Columns.Clear();
            this.GrdAusentes.Rows.Clear();
            this.GrdAusentes.Columns.Add("Nombre", "Nombre");
            this.GrdAusentes.Columns.Add("Visitas", "Visitas");

            foreach (var persona in this.VisitaController.RankingAusentes)
            {
                var visitas = this.VisitaController.ContarDe(
                    persona.Id,
                    this.VisitaController.InicioConsultado,
                    this.VisitaController.FinConsultado);
                this.GrdAusentes.Rows.Add(persona.Nombre + " " + persona.Apellidos, visitas.ToString());
            }
        }

        private void CargarMetas()
        {
            this.GrdMetas.Columns.Clear();
            this.GrdMetas.Rows.Clear();
            this.GrdMetas.Columns.Add("Meta", "Meta");
            this.GrdMetas.Columns.Add("Valor", "Valor");
            this.GrdMetas.Columns.Add("Ahora", "Ahora");
            this.GrdMetas.Columns.Add("Estado", "Estado");

            var inicio = this.VisitaController.InicioConsultado;
            var fin = this.VisitaController.FinConsultado;
            var metas = this.ObjetivoController.ObtenerEnRango(inicio, fin);
            foreach (var meta in metas)
            {
                this.GrdMetas.Rows.Add(
                    meta.ObtenerNombre(),
                    meta.ValorMeta.ToString("0.##", CultureInfo.InvariantCulture),
                    this.ObjetivoController.TextoValorEnRango(meta, inicio, fin),
                    this.ObjetivoController.EstadoEnRango(meta, inicio, fin));
            }

            this.LblSinMetas.Visible = metas.Count == 0;
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
