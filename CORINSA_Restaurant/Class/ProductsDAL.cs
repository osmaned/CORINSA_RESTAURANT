using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CORINSA_Restaurant
{
    public class ProductsDAL
    {
        public static int Add(Product pProduct)
        {

            int count = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into corinsa_products (product_name, product_description, product_alias, product_price) values ('{0}','{1}','{2}', '{3}')",
                pProduct.Name, pProduct.Description, pProduct.Alias, pProduct.Price), BD_Connector.GetConnection());
            count = comando.ExecuteNonQuery();
            return count;
        }

        public static List<Product> Search(string pName)
        {
            List<Product> _lista = new List<Product>();

            MySqlCommand _comando = new MySqlCommand(String.Format(
            "select idcorinsa_products, product_alias, product_name, product_description, product_price FROM corinsa_products  where product_alias like '{0}%'", pName), BD_Connector.GetConnection());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                Product pProduct = new Product();
                pProduct.Id = _reader.GetInt32(0);
                pProduct.Alias = _reader.GetString(1);
                pProduct.Name = _reader.GetString(2);
                pProduct.Description = _reader.GetString(3);
                pProduct.Price = Convert.ToDecimal(_reader.GetString(4));


                _lista.Add(pProduct);
            }

            return _lista;
        }

        public static Product GetProduct(int pId)
        {
            Product pProduct = new Product();
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand _comando = new MySqlCommand(String.Format("select idcorinsa_products, product_alias, product_name, product_description, product_price FROM corinsa_products  where idcorinsa_products={0}", pId), connetion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pProduct.Id = _reader.GetInt32(0);
                pProduct.Alias = _reader.GetString(1);
                pProduct.Name = _reader.GetString(2);
                pProduct.Description = _reader.GetString(3);
                pProduct.Price = Convert.ToDecimal(_reader.GetString(4));

            }

            connetion.Close();
            return pProduct;

        }

        public static int Update(Product pProduct)
        {
            int counter = 0;
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand comando = new MySqlCommand(string.Format("Update corinsa_products set product_name='{0}', product_description='{1}', product_price='{2}', product_alias='{3}' where idcorinsa_products={4}",
                pProduct.Name, pProduct.Description, pProduct.Price, pProduct.Alias, pProduct.Id), connetion);

            counter = comando.ExecuteNonQuery();
            connetion.Close();

            return counter;


        }

        public static int Delete(Product pProduct)
        {
            int counter = 0;
            MySqlConnection connetion = BD_Connector.GetConnection();

            MySqlCommand comando = new MySqlCommand(string.Format("delete from corinsa_products where idcorinsa_products={0}",
                pProduct.Id), connetion);

            counter = comando.ExecuteNonQuery();
            connetion.Close();

            return counter;
        }
    }
}
