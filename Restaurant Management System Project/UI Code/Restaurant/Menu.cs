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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
            
            this.cmdDelete.Visible = false;
            this.cmdEdit.Visible = false;

            this.cmdSubmit.Visible = true;
            this.txtName.Visible = true;
            
            this.itemNameComboBox.Visible = false;

            this.cmdCancel.Location = this.cmdSubmit.Location;
            this.cmdSubmit.Location = this.cmdDelete.Location;
            
        }

        public FrmMenu(bool rem)
        {
            InitializeComponent();
            
            this.cmdEdit.Visible = false;
            this.cmdSubmit.Visible = false;

            this.cmdCancel.Visible = true;
            this.cmdDelete.Visible = true;

            this.txtName.Visible = false;
            this.itemNameComboBox.Visible = true;
            this.itemNameComboBox.Location = this.txtName.Location;

            this.cmdCancel.Location = this.cmdSubmit.Location;
            this.cmdDelete.Location = this.cmdDelete.Location;
            
        }


        public FrmMenu(string edit)
        {
            InitializeComponent();

            this.cmdSubmit.Visible = false;
            this.cmdDelete.Visible = false;

            this.cmdCancel.Visible = true;
            this.cmdEdit.Visible = true;


            this.txtName.Visible = false;
            this.itemNameComboBox.Visible = true;
            this.itemNameComboBox.Location = this.txtName.Location;

            this.cmdCancel.Location = this.cmdSubmit.Location;
            this.cmdEdit.Location = this.cmdDelete.Location;
            
        }


        private void menuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.menuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.Menu' table. You can move, or remove it, as needed.
            this.menuTableAdapter.Fill(this.restaurantDataSet.Menu);

        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Menu (ItemName,Price,Description) Values (@ItemName,@Price,@Description)";
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ItemName", this.txtName.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(this.txtPrice.Text));
                cmd.Parameters.AddWithValue("@Description", this.txtDescription.Text);

                int i = cmd.ExecuteNonQuery();
                if (i < 1)
                {
                    throw new SystemException();
                }

                connection.Close();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show("Incorrect values entered");
                MessageBox.Show(Ex.Data.ToString());
                this.Close();
            }
        }



        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "DELETE FROM Menu WHERE ItemId = @ItemId";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ItemId", Convert.ToInt32(this.itemNameComboBox.SelectedValue));

                cmd.ExecuteNonQuery();
                connection.Close();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show("Not Able to Delete. Cascading Issues Faced");
                MessageBox.Show(Ex.Data.ToString());
            }

        }



        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Menu (ItemName,Price,Description) VALUES (@ItemName, @Price, @Description) ";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ItemName", this.txtName.Text);
                cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(this.txtPrice.Text));
                cmd.Parameters.AddWithValue("@Description",this.txtDescription.Text);
           
                int i = cmd.ExecuteNonQuery();
                if (i < 1)
                {
                    throw new SystemException();
                }
                connection.Close();
                this.Close();
            }

            catch (SystemException Ex)
            {
                MessageBox.Show("Incorrect values entered");
                MessageBox.Show(Ex.Data.ToString());
                this.txtPrice.Text = "";
            }

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void itemNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT ItemID,ItemName,Price,Description from Menu where ItemID=@ItemID ";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ItemID", Convert.ToInt32(this.itemNameComboBox.SelectedValue));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.txtName.Text = dr[1].ToString();
                    this.txtPrice.Text = dr[2].ToString();
                    this.txtDescription.Text = dr[3].ToString();
                }
            }

            connection.Close();
            connection.Dispose();
        }
    }
}
