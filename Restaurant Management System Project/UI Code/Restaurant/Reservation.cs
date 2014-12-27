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
    public partial class FrmPatron : Form
    {
        
        public FrmPatron()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.txtCapacity.ResetText();
            this.txtEmaiID.ResetText();
            this.txtName.ResetText();
            this.txtPhoneNumber.ResetText();
            this.txtCapacity.ResetText();
            this.txtCreditCard.ResetText();
            this.txtCreditCardNo.ResetText();

        }

        /// <summary>
        /// Inserting Values into patron table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string query = "INSERT INTO Patron VALUES (@Name, @Email,@CardHolderName,@CreditCard,@Phone)";

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", this.txtName.Text);
                cmd.Parameters.AddWithValue("@Email", this.txtEmaiID.Text);
                cmd.Parameters.AddWithValue("@CardHolderName", this.txtCreditCard.Text);
                cmd.Parameters.AddWithValue("@CreditCard", this.txtCreditCardNo.Text);
                cmd.Parameters.AddWithValue("@Phone", this.txtPhoneNumber.Text);

                //Returns number of rows effected by the query
                System.Int32 i = cmd.ExecuteNonQuery();
                if (i < 1)
                {
                    throw new SystemException(); 
                }
                connection.Close();
                int capacity = (int)(Convert.ToInt16(this.txtCapacity.Text));

                //Sending connection for cmdMealOrder
                
                SqlCommand cmdMealOrderID = new SqlCommand("select MAX(MealOrderID) from MealOrder",connection);
                connection.Open();
                int MealOrderID = (int)cmdMealOrderID.ExecuteScalar(); 
                connection.Close();

                SqlCommand cmdTableId= new SqlCommand("select TableID from PatronGIVESOrder where MealOrderID=@mealorderid ", connection);
                cmdTableId.Parameters.AddWithValue("@mealorderid", MealOrderID);
                connection.Open();
                int TableID = (int)cmdMealOrderID.ExecuteScalar();
                connection.Close();
                connection.Dispose();

                //Sending capacity to be included in updating tables
                Form Frm = new FrmOrder(capacity, MealOrderID, TableID, this.txtName.Text, this.txtCreditCardNo.Text);
                Frm.Show();
                this.Close();
            }

            // Throwing Exception in case of problem in Insertion of data
            catch (SystemException Ex)
            {
                this.txtCreditCardNo.ResetText();
                this.txtPhoneNumber.ResetText();

                MessageBox.Show(Ex.Data.ToString());
                MessageBox.Show("Please Enter number in numeric fields. Example Credit Card number, Phone Number or capacity");
            }
        }
    }
}
