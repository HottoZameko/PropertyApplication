using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyApplication
{
    public partial class Form1 : Form
    {
        public string AsignUser { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUser.Text = AsignUser;
            lblText.Text = lblUser.Text;

            ucAgencies1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {

                ucPropertyType1.BringToFront();
            }
            else
                button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "AGENT" || lblUser.Text.ToUpper() == "ADMIN")
            {
                ucProperties1.BringToFront();
                ucProperties1.LoadPropertyTypeID();
                ucProperties1.LoadSuburbID();
            }
            else
                button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucProvince1.BringToFront();
            }
            else
                button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucCities1.BringToFront();
                ucCities1.LoadPro();
            }
            else
                button4.Enabled = false;
               
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucSuburbs1.BringToFront();
                ucSuburbs1.LoadSub();
            }
            else
                button5.Enabled = false;
               
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucAgent1.BringToFront();
                ucAgent1.LoadAgency();
            }
            else
                button6.Enabled = false;
               
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucAgencies1.Enabled = true;
                ucAgencies1.BringToFront();
                ucAgencies1.LoadS();
            }
            else
                button7.Enabled = false;
               
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "TENANT")
            {

                ucRental1.BringToFront();
                ucRental1.LoadT();
                ucRental1.LoadPropAgen();
            }
            else
                button8.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "TENANT")
            {
                ucTenant1.BringToFront();
            }
            else
                button9.Enabled = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "AGENT" || lblUser.Text.ToUpper() == "ADMIN")
            {
                ucPropertyAgent1.BringToFront();
                ucPropertyAgent1.LoadPro();
                ucPropertyAgent1.LoadAge();
            }
            else
                button10.Enabled = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucAdmin1.BringToFront();
            }
            else
                button11.Enabled = false;
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (lblUser.Text.ToUpper() == "ADMIN")
            {
                ucReports1.BringToFront();
            }
            else
                btnReports.Enabled = false;
                
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            lblUser.Text = ucLogin.userRole;
            lblUser.Text = AsignUser;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLog log = new frmLog();
            log.Show();
            this.Hide();
        }
    }
}
