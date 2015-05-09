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
    public partial class CORINSA_ORDERS : Form
    {
        private int ProductSelected;
        public CORINSA_ORDERS()
        {
            InitializeComponent();
        }

        private void tbtBuscar_Click(object sender, EventArgs e)
        {
            if (txtAlias.Text != "")
                dgvProducts.DataSource = ProductsDAL.Search(txtAlias.Text);
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducts.RowCount > 0 && dgvProducts.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value);
                Product SelectedClient = ProductsDAL.GetProduct(id);
                this.ProductSelected = SelectedClient.Id;
            }
            else
            {
                MessageBox.Show("debe de seleccionar una fila");
                this.ProductSelected = 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
