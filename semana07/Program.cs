class BalanceoSimbolos
{
    public static bool EstaBalanceado(string expresion)
    {
        Stack<char> pila = new Stack<char>();

        foreach (char c in expresion)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (pila.Count == 0) return false;

                char top = pila.Pop();
                if (!Coinciden(top, c))
                    return false;
            }
        }

        return pila.Count == 0;
    }

    private static bool Coinciden(char abierto, char cerrado)
    {
        return (abierto == '(' && cerrado == ')') ||
               (abierto == '{' && cerrado == '}') ||
               (abierto == '[' && cerrado == ']');
    }

    static void Main()
    {
        string entrada = "{7 * (8 + 5) * [(9 - 7) + (4 + 11)]}";
        Console.WriteLine("Expresión: " + entrada);

        if (EstaBalanceado(entrada))
            Console.WriteLine("Fórmula balanceada.");
        else
            Console.WriteLine("Fórmula NO balanceada.");
    }
}



