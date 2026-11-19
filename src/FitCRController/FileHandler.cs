using FitCRController.Abstractions;

namespace FitCRController
{
    /// <summary>
    /// Lee y guarda una lista de objetos en un archivo CSV.
    /// Cada columna del archivo llega al constructor de la clase como texto.
    /// </summary>
    public class FileHandler<T> : IDataHandler<T>
    {
        /// <summary>
        /// Carga los registros. Omite el encabezado y las líneas vacías.
        /// </summary>
        public List<T> LoadData(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                throw new ArgumentException("Debe indicar el archivo que se va a leer.");
            }

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("No se encontró el archivo de datos.", filename);
            }

            var data = new List<T>();
            var lines = File.ReadAllLines(filename);

            for (var i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                try
                {
                    var lineElements = lines[i].Split(',');
                    var newElement = Activator.CreateInstance(typeof(T), lineElements);
                    if (newElement != null)
                    {
                        data.Add((T)newElement);
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"No se pudo leer la línea {i + 1} del archivo. Revise que las columnas estén completas y usen el formato correcto.", ex);
                }
            }

            return data;
        }

        /// <summary>
        /// Guarda el encabezado y una fila por cada elemento.
        /// La fila sale de ToString, así que cada clase debe devolver sus columnas en orden.
        /// </summary>
        public bool SaveData(string filename, string encabezado, List<T> data)
        {
            if (string.IsNullOrWhiteSpace(filename) || string.IsNullOrWhiteSpace(encabezado) || data == null)
            {
                return false;
            }

            try
            {
                var lines = new List<string>();
                lines.Add(encabezado);

                foreach (var element in data)
                {
                    var line = element?.ToString();
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        lines.Add(line);
                    }
                }

                File.WriteAllLines(filename, lines);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
