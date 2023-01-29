﻿namespace Application
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProduct = new System.Windows.Forms.TabPage();
            this.buttonViewAllProducts = new System.Windows.Forms.Button();
            this.richTextBoxProduct = new System.Windows.Forms.RichTextBox();
            this.textBoxCategoryID = new System.Windows.Forms.TextBox();
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
            this.pictureBoxStoreMap = new System.Windows.Forms.PictureBox();
            this.buttonViewAllStore = new System.Windows.Forms.Button();
            this.richTextBoxStore = new System.Windows.Forms.RichTextBox();
            this.pictureBoxStore = new System.Windows.Forms.PictureBox();
            this.textBoxStoreID = new System.Windows.Forms.TextBox();
            this.textBoxStoreRegionName = new System.Windows.Forms.TextBox();
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.textBoxStoreCity = new System.Windows.Forms.TextBox();
            this.textBoxStoreAddress = new System.Windows.Forms.TextBox();
            this.buttonStoreAdd = new System.Windows.Forms.Button();
            this.buttonStoreFind = new System.Windows.Forms.Button();
            this.buttonStoreUpdate = new System.Windows.Forms.Button();
            this.buttonStoreDelete = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxICA)).BeginInit();
            this.tabStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStoreMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStore)).BeginInit();
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
            this.tabProduct.Controls.Add(this.buttonViewAllProducts);
            this.tabProduct.Controls.Add(this.richTextBoxProduct);
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
            // buttonViewAllProducts
            // 
            this.buttonViewAllProducts.Location = new System.Drawing.Point(312, 257);
            this.buttonViewAllProducts.Name = "buttonViewAllProducts";
            this.buttonViewAllProducts.Size = new System.Drawing.Size(109, 23);
            this.buttonViewAllProducts.TabIndex = 11;
            this.buttonViewAllProducts.Text = "View all";
            this.buttonViewAllProducts.UseVisualStyleBackColor = true;
            this.buttonViewAllProducts.Click += new System.EventHandler(this.buttonViewAllProducts_Click);
            // 
            // richTextBoxProduct
            // 
            this.richTextBoxProduct.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxProduct.Location = new System.Drawing.Point(40, 140);
            this.richTextBoxProduct.Name = "richTextBoxProduct";
            this.richTextBoxProduct.ReadOnly = true;
            this.richTextBoxProduct.Size = new System.Drawing.Size(662, 96);
            this.richTextBoxProduct.TabIndex = 10;
            this.richTextBoxProduct.Text = "";
            // 
            // textBoxCategoryID
            // 
            this.textBoxCategoryID.Location = new System.Drawing.Point(602, 315);
            this.textBoxCategoryID.Name = "textBoxCategoryID";
            this.textBoxCategoryID.PlaceholderText = "Category ID:";
            this.textBoxCategoryID.Size = new System.Drawing.Size(100, 23);
            this.textBoxCategoryID.TabIndex = 9;
            // 
            // pictureBoxICA
            // 
            this.pictureBoxICA.Image = global::Application.Properties.Resources.ICA;
            this.pictureBoxICA.Location = new System.Drawing.Point(312, 0);
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
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonProductDelete_Click);
            // 
            // buttonUpdateProduct
            // 
            this.buttonUpdateProduct.Location = new System.Drawing.Point(410, 359);
            this.buttonUpdateProduct.Name = "buttonUpdateProduct";
            this.buttonUpdateProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonUpdateProduct.TabIndex = 6;
            this.buttonUpdateProduct.Text = "Update";
            this.buttonUpdateProduct.UseVisualStyleBackColor = true;
            this.buttonUpdateProduct.Click += new System.EventHandler(this.buttonProductUpdate_Click);
            // 
            // buttonFindProduct
            // 
            this.buttonFindProduct.Location = new System.Drawing.Point(220, 359);
            this.buttonFindProduct.Name = "buttonFindProduct";
            this.buttonFindProduct.Size = new System.Drawing.Size(100, 23);
            this.buttonFindProduct.TabIndex = 5;
            this.buttonFindProduct.Text = "Find";
            this.buttonFindProduct.UseVisualStyleBackColor = true;
            this.buttonFindProduct.Click += new System.EventHandler(this.buttonFindProduct_Click);
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
            this.tabStore.Controls.Add(this.buttonStoreDelete);
            this.tabStore.Controls.Add(this.buttonStoreUpdate);
            this.tabStore.Controls.Add(this.buttonStoreFind);
            this.tabStore.Controls.Add(this.buttonStoreAdd);
            this.tabStore.Controls.Add(this.textBoxStoreAddress);
            this.tabStore.Controls.Add(this.textBoxStoreCity);
            this.tabStore.Controls.Add(this.textBoxStoreName);
            this.tabStore.Controls.Add(this.textBoxStoreRegionName);
            this.tabStore.Controls.Add(this.textBoxStoreID);
            this.tabStore.Controls.Add(this.pictureBoxStoreMap);
            this.tabStore.Controls.Add(this.buttonViewAllStore);
            this.tabStore.Controls.Add(this.richTextBoxStore);
            this.tabStore.Controls.Add(this.pictureBoxStore);
            this.tabStore.Location = new System.Drawing.Point(4, 24);
            this.tabStore.Name = "tabStore";
            this.tabStore.Padding = new System.Windows.Forms.Padding(3);
            this.tabStore.Size = new System.Drawing.Size(775, 420);
            this.tabStore.TabIndex = 4;
            this.tabStore.Text = "Store";
            this.tabStore.UseVisualStyleBackColor = true;
            // 
            // pictureBoxStoreMap
            // 
            this.pictureBoxStoreMap.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxStoreMap.Image")));
            this.pictureBoxStoreMap.Location = new System.Drawing.Point(397, 18);
            this.pictureBoxStoreMap.Name = "pictureBoxStoreMap";
            this.pictureBoxStoreMap.Size = new System.Drawing.Size(324, 181);
            this.pictureBoxStoreMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStoreMap.TabIndex = 13;
            this.pictureBoxStoreMap.TabStop = false;
            // 
            // buttonViewAllStore
            // 
            this.buttonViewAllStore.Location = new System.Drawing.Point(492, 212);
            this.buttonViewAllStore.Name = "buttonViewAllStore";
            this.buttonViewAllStore.Size = new System.Drawing.Size(109, 23);
            this.buttonViewAllStore.TabIndex = 12;
            this.buttonViewAllStore.Text = "View all";
            this.buttonViewAllStore.UseVisualStyleBackColor = true;
            // 
            // richTextBoxStore
            // 
            this.richTextBoxStore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxStore.Location = new System.Drawing.Point(377, 241);
            this.richTextBoxStore.Name = "richTextBoxStore";
            this.richTextBoxStore.ReadOnly = true;
            this.richTextBoxStore.Size = new System.Drawing.Size(365, 158);
            this.richTextBoxStore.TabIndex = 11;
            this.richTextBoxStore.Text = "";
            // 
            // pictureBoxStore
            // 
            this.pictureBoxStore.Image = global::Application.Properties.Resources.ICA;
            this.pictureBoxStore.Location = new System.Drawing.Point(17, 18);
            this.pictureBoxStore.Name = "pictureBoxStore";
            this.pictureBoxStore.Size = new System.Drawing.Size(123, 86);
            this.pictureBoxStore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStore.TabIndex = 9;
            this.pictureBoxStore.TabStop = false;
            // 
            // textBoxStoreID
            // 
            this.textBoxStoreID.Location = new System.Drawing.Point(17, 148);
            this.textBoxStoreID.Name = "textBoxStoreID";
            this.textBoxStoreID.PlaceholderText = "Supermarket ID:";
            this.textBoxStoreID.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreID.TabIndex = 14;
            // 
            // textBoxStoreRegionName
            // 
            this.textBoxStoreRegionName.Location = new System.Drawing.Point(17, 187);
            this.textBoxStoreRegionName.Name = "textBoxStoreRegionName";
            this.textBoxStoreRegionName.PlaceholderText = "Region name:";
            this.textBoxStoreRegionName.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreRegionName.TabIndex = 15;
            // 
            // textBoxStoreName
            // 
            this.textBoxStoreName.Location = new System.Drawing.Point(17, 228);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.PlaceholderText = "Store name:";
            this.textBoxStoreName.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreName.TabIndex = 16;
            // 
            // textBoxStoreCity
            // 
            this.textBoxStoreCity.Location = new System.Drawing.Point(17, 272);
            this.textBoxStoreCity.Name = "textBoxStoreCity";
            this.textBoxStoreCity.PlaceholderText = "City:";
            this.textBoxStoreCity.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreCity.TabIndex = 17;
            // 
            // textBoxStoreAddress
            // 
            this.textBoxStoreAddress.Location = new System.Drawing.Point(17, 311);
            this.textBoxStoreAddress.Name = "textBoxStoreAddress";
            this.textBoxStoreAddress.PlaceholderText = "Address:";
            this.textBoxStoreAddress.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreAddress.TabIndex = 18;
            // 
            // buttonStoreAdd
            // 
            this.buttonStoreAdd.Location = new System.Drawing.Point(6, 376);
            this.buttonStoreAdd.Name = "buttonStoreAdd";
            this.buttonStoreAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreAdd.TabIndex = 19;
            this.buttonStoreAdd.Text = "Add";
            this.buttonStoreAdd.UseVisualStyleBackColor = true;
            // 
            // buttonStoreFind
            // 
            this.buttonStoreFind.Location = new System.Drawing.Point(98, 376);
            this.buttonStoreFind.Name = "buttonStoreFind";
            this.buttonStoreFind.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreFind.TabIndex = 20;
            this.buttonStoreFind.Text = "Find";
            this.buttonStoreFind.UseVisualStyleBackColor = true;
            // 
            // buttonStoreUpdate
            // 
            this.buttonStoreUpdate.Location = new System.Drawing.Point(194, 376);
            this.buttonStoreUpdate.Name = "buttonStoreUpdate";
            this.buttonStoreUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreUpdate.TabIndex = 21;
            this.buttonStoreUpdate.Text = "Update";
            this.buttonStoreUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonStoreDelete
            // 
            this.buttonStoreDelete.Location = new System.Drawing.Point(287, 376);
            this.buttonStoreDelete.Name = "buttonStoreDelete";
            this.buttonStoreDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreDelete.TabIndex = 22;
            this.buttonStoreDelete.Text = "Delete";
            this.buttonStoreDelete.UseVisualStyleBackColor = true;
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
            this.tabStore.ResumeLayout(false);
            this.tabStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStoreMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStore)).EndInit();
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
        private RichTextBox richTextBoxProduct;
        private Button buttonViewAllProducts;
        private PictureBox pictureBoxStore;
        private Button buttonViewAllStore;
        private RichTextBox richTextBoxStore;
        private PictureBox pictureBoxStoreMap;
        private Button buttonStoreDelete;
        private Button buttonStoreUpdate;
        private Button buttonStoreFind;
        private Button buttonStoreAdd;
        private TextBox textBoxStoreAddress;
        private TextBox textBoxStoreCity;
        private TextBox textBoxStoreName;
        private TextBox textBoxStoreRegionName;
        private TextBox textBoxStoreID;
    }
}