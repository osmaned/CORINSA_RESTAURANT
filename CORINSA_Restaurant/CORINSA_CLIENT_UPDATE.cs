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
    public partial class CORINSA_CLIENT_UPDATE : Form
    {
        private int ClientSelected = 0;
        
        public CORINSA_CLIENT_UPDATE()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
                dgvClient.DataSource = ClientsDAL.Search(txtName.Text);
        }

        private void dgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClient.RowCount > 0 && dgvClient.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvClient.CurrentRow.Cells[0].Value);
                Clients SelectedClient = ClientsDAL.GetClient(id);

                txtName.Text = SelectedClient.Name.ToString();
                txtEmail.Text = SelectedClient.Email.ToString();
                txtTelephone.Text = SelectedClient.Telephone.ToString();
                txtAddress.Text = SelectedClient.Address.ToString();
                this.ClientSelected = SelectedClient.Id;
            }
            else
            {
                MessageBox.Show("debe de seleccionar una fila");
                this.ClientSelected = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ClientSelected != 0)
            {
                Clients pClient = new Clients();

                pClient.Name = txtName.Text.Trim();
                pClient.Email = txtEmail.Text.Trim();
                pClient.Telephone = txtTelephone.Text.Trim();
                pClient.Address = (txtAddress.Text);
                pClient.Id = ClientSelected;
                if (ClientsDAL.Update(pClient) > 0)
                {
                    MessageBox.Show("Los datos del Cliente se actualizaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.ClientSelected != 0)
            {
                Clients pClient = new Clients();

                pClient.Name = txtName.Text.Trim();
                pClient.Email = txtEmail.Text.Trim();
                pClient.Telephone = txtTelephone.Text.Trim();
                pClient.Address = (txtAddress.Text);
                pClient.Id = ClientSelected;
                if (ClientsDAL.Delete(pClient) > 0)
                {
                    MessageBox.Show("Los datos del Cliente se eliminaron", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar", "Error al Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtEmail.Clear();
            txtTelephone.Clear();
            txtAddress.Clear();

            dgvClient.DataSource = null;
        }
    }
}
