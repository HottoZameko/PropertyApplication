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
using System.Text.RegularExpressions;

namespace PropertyApplication
{
    public partial class ucTenant : UserControl
    {
        public ucTenant()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Tenants tenant = new Tenants();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errTenant.SetError(txtName, "Enter name!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errTenant.SetError(txtSurname, "Enter Surname!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text) || (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")))
            {
                errTenant.SetError(txtEmail, "Enter a valid Email!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")))
            {
                errTenant.SetError(txtPassword, "Your password must incude Special characters, Capital letters and at least one numerical value!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text) || (!Regex.IsMatch(txtPhone.Text, @"^(\+27|0)[6-8][0-9]{8}$")))
            {
                errTenant.SetError(txtPhone, "Enter valid phone number!");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {
                tenant.Name = txtName.Text;
                tenant.Surname = txtSurname.Text;
                tenant.Email = txtEmail.Text;
                tenant.Password = txtPassword.Text;
                tenant.Phone = int.Parse(txtPhone.Text);
                tenant.Status = cmbStatus.SelectedItem.ToString();

                int x = bll.InsertTenant(tenant);

                if (x > 0)
                {
                    MessageBox.Show(x + " Added.");
                    txtName.Clear();
                    txtSurname.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtPhone.Clear();
                    errTenant.Clear();
                }
            }
        }

        private void ucTenant_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;

            cmbStatus.Items.Add("Available.");
            cmbStatus.Items.Add("Not Available");
        }

        private void dgvTenant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTenant.SelectedRows.Count > 0)
            {
                txtID.Text = dgvTenant.SelectedRows[0].Cells["TenantID"].Value.ToString();
                txtName.Text = dgvTenant.SelectedRows[0].Cells["Name"].Value.ToString();
                txtSurname.Text = dgvTenant.SelectedRows[0].Cells["Surname"].Value.ToString();
                txtEmail.Text = dgvTenant.SelectedRows[0].Cells["Email"].Value.ToString();
                txtPassword.Text = dgvTenant.SelectedRows[0].Cells["Password"].Value.ToString();
                txtPhone.Text = dgvTenant.SelectedRows[0].Cells["Phone"].Value.ToString();
                cmbStatus.Text = dgvTenant.SelectedRows[0].Cells["Status"].Value.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Tenants tenants = new Tenants();

                tenants.TenantID = int.Parse(txtID.Text);
                tenants.Email = txtEmail.Text;
                tenants.Phone = int.Parse(txtPhone.Text);
                tenants.Status = cmbStatus.SelectedItem.ToString();

                int x = bll.UpdateTenant(tenants);

                if (x > 0)
                {
                    MessageBox.Show("Tenant UPDATED Successfully!");
                    dgvTenant.DataSource = bll.GetTenant();

                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Tenants tenants = new Tenants();

                tenants.TenantID = int.Parse(txtID.Text);

                int x = bll.DeleteTenant(tenants);

                if (x > 0)
                {
                    MessageBox.Show(x + " Deleted.");
                    bll.GetTenant();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvTenant.DataSource = bll.GetTenant();
        }
    }
}
