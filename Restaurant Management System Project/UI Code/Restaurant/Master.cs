using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class FrmMaster : Form
    {
        public FrmMaster()
        {
            InitializeComponent();
        }

        private void cmdAddMenu_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmMenu();
            Frm.Show();
        }

        private void cmdRemoveMenu_Click(object sender, EventArgs e)
        {
            bool frmrem = true;
            Form Frm = new FrmMenu(frmrem);
            Frm.Show();
        }

        private void cmdAddSupplier_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmSupplier();
            Frm.Show();
        }

        private void cmdRemoveSupplier_Click(object sender, EventArgs e)
        {
            bool frmrem = true;
            Form Frm = new FrmSupplier(frmrem);
            Frm.Show();
        }

        private void cmdAddEmployee_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmEmployee();
            Frm.Show();
        }

        private void cmdRemoveEmployee_Click(object sender, EventArgs e)
        {
            bool frmrem = true;
            Form Frm = new FrmEmployee(frmrem);
            Frm.Show();
        }

        private void cmdAddProduct_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmProduct();
            Frm.Show();
        }

        private void cmdRemoveProduct_Click(object sender, EventArgs e)
        {
            bool frmrem = true;
            Form Frm = new FrmProduct(frmrem);
            Frm.Show();
        }

        private void cmdReserve_Click(object sender, EventArgs e)
        {
            Form Frm = new FrmPatron();
            Frm.Show();
        }

        private void cmdPurchaseProduct_Click(object sender, EventArgs e)
        {
            string editprd = "edit";
            Form Frm = new FrmProduct(editprd);
            Frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string editsupplier = "edit";
            Form Frm = new FrmSupplier(editsupplier);
            Frm.Show();
        }

        private void cmdEditEmployee_Click(object sender, EventArgs e)
        {
            string editemployee = "edit";
            Form Frm = new FrmEmployee(editemployee);
            Frm.Show();
        }

        private void cmdEditMenu_Click(object sender, EventArgs e)
        {
            string editmenu = "edit";
            Form Frm = new FrmMenu(editmenu);
            Frm.Show();
        }

        private void FrmMaster_Load(object sender, EventArgs e)
        {

        }
    }
}
