Funcion.GenerarTitulo("Indexador de Carpeta");
Console.Write("Ingrese una ruta: ");
string? RutaDeLaCarpeta = Console.ReadLine();

if (!Directory.Exists(RutaDeLaCarpeta))
{
    Console.WriteLine("Parece que la ruta ingresada no es válida. El programa se cerrará");
    return;
}
else
{
    string NombreDelCSV = RutaDeLaCarpeta + @"\directorios.csv";
    List<string> ListadoDecarpetas = Directory.GetDirectories(RutaDeLaCarpeta).ToList();
    List<string> ListadoDeArchivos = Directory.GetFiles(RutaDeLaCarpeta).ToList();
    
    FileStream FS;

    if (!File.Exists(NombreDelCSV))
    {
        FS = File.Create(NombreDelCSV);
        FS.Close();
    }

    using (FS = new FileStream(NombreDelCSV, FileMode.OpenOrCreate))
    using (var SW = new StreamWriter(FS))
    {
        foreach (string Carpeta in ListadoDecarpetas)
        {
            int Indice = ListadoDecarpetas.IndexOf(Carpeta) + 1;
            string Nombre = new DirectoryInfo(Carpeta).Name;
            SW.WriteLine($"{Indice},{Nombre},");
        }
        foreach (string Archivo in ListadoDeArchivos)
        {
            int Indice = ListadoDeArchivos.IndexOf(Archivo) + 1;
            string Nombre = Path.GetFileNameWithoutExtension(Archivo);
            string Extension = Path.GetExtension(Archivo);
            SW.WriteLine($"{Indice},{Nombre},{Extension}");
        }
    }
    Console.WriteLine("La ruta ingresada es válida. El programa creó el archivo en dicha ruta.");
}