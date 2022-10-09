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
    public partial class ucLogin : UserControl
    {
        // public static DataTable dtLog = null;
        public static string userRole;
        public static string role
        {
            get { return userRole; }
            set { userRole = value; }
        }
        
        public ucLogin()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        public void Login()
        {
            if (txtRole.Text.ToUpper() == "ADMIN")
            {
                
                DataTable dt = bll.AdminLog(txtUsername.Text, txtPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    role = txtRole.Text;
                    Form1 form = new Form1();
                    form.AsignUser = userRole;
                    form.BringToFront();
                    this.Hide();
                }
                else
                    lblWrong.Visible = true;
            }

            if (txtRole.Text.ToUpper() == "AGENT")
            {
                DataTable dt = bll.AgentLog(txtUsername.Text, txtPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    userRole = txtRole.Text;
                    Form1 form = new Form1();
                    form.AsignUser = userRole;
                    form.BringToFront();
                    this.Hide();
                }
                else
                    lblWrong.Visible = true;


            }
            if (txtRole.Text.ToUpper() == "TENANT")
            {
                DataTable dt = bll.TenantLog(txtUsername.Text, txtPassword.Text);

                if (dt.Rows.Count > 0)
                {
                    userRole = txtRole.Text;

                    Form1 form = new Form1();
                    form.AsignUser = userRole;
                    form.BringToFront();
                    this.Hide();
                }
                else
                    lblWrong.Visible = true;
            }

        }
        private void ucLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
