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
    public partial class FrmProduct : Form
    {
        /// <summary>
        /// For adding new Product
        /// </summary>
        public FrmProduct()
        {
            InitializeComponent();
            this.cmdAddNew.Visible = true;
            this.cmdRemove.Visible = false;
            this.txtName.Visible = true;
            this.nameComboBox.Visible = false;

            this.lblAmountAvailable.Text = "Amount";
            this.lblAmountAvailable.Visible = true;
            this.txtAmountAvailable.Visible = true;

            this.lblAddAmount.Visible = false;
            this.txtAddAmount.Visible = false;

            
            this.lblIncrementalCost.Visible = false;
            this.txtIncrementalCost.Visible = false;

            this.cmdIncrement.Visible = false;
            this.cmdAddNew.Visible = true;
            this.cmdAddNew.Location = this.cmdRemove.Location;

            this.txtCost.Enabled = false;
            this.txtUnitPrice.Text = "0";
            this.txtAmountAvailable.Text = "0";
        }

        /// <summary>
        /// For Deleting Product from Product Table
        /// </summary>
        /// <param name="frmrem">bool frmrem</param>
        public FrmProduct(bool frmrem)
        {
            InitializeComponent();
            this.txtName.Visible = false;
            this.nameComboBox.Visible = true;
            this.nameComboBox.Location = this.txtName.Location;

            this.cmdAddNew.Visible = false;
            this.cmdRemove.Visible = true;

            this.txtCost.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtUnit.Enabled = false;
            this.txtUnitPrice.Enabled = false;
            this.txtAmountAvailable.Enabled = false;

            this.lblAmountAvailable.Visible = true;
            this.txtAmountAvailable.Visible = true;

            this.lblAddAmount.Visible = false;
            this.txtAddAmount.Visible = false;

            this.lblIncrementalCost.Visible = false;
            this.txtIncrementalCost.Visible = false;

            this.cmdIncrement.Visible = false;
            this.cmdAddNew.Visible = false;

            this.supplierComboBox.Visible = false;
        }

        /// <summary>
        /// For Purchasing Already Present Product
        /// </summary>
        /// <param name="frmrem">string frmPurchase</param>
        public FrmProduct(string frmPurchase)
        {
            InitializeComponent();
            this.txtName.Visible = false;
            this.nameComboBox.Visible = true;
            this.nameComboBox.Location = this.txtName.Location;
            this.cmdRemove.Visible = false;

            this.txtUnitPrice.Enabled = false;
            this.txtUnit.Enabled = false;
            this.txtAmountAvailable.Enabled = false;
            this.txtCost.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtCost.Enabled = false;

            this.lblAmountAvailable.Visible = true;
            this.txtAmountAvailable.Visible = true;

            this.lblAddAmount.Visible = true;
            this.txtAddAmount.Visible = true;

            this.lblIncrementalCost.Visible = true;
            this.txtIncrementalCost.Visible = true;
            this.txtIncrementalCost.Enabled = false;

            this.cmdIncrement.Visible = true;
            this.cmdAddNew.Visible = false;
            this.cmdIncrement.Location = this.cmdRemove.Location;

            this.lblSupplierName.Visible = false;

            this.supplierComboBox.Visible = false;
        }

        /// <summary>
        /// Binding Navigator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void productBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }


        /// <summary>
        /// Product Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.Supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.restaurantDataSet.Supplier);
            // TODO: This line of code loads data into the 'restaurantDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.restaurantDataSet.Employee);
            // TODO: This line of code loads data into the 'restaurantDataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.restaurantDataSet.Product);
        }

        /// <summary>
        /// Cancel Button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        /// <summary>
        /// Selected Index shows change in all items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT ProductID,ProductName,Unit,Amount,UnitPrice,TotalCost,Description from Product where ProductId=@productid ";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@productid",Convert.ToInt32(this.nameComboBox.SelectedValue));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.txtUnit.Text = dr[2].ToString();
                    this.txtAmountAvailable.Text = dr[3].ToString();
                    this.txtUnitPrice.Text = dr[4].ToString();
                    this.txtCost.Text = dr[5].ToString(); ;
                    this.txtDescription.Text= dr[6].ToString();
                }
            }

            connection.Close();
            connection.Dispose();
        }

        /// <summary>
        /// To add product to already existing tally
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdIncrement_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "UPDATE Product  SET Amount = @amount, TotalCost = @totalCost WHERE ProductID = @productID";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productid", Convert.ToInt32(this.nameComboBox.SelectedValue));
                cmd.Parameters.AddWithValue("@amount", Convert.ToInt32(this.txtAddAmount.Text));
                cmd.Parameters.AddWithValue("@totalCost", (Convert.ToInt32(this.txtAddAmount.Text) * Convert.ToInt32(this.txtUnitPrice.Text) + Convert.ToInt32(this.txtCost.Text)));

                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show( "The current exception :" + Ex.Data.ToString()+ ".Please try again.");
                this.txtAddAmount.Text = "0";
            }
        }


        /// <summary>
        /// To add new product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                //Query in cascading order
                string query1 = "INSERT INTO PRODUCT (ProductName,Unit,Amount,UnitPrice,TotalCost,Description) VALUES (@ProductName,@Unit,@Amount,@UnitPrice,@TotalCost,@Description)";
                string query2 = "SELECT MAX(ProductID) from Product";
                string query3 = "INSERT  INTO PURCHASE (ProductID,EmpID,Quantity,PurchaseDate) VALUES (@ProductID,@EmpID,@Quantity,@PurchaseDate)";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd1 = new SqlCommand(query1, connection);
                cmd1.Parameters.AddWithValue("@ProductName", this.txtName.Text);
                cmd1.Parameters.AddWithValue("@Unit", this.txtUnit.Text);
                cmd1.Parameters.AddWithValue("@Amount", Convert.ToInt32(this.txtAmountAvailable.Text));
                cmd1.Parameters.AddWithValue("@UnitPrice", Convert.ToInt32(this.txtUnitPrice.Text));
                cmd1.Parameters.AddWithValue("@TotalCost", (Convert.ToInt32(this.txtAmountAvailable.Text) * Convert.ToInt32(this.txtUnitPrice.Text)));
                cmd1.Parameters.AddWithValue("@Description", this.txtDescription.Text);

                int cost = (Convert.ToInt32(this.txtAmountAvailable.Text) * Convert.ToInt32(this.txtUnitPrice.Text));

                int i = cmd1.ExecuteNonQuery();

                if (i < 1)
                {
                    throw new SystemException();
                }

                connection.Close();

                
                connection.Open();

                SqlCommand cmd2 = new SqlCommand(query2, connection);

                int productId = (int)cmd2.ExecuteScalar();

                if ((productId < 1)||(productId == null))
                {
                    throw new SystemException();
                }
                connection.Close();

                connection.Open();
                

                SqlCommand cmd3 = new SqlCommand(query3, connection);
                cmd3.Parameters.AddWithValue("@ProductID", productId);
                cmd3.Parameters.AddWithValue("@EmpID", Convert.ToInt32(this.employeeComboBox.SelectedValue));
                cmd3.Parameters.AddWithValue("@Quantity", Convert.ToInt32(this.txtAmountAvailable.Text));
                cmd3.Parameters.Add("@PurchaseDate", SqlDbType.DateTime);
                cmd3.Parameters["@PurchaseDate"].Value = DateTime.Now;

                int j = cmd3.ExecuteNonQuery();

                if (j < 1)
                {
                    throw new SystemException();
                }
                
                connection.Close();

                connection.Open();
                string query4 = "INSERT  INTO Supplies (SupplierID,ProductID) VALUES (@SupplierID,@ProductID)";

                SqlCommand cmd4 = new SqlCommand(query4, connection);
                cmd4.Parameters.AddWithValue("@SupplierID", Convert.ToInt32(this.supplierComboBox.SelectedValue));
                cmd4.Parameters.AddWithValue("@ProductID", productId);

                int k = cmd4.ExecuteNonQuery();

                if (k < 1)
                {
                    throw new SystemException();
                }

                connection.Close();
                connection.Dispose();

                MessageBox.Show("You bought the product worth $" + cost.ToString() );

                this.Close();
            }

            catch (SystemException Ex)
            {
                MessageBox.Show("Incorrect values entered");
                MessageBox.Show(Ex.Data.ToString());

                this.txtUnitPrice.Text = "0";
                this.txtAmountAvailable.Text = "0";
                this.txtCost.Text = "0";

            }


        }

        /// <summary>
        /// To remove product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //Query in cascading effect
                string query1 = "DELETE FROM Supplies WHERE ProductId = @ProductID";
                string query2 = "DELETE FROM Purchase WHERE ProductId = @ProductID";
                string query3 = "DELETE FROM Product WHERE ProductId = @ProductID";

                
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

                connection.Open();
                SqlCommand cmd1 = new SqlCommand(query1, connection);
                cmd1.Parameters.AddWithValue("@ProductID",Convert.ToInt32(this.nameComboBox.SelectedValue));

                cmd1.ExecuteNonQuery();
                connection.Close();

           

                
                connection.Open();
                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@productid", Convert.ToInt32( this.nameComboBox.SelectedValue));

                int j = cmd2.ExecuteNonQuery();
                connection.Close();
                

                connection.Open();
                SqlCommand cmd3 = new SqlCommand(query3, connection);
                cmd3.Parameters.AddWithValue("@ProductID", Convert.ToInt32(this.nameComboBox.SelectedValue));

                cmd3.ExecuteNonQuery();                 
                connection.Close();
                connection.Dispose();

                this.Close();
            }

            catch (SystemException Ex)
            {
                MessageBox.Show("Not Able to Delete. Cascading Issues Faced");
                MessageBox.Show(Ex.Data.ToString());
            }

        }

        /// <summary>
        /// Changing combo box index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




    }
}
