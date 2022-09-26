using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace tallerconfiable53.Datos;
    public class Conexion
    {
        private string cadenaSQL = String.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }

