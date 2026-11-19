using System.Globalization;

namespace FitCRModels
{
    /// <summary>
    /// Medición física de un usuario en una fecha.
    /// Cada medición genera un registro nuevo, para conservar el historial.
    /// </summary>
    public class MedicionFisica
    {
        /// <summary>
        /// Crea una medición a partir de los textos de una fila CSV.
        /// El orden de los parámetros debe coincidir con el orden de las columnas.
        /// </summary>
        public MedicionFisica(string id, string idUsuario, string fecha, string peso, string altura, string grasa, string musculatura)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.Fecha = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Peso = double.Parse(peso, CultureInfo.InvariantCulture);
            this.Altura = double.Parse(altura, CultureInfo.InvariantCulture);
            this.Grasa = double.Parse(grasa, CultureInfo.InvariantCulture);
            this.Musculatura = double.Parse(musculatura, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Identificador de la medición.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificador del usuario medido.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// Fecha de la medición.
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Peso, en kilogramos.
        /// </summary>
        public double Peso { get; set; }

        /// <summary>
        /// Estatura, en centímetros.
        /// </summary>
        public double Altura { get; set; }

        /// <summary>
        /// Porcentaje de grasa corporal. Puede ser 0 si ese día no se midió.
        /// </summary>
        public double Grasa { get; set; }

        /// <summary>
        /// Masa muscular, en kilogramos. Puede ser 0 si ese día no se midió.
        /// </summary>
        public double Musculatura { get; set; }

        /// <summary>
        /// Índice de masa corporal de esta medición.
        /// Usa la misma fórmula que Usuario: peso dividido entre la estatura al cuadrado.
        /// </summary>
        public double Imc
        {
            get
            {
                if (Altura <= 0)
                {
                    return 0;
                }

                var alturaMetros = Altura / 100;
                return Peso / (alturaMetros * alturaMetros);
            }
        }

        /// <summary>
        /// Devuelve la fila CSV de esta medición, en el mismo orden del constructor.
        /// El IMC no se guarda: se calcula al leer la fila.
        /// </summary>
        public override string ToString()
        {
            return string.Join(",",
                this.Id,
                this.IdUsuario,
                this.Fecha.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                this.Peso.ToString(CultureInfo.InvariantCulture),
                this.Altura.ToString(CultureInfo.InvariantCulture),
                this.Grasa.ToString(CultureInfo.InvariantCulture),
                this.Musculatura.ToString(CultureInfo.InvariantCulture));
        }
    }
}
