using System;
using System.Collections.Generic;

namespace CatalogoRevistas
{
    class Program
    {
        // Lista que representa el catálogo de revistas
        static List<string> catalogo = new List<string>()
        {
            "National Geographic",
            "Time",
            "Scientific American",
            "Forbes",
            "Nature",
            "The Economist",
            "Popular Science",
            "PC Magazine",
            "Wired",
            "Reader's Digest"
        };

        /// <summary>
        /// Método principal que ejecuta el menú de la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            int opcion;

            // Bucle principal del menú
            do
            {
                // Limpia la pantalla y muestra el menú
                Console.Clear();
                MostrarMenu();

                // Lee la opción del usuario
                bool entradaValida = int.TryParse(Console.ReadLine(), out opcion);

                // Validación básica de entrada
                if (!entradaValida)
                {
                    Console.WriteLine("⚠️ Opción no válida. Intente de nuevo.");
                    EsperarUsuario();
                    continue;
                }

                // Ejecuta la opción elegida
                switch (opcion)
                {
                    case 1:
                        BuscarRevista();
                        break;
                    case 2:
                        MostrarCatalogo();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("⚠️ Opción inválida. Intente nuevamente.");
                        break;
                }

                // Espera antes de continuar
                if (opcion != 0)
                {
                    EsperarUsuario();
                }

            } while (opcion != 0);
        }

        /// <summary>
        /// Muestra el menú principal en consola.
        /// </summary>
        static void MostrarMenu()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("      📚 CATÁLOGO DE REVISTAS");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. Buscar revista por título");
            Console.WriteLine("2. Mostrar todas las revistas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
        }

        /// <summary>
        /// Permite al usuario buscar un título de revista.
        /// </summary>
        static void BuscarRevista()
        {
            Console.Write("\n🔍 Ingrese el título de la revista a buscar: ");
            string tituloBuscado = Console.ReadLine();

            // Llamada al método de búsqueda iterativa
            bool encontrado = BuscarTituloIterativo(tituloBuscado);

            // Muestra el resultado
            if (encontrado)
            {
                Console.WriteLine("\n✅ Resultado: Revista encontrada.");
            }
            else
            {
                Console.WriteLine("\n❌ Resultado: Revista no encontrada.");
            }
        }

        /// <summary>
        /// Realiza una búsqueda iterativa en el catálogo.
        /// </summary>
        /// <param name="titulo">Título de la revista a buscar</param>
        /// <returns>True si se encuentra el título, False en caso contrario</returns>
        static bool BuscarTituloIterativo(string titulo)
        {
            foreach (string revista in catalogo)
            {
                // Comparación sin importar mayúsculas o minúsculas
                if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Muestra el listado completo del catálogo.
        /// </summary>
        static void MostrarCatalogo()
        {
            Console.WriteLine("\n📖 Lista de revistas en el catálogo:");
            Console.WriteLine("---------------------------------------");

            foreach (var revista in catalogo)
            {
                Console.WriteLine("- " + revista);
            }
        }

        /// <summary>
        /// Pausa la consola hasta que el usuario presione una tecla.
        /// </summary>
        static void EsperarUsuario()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}


