namespace Application
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.pictureBoxICA = new System.Windows.Forms.PictureBox();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonUpdateProduct = new System.Windows.Forms.Button();
            this.buttonFindProduct = new System.Windows.Forms.Button();
            this.buttonCreateProduct = new System.Windows.Forms.Button();
            this.textBoxProductPrice = new System.Windows.Forms.TextBox();
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.tabProductCategory = new System.Windows.Forms.TabPage();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.textBoxCategoryID = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxICA)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabProduct);
            this.tabControl1.Controls.Add(this.tabProductCategory);
            this.tabControl1.Controls.Add(this.tabOrder);
            this.tabControl1.Controls.Add(this.tabCustomer);
            this.tabControl1.Controls.Add(this.tabStore);
            this.tabControl1.Location = new System.Drawing.Point(5, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(783, 448);
            this.tabControl1.TabIndex = 0;
            // 
            // tabProduct
            // 
            this.tabProduct.Controls.Add(this.textBoxCategoryID);
            this.tabProduct.Controls.Add(this.pictureBoxICA);
            this.tabProduct.Controls.Add(this.buttonDeleteProduct);
            this.tabProduct.Controls.Add(this.buttonUpdateProduct);
            this.tabProduct.Controls.Add(this.buttonFindProduct);
            this.tabProduct.Controls.Add(this.buttonCreateProduct);
            this.tabProduct.Controls.Add(this.textBoxProductPrice);
            this.tabProduct.Controls.Add(this.textBoxProductID);
            this.tabProduct.Controls.Add(this.textBoxProductName);
            this.tabProduct.Location = new System.Drawing.Point(4, 24);
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Padding = new System.Windows.Forms.Padding(3);
            this.tabProduct.Size = new System.Drawing.Size(775, 420);
            this.tabProduct.TabIndex = 0;
            this.tabProduct.Text = "Product";
            this.tabProduct.UseVisualStyleBackColor = true;
            // 
            // pictureBoxICA
            // 
            this.pictureBoxICA.Image = global::Application.Properties.Resources.ICA;
            this.pictureBoxICA.Location = new System.Drawing.Point(652, 0);
            this.pictureBoxICA.Name = "pictureBoxICA";
            this.pictureBoxICA.Size = new System.Drawing.Size(123, 86);
            this.pictureBoxICA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxICA.TabIndex = 8;
            this.pictureBoxICA.TabStop = false;
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(602, 359);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteProduct.TabIndex = 7;
            this.buttonDeleteProduct.Text = "Delete";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateProduct
            // 
            this.buttonUpdateProduct.Location = new System.Drawing.Point(410, 359);
            this.buttonUpdateProduct.Name = "buttonUpdateProduct";
            this.buttonUpdateProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateProduct.TabIndex = 6;
            this.buttonUpdateProduct.Text = "Update";
            this.buttonUpdateProduct.UseVisualStyleBackColor = true;
            // 
            // buttonFindProduct
            // 
            this.buttonFindProduct.Location = new System.Drawing.Point(220, 359);
            this.buttonFindProduct.Name = "buttonFindProduct";
            this.buttonFindProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonFindProduct.TabIndex = 5;
            this.buttonFindProduct.Text = "Find";
            this.buttonFindProduct.UseVisualStyleBackColor = true;
            // 
            // buttonCreateProduct
            // 
            this.buttonCreateProduct.Location = new System.Drawing.Point(40, 359);
            this.buttonCreateProduct.Name = "buttonCreateProduct";
            this.buttonCreateProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonCreateProduct.TabIndex = 4;
            this.buttonCreateProduct.Text = "Create";
            this.buttonCreateProduct.UseVisualStyleBackColor = true;
            this.buttonCreateProduct.Click += new System.EventHandler(this.buttonProductAdd_Click);
            // 
            // textBoxProductPrice
            // 
            this.textBoxProductPrice.Location = new System.Drawing.Point(410, 315);
            this.textBoxProductPrice.Name = "textBoxProductPrice";
            this.textBoxProductPrice.PlaceholderText = "Product Price:";
            this.textBoxProductPrice.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductPrice.TabIndex = 2;
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.Location = new System.Drawing.Point(220, 315);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.PlaceholderText = "Product ID:";
            this.textBoxProductID.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductID.TabIndex = 1;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(40, 315);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.PlaceholderText = "Product Name:";
            this.textBoxProductName.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductName.TabIndex = 0;
            // 
            // tabProductCategory
            // 
            this.tabProductCategory.Location = new System.Drawing.Point(4, 24);
            this.tabProductCategory.Name = "tabProductCategory";
            this.tabProductCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductCategory.Size = new System.Drawing.Size(775, 420);
            this.tabProductCategory.TabIndex = 1;
            this.tabProductCategory.Text = "Product Category";
            this.tabProductCategory.UseVisualStyleBackColor = true;
            // 
            // tabOrder
            // 
            this.tabOrder.Location = new System.Drawing.Point(4, 24);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(775, 420);
            this.tabOrder.TabIndex = 2;
            this.tabOrder.Text = "Order";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Location = new System.Drawing.Point(4, 24);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(775, 420);
            this.tabCustomer.TabIndex = 3;
            this.tabCustomer.Text = "Customer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // tabStore
            // 
            this.tabStore.Location = new System.Drawing.Point(4, 24);
            this.tabStore.Name = "tabStore";
            this.tabStore.Padding = new System.Windows.Forms.Padding(3);
            this.tabStore.Size = new System.Drawing.Size(775, 420);
            this.tabStore.TabIndex = 4;
            this.tabStore.Text = "Store";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // textBoxCategoryID
            // 
            this.textBoxCategoryID.Location = new System.Drawing.Point(602, 315);
            this.textBoxCategoryID.Name = "textBoxCategoryID";
            this.textBoxCategoryID.PlaceholderText = "Category ID:";
            this.textBoxCategoryID.Size = new System.Drawing.Size(100, 23);
            this.textBoxCategoryID.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 453);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ICA Store";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabProduct.ResumeLayout(false);
            this.tabProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxICA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabProduct;
        private TabPage tabProductCategory;
        private TabPage tabOrder;
        private TabPage tabCustomer;
        private TextBox textBoxProductPrice;
        private TextBox textBoxProductID;
        private TextBox textBoxProductName;
        private TabPage tabStore;
        private Button buttonFindProduct;
        private Button buttonCreateProduct;
        private PictureBox pictureBoxICA;
        private Button buttonDeleteProduct;
        private Button buttonUpdateProduct;
        private TextBox textBoxCategoryID;
    }
}