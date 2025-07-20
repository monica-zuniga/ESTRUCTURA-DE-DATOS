
namespace ParqueDiversiones
{
    class Persona
    {
        public string Nombre { get; set; }

        public Persona(string nombre)
        {
            Nombre = nombre;
        }
    }

    class Atraccion
    {
        private Queue<Persona> colaEspera = new Queue<Persona>();
        private int capacidadMaxima = 30;

        public void AgregarPersona(string nombre)
        {
            if (colaEspera.Count < capacidadMaxima)
            {
                colaEspera.Enqueue(new Persona(nombre));
                Console.WriteLine($"{nombre} ha sido agregado a la fila.");
            }
            else
            {
                Console.WriteLine("La atracción ya está llena. No se pueden agregar más personas.");
            }
        }

        public void MostrarCola()
        {
            Console.WriteLine("\nPersonas en la cola:");
            foreach (var persona in colaEspera)
            {
                Console.WriteLine($"- {persona.Nombre}");
            }
        }

        public void IniciarAtraccion()
        {
            Console.WriteLine("\nIniciando la atracción...");
            int asiento = 1;
            while (colaEspera.Count > 0)
            {
                Persona p = colaEspera.Dequeue();
                Console.WriteLine($"Asiento {asiento++}: {p.Nombre}");
            }
            Console.WriteLine("Todos los asientos han sido ocupados.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion();

            while (true)
            {
                Console.Write("\nIngrese el nombre de la persona (o 'iniciar' para comenzar la atracción): ");
                string entrada = Console.ReadLine();

                if (entrada.ToLower() == "iniciar")
                {
                    atraccion.MostrarCola();
                    atraccion.IniciarAtraccion();
                    break;
                }
                else
                {
                    atraccion.AgregarPersona(entrada);
                }
            }

            Console.WriteLine("Fin del programa.");
        }
    }
}

