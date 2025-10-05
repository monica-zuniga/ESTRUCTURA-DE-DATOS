```csharp
// ================================
// Cálculo de métricas de centralidades
// Autor: Mónica Zúñiga
// Lenguaje: C# (.NET 6/7)
// ================================

using System;
using System.Collections.Generic;
using System.Linq;

class Grafo
{
    private Dictionary<string, List<string>> adj;

    public Grafo()
    {
        adj = new Dictionary<string, List<string>>();
    }

    public void AgregarNodo(string nodo)
    {
        if (!adj.ContainsKey(nodo))
            adj[nodo] = new List<string>();
    }

    public void AgregarArista(string nodo1, string nodo2)
    {
        AgregarNodo(nodo1);
        AgregarNodo(nodo2);

        if (!adj[nodo1].Contains(nodo2))
            adj[nodo1].Add(nodo2);
        if (!adj[nodo2].Contains(nodo1))
            adj[nodo2].Add(nodo1);
    }

    // Centralidad de Grado
    public Dictionary<string, double> CentralidadGrado()
    {
        int n = adj.Count - 1;
        var resultado = new Dictionary<string, double>();
        foreach (var kvp in adj)
        {
            resultado[kvp.Key] = kvp.Value.Count / (double)n;
        }
        return resultado;
    }

    // Centralidad de Cercanía
    public Dictionary<string, double> CentralidadCercania()
    {
        var resultado = new Dictionary<string, double>();

        foreach (var nodo in adj.Keys)
        {
            var distancias = BFS(nodo);
            double suma = 0;
            foreach (var d in distancias.Values)
                suma += d;

            if (suma > 0)
                resultado[nodo] = (adj.Count - 1) / suma;
            else
                resultado[nodo] = 0;
        }

        return resultado;
    }

    // Centralidad de Intermediación (simplificada)
    public Dictionary<string, double> CentralidadIntermediacion()
    {
        var resultado = new Dictionary<string, double>();
        foreach (var nodo in adj.Keys)
            resultado[nodo] = 0.0;

        foreach (var s in adj.Keys)
        {
            foreach (var t in adj.Keys)
            {
                if (s == t) continue;
                var camino = BFS_CaminoMasCorto(s, t);
                if (camino.Count > 2)
                {
                    for (int i = 1; i < camino.Count - 1; i++)
                        resultado[camino[i]] += 1;
                }
            }
        }

        double factor = (adj.Count - 1) * (adj.Count - 2);
        var normalizado = new Dictionary<string, double>();
        foreach (var kvp in resultado)
            normalizado[kvp.Key] = kvp.Value / factor;

        return normalizado;
    }

    // BFS para distancias mínimas
    private Dictionary<string, int> BFS(string inicio)
    {
        var dist = new Dictionary<string, int>();
        foreach (var n in adj.Keys) dist[n] = int.MaxValue;

        Queue<string> cola = new Queue<string>();
        dist[inicio] = 0;
        cola.Enqueue(inicio);

        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            foreach (var vecino in adj[actual])
            {
                if (dist[vecino] == int.MaxValue)
                {
                    dist[vecino] = dist[actual] + 1;
                    cola.Enqueue(vecino);
                }
            }
        }
        return dist;
    }

    // BFS para obtener camino más corto
    private List<string> BFS_CaminoMasCorto(string inicio, string destino)
    {
        var predecesor = new Dictionary<string, string>();
        var visitados = new HashSet<string>();
        Queue<string> cola = new Queue<string>();

        cola.Enqueue(inicio);
        visitados.Add(inicio);

        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            if (actual == destino) break;

            foreach (var vecino in adj[actual])
            {
                if (!visitados.Contains(vecino))
                {
                    visitados.Add(vecino);
                    predecesor[vecino] = actual;
                    cola.Enqueue(vecino);
                }
            }
        }

        List<string> camino = new List<string>();
        if (!visitados.Contains(destino)) return camino;

        string nodo = destino;
        while (true)
        {
            camino.Insert(0, nodo);
            if (nodo == inicio) break;
            if (!predecesor.ContainsKey(nodo)) break;
            nodo = predecesor[nodo];
        }

        return camino;
    }

    // Reportería de nodos
    public List<string> ObtenerNodos()
    {
        return new List<string>(adj.Keys);
    }
}

class Program
{
    static void Main()
    {
        Grafo g = new Grafo();

        // Definir nodos y aristas
        g.AgregarArista("A", "B");
        g.AgregarArista("A", "C");
        g.AgregarArista("B", "D");
        g.AgregarArista("C", "D");
        g.AgregarArista("C", "E");
        g.AgregarArista("D", "E");
        g.AgregarArista("E", "F");

        // Mostrar resultados
        Console.WriteLine("=== Centralidad de Grado ===");
        foreach (var kvp in g.CentralidadGrado())
            Console.WriteLine($"Nodo {kvp.Key}: {kvp.Value:F4}");

        Console.WriteLine("\n=== Centralidad de Cercanía ===");
        foreach (var kvp in g.CentralidadCercania())
            Console.WriteLine($"Nodo {kvp.Key}: {kvp.Value:F4}");

        Console.WriteLine("\n=== Centralidad de Intermediación ===");
        foreach (var kvp in g.CentralidadIntermediacion())
            Console.WriteLine($"Nodo {kvp.Key}: {kvp.Value:F4}");

        Console.WriteLine("\n=== Reportería del Grafo ===");
        Console.WriteLine("Nodos: " + string.Join(", ", g.ObtenerNodos()));
    }
}
```





  