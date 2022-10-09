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
    public partial class ucPropertyType : UserControl
    {
        public ucPropertyType()
        {
            InitializeComponent();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void ucPropertyType_Load(object sender, EventArgs e)
        {
            txtTypeID.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Validate = false;

            PropertyTypes types = new PropertyTypes();

            if (string.IsNullOrEmpty(txtTypeDesc.Text))
            {
                errTypes.SetError(txtTypeDesc, "Invalid description entered.");
                Validate = false;
            }
            else
                Validate = true;

            if (Validate)
            {
                types.PropertyTypeDescr = txtTypeDesc.Text;


                int x = bll.InsertPropertyTypes(types);

                if (x > 0)
                {
                    MessageBox.Show(x +" Added!");
                    txtTypeDesc.Clear();
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dgvPropertyType.DataSource = bll.GetPropertyTypes();
        }
    }
}
