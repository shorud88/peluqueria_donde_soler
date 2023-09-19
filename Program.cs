using System;
using System.Globalization;

namespace ConsoleAppDAOMVCSingletonSolid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string action;
            int id;

            IEmpleadoDao dao = EmpleadoDAOFactory.CrearEmpleadoDAO();
            EmpleadoView vista = new EmpleadoView();
            EmpleadoService empleadoService = new EmpleadoService(dao);
            EmpleadoController controller = new EmpleadoController(empleadoService, vista);

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("         ////////////////////");
                Console.WriteLine("         CITY PARKING PENAGOS\n");
                Console.WriteLine("\nPor favor digite el numero de la opción deseada:\n");
                Console.WriteLine("[1] Lista clientes\n[2] Ingresar Nuevo\n[3] Actualizar\n[4] Eliminar\n[5] Total ingresos \n[6] Ayuda: \n[7] Salir del programa ");

                action = Console.ReadLine()?.ToUpper();

                if (!string.IsNullOrEmpty(action))
                {
                    try
                    {
                        switch (action)
                        {
                            case "1":
                                controller.ListarEmpleados();
                                break;
                            case "2":
                                Empleado nuevoEmpleado = InputEmpleado();
                                controller.RegistrarEmpleado(nuevoEmpleado);
                                break;
                            case "3":
                                id = InputId();
                                Console.WriteLine("-------------------");
                                controller.VerEmpleado(id);
                                Console.WriteLine("------------Datos originales------------");
                                Console.WriteLine("parqueadero");
                                Console.WriteLine("Ingrese los nuevos datos");

                                string nuevoNombre = InputNombre();
                                string nuevoApellido = InputApellido();
                                int nuevaCedula = InputCedula();
                                int nuevoDuracion_meses = InputDuracionMeses();
                                DateTime nuevaFecha = InputFecha();
                                double nuevoPrecio_mensual = InputPrecioMensual();

                                controller.ActualizarEmpleado(id, nuevoNombre, nuevoApellido, nuevaCedula, nuevoDuracion_meses, nuevaFecha, nuevoPrecio_mensual);
                                controller.VerEmpleado(id);
                                break;
                            case "4":
                                id = InputId();
                                controller.EliminarEmpleado(id);
                                break;
                            
                            case "5":
                                ingresosEstadistica(dao);
                                break;

                            case "6":
                                MostrarAyuda();
                                break;
                            case "7":
                                return;


                            default:
                                Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                                break;
                        }
                    }
                    catch (DAOException e)
                    {
                        Console.WriteLine("Error: " + e.Message);
                    }
                }
            }
        }

        private static void MostrarAyuda()
        {
            Console.WriteLine("****MENU DE AYUDA*****\n");
            Console.WriteLine("Opciones disponibles:\n");
            Console.WriteLine("[1] Listar:          Muestra la lista de clientes activos.");
            Console.WriteLine("[2] Ingresar nuevo:  Registra un nuevo cliente.");
            Console.WriteLine("[3] Actualizar:      Actualiza la informacion de un cliente existente.");
            Console.WriteLine("[4] Eliminar:        Elimina un cliente.");
            Console.WriteLine("[5] Total Ingresos:  Muestra el total de ingresos mensual y neto");
            Console.WriteLine("[6] Ayuda:           Muestra a detalle cada opcion.");
            Console.WriteLine("[7] Salir:           Sale del programa.\n");
        }

        
        private static Empleado InputEmpleado()
        {
            int id = 0; // Asigna un valor por defecto al id, ya que no se proporciona en la entrada.
            string nombre = InputNombre();
            string apellido = InputApellido();
            int cedula = InputCedula();
            int duracion_meses = InputDuracionMeses();
            DateTime fecha = InputFecha();
            double precio_mensual = InputPrecioMensual();

            return new Empleado(id, nombre, apellido, cedula, duracion_meses, fecha, precio_mensual);
        }


        private static int InputId()
        {
            int id;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese un valor entero para el ID del empleado: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error de formato de número");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato de número");
                }
            }
            return id;
        }
        // paso los input de nombre, apellido y cedula

        private static string InputNombre()
        {
            return InputString("Ingrese el nombre del cliente: ");
        }
        private static string InputApellido()
        {
            return InputString("Ingrese el apellido del cliente: ");
        }
        private static int InputCedula()
        {
            int cedula;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el número de cédula del cliente: ");
                    if (int.TryParse(Console.ReadLine(), out cedula))
                    {
                        return cedula;
                    }
                    else
                    {
                        Console.WriteLine("Error: Ingrese un número válido de cédula.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Formato de número incorrecto.");
                }
            }
        }


        private static string InputString(string message)
        {
            string s;
            while (true)
            {
                Console.WriteLine(message);
                s = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(s) && s.Length >= 2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("La longitud de la cadena debe ser >= 2");
                }
            }
            return s;
        }


        private static int InputDuracionMeses()
        {
            int duracion_meses;
            while (true)
            {
                try
                {
                    Console.WriteLine("Ingrese el número de meses a pagar: ");
                    if (int.TryParse(Console.ReadLine(), out duracion_meses))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error de formato de número: ");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error del formato de número: ");
                }
            }
            return duracion_meses;
        }
        
        private static DateTime InputFecha()
        {
            DateTime fecha;
            bool entradaValida = false;

            do
            {
                Console.WriteLine("Ingrese la fecha de inicio de la inscripcion: (Formato: dd/mm/yyyy): ");
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Asegúrese de ingresar la fecha en el formato correcto (dd/mm/yyyy).");
                }
            } while (!entradaValida);

            return fecha;
        }
        private static double InputPrecioMensual()
        {
            double precio;
            bool entradaValida = false;

            do
            {
                Console.WriteLine("Ingrese el precio mensual: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out precio))
                {
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Debe ingresar un valor numérico.");
                }
            } while (!entradaValida);

            return precio;
        }
        private static double InputDouble(string message)
        {
            double value;
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    if (double.TryParse(Console.ReadLine(), out value))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Error de formato de número");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error de formato de número");
                }
            }
            return value;
        }

       
        private static void ingresosEstadistica(IEmpleadoDao dao)
        {
            try
            {
                Console.WriteLine("INFORME DE INGRESOS");
                Console.WriteLine("-------------------");
                double ingresosMensuales = dao.CalcularIngresosMensuales();
                double ingresosTotales = dao.CalcularIngresosTotales();

                Console.WriteLine("Ingreso total del mes: = $" + ingresosMensuales);
                Console.WriteLine("Ingreso del mes actual, mas los meses pagos por adelantado");
                Console.WriteLine("                 " +
                    "NETO: = $" + ingresosTotales);
                Console.WriteLine("------------------");
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al calcular las estadísticas: " + e.Message);
            }
        }

    }
}
