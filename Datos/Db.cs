using System.Configuration;
using System.Data.SqlClient;

namespace Datos
{
    public class Db
    {
        public static SqlConnection GetConnection()
        {
            string cn = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
            return new SqlConnection(cn);
        }
    }
}
