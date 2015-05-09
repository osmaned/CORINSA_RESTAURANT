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
    public partial class CORINSA_PRODUCT_UPDATE : Form
    {
        private int ProductSelected = 0;
        
        public CORINSA_PRODUCT_UPDATE()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtAlias.Clear();
            txtDescription.Clear();
            txtPrice.Clear();

            dgvProducts.DataSource = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(txtAlias.Text!="")
                dgvProducts.DataSource = ProductsDAL.Search(txtAlias.Text);
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.RowCount > 0 && dgvProducts.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                Product SelectedClient = ProductsDAL.GetProduct(id);

                txtName.Text = SelectedClient.Name.ToString();
                txtAlias.Text = SelectedClient.Alias.ToString();
                txtDescription.Text = SelectedClient.Description.ToString();
                txtPrice.Text = SelectedClient.Price.ToString();
                this.ProductSelected = SelectedClient.Id;
            }
            else
            {
                MessageBox.Show("debe de seleccionar una fila");
                this.ProductSelected = 0;
            }
        }

        private void ss(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ProductSelected != 0)
            {
                Product pProduct = new Product();

                pProduct.Name = txtName.Text.Trim();
                pProduct.Alias = txtAlias.Text.Trim();
                pProduct.Description = txtDescription.Text.Trim();
                pProduct.Price = Convert.ToDecimal(txtPrice.Text);
                pProduct.Id = ProductSelected;
                if (ProductsDAL.Update(pProduct) > 0)
                {
                    MessageBox.Show("Los datos del Product se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar", "Error al Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.ProductSelected != 0)
            {
                Product pProduct = new Product();

                pProduct.Name = txtName.Text.Trim();
                pProduct.Alias = txtAlias.Text.Trim();
                pProduct.Description = txtDescription.Text.Trim();
                pProduct.Price = Convert.ToDecimal(txtPrice.Text);
                pProduct.Id = ProductSelected;
                if (ProductsDAL.Delete(pProduct) > 0)
                {
                    MessageBox.Show("Los datos del Producto se eliminaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }
    }
}
