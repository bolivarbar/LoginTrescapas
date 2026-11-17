using Microsoft.Data.SqlClient;
using LoginTresCapas.Models;
namespace LoginTresCapas.Datos
{
    public class UsuarioDao
    {
        private readonly Conexion _conexion;
        public UsuarioDao(Conexion conexion)
        {
            _conexion = conexion;
        }
        public Usuario? ObtenerPorNombre(string nombreUsuario)
        {
            string sql = "SELECT IdUsuarios, NombreUsuario, clave, rol, activo" +
                "FROM usuarios WHQRE NombreUsuario =@nombre";
            using (SqlConnection cn = _conexion.Obtener())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                cmd.Parameters.AddWithValue("@nombre", nombreUsuario);
                cn.Open();

                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    if (!lector.Read())
                    {
                        return null;
                    }
                    return new Usuario
                    {
                        IdUsuarios = lector.GetInt32(0),
                        Nombreusuario = lector.GetString(1),
                        Clave = lector.GetString(2),
                        Rol = lector.GetString(3),
                        Activo = lector.GetBoolean(4)
                    };

                }
            }
        }
    }
}
