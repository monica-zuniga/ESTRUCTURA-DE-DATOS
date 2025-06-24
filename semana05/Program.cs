using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosListasPOO
{
    public class ListaOperaciones
    {
        public List<int> EliminarDuplicados(List<int> lista) =>
            lista.Distinct().ToList();

        public bool EstaOrdenada(List<int> lista) =>
            lista.SequenceEqual(lista.OrderBy(x => x));

        public List<int> NumerosPrimos(int limite)
        {
            List<int> primos = new List<int>();
            for (int i = 2; i < limite; i++)
            {
                if (EsPrimo(i))
                    primos.Add(i);
            }
            return primos;
        }

        private bool EsPrimo(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
                if (num % i == 0) return false;
            return true;
        }

        public void IntercambiarPrimerUltimo(List<int> lista)
        {
            if (lista.Count < 2) return;
            int temp = lista[0];
            lista[0] = lista[lista.Count - 1];
            lista[lista.Count - 1] = temp;
        }

        public int SegundoMayor(List<int> lista)
        {
            if (lista.Count < 2) throw new InvalidOperationException("Lista muy corta");
            return lista.Distinct().OrderByDescending(x => x).Skip(1).First();
        }
    }

    class Program
    {
        static void Main()
        {
            ListaOperaciones operaciones = new ListaOperaciones();

            // Ejercicio 1
            var lista1 = new List<int> { 1, 2, 2, 3, 4, 4 };
            var sinDuplicados = operaciones.EliminarDuplicados(lista1);
            Console.WriteLine("Sin duplicados: " + string.Join(", ", sinDuplicados));

            // Ejercicio 2
            var lista2 = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("¿Está ordenada? " + operaciones.EstaOrdenada(lista2));

            // Ejercicio 3
            var primos = operaciones.NumerosPrimos(20);
            Console.WriteLine("Primos menores que 20: " + string.Join(", ", primos));

            // Ejercicio 4
            var lista4 = new List<int> { 10, 20, 30, 40 };
            operaciones.IntercambiarPrimerUltimo(lista4);
            Console.WriteLine("Intercambiada: " + string.Join(", ", lista4));

            // Ejercicio 5
            var lista5 = new List<int> { 3, 5, 2, 5, 1 };
            Console.WriteLine("Segundo mayor: " + operaciones.SegundoMayor(lista5));
        }
    }
}

