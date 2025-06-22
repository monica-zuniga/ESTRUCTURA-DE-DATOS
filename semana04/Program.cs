// Programa: Agenda de Turnos para Pacientes de una Clínica
// Autor: Mónica Zúñiga
// Descripción: Sistema en C# para registrar y consultar turnos médicos

using System;
using System.Collections.Generic;

namespace AgendaTurnosClinica
{
    // Estructura para el paciente
    struct Paciente
    {
        public string Cedula;
        public string Nombre;
        public string Telefono;
    }

    // Clase que representa el turno
    class Turno
    {
        public Paciente paciente;
        public DateTime FechaHora;

        public void MostrarInfo()
        {
            Console.WriteLine($"Cédula: {paciente.Cedula} | Nombre: {paciente.Nombre} | Teléfono: {paciente.Telefono} | Turno: {FechaHora:dddd, dd 'de' MMMM 'del' yyyy HH:mm}");
        }
    }

    class Program
    {
        static List<Turno> listaTurnos = new List<Turno>();

        static void Main(string[] args)
        {
            // Cargar turnos con datos dados
            listaTurnos.Add(new Turno
            {
                paciente = new Paciente { Cedula = "0657348495", Nombre = "Erick Guananga Zúñiga", Telefono = "0994959599" },
                FechaHora = new DateTime(2025, 6, 24, 8, 0, 0)
            });

            listaTurnos.Add(new Turno
            {
                paciente = new Paciente { Cedula = "0395738126", Nombre = "Oztin Guananga Zúñiga", Telefono = "0949495939" },
                FechaHora = new DateTime(2025, 6, 24, 9, 0, 0)
            });

            listaTurnos.Add(new Turno
            {
                paciente = new Paciente { Cedula = "0495828385", Nombre = "Maicol Guananga Wisum", Telefono = "0990394040" },
                FechaHora = new DateTime(2025, 6, 24, 10, 0, 0)
            });

            listaTurnos.Add(new Turno
            {
                paciente = new Paciente { Cedula = "0948284986", Nombre = "Mónica Zúñiga Muyolema", Telefono = "0973618381" },
                FechaHora = new DateTime(2025, 6, 24, 11, 0, 0)
            });

            // Menú principal
            int opcion;
            do
            {
                Console.WriteLine("\n=== Agenda de Turnos de Pacientes ===");
                Console.WriteLine("1. Ver turnos agendados");
                Console.WriteLine("2. Buscar turno por cédula");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                if (!int.TryParse(Console.ReadLine(), out opcion)) opcion = 0;

                switch (opcion)
                {
                    case 1:
                        VerTurnos();
                        break;
                    case 2:
                        BuscarTurno();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 3);
        }

        // Mostrar todos los turnos
        static void VerTurnos()
        {
            Console.WriteLine("\n--- Lista de Turnos ---");
            foreach (var turno in listaTurnos)
            {
                turno.MostrarInfo();
            }
        }

        // Buscar turno por cédula
        static void BuscarTurno()
        {
            Console.Write("Ingrese la cédula a buscar: ");
            string cedula = Console.ReadLine();
            bool encontrado = false;

            foreach (var turno in listaTurnos)
            {
                if (turno.paciente.Cedula == cedula)
                {
                    turno.MostrarInfo();
                    encontrado = true;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("No se encontró un turno con esa cédula.");
            }
        }
    }
}
