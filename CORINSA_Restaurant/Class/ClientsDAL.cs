using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CORINSA_Restaurant
{
    public class ClientsDAL
    {
        public static int Add(Clients pClient)
        {

            int count = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into corinsa_clients (client_name, client_email, client_cellphone, client_address) values ('{0}','{1}','{2}', '{3}')",
                pClient.Name, pClient.Email, pClient.Telephone, pClient.Address), BD_Connector.GetConnection());
            count = comando.ExecuteNonQuery();
            return count;
        }

        public static List<Clients> Search(string pName)
        {
            List<Clients> _lista = new List<Clients>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "select idcorinsa_clients, client_name, client_email, client_cellphone, client_address FROM corinsa_clients  where client_name like'%{0}%'", pName), BD_Connector.GetConnection());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Clients pClients = new Clients();
                pClients.Id = _reader.GetInt32(0);
                pClients.Name = _reader.GetString(1);
                pClients.Email = _reader.GetString(2);
                pClients.Telephone = _reader.GetString(3);
                pClients.Address = _reader.GetString(4);


                _lista.Add(pClients);
            }

            return _lista;
        }

        public static Clients GetClient(int pId)
        {
            Clients pClient = new Clients();
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand _comando = new MySqlCommand(String.Format("select idcorinsa_clients, client_name, client_email, client_cellphone, client_address FROM corinsa_clients  where idcorinsa_clients={0}", pId), connetion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pClient.Id = _reader.GetInt32(0);
                pClient.Name = _reader.GetString(1);
                pClient.Email = _reader.GetString(2);
                pClient.Telephone = _reader.GetString(3);
                pClient.Address = _reader.GetString(4);

            }

            connetion.Close();
            return pClient;

        }

        public static int Update(Clients pClient)
        {
            int counter = 0;
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand comando = new MySqlCommand(string.Format("Update corinsa_clients set client_name='{0}', client_email='{1}', client_cellphone='{2}',client_address='{3}' where idcorinsa_clients={4}",
                pClient.Name, pClient.Email, pClient.Telephone, pClient.Address, pClient.Id), connetion);

            counter = comando.ExecuteNonQuery();
            connetion.Close();

            return counter;


        }

        public static int Delete(Clients pClient)
        {
            int counter = 0;
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand comando = new MySqlCommand(string.Format("delete from corinsa_clients where idcorinsa_clients={0}",
                pClient.Id), connetion);

            counter = comando.ExecuteNonQuery();
            connetion.Close();

            return counter;
        }
    }
}
