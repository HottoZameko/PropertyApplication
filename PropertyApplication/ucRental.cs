using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
namespace PropertyApplication
{
    public partial class ucRental : UserControl
    {
        public ucRental()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Rentals rental = new Rentals();

            rental.PropertyAgentID = int.Parse(cmbPropertyAgent.SelectedValue.ToString());
            rental.TenantID = int.Parse(cmbTenant.SelectedValue.ToString());
            rental.StartDate = dtpStart.Value.ToString();
            rental.EndDate = dtpStart.Value.ToString();

            int x = bll.InsertRentals(rental);

            if (x > 0)
            {
                MessageBox.Show(x + " Added.");

            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvRental.DataSource = bll.GetRentals();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Rentals rental = new Rentals();

                rental.RentalID = int.Parse(txtID.Text);
                rental.StartDate = dtpStart.Value.ToString();
                rental.EndDate = dtpEnd.Value.ToString();

                int x = bll.UpdateRentals(rental);

                if (x > 0)
                {
                    MessageBox.Show(x + " Updated!");
                    dgvRental.DataSource = bll.GetRentals();
                }
            }catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
        }

        private void dgvRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRental.SelectedRows.Count > 0)
            {
                txtID.Text = dgvRental.SelectedRows[0].Cells["RentalID "].Value.ToString();
                cmbPropertyAgent.Text = dgvRental.SelectedRows[0].Cells["PropertyAgentID"].Value.ToString();
                cmbTenant.Text = dgvRental.SelectedRows[0].Cells["TenantID"].Value.ToString();
                dtpStart.Text = dgvRental.SelectedRows[0].Cells["StartDate"].Value.ToString();
                dtpEnd.Text = dgvRental.SelectedRows[0].Cells["EndDate"].Value.ToString();
            }
        }

        private void ucRental_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            LoadPropAgen();
            LoadT();
           
        }
        public void LoadPropAgen()
        {
            cmbPropertyAgent.DataSource = bll.GetPropertyAgent();
            cmbPropertyAgent.DisplayMember = "PropertyAgentID";
            cmbPropertyAgent.ValueMember = "PropertyAgentID";
        }
        public void LoadT()
        {
            cmbTenant.DataSource = bll.GetTenant();
            cmbTenant.DisplayMember = "Name";
            cmbTenant.ValueMember = "TenantID";
        }
    }
}
