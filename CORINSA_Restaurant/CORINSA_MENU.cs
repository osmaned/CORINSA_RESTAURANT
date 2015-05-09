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
    public partial class CORINSA_MENU : Form
    {
        public CORINSA_MENU()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mantenimientoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CORINSA_PRODUCTS form = new CORINSA_PRODUCTS();
            form.Show();
        }

        private void CORINSA_MENU_Load(object sender, EventArgs e)
        {
           
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CORINSA_CLIENTS form = new CORINSA_CLIENTS();
            form.Show();
        }

        private void mantenimientoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CORINSA_PRODUCT_UPDATE form = new CORINSA_PRODUCT_UPDATE();
            form.Show();
        }

        private void mantenimientoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CORINSA_CLIENT_UPDATE form = new CORINSA_CLIENT_UPDATE();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void nuevoPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CORINSA_ORDERS form = new CORINSA_ORDERS();
            form.Show();
        }
    }
}
