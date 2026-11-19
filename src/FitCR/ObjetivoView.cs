using FitCRController;
using System.ComponentModel;
using System.Globalization;

namespace FitCR
{
    /// <summary>
    /// Registra una meta, muestra las que ya tiene la persona y dice si ya se cumplió.
    /// </summary>
    public partial class ObjetivoView : Form
    {
        /// <summary>
        /// Controlador que valida y guarda la meta.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ObjetivoController ObjetivoController { get; set; }

        /// <summary>
        /// Crea la ventana y muestra las metas ya registradas.
        /// </summary>
        public ObjetivoView(ObjetivoController objetivoController)
        {
            this.ObjetivoController = objetivoController;
            InitializeComponent();
            this.CmbTipo.SelectedIndexChanged += this.CmbTipo_SelectedIndexChanged;
            this.BtnRegistrar.Click += this.BtnRegistrar_Click;
            this.BtnCerrar.Click += this.BtnCerrar_Click;
            this.CmbTipo.SelectedIndex = 1;
            this.CargarTabla();
        }

        private void CmbTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (this.CmbTipo.SelectedIndex == 0)
            {
                this.LblValor.Text = "Kilogramos de musculatura";
            }
            else if (this.CmbTipo.SelectedIndex == 1)
            {
                this.LblValor.Text = "Porcentaje de grasa";
            }
            else
            {
                this.LblValor.Text = "Cantidad de visitas";
            }
        }

        private void CargarTabla()
        {
            this.GrdObjetivos.Columns.Clear();
            this.GrdObjetivos.Rows.Clear();
            this.GrdObjetivos.Columns.Add("Meta", "Meta");
            this.GrdObjetivos.Columns.Add("Valor", "Valor");
            this.GrdObjetivos.Columns.Add("Inicio", "Inicio");
            this.GrdObjetivos.Columns.Add("Fin", "Fin");
            this.GrdObjetivos.Columns.Add("Ahora", "Ahora");
            this.GrdObjetivos.Columns.Add("Estado", "Estado");

            var objetivos = this.ObjetivoController.ObtenerDelUsuarioActual();
            foreach (var objetivo in objetivos)
            {
                this.GrdObjetivos.Rows.Add(
                    objetivo.ObtenerNombre(),
                    objetivo.ValorMeta.ToString(CultureInfo.InvariantCulture),
                    objetivo.FechaInicio.ToString("yyyy-MM-dd"),
                    objetivo.FechaFin.ToString("yyyy-MM-dd"),
                    this.ObjetivoController.TextoValorActual(objetivo),
                    this.ObjetivoController.EstadoDe(objetivo));
            }

            this.LblVacio.Visible = objetivos.Count == 0;
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            var tipo = this.CmbTipo.SelectedIndex < 0 ? string.Empty : this.CmbTipo.SelectedIndex.ToString();
            var registrada = this.ObjetivoController.Registrar(tipo, this.TxtValor.Text, this.TxtInicio.Text, this.TxtFin.Text);
            var mensaje = this.ObjetivoController.Mensaje;
            if (registrada)
            {
                var insignias = new InsigniaController(this.ObjetivoController.InformationService);
                var nuevas = insignias.OtorgarMetasCumplidas();
                if (nuevas.Count > 0)
                {
                    mensaje = mensaje + " Obtuviste la insignia " + string.Join(" y ", nuevas) + ".";
                }

                this.TxtValor.Clear();
                this.TxtInicio.Clear();
                this.TxtFin.Clear();
                this.CargarTabla();
            }

            MessageBox.Show(mensaje, "Fit.CR");
        }

        private void BtnCerrar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
