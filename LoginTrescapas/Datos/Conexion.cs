//trae la herramienta para hablar con sql server
//no sirve si no se instla la extesion primero
using Microsoft.Data.SqlClient;
//trae la herramienta para leer el archivo de configuracion osea direccion de sql server
// appsettings.json
using Microsoft.Extensions.Configuration;

namespace LoginTresCapas.Datos
{
    public class Conexion
    {
        private readonly string _cadena;

        public Conexion(IConfiguration configuracion)
        {
            _cadena = configuracion.GetConnectionString("LoginDB")
                ?? throw new InvalidOperationException(
                    "No se encontro la conexion LoginDB");
        }
        public SqlConnection Obtener()
        {
            return new SqlConnection(_cadena);
        }
    }
}