using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Crea los avisos de la persona y muestra los que ya tiene.
    /// </summary>
    public class NotificacionController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene los avisos y las insignias.
        /// </summary>
        public NotificacionController(InformationService informationService)
        {
            this.InformationService = informationService;
        }

        /// <summary>
        /// Servicio donde están los avisos, las insignias y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Devuelve los avisos de la persona que inició sesión.
        /// </summary>
        public List<Notificacion> ObtenerDelUsuarioActual()
        {
            var resultado = new List<Notificacion>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null)
            {
                return resultado;
            }

            var esEntrenador = actual is Entrenador;
            foreach (var aviso in this.InformationService.Notificaciones)
            {
                if (aviso.IdUsuario == actual.Id && aviso.EsParaEntrenador() == esEntrenador)
                {
                    resultado.Add(aviso);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Crea un aviso por cada insignia de meta cumplida que todavía no tenga mensaje.
        /// </summary>
        public void AsegurarAvisosDeInsignias()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return;
            }

            var creadas = new List<Notificacion>();
            foreach (var insignia in this.InformationService.Insignias)
            {
                if (insignia.IdUsuario != actual.Id || insignia.EsDeIncumplimiento())
                {
                    continue;
                }

                var mensaje = ("Obtuviste la insignia " + insignia.ObtenerNombre() + ".").Replace(',', ' ');
                if (this.YaExiste(actual.Id, TipoNotificacion.InsigniaObtenida, mensaje))
                {
                    continue;
                }

                var aviso = new Notificacion(this.SiguienteId(creadas), actual.Id, ((int)TipoNotificacion.InsigniaObtenida).ToString(CultureInfo.InvariantCulture), insignia.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), mensaje);
                this.InformationService.Notificaciones.Add(aviso);
                creadas.Add(aviso);
            }

            if (creadas.Count == 0)
            {
                return;
            }

            if (!this.InformationService.GuardarNotificaciones())
            {
                foreach (var aviso in creadas)
                {
                    this.InformationService.Notificaciones.Remove(aviso);
                }
            }
        }

        /// <summary>
        /// Crea un aviso por cada insignia de incumplimiento que todavía no tenga mensaje.
        /// </summary>
        public void AsegurarAvisosDeIncumplimiento()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return;
            }

            var creadas = new List<Notificacion>();
            foreach (var insignia in this.InformationService.Insignias)
            {
                if (insignia.IdUsuario != actual.Id || !insignia.EsDeIncumplimiento())
                {
                    continue;
                }

                var mensaje = ("Obtuviste la insignia " + insignia.ObtenerNombre() + ".").Replace(',', ' ');
                if (this.YaExiste(actual.Id, TipoNotificacion.InsigniaIncumplimiento, mensaje))
                {
                    continue;
                }

                var aviso = new Notificacion(this.SiguienteId(creadas), actual.Id, ((int)TipoNotificacion.InsigniaIncumplimiento).ToString(CultureInfo.InvariantCulture), insignia.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), mensaje);
                this.InformationService.Notificaciones.Add(aviso);
                creadas.Add(aviso);
            }

            if (creadas.Count == 0)
            {
                return;
            }

            if (!this.InformationService.GuardarNotificaciones())
            {
                foreach (var aviso in creadas)
                {
                    this.InformationService.Notificaciones.Remove(aviso);
                }
            }
        }

        /// <summary>
        /// Avisa al entrenador las rutinas suyas que vencen en los próximos 30 días.
        /// </summary>
        public void AsegurarAvisosDeRutinasPorVencer()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual is not Entrenador)
            {
                return;
            }

            var limite = DateTime.Today.AddDays(30);
            var creadas = new List<Notificacion>();
            foreach (var rutina in this.InformationService.Rutinas)
            {
                if (rutina.IdEntrenador != actual.Id)
                {
                    continue;
                }

                if (rutina.FechaFin.Date < DateTime.Today || rutina.FechaFin.Date > limite)
                {
                    continue;
                }

                var mensaje = ("La rutina " + rutina.Nombre + " de " + this.NombreDelUsuario(rutina.IdUsuario) + " vence el " + rutina.FechaFin.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ".").Replace(',', ' ');
                if (this.YaExiste(actual.Id, TipoNotificacion.RutinaPorVencer, mensaje))
                {
                    continue;
                }

                var aviso = new Notificacion(this.SiguienteId(creadas), actual.Id, ((int)TipoNotificacion.RutinaPorVencer).ToString(CultureInfo.InvariantCulture), DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), mensaje);
                this.InformationService.Notificaciones.Add(aviso);
                creadas.Add(aviso);
            }

            if (creadas.Count == 0)
            {
                return;
            }

            if (!this.InformationService.GuardarNotificaciones())
            {
                foreach (var aviso in creadas)
                {
                    this.InformationService.Notificaciones.Remove(aviso);
                }
            }
        }

        /// <summary>
        /// Guarda el aviso de descanso si la persona ya tiene 5 visitas en la semana.
        /// </summary>
        public void AsegurarAvisoDeDescanso()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return;
            }

            var mensaje = new VisitaController(this.InformationService).TextoDeDescanso();
            if (mensaje == string.Empty || this.YaExiste(actual.Id, TipoNotificacion.DescansoSemanal, mensaje))
            {
                return;
            }

            var aviso = new Notificacion(this.SiguienteId(new List<Notificacion>()), actual.Id, ((int)TipoNotificacion.DescansoSemanal).ToString(CultureInfo.InvariantCulture), DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), mensaje);
            this.InformationService.Notificaciones.Add(aviso);
            if (!this.InformationService.GuardarNotificaciones())
            {
                this.InformationService.Notificaciones.Remove(aviso);
            }
        }

        /// <summary>
        /// Avisa al entrenador los usuarios sin medición, o con la última hace 30 días o más.
        /// </summary>
        public void AsegurarAvisosDeMedicionesProximas()
        {
            var actual = this.InformationService.UsuarioActual;
            if (actual is not Entrenador)
            {
                return;
            }

            var limite = DateTime.Today.AddDays(-30);
            var creadas = new List<Notificacion>();
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (usuario is Entrenador)
                {
                    continue;
                }

                var ultima = this.UltimaMedicionDe(usuario.Id);
                if (ultima != null && ultima.Value > limite)
                {
                    continue;
                }

                var mensaje = "A " + usuario.Nombre + " " + usuario.Apellidos + " le toca una medición.";
                if (ultima != null)
                {
                    mensaje = mensaje + " La última fue el " + ultima.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ".";
                }

                mensaje = mensaje.Replace(',', ' ');
                if (this.YaExiste(actual.Id, TipoNotificacion.MedicionProxima, mensaje))
                {
                    continue;
                }

                var aviso = new Notificacion(this.SiguienteId(creadas), actual.Id, ((int)TipoNotificacion.MedicionProxima).ToString(CultureInfo.InvariantCulture), DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), mensaje);
                this.InformationService.Notificaciones.Add(aviso);
                creadas.Add(aviso);
            }

            if (creadas.Count == 0)
            {
                return;
            }

            if (!this.InformationService.GuardarNotificaciones())
            {
                foreach (var aviso in creadas)
                {
                    this.InformationService.Notificaciones.Remove(aviso);
                }
            }
        }

        private DateTime? UltimaMedicionDe(string idUsuario)
        {
            DateTime? ultima = null;
            foreach (var medicion in this.InformationService.Mediciones)
            {
                if (medicion.IdUsuario != idUsuario)
                {
                    continue;
                }

                if (ultima == null || medicion.Fecha.Date > ultima.Value)
                {
                    ultima = medicion.Fecha.Date;
                }
            }

            return ultima;
        }

        private string NombreDelUsuario(string idUsuario)
        {
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (usuario.Id == idUsuario)
                {
                    return usuario.Nombre + " " + usuario.Apellidos;
                }
            }

            return idUsuario;
        }

        /// <summary>
        /// Avisa a la persona dueña de la rutina que acaba de recibir una rutina nueva.
        /// </summary>
        public void AvisarRutinaNueva(Rutina rutina)
        {
            var mensaje = ("Tienes una rutina nueva: " + rutina.Nombre + ". Va del " + rutina.FechaInicio.ToString("yyyy-MM-dd") + " al " + rutina.FechaFin.ToString("yyyy-MM-dd") + ".").Replace(',', ' ');
            if (this.YaExiste(rutina.IdUsuario, TipoNotificacion.RutinaNueva, mensaje))
            {
                return;
            }

            var aviso = new Notificacion(this.SiguienteId(new List<Notificacion>()), rutina.IdUsuario, ((int)TipoNotificacion.RutinaNueva).ToString(CultureInfo.InvariantCulture), DateTime.Today.ToString("yyyy-MM-dd"), mensaje);
            this.InformationService.Notificaciones.Add(aviso);
            if (!this.InformationService.GuardarNotificaciones())
            {
                this.InformationService.Notificaciones.Remove(aviso);
            }
        }

        private bool YaExiste(string idUsuario, TipoNotificacion tipo, string mensaje)
        {
            foreach (var aviso in this.InformationService.Notificaciones)
            {
                if (aviso.IdUsuario == idUsuario && aviso.Tipo == tipo && aviso.Mensaje == mensaje)
                {
                    return true;
                }
            }

            return false;
        }

        private string SiguienteId(List<Notificacion> recienCreadas)
        {
            var mayor = 0;
            foreach (var aviso in this.InformationService.Notificaciones)
            {
                if (int.TryParse(aviso.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            foreach (var aviso in recienCreadas)
            {
                if (int.TryParse(aviso.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
