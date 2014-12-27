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
    public partial class FrmEmployee : Form
    {
        /// <summary>
        /// Adding Employee
        /// </summary>
        public FrmEmployee()
        {
            InitializeComponent();
            this.nameComboBox.Visible = false;
            this.txtName.Visible = true;
            this.cmdAdd.Visible = true;
            this.cmdRemove.Visible = false;
            this.cmdEdit.Visible = false;

            this.cmdCancel.Location = this.cmdRemove.Location;
        }

        /// <summary>
        ///  Delete Employee
        /// </summary>
        /// <param name="frmrem"></param>
        public FrmEmployee(bool frmrem)
        {
            InitializeComponent();
            this.txtName.Visible = false;
            this.nameComboBox.Visible = true;

            this.nameComboBox.Location = this.txtName.Location;
            this.cmdRemove.Visible = true;
            this.cmdAdd.Visible = false;
            this.cmdEdit.Visible = false;

            this.cmdCancel.Location = this.cmdRemove.Location;
            this.cmdRemove.Location = this.cmdAdd.Location;
        }


        /// <summary>
        /// Edit Employee
        /// </summary>
        /// <param name="frmedit"></param>
        public FrmEmployee(string frmedit)
        {
            InitializeComponent();
            this.txtName.Visible = false;
            this.nameComboBox.Visible = true;
            this.nameComboBox.Location = this.txtName.Location;
            this.cmdRemove.Visible = true;
            this.cmdAdd.Visible = false;

            this.cmdEdit.Location = this.cmdAdd.Location;
            this.cmdCancel.Location = this.cmdRemove.Location;

        }

        /// <summary>
        /// Employee Binding Navigator
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.restaurantDataSet);

        }

        /// <summary>
        /// Employee Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Employee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'restaurantDataSet.Employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.restaurantDataSet.Employee);

        }


        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Employee (Name,[Hourly Billing],HoursPerWeek,PhoneNumber,ResidenceAddresss,Salary) VALUES (@Name, @HourlyBilling, @HoursPerWeek,@PhoneNumber,@ResidenceAddresss,@Salary) ";
                
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Name", this.txtName.Text);
                cmd.Parameters.AddWithValue("@HourlyBilling", Convert.ToInt32(this.txtHourRate.Text));
                cmd.Parameters.AddWithValue("@HoursPerWeek", Convert.ToInt32(this.txtWeeklyHours.Text));
                cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(this.txtPhone.Text));
                cmd.Parameters.AddWithValue("@ResidenceAddresss", this.txtAddress.Text);
                cmd.Parameters.AddWithValue("@Salary", ((Convert.ToInt32(this.txtHourRate.Text) * Convert.ToInt32(this.txtWeeklyHours.Text))));

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

                this.txtHourRate.Text = "0";
                this.txtPhone.Text = "0";
                this.txtWeeklyHours.Text = "0";
                this.txtSalary.Text = "0";

            }
        }


        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Employee WHERE EmpId = @EmpId";


                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@EmpId", Convert.ToInt32(this.nameComboBox.SelectedValue));

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


        /// <summary>
        /// Cancel Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Edit Employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Employee SET [Hourly Billing]=@HourlyBilling, HoursPerWeek = @HoursPerWeek, PhoneNumber=@PhoneNumber,ResidenceAddresss=@ResidenceAddresss,Salary=@Salary";
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);
 
                cmd.Parameters.AddWithValue("@HourlyBilling", Convert.ToInt32(this.txtHourRate.Text));
                cmd.Parameters.AddWithValue("@HoursPerWeek", Convert.ToInt32(this.txtWeeklyHours.Text));
                cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(this.txtPhone.Text));
                cmd.Parameters.AddWithValue("@ResidenceAddresss", this.txtAddress.Text);
                cmd.Parameters.AddWithValue("@Salary", ((Convert.ToInt32(this.txtHourRate.Text) * Convert.ToInt32(this.txtWeeklyHours.Text))));

                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();

                this.Close();
            }
            catch (SystemException Ex)
            {
                MessageBox.Show("The current exception :" + Ex.Data.ToString() + ".Please try again.");
                this.Close();
            }
        }

        private void nameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT EmpID,Name,[Hourly Billing],HoursPerWeek,PhoneNumber,ResidenceAddresss,Salary from Employee where EmpID=@Empid ";

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Restaurant.Properties.Settings.RestaurantConnectionString"].ToString());
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Empid", Convert.ToInt32(this.nameComboBox.SelectedValue));

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    this.txtName.Text = dr[1].ToString();
                    this.txtHourRate.Text = dr[2].ToString();
                    this.txtWeeklyHours.Text = dr[3].ToString();
                    this.txtPhone.Text = dr[4].ToString(); ;
                    this.txtAddress.Text = dr[5].ToString();
                    this.txtSalary.Text = dr[6].ToString();
                }
            }

            connection.Close();
            connection.Dispose();

        }


    }
}
