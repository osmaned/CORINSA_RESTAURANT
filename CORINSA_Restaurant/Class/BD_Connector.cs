using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace CORINSA_Restaurant
{
    public class BD_Connector
    {
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1; database=corinsa; Uid=root; pwd=superman2009;");
            connection.Open();
            return connection;      
        }
    }
}
