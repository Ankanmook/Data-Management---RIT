namespace Restaurant
{
    partial class frmBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvFinalBill = new System.Windows.Forms.DataGridView();
            this.CmdPay = new System.Windows.Forms.Button();
            this.restaurantDataSet = new Restaurant.RestaurantDataSet();
            this.orderedItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.orderedItemTableAdapter = new Restaurant.RestaurantDataSetTableAdapters.OrderedItemTableAdapter();
            this.menuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuTableAdapter = new Restaurant.RestaurantDataSetTableAdapters.MenuTableAdapter();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtTip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderId = new System.Windows.Forms.TextBox();
            this.txtCreditCardNumber = new System.Windows.Forms.TextBox();
            this.txtPatron = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderedItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFinalBill
            // 
            this.dgvFinalBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFinalBill.Location = new System.Drawing.Point(36, 55);
            this.dgvFinalBill.Name = "dgvFinalBill";
            this.dgvFinalBill.Size = new System.Drawing.Size(544, 185);
            this.dgvFinalBill.TabIndex = 0;
            // 
            // CmdPay
            // 
            this.CmdPay.Location = new System.Drawing.Point(505, 379);
            this.CmdPay.Name = "CmdPay";
            this.CmdPay.Size = new System.Drawing.Size(75, 23);
            this.CmdPay.TabIndex = 1;
            this.CmdPay.Text = "Pay";
            this.CmdPay.UseVisualStyleBackColor = true;
            this.CmdPay.Click += new System.EventHandler(this.CmdPay_Click);
            // 
            // restaurantDataSet
            // 
            this.restaurantDataSet.DataSetName = "RestaurantDataSet";
            this.restaurantDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // orderedItemBindingSource
            // 
            this.orderedItemBindingSource.DataMember = "OrderedItem";
            this.orderedItemBindingSource.DataSource = this.restaurantDataSet;
            // 
            // orderedItemTableAdapter
            // 
            this.orderedItemTableAdapter.ClearBeforeFill = true;
            // 
            // menuBindingSource
            // 
            this.menuBindingSource.DataMember = "Menu";
            this.menuBindingSource.DataSource = this.restaurantDataSet;
            // 
            // menuTableAdapter
            // 
            this.menuTableAdapter.ClearBeforeFill = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(480, 262);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(100, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // txtTip
            // 
            this.txtTip.Location = new System.Drawing.Point(480, 305);
            this.txtTip.Name = "txtTip";
            this.txtTip.Size = new System.Drawing.Size(100, 20);
            this.txtTip.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(364, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Amount :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tip :";
            // 
            // txtOrderId
            // 
            this.txtOrderId.Enabled = false;
            this.txtOrderId.Location = new System.Drawing.Point(36, 28);
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.Size = new System.Drawing.Size(100, 20);
            this.txtOrderId.TabIndex = 6;
            this.txtOrderId.Text = "Meal Order :";
            // 
            // txtCreditCardNumber
            // 
            this.txtCreditCardNumber.Enabled = false;
            this.txtCreditCardNumber.Location = new System.Drawing.Point(138, 299);
            this.txtCreditCardNumber.Name = "txtCreditCardNumber";
            this.txtCreditCardNumber.Size = new System.Drawing.Size(130, 20);
            this.txtCreditCardNumber.TabIndex = 7;
            // 
            // txtPatron
            // 
            this.txtPatron.Enabled = false;
            this.txtPatron.Location = new System.Drawing.Point(138, 262);
            this.txtPatron.Name = "txtPatron";
            this.txtPatron.Size = new System.Drawing.Size(130, 20);
            this.txtPatron.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Customer :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Credit Card Number :";
            // 
            // frmBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 427);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPatron);
            this.Controls.Add(this.txtCreditCardNumber);
            this.Controls.Add(this.txtOrderId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTip);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.CmdPay);
            this.Controls.Add(this.dgvFinalBill);
            this.Name = "frmBill";
            this.Text = "Bill";
            this.Load += new System.EventHandler(this.Bill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFinalBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restaurantDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderedItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFinalBill;
        private System.Windows.Forms.Button CmdPay;
        private RestaurantDataSet restaurantDataSet;
        private System.Windows.Forms.BindingSource orderedItemBindingSource;
        private RestaurantDataSetTableAdapters.OrderedItemTableAdapter orderedItemTableAdapter;
        private System.Windows.Forms.BindingSource menuBindingSource;
        private RestaurantDataSetTableAdapters.MenuTableAdapter menuTableAdapter;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderId;
        private System.Windows.Forms.TextBox txtCreditCardNumber;
        private System.Windows.Forms.TextBox txtPatron;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}