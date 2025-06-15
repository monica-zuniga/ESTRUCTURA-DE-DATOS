using System;

namespace RegistroEstudiante
{
    class Estudiante
    {
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(string id, string nombres, string apellidos, string direccion, string[] telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefonos = telefonos;
        }

        public void MostrarInformacion()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombres: " + Nombres);
            Console.WriteLine("Apellidos: " + Apellidos);
            Console.WriteLine("Dirección: " + Direccion);
            Console.WriteLine("Teléfonos:");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                Console.WriteLine("- " + Telefonos[i]);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string[] telefonos = { "0994032403", "0939893835", "0994686794" };
            Estudiante estudiante = new Estudiante(
                "0605713742",
                "Mónica Maricela",
                "Zuñiga Muyolema",
                "Barrio José Mancero entre Juan de Dios Martínez y Ángel Martínez",
                telefonos
            );
            Console.WriteLine("=== REGISTRO DEL ESTUDIANTE ===");
            estudiante.MostrarInformacion();
        }
    }
}

