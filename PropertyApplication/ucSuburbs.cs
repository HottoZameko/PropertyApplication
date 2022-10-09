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
    public partial class ucSuburbs : UserControl
    {
        public ucSuburbs()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void ucSuburbs_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            LoadSub();
        }
        public void LoadSub()
        {
            cmbCity.DataSource = bll.GetCities();
            cmbCity.DisplayMember = "CityDescription";
            cmbCity.ValueMember = "CityID";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = false;

            Suburbs suburbs = new Suburbs();


            if (string.IsNullOrEmpty(txtDescr.Text))
            {
                errSuburbs.SetError(txtDescr, "Enter a Suburb description");
                validate = false;
            }
            else if (string.IsNullOrEmpty(txtCode.Text))
            {
                errSuburbs.SetError(txtCode, "Enter a valid postal code");
                validate = false;
            }
            else
                validate = true;
            if (validate)
            {
                suburbs.SurbubDescription = txtDescr.Text;
                suburbs.PostalCode = int.Parse(txtCode.Text);
                suburbs.CityID = int.Parse(cmbCity.SelectedValue.ToString());

                int x = bll.InsertSuburbs(suburbs);

                if (x > 0)
                {
                    MessageBox.Show(x + " Added!");
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvSuburb.DataSource = bll.GetSuburbs();
        }
    }
}
