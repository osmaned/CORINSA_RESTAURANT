using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CORINSA_Restaurant
{
    public partial class CORINSA_PRODUCTS : Form
    {
        public CORINSA_PRODUCTS()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtAlias.Text != "" && txtPrice.Text != "")
            {
                Product pProduct = new Product();
                pProduct.Name = txtName.Text.Trim();
                pProduct.Alias = txtAlias.Text.Trim();
                pProduct.Description = txtDescription.Text.Trim();
                pProduct.Price = Convert.ToDecimal(txtPrice.Text);

                int resultado = ProductsDAL.Add(pProduct);
                if (resultado > 0)
                {
                    MessageBox.Show("Producto Guardado Con Exito!!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button3_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el Producto", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("Se requieren datos obligatorios", "Fallo!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAlias.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
        }

        private void CORINSA_PRODUCTS_Load(object sender, EventArgs e)
        {

        }
    }
}
