using System;
using System.Collections.Generic;
using System.Linq;

class TraductorBasico
{
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        { "time", "tiempo" },
        { "person", "persona" },
        { "year", "año" },
        { "way", "camino" },
        { "day", "día" },
        { "thing", "cosa" },
        { "man", "hombre" },
        { "world", "mundo" },
        { "life", "vida" },
        { "hand", "mano" },
        { "part", "parte" },
        { "child", "niño" },
        { "eye", "ojo" },
        { "woman", "mujer" },
        { "place", "lugar" },
        { "work", "trabajo" },
        { "week", "semana" },
        { "case", "caso" },
        { "point", "punto" },
        { "government", "gobierno" },
        { "company", "empresa" }
    };

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.WriteLine("==============================================");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione una tecla para continuar...");
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 0);
    }

    static void TraducirFrase()
    {
        Console.Write("\nIngrese la frase a traducir (Español a Inglés): ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');

        List<string> traducida = new List<string>();

        foreach (string palabra in palabras)
        {
            string limpia = palabra.ToLower().TrimEnd('.', ',', ';', ':', '?', '!');
            string puntuacion = palabra.Length > limpia.Length ? palabra[^1].ToString() : "";

            string traduccion = diccionario.FirstOrDefault(x => x.Value.ToLower() == limpia).Key;

            if (!string.IsNullOrEmpty(traduccion))
                traducida.Add(traduccion + puntuacion);
            else
                traducida.Add(palabra);
        }

        Console.WriteLine("\nFrase traducida:");
        Console.WriteLine(string.Join(" ", traducida));
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }

    static void AgregarPalabra()
    {
        Console.Write("\nIngrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();

        Console.Write("Ingrese su traducción en español: ");
        string espanol = Console.ReadLine().ToLower();

        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada correctamente.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }

        Console.WriteLine("Presione una tecla para continuar...");
        Console.ReadKey();
    }
}

