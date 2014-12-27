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
    public partial class frmBill : Form
    {
        int mealorderID;

        public frmBill()
        {
            InitializeComponent();
        }


        public frmBill(int mealOrderId,String name, String cardno)
        {
            InitializeComponent();
            this.mealorderID = mealOrderId;
            this.txtOrderId.Text = this.txtOrderId.Text + this.mealorderID.ToString();
            this.txtPatron.Text = name;
            this.txtCreditCardNumber.Text = cardno;
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.Menu' table. You can move, or remove it, as needed.
            this.menuTableAdapter.Fill(this.restaurantDataSet.Menu);
            // TODO: This line of code loads data into the 'restaurantDataSet.OrderedItem' table. You can move, or remove it, as needed.
            this.orderedItemTableAdapter.Fill(this.restaurantDataSet.OrderedItem);

            this.Load_Grid();
            this.Load_Amount();

        }

        public void Load_Grid()
        {
            string query = "SELECT M.ItemID,ItemName,Price,Quantity, (Price * Quantity) as CumulativePrice from Menu M, OrderedItem O where M.ItemID = O.ItemID and O.MealOrderID = @mealorderid";

            SqlConnection gridconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

            SqlDataAdapter da = new SqlDataAdapter(query, gridconnection);
            SqlCommand cmd = new SqlCommand(query, gridconnection);
            DataTable dt = new DataTable();
            
            cmd.Parameters.Add(new SqlParameter("@mealorderid",this.mealorderID));
            cmd.CommandType = CommandType.Text;
            da.SelectCommand = cmd;
            da.Fill(dt);

            dgvFinalBill.DataSource = dt;

            gridconnection.Dispose();
        }

        public void Load_Amount()
        {
            string query = "SELECT Sum(Price * Quantity) from Menu M, OrderedItem O where M.ItemID = O.ItemID and O.MealOrderID = @mealorderID";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@mealorderID", this.mealorderID);

            connection.Open();
            string amount = "$" +cmd.ExecuteScalar().ToString();
            
            connection.Close();
            connection.Dispose();
 
            this.txtAmount.Text = amount;
            this.txtAmount.Enabled = false;

       }

        private void CmdPay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you. Have a nice day!");
            this.Close();
        }
    }
}
