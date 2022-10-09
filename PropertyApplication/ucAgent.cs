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
    public partial class ucAgent : UserControl
    {
        public ucAgent()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;
            Agent agent = new Agent();

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errAgent.SetError(txtName, "Enter name.");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtSurname.Text))
            {
                errAgent.SetError(txtSurname, "Enter Surname!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtEmail.Text) || (!Regex.IsMatch(txtEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")))
            {
                errAgent.SetError(txtEmail, "Enter a valid Email!");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text) || (!Regex.IsMatch(txtPassword.Text, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")))
            {
                errAgent.SetError(txtPassword, "Your password Should be 8 characters long including: letters, special characters, numbers");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtPhone.Text) || (!Regex.IsMatch(txtPhone.Text, @"^(\+27|0)[6-8][0-9]{8}$")))
            {
                errAgent.SetError(txtPhone, "Enter valid phone number!");
                validate = false;
            }
            else
                validate = true;

            if (validate)
            {
                agent.Name = txtName.Text;
                agent.Surname = txtSurname.Text;
                agent.Email = txtEmail.Text;
                agent.Password = txtPassword.Text;
                agent.Phone = int.Parse(txtPhone.Text);
                agent.Status = cmbStatus.SelectedItem.ToString();
                agent.AgencyID = int.Parse(cmbAgency.SelectedValue.ToString());

                int x = bll.InsertAgent(agent);

                if (x > 0)
                {
                    MessageBox.Show(x + " Added Successfully.");
                    txtName.Clear();
                    txtSurname.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtPhone.Clear();
                }
            }
        }

        private void ucAgent_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            LoadAgency();

            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Not Available");
        }
        public void LoadAgency()
        {
            cmbAgency.DataSource = bll.GetAgencies();
            cmbAgency.DisplayMember = "AgencyName";
            cmbAgency.ValueMember = "AgencyID";
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvAgent.DataSource = bll.GetAgent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Agent agent = new Agent();

                agent.AgentID = int.Parse(txtID.Text);
                agent.Email = txtEmail.Text;
                agent.Phone = int.Parse(txtPhone.Text);
                agent.Status = cmbStatus.SelectedItem.ToString();

                int x = bll.UpdateAgent(agent);

                if (x > 0)
                {
                    MessageBox.Show(x + " Updated Successfully.");

                    txtName.Clear();
                    txtSurname.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtPhone.Clear();

                    dgvAgent.DataSource = bll.GetAgent();
                }
            }catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Agent agent = new Agent();

                agent.AgentID = int.Parse(txtID.Text);

                int x = bll.DeleteAgent(agent);

                if (x > 0)
                {
                    MessageBox.Show(x + " DELETED Successfully.");

                    txtName.Clear();
                    txtSurname.Clear();
                    txtEmail.Clear();
                    txtPassword.Clear();
                    txtPhone.Clear();

                    dgvAgent.DataSource = bll.GetAgent();

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

        private void dgvAgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgent.SelectedRows.Count > 0)
            {
                txtID.Text = dgvAgent.SelectedRows[0].Cells["AgentID"].Value.ToString();
                txtName.Text = dgvAgent.SelectedRows[0].Cells["Name"].Value.ToString();
                txtSurname.Text = dgvAgent.SelectedRows[0].Cells["Surname"].Value.ToString();
                txtEmail.Text = dgvAgent.SelectedRows[0].Cells["Email"].Value.ToString();
                txtPassword.Text = dgvAgent.SelectedRows[0].Cells["Password"].Value.ToString();
                txtPhone.Text = dgvAgent.SelectedRows[0].Cells["Phone"].Value.ToString();
                cmbStatus.Text = dgvAgent.SelectedRows[0].Cells["Status"].Value.ToString();
                cmbAgency.Text = dgvAgent.SelectedRows[0].Cells["AgencyName"].Value.ToString();
            }
        }
    }
}
