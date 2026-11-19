namespace FitCRController.Abstractions
{
    /// <summary>
    /// Define cómo se leen y se guardan los datos.
    /// La ventana y los controladores dependen de esta interfaz, no de un archivo concreto.
    /// </summary>
    public interface IDataHandler<T>
    {
        /// <summary>
        /// Guarda la lista en el archivo. La primera línea es el encabezado.
        /// </summary>
        bool SaveData(string filename, string encabezado, List<T> data);

        /// <summary>
        /// Carga los registros del archivo. La primera línea se toma como encabezado.
        /// </summary>
        List<T> LoadData(string filename);
    }
}
