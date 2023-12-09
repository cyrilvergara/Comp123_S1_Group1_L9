namespace Comp123_S1_Group1_L9
{
    partial class OrderForm
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
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.lblCustomerDetails = new System.Windows.Forms.Label();
            this.lblMenuItem = new System.Windows.Forms.Label();
            this.lblAddition = new System.Windows.Forms.Label();
            this.cbxMenuItem = new System.Windows.Forms.ComboBox();
            this.cbxAddition1 = new System.Windows.Forms.ComboBox();
            this.cbxAddition2 = new System.Windows.Forms.ComboBox();
            this.cbxAddition3 = new System.Windows.Forms.ComboBox();
            this.cbxAddition4 = new System.Windows.Forms.ComboBox();
            this.lblOrderItemsTitle = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbxOrderItems = new System.Windows.Forms.ListBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Location = new System.Drawing.Point(54, 63);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(104, 25);
            this.lblCustomerTitle.TabIndex = 0;
            this.lblCustomerTitle.Text = "Customer";
            // 
            // lblCustomerDetails
            // 
            this.lblCustomerDetails.AutoSize = true;
            this.lblCustomerDetails.Location = new System.Drawing.Point(54, 115);
            this.lblCustomerDetails.Name = "lblCustomerDetails";
            this.lblCustomerDetails.Size = new System.Drawing.Size(176, 25);
            this.lblCustomerDetails.TabIndex = 1;
            this.lblCustomerDetails.Text = "Customer Details";
            // 
            // lblMenuItem
            // 
            this.lblMenuItem.AutoSize = true;
            this.lblMenuItem.Location = new System.Drawing.Point(54, 230);
            this.lblMenuItem.Name = "lblMenuItem";
            this.lblMenuItem.Size = new System.Drawing.Size(112, 25);
            this.lblMenuItem.TabIndex = 2;
            this.lblMenuItem.Text = "Menu Item";
            // 
            // lblAddition
            // 
            this.lblAddition.AutoSize = true;
            this.lblAddition.Location = new System.Drawing.Point(57, 308);
            this.lblAddition.Name = "lblAddition";
            this.lblAddition.Size = new System.Drawing.Size(101, 25);
            this.lblAddition.TabIndex = 3;
            this.lblAddition.Text = "Additions";
            // 
            // cbxMenuItem
            // 
            this.cbxMenuItem.FormattingEnabled = true;
            this.cbxMenuItem.Location = new System.Drawing.Point(189, 230);
            this.cbxMenuItem.Name = "cbxMenuItem";
            this.cbxMenuItem.Size = new System.Drawing.Size(529, 33);
            this.cbxMenuItem.TabIndex = 4;
            this.cbxMenuItem.SelectedIndexChanged += new System.EventHandler(this.cbxMenuItem_SelectedIndexChanged);
            // 
            // cbxAddition1
            // 
            this.cbxAddition1.FormattingEnabled = true;
            this.cbxAddition1.Location = new System.Drawing.Point(189, 300);
            this.cbxAddition1.Name = "cbxAddition1";
            this.cbxAddition1.Size = new System.Drawing.Size(529, 33);
            this.cbxAddition1.TabIndex = 5;
            // 
            // cbxAddition2
            // 
            this.cbxAddition2.FormattingEnabled = true;
            this.cbxAddition2.Location = new System.Drawing.Point(189, 375);
            this.cbxAddition2.Name = "cbxAddition2";
            this.cbxAddition2.Size = new System.Drawing.Size(529, 33);
            this.cbxAddition2.TabIndex = 6;
            // 
            // cbxAddition3
            // 
            this.cbxAddition3.FormattingEnabled = true;
            this.cbxAddition3.Location = new System.Drawing.Point(189, 452);
            this.cbxAddition3.Name = "cbxAddition3";
            this.cbxAddition3.Size = new System.Drawing.Size(529, 33);
            this.cbxAddition3.TabIndex = 7;
            // 
            // cbxAddition4
            // 
            this.cbxAddition4.FormattingEnabled = true;
            this.cbxAddition4.Location = new System.Drawing.Point(189, 528);
            this.cbxAddition4.Name = "cbxAddition4";
            this.cbxAddition4.Size = new System.Drawing.Size(529, 33);
            this.cbxAddition4.TabIndex = 8;
            // 
            // lblOrderItemsTitle
            // 
            this.lblOrderItemsTitle.AutoSize = true;
            this.lblOrderItemsTitle.Location = new System.Drawing.Point(762, 63);
            this.lblOrderItemsTitle.Name = "lblOrderItemsTitle";
            this.lblOrderItemsTitle.Size = new System.Drawing.Size(123, 25);
            this.lblOrderItemsTitle.TabIndex = 9;
            this.lblOrderItemsTitle.Text = "Order Items";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(762, 680);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(103, 25);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Total: $0-";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(189, 608);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(171, 62);
            this.btnAddItem.TabIndex = 11;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(59, 748);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(171, 62);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 748);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(171, 62);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbxOrderItems
            // 
            this.lbxOrderItems.FormattingEnabled = true;
            this.lbxOrderItems.HorizontalScrollbar = true;
            this.lbxOrderItems.ItemHeight = 25;
            this.lbxOrderItems.Location = new System.Drawing.Point(767, 127);
            this.lbxOrderItems.Name = "lbxOrderItems";
            this.lbxOrderItems.Size = new System.Drawing.Size(530, 504);
            this.lbxOrderItems.TabIndex = 14;
            this.lbxOrderItems.SelectedIndexChanged += new System.EventHandler(this.lbxOrderItems_SelectedIndexChanged);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(1126, 661);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(171, 62);
            this.btnRemoveItem.TabIndex = 15;
            this.btnRemoveItem.Text = "Remove Item";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 853);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.lbxOrderItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblOrderItemsTitle);
            this.Controls.Add(this.cbxAddition4);
            this.Controls.Add(this.cbxAddition3);
            this.Controls.Add(this.cbxAddition2);
            this.Controls.Add(this.cbxAddition1);
            this.Controls.Add(this.cbxMenuItem);
            this.Controls.Add(this.lblAddition);
            this.Controls.Add(this.lblMenuItem);
            this.Controls.Add(this.lblCustomerDetails);
            this.Controls.Add(this.lblCustomerTitle);
            this.Name = "OrderForm";
            this.Text = "OrderForm";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerTitle;
        private System.Windows.Forms.Label lblCustomerDetails;
        private System.Windows.Forms.Label lblMenuItem;
        private System.Windows.Forms.Label lblAddition;
        private System.Windows.Forms.ComboBox cbxMenuItem;
        private System.Windows.Forms.ComboBox cbxAddition1;
        private System.Windows.Forms.ComboBox cbxAddition2;
        private System.Windows.Forms.ComboBox cbxAddition3;
        private System.Windows.Forms.ComboBox cbxAddition4;
        private System.Windows.Forms.Label lblOrderItemsTitle;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lbxOrderItems;
        private System.Windows.Forms.Button btnRemoveItem;
    }
}