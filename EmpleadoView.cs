using System;
using System.Collections.Generic;


namespace ConsoleAppDAOMVCSingletonSolid
{
    public class EmpleadoView
    {
        public void MostrarEmpleado(Empleado parqueadero)
        {
            Console.WriteLine("Datos del Cliente:\n" + parqueadero.ToString());
        }

        public void MostrarEmpleados(List<Empleado> empleados)
        {
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay clientes para mostrar.");
                return;
            }

            Console.WriteLine("Lista de Empleados:");
            foreach (Empleado parqueadero in empleados)
            {
                Console.WriteLine("------------");
                Console.WriteLine(parqueadero.ToString());
            }
        }
    }
}
