using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PropertyApplication
{
    public partial class ucAgencies : UserControl
    {
        public ucAgencies()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Agencies agencies = new Agencies();


            if (string.IsNullOrEmpty(txtName.Text))
            {
                errAgencies.SetError(txtName, "Please enter Name");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {

                agencies.AgencyName = txtName.Text;
                agencies.SurbubID = int.Parse(cmbSuburb.SelectedValue.ToString());

                int x = bll.InsertAgencies(agencies);

                if (x > 0)
                {
                    MessageBox.Show(x + " Agency Has been added!");
                    errAgencies.Clear();
                    txtName.Clear();
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvAgency.DataSource = bll.GetAgencies();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Agencies agencies = new Agencies();

                agencies.AgencyID = int.Parse(txtID.Text);

                int x = bll.DeleteAgencies(agencies);

                if (x > 0)
                {
                    MessageBox.Show("Has been DELETED");

                    dgvAgency.DataSource = bll.GetAgencies();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("You cannot Delete this data, select the unused data.");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
        }

        private void ucAgencies_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;

        }
        public void LoadS()
        {
            cmbSuburb.DataSource = bll.GetSuburbs();
            cmbSuburb.DisplayMember = "SurbubDescription";
            cmbSuburb.ValueMember = "SurbubID";
        }

        private void dgvAgency_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgency.SelectedRows.Count > 0)
            {
                txtID.Text = dgvAgency.SelectedRows[0].Cells["AgencyID"].Value.ToString();
                txtName.Text = dgvAgency.SelectedRows[0].Cells["AgencyName"].Value.ToString();
                cmbSuburb.Text = dgvAgency.SelectedRows[0].Cells["SurbubDescription"].Value.ToString();
            }
        }
    }
}
