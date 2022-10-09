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
    public partial class ucReports : UserControl
    {
        public ucReports()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucReports_Load(object sender, EventArgs e)
        {
            cmbUsers.Items.Add("Tenant");
            cmbUsers.Items.Add("Admin");
            cmbUsers.Items.Add("Agent");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Price p = new Price();
            try
            {
                p.price = double.Parse(txtPrice.Text);

                dgvReports.DataSource = bll.SeacrhByPrice(p);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Enter a valid price to search!");
            }
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbUsers.SelectedItem.ToString() == "Tenant")
            {
                dgvReports.DataSource = bll.GetTenant();
            }
            else if (cmbUsers.SelectedItem.ToString() == "Admin")
            {
                dgvReports.DataSource = bll.GetAdmin();
            }
            else if (cmbUsers.SelectedItem.ToString() == "Agent")
            {
                dgvReports.DataSource = bll.GetAgent();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = bll.GetEndedRentals();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = bll.GetCityProvinceSurbub();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = bll.PopularAgent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = bll.RentalsAndAgents();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgvReports.DataSource = bll.PropertyPropertyType();
        }
    }
}
