using System;
using System.Collections.Generic;


namespace ConsoleAppDAOMVCSingletonSolid
{
    public class EmpleadoController
    {
        private EmpleadoService empleadoService;
        private EmpleadoView vista;

        public EmpleadoController(EmpleadoService empleadoService, EmpleadoView vista)
        {
            this.empleadoService = empleadoService ?? throw new ArgumentNullException(nameof(empleadoService));
            this.vista = vista ?? throw new ArgumentNullException(nameof(vista));
        }

        public void ListarEmpleados()
        {
            try
            {
                List<Empleado> empleados = empleadoService.ObtenerEmpleados();
                vista.MostrarEmpleados(empleados);
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error al listar clientes: " + e.Message);
            }
        }

        public void VerEmpleado(int id)
        {
            try
            {
                Empleado parqueadero = empleadoService.ObtenerEmpleadoPorId(id);

                if (parqueadero != null)
                {
                    vista.MostrarEmpleado(parqueadero);
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún cliente con el ID {id}.");
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error al obtener el cliente: " + e.Message);
            }
        }

        public void RegistrarEmpleado(Empleado parqueadero)
        {
            try
            {
                if (empleadoService.RegistrarEmpleado(parqueadero))
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine("--> Registro exitoso: " + parqueadero.id);
                    vista.MostrarEmpleado(parqueadero);
                }
                else
                {
                    Console.WriteLine("Error al registrar el cliente.");
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error al registrar el cliente: " + e.Message);
            }
        }

        // los cambios q se colocaron en el Program
        //id, nuevoNombre, nuevoApellido, nuevaCedula, nuevoDuracion_meses, nuevaFecha, nuevoPrecio_mensual
        public void ActualizarEmpleado(int id, string nuevoNombre, string nuevoApellido, int nuevaCedula, int nuevoDuracion_meses, DateTime nuevaFecha, double nuevoPrecio_mensual)
        {
            try
            {
                Empleado empleadoExistente = empleadoService.ObtenerEmpleadoPorId(id);

                if (empleadoExistente != null)
                {
                    Console.WriteLine("------------Datos originales------------");
                    Console.WriteLine(empleadoExistente);


                    empleadoExistente.nombre = nuevoNombre;
                    empleadoExistente.apellido = nuevoApellido;
                    empleadoExistente.cedula = nuevaCedula;
                    empleadoExistente.duracion_meses = nuevoDuracion_meses;
                    empleadoExistente.fecha = nuevaFecha;
                    empleadoExistente.precio_mensual = nuevoPrecio_mensual;
                    

                    if (empleadoService.ActualizarEmpleado(empleadoExistente))
                    {
                        Console.WriteLine("--> Actualización exitosa");
                    }
                    else
                    {
                        Console.WriteLine("Error al actualizar el empleado.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún empleado con el ID {id}.");
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error al actualizar el empleado: " + e.Message);
            }
        }

        public void EliminarEmpleado(int id)
        {
            try
            {
                Empleado empleadoAEliminar = empleadoService.ObtenerEmpleadoPorId(id);

                if (empleadoAEliminar != null)
                {
                    if (empleadoService.EliminarEmpleado(id))
                    {
                        Console.WriteLine("Empleado eliminado: " + empleadoAEliminar.id);
                    }
                    else
                    {
                        Console.WriteLine("Error al eliminar el empleado.");
                    }
                }
                else
                {
                    Console.WriteLine($"No se encontró ningún empleado con el ID {id}.");
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine("Error al eliminar el empleado: " + e.Message);
            }
        }

      
    }
}
