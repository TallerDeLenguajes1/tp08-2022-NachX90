static class Funcion
{
    static public void GenerarTitulo(string Titulo)
    {
        int LongitudGuiones = (50-Titulo.Length)/2;
        string Guiones = "".PadLeft(LongitudGuiones, '=');
        string LineaMedia = $"{Guiones} {Titulo} {Guiones}";

        Console.WriteLine("".PadLeft(LineaMedia.Length, '='));
        Console.WriteLine(LineaMedia);
        Console.WriteLine("".PadRight(LineaMedia.Length, '='));
        Console.WriteLine();
    }
}