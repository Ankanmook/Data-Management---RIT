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
    public partial class FrmOrder : Form
    {

        /// <summary>
        /// Member Variables for this form
        /// </summary>
        int capacity;
        int mealOrderId;
        int tableNumber;
        string cardno;
        string patronName;
        string waiterName;
        

        public FrmOrder()
        {
            InitializeComponent();
        }

        public FrmOrder(int capacity,int mealOrderId,int tableNumber,string patronName,string cardno)
        {
            InitializeComponent();
            this.capacity = capacity;
            this.mealOrderId = mealOrderId;

            this.lblMealOderID.Text = lblMealOderID.Text+ this.mealOrderId.ToString();
            this.patronName = patronName;
            this.lblPatronName.Text = lblPatronName.Text+ patronName;
            this.lblTableID.Text = lblTableID.Text+ tableNumber.ToString();
            this.cardno = cardno;
        }

        private void menuBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.menuBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);



        }

        private void Order_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.MealOrder' table. You can move, or remove it, as needed.
            this.mealOrderTableAdapter.Fill(this.restaurantDataSet.MealOrder);
            // TODO: This line of code loads data into the 'restaurantDataSet.OrderedItem' table. You can move, or remove it, as needed.
            this.orderedItemTableAdapter.Fill(this.restaurantDataSet.OrderedItem);
            // TODO: This line of code loads data into the 'restaurantDataSet.OrderedItem' table. You can move, or remove it, as needed.
            this.orderedItemTableAdapter.Fill(this.restaurantDataSet.OrderedItem);
            // TODO: This line of code loads data into the 'restaurantDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.restaurantDataSet.Employee);
            // TODO: This line of code loads data into the 'restaurantDataSet.Menu' table. You can move, or remove it, as needed.
            this.menuTableAdapter.Fill(this.restaurantDataSet.Menu);

        }

        private void menuDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmdDone_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

                foreach (DataGridViewRow DataRow in this.menuDataGridView.Rows)
                {
                    if (DataRow.Cells[4].Value != null)
                    {
                        //If the value of quantity is more than 0 then insert
                        if (Convert.ToInt32(DataRow.Cells[4].Value) > 0)
                        {
                            int itemID = Convert.ToInt32(DataRow.Cells[0].Value);
                            int quantity = Convert.ToInt32(DataRow.Cells[4].Value);

                            string query = "INSERT INTO OrderedItem VALUES (@MealOrderID, @ItemID,@Quantity)";
                            connection.Open();

                            SqlCommand cmd = new SqlCommand(query, connection);

                            cmd.Parameters.AddWithValue("@MealOrderID", this.mealOrderId);
                            cmd.Parameters.AddWithValue("@ItemID", itemID);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);

                            //Returns number of rows effected by the query
                            System.Int32 i = cmd.ExecuteNonQuery();
                            if (i < 1)
                            {
                                throw new SystemException();
                                connection.Close();
                            }
                            connection.Close();

                        }
                    }

                }

                SqlCommand cmdOrderTaken = new SqlCommand("INSERT INTO OrderTaken VALUES (@MealOrderID,@EmpID)", connection);
                cmdOrderTaken.Parameters.AddWithValue("@MealOrderID", this.mealOrderId);
                cmdOrderTaken.Parameters.AddWithValue("@EmpID", this.employeeComboBox.SelectedValue);

                connection.Open();
                System.Int32 j = cmdOrderTaken.ExecuteNonQuery();
                if (j < 1)
                {
                    throw new SystemException();
                    connection.Close();
                    connection.Dispose();

                }

                connection.Close();
                connection.Dispose();

                Form frm = new frmBill(this.mealOrderId,this.patronName,this.cardno);
                frm.Show();
                this.Close();

            }

            catch (SystemException Ex)
            {
                MessageBox.Show("To Err is human to forgive is divine");
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    
    }
}
