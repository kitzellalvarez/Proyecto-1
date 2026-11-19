using System.Globalization;
using FitCRModels;
using FitCRModels.Enums;

namespace FitCRController
{
    /// <summary>
    /// Registra entrenadores y los guarda en su propio archivo.
    /// </summary>
    public class EntrenadorController
    {
        /// <summary>
        /// Crea el controlador con el servicio que contiene las personas del gimnasio.
        /// </summary>
        public EntrenadorController(InformationService informationService)
        {
            this.InformationService = informationService;
            this.Mensaje = string.Empty;
        }

        /// <summary>
        /// Servicio donde están los usuarios y los entrenadores.
        /// </summary>
        public InformationService InformationService { get; set; }

        /// <summary>
        /// Explica el resultado del registro.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Devuelve los entrenadores que ya fueron cargados desde el archivo.
        /// </summary>
        public List<Entrenador> ObtenerEntrenadores()
        {
            return this.InformationService.Entrenadores;
        }

        /// <summary>
        /// Valida los datos, crea el entrenador y lo escribe en el CSV.
        /// El tipo 0 es personal y el tipo 1 es general.
        /// </summary>
        public bool Registrar(string nombre, string apellidos, string correo, string nombreUsuario, string contrasena, string fechaNacimiento, string peso, string altura, int tipo)
        {
            nombre = nombre.Trim();
            apellidos = apellidos.Trim();
            correo = correo.Trim();
            nombreUsuario = nombreUsuario.Trim();
            contrasena = contrasena.Trim();
            fechaNacimiento = fechaNacimiento.Trim();
            var pesoTexto = this.TextoMedida(peso);
            var alturaTexto = this.TextoMedida(altura);

            if (nombre == string.Empty || apellidos == string.Empty || correo == string.Empty || nombreUsuario == string.Empty || contrasena == string.Empty || fechaNacimiento == string.Empty)
            {
                this.Mensaje = "Completa los datos del entrenador. El peso y la estatura pueden quedar en 0.";
                return false;
            }

            if (nombre.Contains(',') || apellidos.Contains(',') || correo.Contains(',') || nombreUsuario.Contains(',') || contrasena.Contains(','))
            {
                this.Mensaje = "Los datos no pueden incluir comas.";
                return false;
            }

            if (!correo.Contains('@') || !correo.Contains('.'))
            {
                this.Mensaje = "Escribe un correo válido.";
                return false;
            }

            if (!DateTime.TryParseExact(fechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fecha) || fecha.Date > DateTime.Today)
            {
                this.Mensaje = "La fecha debe tener el formato aaaa-mm-dd y no puede ser futura.";
                return false;
            }

            if (!double.TryParse(pesoTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var pesoNumero) || pesoNumero < 0)
            {
                this.Mensaje = "El peso no puede ser negativo.";
                return false;
            }

            if (!double.TryParse(alturaTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out var alturaNumero) || alturaNumero < 0)
            {
                this.Mensaje = "La estatura no puede ser negativa.";
                return false;
            }

            if (tipo != (int)TipoEntrenador.Personal && tipo != (int)TipoEntrenador.General)
            {
                this.Mensaje = "Selecciona si el entrenador es personal o general.";
                return false;
            }

            if (this.EstaRepetido(nombreUsuario, correo))
            {
                return false;
            }

            var nuevo = new Entrenador(this.SiguienteId(), nombre, apellidos, correo, nombreUsuario, contrasena, fechaNacimiento, pesoTexto, alturaTexto, tipo.ToString());
            this.InformationService.Entrenadores.Add(nuevo);

            if (!this.InformationService.GuardarEntrenadores())
            {
                this.InformationService.Entrenadores.Remove(nuevo);
                this.Mensaje = "No se pudo guardar el entrenador.";
                return false;
            }

            this.Mensaje = "Entrenador registrado.";
            return true;
        }

        private string TextoMedida(string texto)
        {
            var limpio = texto.Trim().Replace(',', '.');
            if (limpio == string.Empty)
            {
                return "0";
            }

            return limpio;
        }

        private bool EstaRepetido(string nombreUsuario, string correo)
        {
            foreach (var usuario in this.InformationService.Usuarios)
            {
                if (this.Repite(usuario.NombreUsuario, usuario.Correo, nombreUsuario, correo))
                {
                    return true;
                }
            }

            foreach (var entrenador in this.InformationService.Entrenadores)
            {
                if (this.Repite(entrenador.NombreUsuario, entrenador.Correo, nombreUsuario, correo))
                {
                    return true;
                }
            }

            return false;
        }

        private bool Repite(string usuarioExistente, string correoExistente, string nombreUsuario, string correo)
        {
            if (string.Equals(usuarioExistente, nombreUsuario, StringComparison.OrdinalIgnoreCase))
            {
                this.Mensaje = "Ese nombre de usuario ya existe.";
                return true;
            }

            if (string.Equals(correoExistente, correo, StringComparison.OrdinalIgnoreCase))
            {
                this.Mensaje = "Ese correo ya está registrado.";
                return true;
            }

            return false;
        }

        private string SiguienteId()
        {
            var mayor = 0;
            foreach (var entrenador in this.InformationService.Entrenadores)
            {
                if (int.TryParse(entrenador.Id, out var id) && id > mayor)
                {
                    mayor = id;
                }
            }

            return (mayor + 1).ToString();
        }
    }
}
