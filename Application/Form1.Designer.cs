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
            this.buttonViewAllProductCategory = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.richTextBoxProductCategory = new System.Windows.Forms.RichTextBox();
            this.textBoxProductCategoryName = new System.Windows.Forms.TextBox();
            this.textBoxProductCategoryID = new System.Windows.Forms.TextBox();
            this.buttonProductCategoryDelete = new System.Windows.Forms.Button();
            this.buttonFindProductCategory = new System.Windows.Forms.Button();
            this.buttonProductCategoryUpdate = new System.Windows.Forms.Button();
            this.buttonCreateProductCategory = new System.Windows.Forms.Button();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.BtnViewAllOrders = new System.Windows.Forms.Button();
            this.BtnDeleteOrder = new System.Windows.Forms.Button();
            this.BtnUpdateOrder = new System.Windows.Forms.Button();
            this.BtnFindOrder = new System.Windows.Forms.Button();
            this.BtnCreateOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Store = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxSupermarketID = new System.Windows.Forms.ComboBox();
            this.comboBoxCustomerID = new System.Windows.Forms.ComboBox();
            this.OrderDate = new System.Windows.Forms.DateTimePicker();
            this.OrderOrderID = new System.Windows.Forms.TextBox();
            this.comboBoxProductID = new System.Windows.Forms.ComboBox();
            this.OrderTextBox = new System.Windows.Forms.RichTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.buttonAddCostumer = new System.Windows.Forms.Button();
            this.buttonFindCostumer = new System.Windows.Forms.Button();
            this.buttonDeleteCostumer = new System.Windows.Forms.Button();
            this.buttonUpdateCostumer = new System.Windows.Forms.Button();
            this.textBoxCostumerUserName = new System.Windows.Forms.TextBox();
            this.textBoxCostumerAddress = new System.Windows.Forms.TextBox();
            this.textBoxCostumerPhoneNumber = new System.Windows.Forms.TextBox();
            this.textBoxCostumerMail = new System.Windows.Forms.TextBox();
            this.textBoxCostumerName = new System.Windows.Forms.TextBox();
            this.buttonViewAllCostumers = new System.Windows.Forms.Button();
            this.richTextBoxCostumer = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabStore = new System.Windows.Forms.TabPage();
            this.buttonStoreDelete = new System.Windows.Forms.Button();
            this.buttonStoreUpdate = new System.Windows.Forms.Button();
            this.buttonStoreFind = new System.Windows.Forms.Button();
            this.buttonStoreAdd = new System.Windows.Forms.Button();
            this.textBoxStoreAddress = new System.Windows.Forms.TextBox();
            this.textBoxStoreCity = new System.Windows.Forms.TextBox();
            this.textBoxStoreName = new System.Windows.Forms.TextBox();
            this.textBoxStoreRegionName = new System.Windows.Forms.TextBox();
            this.textBoxStoreID = new System.Windows.Forms.TextBox();
            this.pictureBoxStoreMap = new System.Windows.Forms.PictureBox();
            this.buttonViewAllStore = new System.Windows.Forms.Button();
            this.richTextBoxStore = new System.Windows.Forms.RichTextBox();
            this.pictureBoxStore = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxICA)).BeginInit();
            this.tabProductCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.tabCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.tabProductCategory.Controls.Add(this.buttonViewAllProductCategory);
            this.tabProductCategory.Controls.Add(this.pictureBox3);
            this.tabProductCategory.Controls.Add(this.richTextBoxProductCategory);
            this.tabProductCategory.Controls.Add(this.textBoxProductCategoryName);
            this.tabProductCategory.Controls.Add(this.textBoxProductCategoryID);
            this.tabProductCategory.Controls.Add(this.buttonProductCategoryDelete);
            this.tabProductCategory.Controls.Add(this.buttonFindProductCategory);
            this.tabProductCategory.Controls.Add(this.buttonProductCategoryUpdate);
            this.tabProductCategory.Controls.Add(this.buttonCreateProductCategory);
            this.tabProductCategory.Location = new System.Drawing.Point(4, 24);
            this.tabProductCategory.Name = "tabProductCategory";
            this.tabProductCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductCategory.Size = new System.Drawing.Size(775, 420);
            this.tabProductCategory.TabIndex = 1;
            this.tabProductCategory.Text = "Product Category";
            this.tabProductCategory.UseVisualStyleBackColor = true;
            // 
            // buttonViewAllProductCategory
            // 
            this.buttonViewAllProductCategory.Location = new System.Drawing.Point(308, 234);
            this.buttonViewAllProductCategory.Name = "buttonViewAllProductCategory";
            this.buttonViewAllProductCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonViewAllProductCategory.TabIndex = 10;
            this.buttonViewAllProductCategory.Text = "View All";
            this.buttonViewAllProductCategory.UseVisualStyleBackColor = true;
            this.buttonViewAllProductCategory.Click += new System.EventHandler(this.buttonViewAllProductCategory_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Application.Properties.Resources.ICA;
            this.pictureBox3.Location = new System.Drawing.Point(308, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(123, 86);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // richTextBoxProductCategory
            // 
            this.richTextBoxProductCategory.Location = new System.Drawing.Point(45, 132);
            this.richTextBoxProductCategory.Name = "richTextBoxProductCategory";
            this.richTextBoxProductCategory.Size = new System.Drawing.Size(628, 96);
            this.richTextBoxProductCategory.TabIndex = 6;
            this.richTextBoxProductCategory.Text = "";
            // 
            // textBoxProductCategoryName
            // 
            this.textBoxProductCategoryName.Location = new System.Drawing.Point(405, 275);
            this.textBoxProductCategoryName.Name = "textBoxProductCategoryName";
            this.textBoxProductCategoryName.PlaceholderText = "Name:";
            this.textBoxProductCategoryName.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductCategoryName.TabIndex = 5;
            // 
            // textBoxProductCategoryID
            // 
            this.textBoxProductCategoryID.Location = new System.Drawing.Point(190, 275);
            this.textBoxProductCategoryID.Name = "textBoxProductCategoryID";
            this.textBoxProductCategoryID.PlaceholderText = "ID:";
            this.textBoxProductCategoryID.Size = new System.Drawing.Size(100, 23);
            this.textBoxProductCategoryID.TabIndex = 4;
            // 
            // buttonProductCategoryDelete
            // 
            this.buttonProductCategoryDelete.Location = new System.Drawing.Point(598, 335);
            this.buttonProductCategoryDelete.Name = "buttonProductCategoryDelete";
            this.buttonProductCategoryDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonProductCategoryDelete.TabIndex = 3;
            this.buttonProductCategoryDelete.Text = "Delete";
            this.buttonProductCategoryDelete.UseVisualStyleBackColor = true;
            this.buttonProductCategoryDelete.Click += new System.EventHandler(this.buttonProductCategoryDelete_Click);
            // 
            // buttonFindProductCategory
            // 
            this.buttonFindProductCategory.Location = new System.Drawing.Point(199, 335);
            this.buttonFindProductCategory.Name = "buttonFindProductCategory";
            this.buttonFindProductCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonFindProductCategory.TabIndex = 2;
            this.buttonFindProductCategory.Text = "Find";
            this.buttonFindProductCategory.UseVisualStyleBackColor = true;
            this.buttonFindProductCategory.Click += new System.EventHandler(this.buttonFindProductCategory_Click);
            // 
            // buttonProductCategoryUpdate
            // 
            this.buttonProductCategoryUpdate.Location = new System.Drawing.Point(415, 335);
            this.buttonProductCategoryUpdate.Name = "buttonProductCategoryUpdate";
            this.buttonProductCategoryUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonProductCategoryUpdate.TabIndex = 1;
            this.buttonProductCategoryUpdate.Text = "Update";
            this.buttonProductCategoryUpdate.UseVisualStyleBackColor = true;
            this.buttonProductCategoryUpdate.Click += new System.EventHandler(this.buttonUpdateProductCategory_Click);
            // 
            // buttonCreateProductCategory
            // 
            this.buttonCreateProductCategory.Location = new System.Drawing.Point(45, 335);
            this.buttonCreateProductCategory.Name = "buttonCreateProductCategory";
            this.buttonCreateProductCategory.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateProductCategory.TabIndex = 0;
            this.buttonCreateProductCategory.Text = "Create";
            this.buttonCreateProductCategory.UseVisualStyleBackColor = true;
            this.buttonCreateProductCategory.Click += new System.EventHandler(this.buttonAddProductCategory_Click);
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.BtnViewAllOrders);
            this.tabOrder.Controls.Add(this.BtnDeleteOrder);
            this.tabOrder.Controls.Add(this.BtnUpdateOrder);
            this.tabOrder.Controls.Add(this.BtnFindOrder);
            this.tabOrder.Controls.Add(this.BtnCreateOrder);
            this.tabOrder.Controls.Add(this.label5);
            this.tabOrder.Controls.Add(this.Store);
            this.tabOrder.Controls.Add(this.label3);
            this.tabOrder.Controls.Add(this.label2);
            this.tabOrder.Controls.Add(this.label1);
            this.tabOrder.Controls.Add(this.comboBoxSupermarketID);
            this.tabOrder.Controls.Add(this.comboBoxCustomerID);
            this.tabOrder.Controls.Add(this.OrderDate);
            this.tabOrder.Controls.Add(this.OrderOrderID);
            this.tabOrder.Controls.Add(this.comboBoxProductID);
            this.tabOrder.Controls.Add(this.OrderTextBox);
            this.tabOrder.Controls.Add(this.pictureBox4);
            this.tabOrder.Location = new System.Drawing.Point(4, 24);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrder.Size = new System.Drawing.Size(775, 420);
            this.tabOrder.TabIndex = 2;
            this.tabOrder.Text = "Order";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // BtnViewAllOrders
            // 
            this.BtnViewAllOrders.Location = new System.Drawing.Point(608, 371);
            this.BtnViewAllOrders.Name = "BtnViewAllOrders";
            this.BtnViewAllOrders.Size = new System.Drawing.Size(75, 23);
            this.BtnViewAllOrders.TabIndex = 29;
            this.BtnViewAllOrders.Text = "View all";
            this.BtnViewAllOrders.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteOrder
            // 
            this.BtnDeleteOrder.Location = new System.Drawing.Point(472, 371);
            this.BtnDeleteOrder.Name = "BtnDeleteOrder";
            this.BtnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnDeleteOrder.TabIndex = 28;
            this.BtnDeleteOrder.Text = "Delete";
            this.BtnDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // BtnUpdateOrder
            // 
            this.BtnUpdateOrder.Location = new System.Drawing.Point(340, 371);
            this.BtnUpdateOrder.Name = "BtnUpdateOrder";
            this.BtnUpdateOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnUpdateOrder.TabIndex = 27;
            this.BtnUpdateOrder.Text = "Update";
            this.BtnUpdateOrder.UseVisualStyleBackColor = true;
            // 
            // BtnFindOrder
            // 
            this.BtnFindOrder.Location = new System.Drawing.Point(203, 371);
            this.BtnFindOrder.Name = "BtnFindOrder";
            this.BtnFindOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnFindOrder.TabIndex = 26;
            this.BtnFindOrder.Text = "Find";
            this.BtnFindOrder.UseVisualStyleBackColor = true;
            // 
            // BtnCreateOrder
            // 
            this.BtnCreateOrder.Location = new System.Drawing.Point(72, 371);
            this.BtnCreateOrder.Name = "BtnCreateOrder";
            this.BtnCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.BtnCreateOrder.TabIndex = 25;
            this.BtnCreateOrder.Text = "Create";
            this.BtnCreateOrder.UseVisualStyleBackColor = true;
            


            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(662, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Customer";
            // 
            // Store
            // 
            this.Store.AutoSize = true;
            this.Store.Location = new System.Drawing.Point(522, 303);
            this.Store.Name = "Store";
            this.Store.Size = new System.Drawing.Size(34, 15);
            this.Store.TabIndex = 23;
            this.Store.Text = "Store";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Order date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Order ID:";
            // 
            // comboBoxSupermarketID
            // 
            this.comboBoxSupermarketID.FormattingEnabled = true;
            this.comboBoxSupermarketID.Location = new System.Drawing.Point(511, 321);
            this.comboBoxSupermarketID.Name = "comboBoxSupermarketID";
            this.comboBoxSupermarketID.Size = new System.Drawing.Size(94, 23);
            this.comboBoxSupermarketID.TabIndex = 19;
            // 
            // comboBoxCustomerID
            // 
            this.comboBoxCustomerID.FormattingEnabled = true;
            this.comboBoxCustomerID.Location = new System.Drawing.Point(645, 321);
            this.comboBoxCustomerID.Name = "comboBoxCustomerID";
            this.comboBoxCustomerID.Size = new System.Drawing.Size(94, 23);
            this.comboBoxCustomerID.TabIndex = 18;
            // 
            // OrderDate
            // 
            this.OrderDate.Location = new System.Drawing.Point(168, 321);
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.Size = new System.Drawing.Size(174, 23);
            this.OrderDate.TabIndex = 17;
            // 
            // OrderOrderID
            // 
            this.OrderOrderID.Location = new System.Drawing.Point(36, 321);
            this.OrderOrderID.Name = "OrderOrderID";
            this.OrderOrderID.Size = new System.Drawing.Size(94, 23);
            this.OrderOrderID.TabIndex = 14;
            // 
            // comboBoxProductID
            // 
            this.comboBoxProductID.FormattingEnabled = true;
            this.comboBoxProductID.Location = new System.Drawing.Point(381, 321);
            this.comboBoxProductID.Name = "comboBoxProductID";
            this.comboBoxProductID.Size = new System.Drawing.Size(94, 23);
            this.comboBoxProductID.TabIndex = 13;
            // 
            // OrderTextBox
            // 
            this.OrderTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.OrderTextBox.Location = new System.Drawing.Point(63, 97);
            this.OrderTextBox.Name = "OrderTextBox";
            this.OrderTextBox.ReadOnly = true;
            this.OrderTextBox.Size = new System.Drawing.Size(645, 163);
            this.OrderTextBox.TabIndex = 12;
            this.OrderTextBox.Text = "";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Application.Properties.Resources.ICA;
            this.pictureBox4.Location = new System.Drawing.Point(315, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(123, 86);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.buttonAddCostumer);
            this.tabCustomer.Controls.Add(this.buttonFindCostumer);
            this.tabCustomer.Controls.Add(this.buttonDeleteCostumer);
            this.tabCustomer.Controls.Add(this.buttonUpdateCostumer);
            this.tabCustomer.Controls.Add(this.textBoxCostumerUserName);
            this.tabCustomer.Controls.Add(this.textBoxCostumerAddress);
            this.tabCustomer.Controls.Add(this.textBoxCostumerPhoneNumber);
            this.tabCustomer.Controls.Add(this.textBoxCostumerMail);
            this.tabCustomer.Controls.Add(this.textBoxCostumerName);
            this.tabCustomer.Controls.Add(this.buttonViewAllCostumers);
            this.tabCustomer.Controls.Add(this.richTextBoxCostumer);
            this.tabCustomer.Controls.Add(this.pictureBox2);
            this.tabCustomer.Controls.Add(this.pictureBox1);
            this.tabCustomer.Location = new System.Drawing.Point(4, 24);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(775, 420);
            this.tabCustomer.TabIndex = 3;
            this.tabCustomer.Text = "Customer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // buttonAddCostumer
            // 
            this.buttonAddCostumer.Location = new System.Drawing.Point(56, 369);
            this.buttonAddCostumer.Name = "buttonAddCostumer";
            this.buttonAddCostumer.Size = new System.Drawing.Size(109, 23);
            this.buttonAddCostumer.TabIndex = 21;
            this.buttonAddCostumer.Text = "Create";
            this.buttonAddCostumer.UseVisualStyleBackColor = true;
            this.buttonAddCostumer.Click += new System.EventHandler(this.buttonAddCostumer_Click);
            // 
            // buttonFindCostumer
            // 
            this.buttonFindCostumer.Location = new System.Drawing.Point(249, 369);
            this.buttonFindCostumer.Name = "buttonFindCostumer";
            this.buttonFindCostumer.Size = new System.Drawing.Size(109, 23);
            this.buttonFindCostumer.TabIndex = 20;
            this.buttonFindCostumer.Text = "Find";
            this.buttonFindCostumer.UseVisualStyleBackColor = true;
            this.buttonFindCostumer.Click += new System.EventHandler(this.buttonFindCostumer_Click);
            // 
            // buttonDeleteCostumer
            // 
            this.buttonDeleteCostumer.Location = new System.Drawing.Point(609, 369);
            this.buttonDeleteCostumer.Name = "buttonDeleteCostumer";
            this.buttonDeleteCostumer.Size = new System.Drawing.Size(109, 23);
            this.buttonDeleteCostumer.TabIndex = 19;
            this.buttonDeleteCostumer.Text = "Delete";
            this.buttonDeleteCostumer.UseVisualStyleBackColor = true;
            this.buttonDeleteCostumer.Click += new System.EventHandler(this.buttonDeleteCostumer_Click);
            // 
            // buttonUpdateCostumer
            // 
            this.buttonUpdateCostumer.Location = new System.Drawing.Point(440, 369);
            this.buttonUpdateCostumer.Name = "buttonUpdateCostumer";
            this.buttonUpdateCostumer.Size = new System.Drawing.Size(109, 23);
            this.buttonUpdateCostumer.TabIndex = 18;
            this.buttonUpdateCostumer.Text = "Update";
            this.buttonUpdateCostumer.UseVisualStyleBackColor = true;
            this.buttonUpdateCostumer.Click += new System.EventHandler(this.buttonUpdateCostumer_Click);
            // 
            // textBoxCostumerUserName
            // 
            this.textBoxCostumerUserName.Location = new System.Drawing.Point(182, 320);
            this.textBoxCostumerUserName.Name = "textBoxCostumerUserName";
            this.textBoxCostumerUserName.PlaceholderText = "User name:";
            this.textBoxCostumerUserName.Size = new System.Drawing.Size(100, 23);
            this.textBoxCostumerUserName.TabIndex = 17;
            // 
            // textBoxCostumerAddress
            // 
            this.textBoxCostumerAddress.Location = new System.Drawing.Point(333, 320);
            this.textBoxCostumerAddress.Name = "textBoxCostumerAddress";
            this.textBoxCostumerAddress.PlaceholderText = "Address:";
            this.textBoxCostumerAddress.Size = new System.Drawing.Size(100, 23);
            this.textBoxCostumerAddress.TabIndex = 16;
            // 
            // textBoxCostumerPhoneNumber
            // 
            this.textBoxCostumerPhoneNumber.Location = new System.Drawing.Point(475, 320);
            this.textBoxCostumerPhoneNumber.Name = "textBoxCostumerPhoneNumber";
            this.textBoxCostumerPhoneNumber.PlaceholderText = "Phone Number#";
            this.textBoxCostumerPhoneNumber.Size = new System.Drawing.Size(100, 23);
            this.textBoxCostumerPhoneNumber.TabIndex = 15;
            // 
            // textBoxCostumerMail
            // 
            this.textBoxCostumerMail.Location = new System.Drawing.Point(618, 320);
            this.textBoxCostumerMail.Name = "textBoxCostumerMail";
            this.textBoxCostumerMail.PlaceholderText = "E-mail:";
            this.textBoxCostumerMail.Size = new System.Drawing.Size(100, 23);
            this.textBoxCostumerMail.TabIndex = 14;
            // 
            // textBoxCostumerName
            // 
            this.textBoxCostumerName.Location = new System.Drawing.Point(56, 320);
            this.textBoxCostumerName.Name = "textBoxCostumerName";
            this.textBoxCostumerName.PlaceholderText = "Name:";
            this.textBoxCostumerName.Size = new System.Drawing.Size(100, 23);
            this.textBoxCostumerName.TabIndex = 13;
            // 
            // buttonViewAllCostumers
            // 
            this.buttonViewAllCostumers.Location = new System.Drawing.Point(324, 282);
            this.buttonViewAllCostumers.Name = "buttonViewAllCostumers";
            this.buttonViewAllCostumers.Size = new System.Drawing.Size(109, 23);
            this.buttonViewAllCostumers.TabIndex = 12;
            this.buttonViewAllCostumers.Text = "View all";
            this.buttonViewAllCostumers.UseVisualStyleBackColor = true;
            this.buttonViewAllCostumers.Click += new System.EventHandler(this.buttonViewAllCostumers_Click);
            // 
            // richTextBoxCostumer
            // 
            this.richTextBoxCostumer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxCostumer.Location = new System.Drawing.Point(56, 180);
            this.richTextBoxCostumer.Name = "richTextBoxCostumer";
            this.richTextBoxCostumer.ReadOnly = true;
            this.richTextBoxCostumer.Size = new System.Drawing.Size(662, 96);
            this.richTextBoxCostumer.TabIndex = 11;
            this.richTextBoxCostumer.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(310, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(123, 111);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Application.Properties.Resources.ICA;
            this.pictureBox1.Location = new System.Drawing.Point(310, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
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
            // buttonStoreDelete
            // 
            this.buttonStoreDelete.Location = new System.Drawing.Point(287, 376);
            this.buttonStoreDelete.Name = "buttonStoreDelete";
            this.buttonStoreDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreDelete.TabIndex = 22;
            this.buttonStoreDelete.Text = "Delete";
            this.buttonStoreDelete.UseVisualStyleBackColor = true;
            this.buttonStoreDelete.Click += new System.EventHandler(this.buttonStoreDelete_Click);
            // 
            // buttonStoreUpdate
            // 
            this.buttonStoreUpdate.Location = new System.Drawing.Point(194, 376);
            this.buttonStoreUpdate.Name = "buttonStoreUpdate";
            this.buttonStoreUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreUpdate.TabIndex = 21;
            this.buttonStoreUpdate.Text = "Update";
            this.buttonStoreUpdate.UseVisualStyleBackColor = true;
            this.buttonStoreUpdate.Click += new System.EventHandler(this.buttonStoreUpdate_Click);
            // 
            // buttonStoreFind
            // 
            this.buttonStoreFind.Location = new System.Drawing.Point(98, 376);
            this.buttonStoreFind.Name = "buttonStoreFind";
            this.buttonStoreFind.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreFind.TabIndex = 20;
            this.buttonStoreFind.Text = "Find";
            this.buttonStoreFind.UseVisualStyleBackColor = true;
            this.buttonStoreFind.Click += new System.EventHandler(this.buttonStoreFind_Click);
            // 
            // buttonStoreAdd
            // 
            this.buttonStoreAdd.Location = new System.Drawing.Point(6, 376);
            this.buttonStoreAdd.Name = "buttonStoreAdd";
            this.buttonStoreAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonStoreAdd.TabIndex = 19;
            this.buttonStoreAdd.Text = "Create";
            this.buttonStoreAdd.UseVisualStyleBackColor = true;
            this.buttonStoreAdd.Click += new System.EventHandler(this.buttonStoreAdd_Click);
            // 
            // textBoxStoreAddress
            // 
            this.textBoxStoreAddress.Location = new System.Drawing.Point(17, 311);
            this.textBoxStoreAddress.Name = "textBoxStoreAddress";
            this.textBoxStoreAddress.PlaceholderText = "Address:";
            this.textBoxStoreAddress.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreAddress.TabIndex = 18;
            // 
            // textBoxStoreCity
            // 
            this.textBoxStoreCity.Location = new System.Drawing.Point(17, 272);
            this.textBoxStoreCity.Name = "textBoxStoreCity";
            this.textBoxStoreCity.PlaceholderText = "City:";
            this.textBoxStoreCity.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreCity.TabIndex = 17;
            // 
            // textBoxStoreName
            // 
            this.textBoxStoreName.Location = new System.Drawing.Point(17, 228);
            this.textBoxStoreName.Name = "textBoxStoreName";
            this.textBoxStoreName.PlaceholderText = "Store name:";
            this.textBoxStoreName.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreName.TabIndex = 16;
            // 
            // textBoxStoreRegionName
            // 
            this.textBoxStoreRegionName.Location = new System.Drawing.Point(17, 187);
            this.textBoxStoreRegionName.Name = "textBoxStoreRegionName";
            this.textBoxStoreRegionName.PlaceholderText = "Region name:";
            this.textBoxStoreRegionName.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreRegionName.TabIndex = 15;
            // 
            // textBoxStoreID
            // 
            this.textBoxStoreID.Location = new System.Drawing.Point(17, 148);
            this.textBoxStoreID.Name = "textBoxStoreID";
            this.textBoxStoreID.PlaceholderText = "Supermarket ID:";
            this.textBoxStoreID.Size = new System.Drawing.Size(108, 23);
            this.textBoxStoreID.TabIndex = 14;
            // 
            // pictureBoxStoreMap
            // 
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
            this.buttonViewAllStore.Click += new System.EventHandler(this.buttonViewAllStore_Click);
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
            this.tabProductCategory.ResumeLayout(false);
            this.tabProductCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabOrder.ResumeLayout(false);
            this.tabOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.tabCustomer.ResumeLayout(false);
            this.tabCustomer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private TabPage tabCustomer;
        private Button buttonAddCostumer;
        private Button buttonFindCostumer;
        private Button buttonDeleteCostumer;
        private Button buttonUpdateCostumer;
        private TextBox textBoxCostumerUserName;
        private TextBox textBoxCostumerAddress;
        private TextBox textBoxCostumerPhoneNumber;
        private TextBox textBoxCostumerMail;
        private TextBox textBoxCostumerName;
        private Button buttonViewAllCostumers;
        private RichTextBox richTextBoxCostumer;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button buttonProductCategoryDelete;
        private Button buttonFindProductCategory;
        private Button buttonProductCategoryUpdate;
        private Button buttonCreateProductCategory;
        private RichTextBox richTextBoxProductCategory;
        private TextBox textBoxProductCategoryName;
        private TextBox textBoxProductCategoryID;
        private Button buttonViewAllProductCategory;
        private PictureBox pictureBox3;
        private RichTextBox OrderTextBox;
        private PictureBox pictureBox4;
        private DateTimePicker OrderDate;
        private TextBox OrderOrderID;
        private ComboBox comboBoxProductID;
        private Button BtnViewAllOrders;
        private Button BtnDeleteOrder;
        private Button BtnUpdateOrder;
        private Button BtnFindOrder;
        private Button BtnCreateOrder;
        private Label label5;
        private Label Store;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxSupermarketID;
        private ComboBox comboBoxCustomerID;
    }
}