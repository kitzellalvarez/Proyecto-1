using FitCRController;
using FitCRModels;

namespace FitCR
{
    /// <summary>
    /// Menú que aparece después de ingresar.
    /// Muestra quién entró y abre el perfil, los entrenadores, las rutinas, las clases, el progreso, las visitas, las mediciones, las metas, las insignias o los avisos.
    /// </summary>
    public partial class MainMenuView : Form
    {
        private InformationService InformationService { get; set; }

        /// <summary>
        /// Crea el menú con los datos de la persona que inició sesión.
        /// </summary>
        public MainMenuView(InformationService informationService)
        {
            this.InformationService = informationService;
            InitializeComponent();
            this.BtnPerfil.Click += this.BtnPerfil_Click;
            this.BtnEntrenadores.Click += this.BtnEntrenadores_Click;
            this.BtnNuevaRutina.Click += this.BtnNuevaRutina_Click;
            this.BtnClase.Click += this.BtnClase_Click;
            this.BtnMiProgreso.Click += this.BtnMiProgreso_Click;
            this.BtnVisita.Click += this.BtnVisita_Click;
            this.BtnMedicion.Click += this.BtnMedicion_Click;
            this.BtnMeta.Click += this.BtnMeta_Click;
            this.BtnInsignias.Click += this.BtnInsignias_Click;
            this.BtnConsultaClases.Click += this.BtnConsultaClases_Click;
            this.BtnAvisos.Click += this.BtnAvisos_Click;
            this.BtnMisRutinas.Click += this.BtnMisRutinas_Click;
            this.BtnHistorialPeso.Click += this.BtnHistorialPeso_Click;
            this.BtnEstadisticas.Click += this.BtnEstadisticas_Click;
            this.BtnSalir.Click += this.BtnSalir_Click;
            this.MostrarPersona();
        }

        private void MostrarPersona()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null)
            {
                this.LblBienvenida.Text = "No hay una sesión activa.";
                this.LblDetalle.Text = string.Empty;
                return;
            }

            this.LblBienvenida.Text = $"Hola, {actual.Nombre}";
            this.LblDetalle.Text = $"{actual.Nombre} {actual.Apellidos}{Environment.NewLine}" +
                $"{actual.NombreUsuario}{Environment.NewLine}" +
                $"{actual.DescribirRol()}";
            this.LblTitulo.Location = new Point(24, 12);
            this.LblBienvenida.Location = new Point(24, 48);
            this.LblDetalle.Location = new Point(24, 78);
            var esEntrenador = actual is Entrenador;
            this.BtnNuevaRutina.Visible = esEntrenador;
            this.BtnClase.Visible = esEntrenador;
            this.BtnMiProgreso.Visible = !esEntrenador;
            this.BtnVisita.Visible = !esEntrenador;
            this.BtnMedicion.Visible = !esEntrenador;
            this.BtnMeta.Visible = !esEntrenador;
            this.BtnInsignias.Visible = !esEntrenador;
            this.BtnConsultaClases.Visible = !esEntrenador;
            this.BtnAvisos.Visible = true;
            this.BtnMisRutinas.Visible = !esEntrenador;
            this.BtnHistorialPeso.Visible = !esEntrenador;
            this.BtnEstadisticas.Visible = !esEntrenador;
            if (esEntrenador)
            {
                this.Colocar(this.BtnPerfil, 24, 136, 320);
                this.Colocar(this.BtnEntrenadores, 24, 176, 320);
                this.Colocar(this.BtnNuevaRutina, 24, 216, 320);
                this.Colocar(this.BtnClase, 24, 256, 320);
                this.Colocar(this.BtnAvisos, 24, 296, 320);
                this.Colocar(this.BtnSalir, 24, 336, 320);
                this.ClientSize = new Size(368, 390);
                return;
            }

            this.Colocar(this.BtnPerfil, 24, 136, 200);
            this.Colocar(this.BtnEntrenadores, 236, 136, 200);
            this.Colocar(this.BtnMiProgreso, 24, 176, 200);
            this.Colocar(this.BtnVisita, 236, 176, 200);
            this.Colocar(this.BtnMedicion, 24, 216, 200);
            this.Colocar(this.BtnMeta, 236, 216, 200);
            this.Colocar(this.BtnInsignias, 24, 256, 200);
            this.Colocar(this.BtnConsultaClases, 236, 256, 200);
            this.Colocar(this.BtnAvisos, 24, 296, 200);
            this.Colocar(this.BtnMisRutinas, 236, 296, 200);
            this.Colocar(this.BtnHistorialPeso, 24, 336, 200);
            this.Colocar(this.BtnEstadisticas, 236, 336, 200);
            this.Colocar(this.BtnSalir, 24, 376, 412);
            this.ClientSize = new Size(460, 430);
        }

        private void Colocar(Button boton, int x, int y, int ancho)
        {
            boton.Location = new Point(x, y);
            boton.Size = new Size(ancho, 34);
        }

        private void BtnPerfil_Click(object? sender, EventArgs e)
        {
            var controlador = new UsuarioController(this.InformationService);
            var ventana = new PerfilView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnEntrenadores_Click(object? sender, EventArgs e)
        {
            var controlador = new EntrenadorController(this.InformationService);
            var ventana = new EntrenadoresView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnNuevaRutina_Click(object? sender, EventArgs e)
        {
            var controlador = new RutinaController(this.InformationService);
            var ventana = new RutinaView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnClase_Click(object? sender, EventArgs e)
        {
            var controlador = new ClaseController(this.InformationService);
            var ventana = new ClaseView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnMiProgreso_Click(object? sender, EventArgs e)
        {
            var controlador = new ProgresoController(this.InformationService);
            var ventana = new HistorialProgresoView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnVisita_Click(object? sender, EventArgs e)
        {
            var controlador = new VisitaController(this.InformationService);
            var ventana = new VisitaView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnMedicion_Click(object? sender, EventArgs e)
        {
            var controlador = new MedicionController(this.InformationService);
            var ventana = new MedicionView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnMeta_Click(object? sender, EventArgs e)
        {
            var controlador = new ObjetivoController(this.InformationService);
            var ventana = new ObjetivoView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnInsignias_Click(object? sender, EventArgs e)
        {
            var controlador = new InsigniaController(this.InformationService);
            var ventana = new InsigniaView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnConsultaClases_Click(object? sender, EventArgs e)
        {
            var controlador = new ClaseController(this.InformationService);
            var ventana = new ConsultaClasesView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnAvisos_Click(object? sender, EventArgs e)
        {
            var controlador = new NotificacionController(this.InformationService);
            var ventana = new NotificacionView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnMisRutinas_Click(object? sender, EventArgs e)
        {
            var controlador = new RutinaController(this.InformationService);
            var ventana = new ConsultaRutinasView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnHistorialPeso_Click(object? sender, EventArgs e)
        {
            var controlador = new MedicionController(this.InformationService);
            var ventana = new HistorialPesoView(controlador);
            ventana.ShowDialog(this);
        }

        private void BtnEstadisticas_Click(object? sender, EventArgs e)
        {
            var visitas = new VisitaController(this.InformationService);
            var mediciones = new MedicionController(this.InformationService);
            var metas = new ObjetivoController(this.InformationService);
            var ventana = new EstadisticasVisitasView(visitas, mediciones, metas);
            ventana.ShowDialog(this);
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
