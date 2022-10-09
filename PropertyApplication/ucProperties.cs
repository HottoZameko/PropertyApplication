using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;
using DAL;
using System.Text.RegularExpressions;

namespace PropertyApplication
{
    public partial class ucProperties : UserControl
    {
        public ucProperties()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ucProperties_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Not Available");
            LoadPropertyTypeID();

            LoadSuburbID();
        }

        BusinessLogicLayer bll = new BusinessLogicLayer();
        private void btnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fld = new OpenFileDialog();
                {
                    string fileName = fld.FileName;
                    if (fld.ShowDialog() == DialogResult.OK)
                    {
                        pictureImage.Image = Image.FromFile(fld.FileName);
                    }
                }
            }
            catch (System.OutOfMemoryException)
            {
                MessageBox.Show("Invalid Selection, select pictures only!!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                Property prop = new Property();
                bool validate = false;

                MemoryStream ms = new MemoryStream();
                pictureImage.Image.Save(ms, pictureImage.Image.RawFormat);


                if (string.IsNullOrEmpty(txtDescr.Text))
                {
                    errProperty.SetError(txtDescr, "Enter property description");
                    validate = false;
                }
                else if (string.IsNullOrEmpty(txtPrice.Text) || (!Regex.IsMatch(txtPrice.Text, @"^\d{0,8}(\.\d{1,4})?$")))
                {
                    errProperty.SetError(txtPrice, "Invalid price.");
                    validate = false;
                }
                else
                    validate = true;
                if (validate)
                {
                    prop.Description = txtDescr.Text;
                    prop.Price = int.Parse(txtPrice.Text);
                    prop.Image = ms.ToArray();
                    prop.PropertyTypeID = int.Parse(cmbType.SelectedValue.ToString());
                    prop.Status = cmbStatus.SelectedItem.ToString();
                    prop.SuburbID = int.Parse(cmbSuburb.SelectedValue.ToString());

                    int x = bll.InsertProperties(prop);
                    if (x > 0)
                    {
                        MessageBox.Show(x + " added Successfully.");

                        errProperty.Clear();
                    }
                }
            }catch (System.FormatException)
            {
                MessageBox.Show("No selected Column");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("You cannot Delete this data, select the unused data.");
            }
            
        }

        public void LoadSuburbID()
        {
            cmbSuburb.DataSource = bll.GetSuburbs();
            cmbSuburb.DisplayMember = "SurbubDescription";
            cmbSuburb.ValueMember = "SurbubID";
        }
        public void LoadPropertyTypeID()
        {
            cmbType.DataSource = bll.GetPropertyTypes();
            cmbType.DisplayMember = "PropertyTypeDescription";
            cmbType.ValueMember = "PropertyTypeID";
        }
        public void LoadProperty()
        {
            dgvProperty.DataSource = bll.GetProperties();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadProperty();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Property prop = new Property();


                prop.PropertyID = int.Parse(txtID.Text);
                prop.PropertyTypeID = int.Parse(cmbType.SelectedValue.ToString());
                prop.Price = int.Parse(txtPrice.Text);
                prop.Status = cmbStatus.SelectedItem.ToString();

                int x = bll.UpdateProperties(prop);

                if (x > 0)
                {
                    MessageBox.Show(x + " Property has been UPDATED.");
                    LoadProperty();

                }
            }catch (System.FormatException)
            {
                MessageBox.Show("Choose a column to update");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Property prop = new Property();
                prop.PropertyID = int.Parse(txtID.Text);

                int x = bll.DeleteProperties(prop);

                if (x > 0)
                {
                    MessageBox.Show(x + "DELETED.");
                    LoadProperty();
                    txtDescr.Clear();
                    txtPrice.Clear();
                    errProperty.Clear();
                }
            }catch (System.FormatException)
            {
                MessageBox.Show("Choose a column to delete");
            }
        }

        private void dgvProperty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProperty.SelectedRows.Count > 0)
                {
                    txtID.Text = dgvProperty.SelectedRows[0].Cells["PropertyID"].Value.ToString();
                    txtDescr.Text = dgvProperty.SelectedRows[0].Cells["Description"].Value.ToString();
                    txtPrice.Text = dgvProperty.SelectedRows[0].Cells["Price"].Value.ToString();
                    MemoryStream ms = new MemoryStream((byte[])dgvProperty.SelectedRows[0].Cells["Image"].Value);
                    pictureImage.Image = Image.FromStream(ms);
                    cmbType.Text = dgvProperty.SelectedRows[0].Cells["PropertyTypeDescription"].Value.ToString();
                    cmbStatus.Text = dgvProperty.SelectedRows[0].Cells["Status"].Value.ToString();
                    cmbSuburb.Text = dgvProperty.SelectedRows[0].Cells["SurbubDescription"].Value.ToString();
                }
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("Nothing to Show");
            }
        }
    }
}
