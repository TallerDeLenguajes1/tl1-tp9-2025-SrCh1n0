string? Direccion;
do
{
    Console.WriteLine("-Analisis de Directorios-");
    Console.WriteLine("-----------------------");
    Console.WriteLine("Ingrese el directorio que desea analizar: ");
    Direccion = Console.ReadLine();
    if (Directory.Exists(Direccion))
    {
        string[] carpetas = Directory.GetDirectories(Direccion);
        DirectoryInfo direc = new DirectoryInfo(Direccion);
        FileInfo[] archivos = direc.GetFiles();
        Console.WriteLine("-Carpetas en el directorio-");
        int i = 1;
        foreach (string carpeta in carpetas)
        {
            Console.WriteLine($"{i}. {carpeta}");
            i++;
        }
        Console.WriteLine($"-Archivos en el directorio-");
        List<string> lineas = new List<string>();
        lineas.Add("Nombre;Tamanio;UltimoAcceso");
        foreach (FileInfo archivo in archivos)
        {
            double tamanioKB = archivo.Length / 1024.0;
            string tamaKB = tamanioKB.ToString("N2");
            Console.WriteLine($"* {archivo.Name}, tamaño {tamaKB} KB");
            lineas.Add($"{archivo.Name};{tamaKB} KB;{archivo.LastAccessTime:G}");
        }
        string savePath = Path.Combine(Direccion, "reporte_archivos.csv");
        File.WriteAllLines(savePath, lineas);
    }
    else
    {
        Console.WriteLine($"Direccion no encontrada");
        Console.WriteLine($"Ingrese un directorio valido");
    }
} while (Direccion != "");