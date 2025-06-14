// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Teacher!");

// Autor: [Monica Zuñiga]
// Fecha: 08/06/2025
// Página: 1

using System;

namespace FigurasGeometricas
{
    // Clase Círculo
    public class Circulo
    {
        // Atributo privado que almacena el radio (tipo de dato primitivo double)
        private double radio;

        // Constructor
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área del círculo
        // CalcularArea es una función que devuelve un valor double. 
        // Se utiliza para calcular el área de un círculo, requiere como argumento el radio del círculo.
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro del círculo
        // CalcularPerimetro devuelve el perímetro (circunferencia) del círculo.
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectángulo
    public class Rectangulo
    {
        // Atributos privados que almacenan la base y la altura (tipo double)
        private double baseRectangulo;
        private double altura;

        // Constructor
        public Rectangulo(double baseRectangulo, double altura)
        {
            this.baseRectangulo = baseRectangulo;
            this.altura = altura;
        }

        // Método para calcular el área del rectángulo
        // CalcularArea devuelve un valor double que representa el área del rectángulo.
        public double CalcularArea()
        {
            return baseRectangulo * altura;
        }

        // Método para calcular el perímetro del rectángulo
        // CalcularPerimetro devuelve el perímetro del rectángulo.
        public double CalcularPerimetro()
        {
            return 2 * (baseRectangulo + altura);
        }
    }

    // Programa principal para probar las clases
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un objeto de la clase Circulo
            Circulo circulo = new Circulo(5.0);
            Console.WriteLine("Área del círculo: " + circulo.CalcularArea());
            Console.WriteLine("Perímetro del círculo: " + circulo.CalcularPerimetro());

            // Crear un objeto de la clase Rectangulo
            Rectangulo rectangulo = new Rectangulo(4.0, 6.0);
            Console.WriteLine("Área del rectángulo: " + rectangulo.CalcularArea());
            Console.WriteLine("Perímetro del rectángulo: " + rectangulo.CalcularPerimetro());
        }
    }
}
