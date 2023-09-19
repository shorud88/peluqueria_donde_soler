using System;
using System.Collections.Generic;


namespace ConsoleAppDAOMVCSingletonSolid
{
    public class EmpleadoService
    {
        private IEmpleadoDao dao;

        public EmpleadoService(IEmpleadoDao dao)
        {
            this.dao = dao ?? throw new ArgumentNullException(nameof(dao));
        }

        public bool RegistrarEmpleado(Empleado parqueadero)
        {
            try
            {
                return dao.RegistrarEmpleado(parqueadero);
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al registrar el cliente: " + e.Message);
                return false;
            }
        }

        public bool ActualizarEmpleado(Empleado parqueadero)
        {
            try
            {
                return dao.ActualizarEmpleado(parqueadero);
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al actualizar el cliente: " + e.Message);
                return false;
            }
        }

        public bool EliminarEmpleado(int id)
        {
            try
            {
                return dao.EliminarEmpleado(id);
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al eliminar el cliente: " + e.Message);
                return false;
            }
        }

        public List<Empleado> ObtenerEmpleados()
        {
            try
            {
                return dao.ObtenerEmpleados();
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al obtener los clientes: " + e.Message);
                return new List<Empleado>();
            }
        }

        public Empleado ObtenerEmpleadoPorId(int id)
        {
            try
            {
                return dao.ObtenerEmpleadoPorId(id);
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al obtener el cliente por ID: " + e.Message);
                return null;
            }
        }

        // Calcular los porcentajes
        
        //public void VerEstadisticas()
        public void ingresosEstadistica()
        {
            try
            {
                double ingresosMensuales = dao.CalcularIngresosMensuales();
                double ingresosTotales = dao.CalcularIngresosTotales();

                Console.WriteLine("Ingreso total por mes: = $" + ingresosMensuales);
                Console.WriteLine("Ingreso del mes actual mas los meses pagos por adelantado");
                Console.WriteLine("NETO: = $" + ingresosTotales);
            }
            catch (DAOException e)
            {
                Console.WriteLine("Error al calcular las estadísticas: " + e.Message);
            }
        }
    }
}
