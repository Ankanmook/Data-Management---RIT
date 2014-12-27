using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;


namespace Restaurant
{
    public partial class FrmSupplier : Form
    {
        /// <summary>
        /// Customer Add contructor
        /// </summary>
        public FrmSupplier()
        {
            InitializeComponent();
            this.cmdDelete.Visible = false;
            this.cmdSubmit.Visible = true;
            this.supplierComboBox.Visible = false;
            this.cmdEdit.Visible = false;

            this.cmdCancel.Location = this.cmdDelete.Location;
        }

        /// <summary>
        /// Customer delete contructor
        /// </summary>
        /// <param name="frmdelete"></param>
        public FrmSupplier(bool frmdelete)
        {
            InitializeComponent();
            this.cmdSubmit.Visible = false;
            this.cmdDelete.Visible = true ;
            this.supplierComboBox.Visible = true;
            this.txtName.Visible = false;
            this.supplierComboBox.Location = this.txtName.Location;
            this.cmdEdit.Visible = false;

            this.cmdCancel.Location = this.cmdDelete.Location;
            this.cmdDelete.Location = this.cmdSubmit.Location;
            
        }

        /// <summary>
        /// Customer Edit constructor
        /// </summary>
        /// <param name="frmedit"></param>
        public FrmSupplier(string frmedit)
        {
            InitializeComponent();
            this.cmdSubmit.Visible = false;
            this.cmdDelete.Visible = true;
            this.supplierComboBox.Visible = true;
            this.txtName.Visible = false;
            this.supplierComboBox.Location = this.txtName.Location;
            this.cmdEdit.Location = this.cmdSubmit.Location;
            this.cmdSubmit.Visible = false;
            this.cmdDelete.Visible = false;

            this.cmdCancel.Location = this.cmdDelete.Location;
            this.cmdEdit.Location = this.cmdSubmit.Location;
        }

        /// <summary>
        /// Binding Navigator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }

        /// <summary>
        /// Loading the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.restaurantDataSet.Supplier);
            // TODO: This line of code loads data into the 'restaurantDataSet.Supplier' table. You can move, or remove it, as needed.
        }

        /// <summary>
        /// Submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Supplier (SupplierName,PhoneNumber,Address) VALUES (@SupplierName,@PhoneNumber,@Address)";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@SupplierName", this.txtName.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(this.txtPhoneNumber.Text));
                cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text);

                int i = cmd.ExecuteNonQuery();

                if (i < 1)
                {
                    throw new SystemException();
                }

                connection.Close();
                connection.Dispose();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show("Please enter your phone number correctly.");
                this.txtPhoneNumber.Text = "";
            }
        }



        /// <summary>
        /// Delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Supplier WHERE SupplierId = @SupplierId";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@SupplierId",Convert.ToInt32(this.supplierComboBox.SelectedValue));

                int i = cmd.ExecuteNonQuery();

                if (i < 1)
                {
                    throw new SystemException();
                }

                connection.Close();
                connection.Dispose();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show(Ex.Message.ToString());
                this.txtPhoneNumber.Text = "";
            }
        }



        /// <summary>
        /// Edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEdit_Click(object sender, EventArgs e)
        {
             try
            {

                string query = "UPDATE Supplier SET PhoneNumber=@PhoneNumber, Address= @Address WHERE SupplierID = @SupplierID";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(this.txtPhoneNumber.Text));
                cmd.Parameters.AddWithValue("@Address", this.txtAddress.Text);
                cmd.Parameters.AddWithValue("@SupplierID", Convert.ToInt32(this.supplierComboBox.SelectedValue));

                cmd.ExecuteNonQuery();
                

                connection.Close();
                connection.Dispose();

                this.Close();
            }

            catch (SystemException Ex)
            {
                MessageBox.Show( "The current exception :" + Ex.Data.ToString()+ ".Please try again.");
            }


        }




        /// <summary>
        /// Supplier Combo box change index event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        /// <summary>
        /// Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void supplierBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }

        private void supplierBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }

        private void supplierBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
        {
            this.Validate();
            this.supplierBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }


        private void supplierComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string query = "SELECT SupplierID,SupplierName,PhoneNumber, Address from Supplier where SupplierId=@SupplierId ";


            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@SupplierId", Convert.ToInt32(this.supplierComboBox.SelectedValue));

            SqlDataReader dr = cmd.ExecuteReader();

            if ((dr.HasRows) || (dr != null))
            {
                while (dr.Read())
                {
                    this.txtAddress.Text = dr[3].ToString();
                    this.txtPhoneNumber.Text = dr[2].ToString();
                }
            }

            connection.Close();
            connection.Dispose();
        }


    }
}
