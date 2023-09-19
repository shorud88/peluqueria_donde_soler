using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ConsoleAppDAOMVCSingletonSolid
{
    public class EmpleadoDAOFactory
    {
        public static IEmpleadoDao CrearEmpleadoDAO()
        {
            using (MySqlConnection connection = Conexion.Instance.AbrirConexion())
            {
                return new EmpleadoDaoImpl(connection);
            }
        }
    }
}