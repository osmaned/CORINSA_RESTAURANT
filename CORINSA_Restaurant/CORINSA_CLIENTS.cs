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
    public partial class CORINSA_CLIENTS : Form
    {
        public CORINSA_CLIENTS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                Clients pClient = new Clients();
                pClient.Name = txtName.Text.Trim();
                pClient.Email = txtEmail.Text.Trim();
                pClient.Telephone = txtTelephone.Text.Trim();
                pClient.Address = txtAddress.Text;

                int resultado = ClientsDAL.Add(pClient);
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
            txtEmail.Clear();
            txtTelephone.Clear();
            txtAddress.Clear();
        }
    }
}
