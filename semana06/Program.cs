using System;

public class Nodo
{
    public int Valor;
    public Nodo Siguiente;

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo cabeza;

    // Agrega un nuevo nodo al final
    public void Agregar(int valor)
    {
        Nodo nuevo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
    }

    // EJERCICIO 1: Calcular número de elementos
    public int ContarElementos()
    {
        int contador = 0;
        Nodo actual = cabeza;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }

    // EJERCICIO 2: Invertir la lista enlazada
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente;

        while (actual != null)
        {
            siguiente = actual.Siguiente;
            actual.Siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }

        cabeza = anterior;
    }

    // Mostrar lista en consola
    public void Mostrar()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " -> ");
            actual = actual.Siguiente;
        }
        Console.WriteLine("null");
    }
}

class Programa
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        lista.Agregar(5);
        lista.Agregar(10);
        lista.Agregar(15);
        lista.Agregar(20);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        Console.WriteLine("Número de elementos: " + lista.ContarElementos());

        lista.Invertir();
        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}


