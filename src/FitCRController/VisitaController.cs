using System.Globalization;
using FitCRModels;

namespace FitCRController
{
    /// <summary>
    /// Registra visitas, cuenta las de la semana y arma el ranking de un período.
    /// </summary>
    public class VisitaController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las visitas.
        /// </summary>
        public VisitaController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
            this.Ranking = new List<Usuario>();
            this.RankingAusentes = new List<Usuario>();
        }

        /// <summary>
        /// Servicio donde están las visitas y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Personas ordenadas de quien más visitó a quien menos visitó.
        /// </summary>
        public List<Usuario> Ranking { get; set; }

        /// <summary>
        /// Personas ordenadas de quien menos visitó a quien más visitó.
        /// </summary>
        public List<Usuario> RankingAusentes { get; set; }

        /// <summary>
        /// Primer día del período consultado.
        /// </summary>
        public DateTime InicioConsultado { get; set; }

        /// <summary>
        /// Último día del período consultado.
        /// </summary>
        public DateTime FinConsultado { get; set; }

        /// <summary>
        /// Devuelve las visitas de la persona que inició sesión.
        /// </summary>
        public List<VisitaGimnasio> ObtenerDelUsuarioActual()
        {
            var resultado = new List<VisitaGimnasio>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario == actual.Id)
                {
                    resultado.Add(visita);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Cuenta las visitas de la persona, de lunes a domingo de la semana actual.
        /// </summary>
        public int ContarSemanaActual()
        {
            var inicio = InicioDeSemana(DateTime.Today);
            return this.ContarEntre(inicio, inicio.AddDays(6));
        }

        /// <summary>
        /// Texto de la semana. Pide descanso cuando ya hay 5 visitas o más.
        /// </summary>
        public string TextoDeLaSemana()
        {
            var inicio = InicioDeSemana(DateTime.Today);
            var fin = inicio.AddDays(6);
            var cantidad = this.ContarEntre(inicio, fin);
            var rango = inicio.ToString("yyyy-MM-dd") + " a " + fin.ToString("yyyy-MM-dd");
            if (cantidad >= 5)
            {
                return "Ya van " + cantidad + " visitas del " + rango + ". Conviene descansar.";
            }

            return "Visitas del " + rango + ": " + cantidad + ".";
        }

        /// <summary>
        /// Texto del aviso de descanso. Queda vacío mientras la semana tenga menos de 5 visitas.
        /// </summary>
        public string TextoDeDescanso()
        {
            var inicio = InicioDeSemana(DateTime.Today);
            var fin = inicio.AddDays(6);
            if (this.ContarEntre(inicio, fin) < 5)
            {
                return string.Empty;
            }

            return "Ya llegaste a 5 visitas del " + inicio.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + " al " + fin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ". Conviene descansar.";
        }

        private int ContarEntre(DateTime inicio, DateTime fin)
        {
            var cantidad = 0;
            foreach (var visita in this.ObtenerDelUsuarioActual())
            {
                if (visita.Fecha.Date >= inicio.Date && visita.Fecha.Date <= fin.Date)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        /// <summary>
        /// Ordena a los usuarios básicos según sus visitas entre dos fechas, inclusive.
        /// </summary>
        public bool ConsultarRanking(string fechaInicio, string fechaFin)
        {
            this.Ranking = new List<Usuario>();
            this.RankingAusentes = new List<Usuario>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                this.Mensaje = "Solo un usuario básico puede ver esta estadística.";
                return false;
            }

            if (!this.LeerRango(fechaInicio, fechaFin, out var inicio, out var fin))
            {
                return false;
            }

            this.Ranking = this.OrdenarPorVisitas(inicio, fin, true);
            this.RankingAusentes = this.OrdenarPorVisitas(inicio, fin, false);
            this.InicioConsultado = inicio;
            this.FinConsultado = fin;
            this.Mensaje = "Ranking de visitas listo.";
            return true;
        }

        /// <summary>
        /// Cuenta las visitas de una persona entre dos fechas, inclusive.
        /// </summary>
        public int ContarDe(string idUsuario, DateTime inicio, DateTime fin)
        {
            var cantidad = 0;
            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario == idUsuario && visita.Fecha.Date >= inicio.Date && visita.Fecha.Date <= fin.Date)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private List<Usuario> OrdenarPorVisitas(DateTime inicio, DateTime fin, bool masVisitasPrimero)
        {
            var personas = new List<Usuario>();
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (usuario is Entrenador)
                {
                    continue;
                }

                personas.Add(usuario);
            }

            for (var i = 0; i < personas.Count; i++)
            {
                for (var j = i + 1; j < personas.Count; j++)
                {
                    var visitasDeI = this.ContarDe(personas[i].Id, inicio, fin);
                    var visitasDeJ = this.ContarDe(personas[j].Id, inicio, fin);
                    var cambia = masVisitasPrimero ? visitasDeJ > visitasDeI : visitasDeJ < visitasDeI;
                    if (cambia)
                    {
                        var temporal = personas[i];
                        personas[i] = personas[j];
                        personas[j] = temporal;
                    }
                }
            }

            while (personas.Count > 10)
            {
                personas.RemoveAt(personas.Count - 1);
            }

            return personas;
        }

        private bool LeerRango(string fechaInicio, string fechaFin, out DateTime inicio, out DateTime fin)
        {
            inicio = DateTime.MinValue;
            fin = DateTime.MinValue;
            fechaInicio = fechaInicio.Trim();
            fechaFin = fechaFin.Trim();
            if (fechaInicio == string.Empty || fechaFin == string.Empty)
            {
                this.Mensaje = "Escribe la fecha de inicio y la fecha de fin.";
                return false;
            }

            if (!DateTime.TryParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out inicio) ||
                !DateTime.TryParseExact(fechaFin, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out fin))
            {
                this.Mensaje = "Las fechas deben tener el formato aaaa-mm-dd.";
                return false;
            }

            if (fin.Date < inicio.Date)
            {
                this.Mensaje = "La fecha de fin no puede ser anterior al inicio.";
                return false;
            }

            return true;
        }

        private static DateTime InicioDeSemana(DateTime fecha)
        {
            var diasDesdeElLunes = ((int)fecha.DayOfWeek + 6) % 7;
            return fecha.Date.AddDays(-diasDesdeElLunes);
        }

        /// <summary>
        /// Anota una visita de la persona que inició sesión y la guarda en el archivo.
        /// </summary>
        public bool Registrar(string fecha)
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                this.Mensaje = "Solo un usuario básico puede registrar su visita.";
                return false;
            }

            fecha = fecha.Trim();
            if (fecha == string.Empty)
            {
                this.Mensaje = "Escribe la fecha de la visita.";
                return false;
            }

            if (!DateTime.TryParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dia))
            {
                this.Mensaje = "La fecha debe tener el formato aaaa-mm-dd.";
                return false;
            }

            if (dia.Date > DateTime.Today)
            {
                this.Mensaje = "La fecha no puede ser posterior a hoy.";
                return false;
            }

            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario == actual.Id && visita.Fecha.Date == dia.Date)
                {
                    this.Mensaje = "Ya registraste una visita en esa fecha.";
                    return false;
                }
            }

            var nueva = new VisitaGimnasio(this.SiguienteId(), actual.Id, fecha);
            this.InformationService.Visitas.Add(nueva);

            if (!this.InformationService.GuardarVisitas())
            {
                this.InformationService.Visitas.Remove(nueva);
                this.Mensaje = "No se pudo guardar la visita.";
                return false;
            }

            this.Mensaje = "Visita registrada.";
            new NotificacionController(this.InformationService).AsegurarAvisoDeDescanso();
            return true;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var visita in this.InformationService.Visitas)
            {
                if (int.TryParse(visita.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
