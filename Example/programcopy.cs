using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DiarioMejorado
{
    class EntradaDiario
    {
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public List<string> Categorias { get; set; } // Nueva propiedad para categorías
    }

    class Programa
    {
        static List<EntradaDiario> entradasDiario = new List<EntradaDiario>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("Menú del Diario:");
                Console.WriteLine("1. Escribir una nueva entrada");
                Console.WriteLine("2. Mostrar todas las entradas");
                Console.WriteLine("3. Guardar el diario en un archivo CSV");
                Console.WriteLine("4. Cargar el diario desde un archivo CSV");
                Console.WriteLine("5. Salir");
                Console.Write("Ingrese su elección: ");
                string eleccion = Console.ReadLine();

                switch (eleccion)
                {
                    case "1":
                        EscribirNuevaEntrada();
                        break;
                    case "2":
                        MostrarTodasLasEntradas();
                        break;
                    case "3":
                        GuardarDiarioEnCsv();
                        break;
                    case "4":
                        CargarDiarioDesdeCsv();
                        break;
                    case "5":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                        break;
                }
            }
        }

        static void EscribirNuevaEntrada()
        {
            Console.Write("Ingrese su mensaje: ");
            string mensaje = Console.ReadLine();
            Console.Write("Ingrese las categorías (separadas por comas): ");
            string entradaCategorias = Console.ReadLine();
            List<string> categorias = entradaCategorias.Split(',').Select(c => c.Trim()).ToList();

            EntradaDiario entrada = new EntradaDiario
            {
                Mensaje = mensaje,
                Fecha = DateTime.Now,
                Categorias = categorias
            };
            entradasDiario.Add(entrada);
            Console.WriteLine("¡Entrada agregada exitosamente!");
        }

        static void MostrarTodasLasEntradas()
        {
            Console.WriteLine("Entradas del Diario:");
            foreach (var entrada in entradasDiario)
            {
                Console.WriteLine($"{entrada.Fecha}: {entrada.Mensaje} ({string.Join(", ", entrada.Categorias)})");
            }
        }

        static void GuardarDiarioEnCsv()
        {
            Console.Write("Ingrese un nombre de archivo para guardar el diario (sin extensión): ");
            string nombreArchivo = Console.ReadLine() + ".csv";
            using (StreamWriter escritor = new StreamWriter(nombreArchivo))
            {
                foreach (var entrada in entradasDiario)
                {
                    escritor.WriteLine($"{entrada.Fecha},{entrada.Mensaje},{string.Join("|", entrada.Categorias)}");
                }
            }
            Console.WriteLine($"Diario guardado en {nombreArchivo}.");
        }

        static void CargarDiarioDesdeCsv()
        {
            Console.Write("Ingrese el nombre del archivo para cargar el diario (con extensión .csv): ");
            string nombreArchivo = Console.ReadLine();
            if (File.Exists(nombreArchivo))
            {
                entradasDiario.Clear();
                using (StreamReader lector = new StreamReader(nombreArchivo))
                {
                    while (!lector.EndOfStream)
                    {
                        string linea = lector.ReadLine();
                        string[] partes = linea.Split(',');
                        if (partes.Length >= 2)
                        {
                            DateTime fecha;
                            if (DateTime.TryParse(partes[0], out fecha))
                            {
                                EntradaDiario entrada = new EntradaDiario
                                {
                                    Fecha = fecha,
                                    Mensaje = partes[1],
                                    Categorias = partes.Length > 2 ? partes[2].Split('|').ToList() : new List<string>()
                                };
                                entradasDiario.Add(entrada);
                            }
                        }
                    }
                }
                Console.WriteLine($"Diario cargado desde {nombreArchivo}.");
            }
            else
            {
                Console.WriteLine($"El archivo {nombreArchivo} no existe.");
            }
        }
    }
}
