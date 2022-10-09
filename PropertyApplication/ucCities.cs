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
    public partial class ucCities : UserControl
    {
        public ucCities()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void ucCities_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;

            LoadPro();
        }
        public void LoadPro()
        {
            cmbProvince.DataSource = bll.GetProvinces();
            cmbProvince.DisplayMember = "Description";
            cmbProvince.ValueMember = "ProvinceID";
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvCity.DataSource = bll.GetCities();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Cities cities = new Cities();


            if (string.IsNullOrEmpty(txtDescr.Text))
            {
                errCities.SetError(txtDescr, "Please Enter a City");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {
                cities.CityDescr = txtDescr.Text;
                cities.ProvinceID = int.Parse(cmbProvince.SelectedValue.ToString());

                int x = bll.InsertCities(cities);

                if (x > 0)
                {
                    MessageBox.Show(x + " Added Successfully!");
                    txtDescr.Clear();
                    errCities.Clear();
                }
            }
        }
    }
}
