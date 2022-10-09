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
    public partial class ucProvince : UserControl
    {
        public ucProvince()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Provinces province = new Provinces();

            if (string.IsNullOrEmpty(txtDescr.Text))
            {
                errProvinces.SetError(txtDescr, "Enter a province!!");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {
                province.Description = txtDescr.Text;

                int x = bll.InsertProvince(province);
                if (x > 0)
                {
                    MessageBox.Show(x + " Added.");
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvProvince.DataSource = bll.GetProvinces();
        }

        private void ucProvince_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
        }
    }
}
