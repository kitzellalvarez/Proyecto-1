using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Crea las insignias de la persona y muestra las que ya tiene.
    /// </summary>
    public class InsigniaController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las insignias y las metas.
        /// </summary>
        public InsigniaController(InformationService informationService)
        {
            this.InformationService = informationService;
        }

        /// <summary>
        /// Servicio donde están las insignias, las metas y la persona que inició sesión.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Devuelve las insignias de la persona que inició sesión.
        /// </summary>
        public List<Insignia> ObtenerDelUsuarioActual()
        {
            var resultado = new List<Insignia>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return resultado;
            }

            foreach (var insignia in this.InformationService.Insignias)
            {
                if (insignia.IdUsuario == actual.Id)
                {
                    resultado.Add(insignia);
                }
            }

            return resultado;
        }

        /// <summary>
        /// Crea una insignia por cada tipo de meta que ya esté cumplida y que la persona todavía no tenga.
        /// Devuelve los nombres de las insignias nuevas.
        /// </summary>
        public List<string> OtorgarMetasCumplidas()
        {
            var nuevas = new List<string>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return nuevas;
            }

            var objetivos = new ObjetivoController(this.InformationService);
            var creadas = new List<Insignia>();
            foreach (var objetivo in objetivos.ObtenerDelUsuarioActual())
            {
                if (objetivos.EstadoDe(objetivo) != "Cumplida")
                {
                    continue;
                }

                var tipo = (TipoInsignia)(int)objetivo.Tipo;
                if (this.YaTiene(actual.Id, tipo))
                {
                    continue;
                }

                var insignia = new Insignia(this.SiguienteId(creadas), actual.Id, ((int)tipo).ToString(CultureInfo.InvariantCulture), DateTime.Today.ToString("yyyy-MM-dd"));
                this.InformationService.Insignias.Add(insignia);
                creadas.Add(insignia);
                nuevas.Add(insignia.ObtenerNombre());
            }

            if (creadas.Count == 0)
            {
                return nuevas;
            }

            if (!this.InformationService.GuardarInsignias())
            {
                foreach (var insignia in creadas)
                {
                    this.InformationService.Insignias.Remove(insignia);
                }

                nuevas.Clear();
            }

            return nuevas;
        }

        /// <summary>
        /// Crea la insignia de pocas visitas si la persona está entre las diez con menos visitas.
        /// </summary>
        public List<string> OtorgarPocasVisitas()
        {
            var nuevas = new List<string>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return nuevas;
            }

            if (!this.EstaEntreLosDeMenosVisitas(actual.Id) || this.YaTiene(actual.Id, TipoInsignia.PocasVisitas))
            {
                return nuevas;
            }

            var creadas = new List<Insignia>();
            var insignia = new Insignia(
                this.SiguienteId(creadas),
                actual.Id,
                ((int)TipoInsignia.PocasVisitas).ToString(CultureInfo.InvariantCulture),
                DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            this.InformationService.Insignias.Add(insignia);
            creadas.Add(insignia);

            if (!this.InformationService.GuardarInsignias())
            {
                this.InformationService.Insignias.Remove(insignia);
                return nuevas;
            }

            nuevas.Add(insignia.ObtenerNombre());
            return nuevas;
        }

        /// <summary>
        /// Crea la insignia Sin progreso si la persona no tiene ninguna marca de ejercicio.
        /// </summary>
        public List<string> OtorgarSinProgreso()
        {
            var nuevas = new List<string>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return nuevas;
            }

            if (this.TieneProgreso(actual.Id) || this.YaTiene(actual.Id, TipoInsignia.SinProgreso))
            {
                return nuevas;
            }

            var creadas = new List<Insignia>();
            var insignia = new Insignia(
                this.SiguienteId(creadas),
                actual.Id,
                ((int)TipoInsignia.SinProgreso).ToString(CultureInfo.InvariantCulture),
                DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            this.InformationService.Insignias.Add(insignia);
            creadas.Add(insignia);

            if (!this.InformationService.GuardarInsignias())
            {
                this.InformationService.Insignias.Remove(insignia);
                return nuevas;
            }

            nuevas.Add(insignia.ObtenerNombre());
            return nuevas;
        }

        /// <summary>
        /// Crea la insignia Meta incumplida si una meta ya terminó y no se cumplió.
        /// </summary>
        public List<string> OtorgarMetasIncumplidas()
        {
            var nuevas = new List<string>();
            var actual = this.InformationService.UsuarioActual;
            if (actual == null || actual is Entrenador)
            {
                return nuevas;
            }

            if (!this.TieneMetaVencidaSinCumplir() || this.YaTiene(actual.Id, TipoInsignia.MetaIncumplida))
            {
                return nuevas;
            }

            var creadas = new List<Insignia>();
            var insignia = new Insignia(
                this.SiguienteId(creadas),
                actual.Id,
                ((int)TipoInsignia.MetaIncumplida).ToString(CultureInfo.InvariantCulture),
                DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
            this.InformationService.Insignias.Add(insignia);
            creadas.Add(insignia);

            if (!this.InformationService.GuardarInsignias())
            {
                this.InformationService.Insignias.Remove(insignia);
                return nuevas;
            }

            nuevas.Add(insignia.ObtenerNombre());
            return nuevas;
        }

        private bool TieneMetaVencidaSinCumplir()
        {
            var objetivos = new ObjetivoController(this.InformationService);
            foreach (var objetivo in objetivos.ObtenerDelUsuarioActual())
            {
                if (objetivo.FechaFin.Date >= DateTime.Today)
                {
                    continue;
                }

                if (objetivos.EstadoDe(objetivo) != "Cumplida")
                {
                    return true;
                }
            }

            return false;
        }

        private bool TieneProgreso(string idUsuario)
        {
            foreach (var progreso in this.InformationService.Progresos)
            {
                if (progreso.IdUsuario == idUsuario)
                {
                    return true;
                }
            }

            return false;
        }

        private bool EstaEntreLosDeMenosVisitas(string idUsuario)
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
                    if (this.ContarVisitas(personas[j].Id) < this.ContarVisitas(personas[i].Id))
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

            foreach (var persona in personas)
            {
                if (persona.Id == idUsuario)
                {
                    return true;
                }
            }

            return false;
        }

        private int ContarVisitas(string idUsuario)
        {
            var cantidad = 0;
            foreach (var visita in this.InformationService.Visitas)
            {
                if (visita.IdUsuario == idUsuario)
                {
                    cantidad++;
                }
            }

            return cantidad;
        }

        private bool YaTiene(string idUsuario, TipoInsignia tipo)
        {
            foreach (var insignia in this.InformationService.Insignias)
            {
                if (insignia.IdUsuario == idUsuario && insignia.Tipo == tipo)
                {
                    return true;
                }
            }

            return false;
        }

        private string SiguienteId(List<Insignia> recienCreadas)
        {
            var mayor = 0;
            foreach (var insignia in this.InformationService.Insignias)
            {
                if (int.TryParse(insignia.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            foreach (var insignia in recienCreadas)
            {
                if (int.TryParse(insignia.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
