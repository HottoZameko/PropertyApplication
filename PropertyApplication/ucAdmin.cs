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
    public partial class ucAdmin : UserControl
    {
        public ucAdmin()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Admin ad = new Admin();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errAdmin.SetError(txtName, "Please Enter Name.");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errAdmin.SetError(txtSurname, "Please Enter Surname.");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text) || (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")))
            {
                errAdmin.SetError(txtEmail, "Enter a valid Email!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")))
            {
                errAdmin.SetError(txtPassword, "Your password Should be 8 characters long including: letters, special characters, numbers");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {
                ad.Name = txtName.Text;
                ad.Surname = txtSurname.Text;
                ad.Email = txtEmail.Text;
                ad.Password = txtPassword.Text;
                ad.Status = cmbStatus.SelectedItem.ToString();

                int x = bll.InsertAdmin(ad);

                if (x > 0)
                {
                    MessageBox.Show("Admin Info. has been captured Successfully!!");
                    errAdmin.Clear();
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvAdmin.DataSource = bll.GetAdmin();
        }

        private void ucAdmin_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Not available");
        }
    }
}
