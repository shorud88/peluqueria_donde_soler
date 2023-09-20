using System;
using System.Collections.Generic;


namespace ConsoleAppDAOMVCSingletonSolid
{
    public class EmpleadoView
    {
        public void MostrarEmpleado(Empleado peluqueria)
        {
            Console.WriteLine("Datos del Cliente:\n" + peluqueria.ToString());
        }

        public void MostrarEmpleados(List<Empleado> empleados)
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay clientes para mostrar.");
                return;
            }

            Console.WriteLine("Lista de Empleados:");
            foreach (Empleado peluqueria in empleados)
            {
                Console.WriteLine("------------");
                Console.WriteLine(peluqueria.ToString());
            }
        }
    }
}
