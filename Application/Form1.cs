using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Application
{
    public partial class Form1 : Form
    {
        private readonly DataAccessLayer _layer;
        public Form1()
        {
            _layer = new();
            InitializeComponent();
            updateCombobox();
        }

        public void updateCombobox()
        {
            // Populate combobox with product data
            List<string> productData = _layer.GetProductDataCombobox();
            comboBoxOrderlineProductID.DataSource = productData;

            // Populate combobox with supermarket data
            List<string> supermarketData = _layer.GetSupermarketDataCombobox();
            comboBoxOrderSupermarketID.DataSource = supermarketData;

            // Populate combobox with customer data
            List<string> customerData = _layer.GetCustomerDataCombobox();
            comboBoxOrderCustomerID.DataSource = customerData;

            // Populate combobox with product category data
            List<string> categoryData = _layer.GetProductCategoryDataCombobox();
            comboBoxProductCategory.DataSource = categoryData;

            // Populate combobox with order data
            List<int> orderData = _layer.GetOrderDataCombobox();
            comboBoxOrderlineOrderID.DataSource = orderData;
        }

        public void clearAllTextBox()
        {
            List<TextBox> list = new List<TextBox>();
            list.Add(textBoxProductID);
            list.Add(textBoxProductName);
            list.Add(textBoxProductPrice);
            list.Add(textBoxStoreID);
            list.Add(textBoxStoreName);
            list.Add(textBoxStoreCity);
            list.Add(textBoxStoreRegionName);
            list.Add(textBoxStoreAddress);
            list.Add(textBoxCostumerAddress);
            list.Add(textBoxCostumerMail);
            list.Add(textBoxCostumerName);
            list.Add(textBoxCostumerPhoneNumber);
            list.Add(textBoxCostumerUserName);
            list.Add(textBoxCustomerID);
            list.Add(textBoxProductCategoryID);
            list.Add(textBoxProductCategoryName);

            foreach (TextBox tb in list)
            {
                tb.Text = ("");
            }
        }





        private void Form1_Load(object sender, EventArgs e)
        {
           // DataTable productData = _layer.GetProductData();
            DataTable supermarketData = _layer.GetSupermarketData();
            DataTable customerData = _layer.GetCustomerData();
            DataTable orderData = _layer.GetOrderData();
            DataTable categoryData = _layer.GetProductCategoryData();


            //DataGridView for Orderline
            DataSet dataSet = _layer.View("Orderline");  //Lagrar data från databas
            DataTable orderLineTable = dataSet.Tables["Orderline"];
            orderlineDataGridView.DataSource = orderLineTable; //Tabellen kan 

            //DataGridView for Order
            DataSet dataSetOrder = _layer.ViewOrder("Order_");
            DataTable orderTable = dataSetOrder.Tables["Order_"];
            orderDataGridView.DataSource = orderTable;

            //DataGridView for Product
            DataSet dataSetProduct = _layer.ViewProduct("Product");
            DataTable productTable = dataSetProduct.Tables["Product"];
            productDataGridView.DataSource = productTable;

            //DataGridView for Store
            DataSet dataSetStore = _layer.ViewStore("Store");
            DataTable storeTable = dataSetStore.Tables["Store"];
            storeDataGridView.DataSource = storeTable;

            //DataGridView for Customer
            DataSet dataSetCustomer = _layer.ViewCustomer("Customer");
            DataTable customerTable = dataSetCustomer.Tables["Customer"];
            customerDataGridView.DataSource = customerTable;

            //DataGridView for ProductCategory
            DataSet dataSetProductCategory = _layer.ViewProductCategory("ProductCategory");
            DataTable productCategoryTable = dataSetProductCategory.Tables["ProductCategory"];
            productCategoryDataGridView.DataSource = productCategoryTable;

            //Comboboxes for Orderline
           // comboBoxOrderlineProductID.DataSource = productData;
            //comboBoxOrderlineProductID.DisplayMember = "ProductID";
           // comboBoxOrderlineProductID.ValueMember = "ProductID";


            comboBoxOrderlineOrderID.DataSource = orderData;
            comboBoxOrderlineOrderID.DisplayMember = "OrderID";
            comboBoxOrderlineOrderID.ValueMember = "OrderID";


            //Comboboxes for Order
            comboBoxOrderSupermarketID.DataSource = supermarketData;
            comboBoxOrderSupermarketID.DisplayMember = "SupermarketID";
            comboBoxOrderSupermarketID.ValueMember = "SupermarketID";

            comboBoxOrderCustomerID.DataSource = customerData;
            comboBoxOrderCustomerID.DisplayMember = "CustomerID";
            comboBoxOrderCustomerID.ValueMember = "CustomerID";

            //Comboboxes for Product
            comboBoxProductCategory.DataSource = categoryData;
            comboBoxProductCategory.DisplayMember = "CategoryID";
            comboBoxProductCategory.ValueMember = "CategoryID";

        }

        private void UpdateView(string type)
        {
            orderlineDataGridView.DataSource = _layer.View(type);
            orderlineDataGridView.DataMember = type;

        }
        private void UpdateViewOrder(string type)
            {
                orderDataGridView.DataSource = _layer.ViewOrder(type);
                orderDataGridView.DataMember = type;

            }

        private void UpdateViewProduct(string type)
        {
            productDataGridView.DataSource = _layer.ViewProduct(type);
            productDataGridView.DataMember = type;

        }

        private void UpdateViewStore(string type)
        {
            storeDataGridView.DataSource = _layer.ViewStore(type);
            storeDataGridView.DataMember = type;

        }

        private void UpdateViewCustomer(string type)
        {
            customerDataGridView.DataSource = _layer.ViewCustomer(type);
            customerDataGridView.DataMember = type;

        }

        private void UpdateViewProductCategory(string type)
        {
            productCategoryDataGridView.DataSource = _layer.ViewProductCategory(type);
            productCategoryDataGridView.DataMember = type;

        }


        //ADD PRODUCT
        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            richTextBoxProduct.Text = "";

            if (string.IsNullOrWhiteSpace(textBoxProductID.Text) || string.IsNullOrWhiteSpace(textBoxProductName.Text) || string.IsNullOrWhiteSpace(textBoxProductPrice.Text))
            {
                richTextBoxProduct.Text = "Please enter all the fields!";
                return;
            }

            int categoryId = -1;

            if (!string.IsNullOrWhiteSpace(comboBoxProductCategory.Text))
            {
                if (int.TryParse(comboBoxProductCategory.Text, out categoryId) == false)
                {
                    richTextBoxProduct.Text = "Invalid category ID!";
                    return;
                }
            }
            else if (comboBoxProductCategory.SelectedItem != null)
            {
                if (int.TryParse(comboBoxProductCategory.SelectedItem.ToString(), out categoryId) == false)
                {
                    richTextBoxProduct.Text = "Invalid category ID!";
                    return;
                }
            }
            else
            {
                richTextBoxProduct.Text = "Please either select or enter a Product Category to the Product you want to create!";
                return;
            }

            int productId = 0;
            decimal productPrice = 0;

            if (int.TryParse(textBoxProductID.Text, out productId) == false || productId <= 0)
            {
                richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID.";
                return;
            }

            if (decimal.TryParse(textBoxProductPrice.Text, out productPrice) == false || productPrice <= 0)
            {
                richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product price.";
                return;
            }

            try
            {
                _layer.insertProduct(productId, textBoxProductName.Text, productPrice, categoryId);

                UpdateViewProduct("Product");

                richTextBoxProduct.Text = "The product has been successfully created!";
                clearAllTextBox();
                comboBoxProductCategory.SelectedIndex = -1;
                updateCombobox();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    richTextBoxProduct.Text = "A product with the same ID already exists.";
                    textBoxProductID.Text = "";
                }
                else if (ex.Number == 547)
                {
                    richTextBoxProduct.Text = "The category ID provided does not exist.";
                }
                else if (ex.Number == 0)
                {
                    richTextBoxProduct.Text = "No connection with the server.";
                }
            }
        }


        //UPDATE PRODUCT
        private void buttonProductUpdate_Click(object sender, EventArgs e)
        {

            richTextBoxProduct.Text = " ";
            string productIdString = textBoxProductID.Text;
            string productName = textBoxProductName.Text;
            string productPriceString = textBoxProductPrice.Text;

            if (string.IsNullOrWhiteSpace(productIdString) || string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(productPriceString))
            {
                richTextBoxProduct.Text = "Please enter all of the following fields: Product Name, Product ID and Product Price.";
            }
            else
            {
                try
                {
                    int productId = int.Parse(productIdString);
                    decimal productPrice = decimal.Parse(productPriceString);

                    SqlDataReader reader = _layer.findProduct(productId);

                    if (!reader.HasRows)
                    {
                        richTextBoxProduct.Text = "The product with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.updateProduct(productId, productName, productPrice);
                        UpdateViewProduct("Product");

                        richTextBoxProduct.Text = "The product has been successfully been updated!";

                        clearAllTextBox();
                        updateCombobox();


                    }
                }
                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        richTextBoxProduct.Text = "Could not connect to the database. Please check your connection and try again. ";
                    }
                }
            }
        }



        //DELETE PRODUCTt
        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
            richTextBoxProduct.Text = "";
            string productIdString = textBoxProductID.Text;

            if (string.IsNullOrWhiteSpace(productIdString))
            {
                richTextBoxProduct.Text = "Please enter the Product ID that you want to delete!";
            }
            else
            {
                try
                {
                    int productId = int.Parse(productIdString);

                    SqlDataReader reader = _layer.findProduct(productId);

                    if (!reader.HasRows)
                    {
                        richTextBoxProduct.Text = "The product with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.deleteProduct(productId);
                        UpdateViewProduct("Product");

                        richTextBoxProduct.Text = "Product has successfully been deleted!";
                        clearAllTextBox();
                        updateCombobox();

                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        richTextBoxProduct.Text = "Cannot delete this product because it is referenced in an orderline.";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxProduct.Text = "Could not connect to the database. Please check your connection and try again.";
                    }
                    else
                    {
                        richTextBoxProduct.Text = "An error occurred while deleting the product.";
                        
                    }
                }

                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
                }
            }
            }
        


        //FIND PRODUCT
        private void buttonFindProduct_Click(object sender, EventArgs e)
        {

            try
            {
                richTextBoxProduct.Text = " ";
                string productIdString = textBoxProductID.Text;
                int productID = Int32.Parse(productIdString);

                using (SqlDataReader readerFindProduct = _layer.findProduct(productID))
                {
                    if (readerFindProduct.HasRows)
                    {
                        while (readerFindProduct.Read())
                        {
                            richTextBoxProduct.Text += "ID: " + readerFindProduct.GetInt32(0) + " " + "\n";
                            richTextBoxProduct.Text += "Name: " + readerFindProduct.GetString(1) + " " + "\n";
                            richTextBoxProduct.Text += "Price: " + readerFindProduct.GetDecimal(2) + "kr " + " " + "\n";
                            richTextBoxProduct.Text += "ProductCategoryID: " + readerFindProduct.GetInt32(3) + "\n";
                            richTextBoxProduct.Text += "Category Name: " + readerFindProduct.GetString(4) + "\n";

                            clearAllTextBox();




                        }
                    }
                    else
                    {
                        richTextBoxProduct.Text += "The ProductID you have provided does not exist";
                    }
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 0)
                {

                    richTextBoxProduct.Text = "Could not connect to the database. Please check your connection and try again. ";
                }
            }
            catch (FormatException)
            {
                richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID";
            }


        }



        // ADD PRODUCTCATEGORY
        private void buttonAddProductCategory_Click(object sender, EventArgs e)
        {

            richTextBoxProductCategory.Text = " ";
            string productCategoryIdString = textBoxProductCategoryID.Text;
            string productCategoryName = textBoxProductCategoryName.Text;


            if (string.IsNullOrWhiteSpace(productCategoryIdString) || string.IsNullOrWhiteSpace(productCategoryName))
            {
                richTextBoxProductCategory.Text = "Please enter all the fields!";
            }
            else
            {
                try
                {
                    int productCategoryId = int.Parse(productCategoryIdString);


                    _layer.insertProductCategory(productCategoryId, productCategoryName);

                    richTextBoxProductCategory.Text = "The Product Category has been successfully created!";

                    clearAllTextBox();

                    UpdateViewProductCategory("ProductCategory");

                    updateCombobox();

                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxProductCategory.Text = "A Product Category with the same ID already exists.";
                        textBoxProductCategoryID.Text = " ";
                    }

                    else if (ex.Number == 0)
                    {
                        richTextBoxProductCategory.Text = "Could not connect to the database. Please check your connection and try again.";

                    }

                     
                }

                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the Product Category ID.";
                }
            }


        }

        // UPDATE PRODUCTCATEGORY
        private void buttonUpdateProductCategory_Click(object sender, EventArgs e)
        {
            richTextBoxProductCategory.Text = "";
            string productCategoryIdString = textBoxProductCategoryID.Text;
            string productCategoryName = textBoxProductCategoryName.Text;

            if (string.IsNullOrWhiteSpace(productCategoryIdString) || string.IsNullOrWhiteSpace(productCategoryName))
            {
                richTextBoxProductCategory.Text = "Please fill in a Product Category ID and a Product Category Name.";
            }
            else
            {
                try
                {
                    int productCategoryId = int.Parse(productCategoryIdString);

                    SqlDataReader reader = _layer.findProductCategory(productCategoryId);

                    if (!reader.HasRows)
                    {
                        richTextBoxProductCategory.Text = "The product category with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.updateProductCategory(productCategoryId, productCategoryName);

                        richTextBoxProductCategory.Text = "The Product Category has been successfully updated!";
                        clearAllTextBox();
                        UpdateViewProductCategory("ProductCategory");

                        updateCombobox();

                    }
                }
                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the Product Category ID.";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        richTextBoxProductCategory.Text = "Could not connect to the database. Please check your connection and try again. ";
                    }
                }
            }
        }


        // DELETE PRODUCTCATEGORY
        private void buttonProductCategoryDelete_Click(object sender, EventArgs e)
        {
            richTextBoxProductCategory.Text = "The Product Category has been successfully created!";
            string productCategoryIdString = textBoxProductCategoryID.Text;

            if (string.IsNullOrWhiteSpace(productCategoryIdString))
            {
                richTextBoxProductCategory.Text = "Please enter the Product Category ID that you want to delete!";
            }
            else
            {
                try
                {
                    int productCategoryId = int.Parse(productCategoryIdString);
                    SqlDataReader reader = _layer.findProductCategory(productCategoryId);

                    if (!reader.HasRows)
                    {
                        richTextBoxProductCategory.Text = "The product category with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.deleteProductCategory(productCategoryId);

                        richTextBoxProductCategory.Text = "The Product Category has been successfully deleted!";
                        clearAllTextBox();
                        UpdateViewProductCategory("ProductCategory");

                        updateCombobox();

                    }
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        richTextBoxProductCategory.Text = "The Product Category you are trying to delete is in use in the Product table. Please remove the references to this category in the Product table before deleting.";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxProductCategory.Text = "Could not connect to the database. Please check your connection and try again. ";
                    }
                }

                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the Product Category ID.";
                }
            }
        }



        //FIND PRODUCTCATEGORY
        private void buttonFindProductCategory_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxProductCategory.Text = " ";
                string productCategoryString = textBoxProductCategoryID.Text;
                int productCategoryID = Int32.Parse(productCategoryString);

                using (SqlDataReader readerFindProductCategory = _layer.findProductCategory(productCategoryID))
                {
                    if (readerFindProductCategory.HasRows)
                    {
                        while (readerFindProductCategory.Read())
                        {
                            richTextBoxProductCategory.Text += "ID: " + readerFindProductCategory.GetInt32(0) + " " + "\n";
                            richTextBoxProductCategory.Text += "Name: " + readerFindProductCategory.GetString(1) + " " + "\n";

                            clearAllTextBox();


                        }
                    }
                    else
                    {
                        richTextBoxProductCategory.Text += "The Product Category ID you have provided does not exist";
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxProductCategory.Text = "Could not connect to the database. Please check your connection and try again. ";
                }
            }
            catch (FormatException)
            {
                richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the Product Category ID";
            }


        }






        //ADD STORE
        private void buttonStoreAdd_Click(object sender, EventArgs e)
        {
            richTextBoxStore.Text = " ";
            string storeID = textBoxStoreID.Text;
            string regionName = textBoxStoreRegionName.Text;
            string storeName = textBoxStoreName.Text;
            string storeCity = textBoxStoreCity.Text;
            string storeAddress = textBoxStoreAddress.Text;

            if (string.IsNullOrWhiteSpace(storeID) || string.IsNullOrWhiteSpace(regionName) || string.IsNullOrWhiteSpace(storeName)
                || string.IsNullOrWhiteSpace(storeCity) || string.IsNullOrWhiteSpace(storeAddress))
            {
                richTextBoxStore.Text = "Please enter all the fields!";
            }
            else
            {
                try
                {
                    int newID = int.Parse(storeID);

                    _layer.addStore(newID, regionName, storeName, storeCity, storeAddress);

                    richTextBoxStore.Text = "The Store has been successfully created!" + "\n";

                    clearAllTextBox();

                    UpdateViewStore("Store");

                    updateCombobox();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) 
                    {
                        richTextBoxStore.Text = $"Store with ID {storeID} already exists.";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxStore.Text = "Could not connect to the database. Please check your connection and try again. ";
                    }
                }
                catch (FormatException)
                {
                    richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Supermarket ID.";
                }
            }
        }







        //FIND STORE
        private void buttonStoreFind_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxStore.Text = " ";
                string storeID = textBoxStoreID.Text;
                int newID = Int32.Parse(storeID);

                using (SqlDataReader readerFindStore = _layer.findStore(newID))
                {
                    if (readerFindStore.HasRows)
                    {
                        while (readerFindStore.Read())
                        {

                            richTextBoxStore.Text += "ID: " + readerFindStore.GetInt32(0) + " " + "\n";
                            richTextBoxStore.Text += "Region Name: " + readerFindStore.GetString(1) + " " + "\n";
                            richTextBoxStore.Text += "Store name: " + readerFindStore.GetString(2).ToUpperInvariant() + " " + "\n";
                            richTextBoxStore.Text += "City: " + readerFindStore.GetString(3) + "\n";
                            richTextBoxStore.Text += "Address: " + readerFindStore.GetString(4) + "\n";
                            richTextBoxStore.Text += "-----------------------" + "\n";

                            clearAllTextBox();

                            updateCombobox();


                        }
                    }
                    else
                    {
                        richTextBoxStore.Text = "The SupermarketID you have provided does not exist";
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxStore.Text = "Could not connect to the database. Please check your connection and try again. ";
                }
            }
            catch (FormatException)
            {
                richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Store ID";
            }
        }

        //UPDATE STORE
        private void buttonStoreUpdate_Click(object sender, EventArgs e)
        {
            richTextBoxStore.Text = "";
            string storeIdString = textBoxStoreID.Text;
            string regionName = textBoxStoreRegionName.Text;
            string storeName = textBoxStoreName.Text;
            string storeCity = textBoxStoreCity.Text;
            string storeAddress = textBoxStoreAddress.Text;

            if (string.IsNullOrWhiteSpace(storeIdString) || string.IsNullOrWhiteSpace(regionName) || string.IsNullOrWhiteSpace(storeName)
                || string.IsNullOrWhiteSpace(storeCity) || string.IsNullOrWhiteSpace(storeAddress))
            {
                richTextBoxStore.Text = "Please enter all of the following fields: Store ID, Region Name, Store Name, Store City & Store Address.";
            }
            else
            {
                try
                {
                    int storeId = int.Parse(storeIdString);

                    SqlDataReader reader = _layer.findStore(storeId);

                    if (!reader.HasRows)
                    {
                        richTextBoxStore.Text = "The store with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.updateStore(storeId, regionName, storeName, storeCity, storeAddress);
                        UpdateViewStore("Store");
                        updateCombobox();
                        richTextBoxStore.Text = "The store has been successfully updated!";
                        clearAllTextBox();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        richTextBoxStore.Text = "Could not connect to the database. Please check your connection and try again. ";
                    }
                }
                catch (FormatException)
                {
                    richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Store ID";
                }
            }
        }

        //DELETE STORE
        private void buttonStoreDelete_Click(object sender, EventArgs e)
        {
            richTextBoxStore.Text = "";
            string storeIdString = textBoxStoreID.Text;

            if (string.IsNullOrWhiteSpace(storeIdString))
            {
                richTextBoxStore.Text = "Please enter the Store ID that you want to delete!";
            }
            else
            {
                try
                {
                    int storeId = int.Parse(storeIdString);

                    SqlDataReader reader = _layer.findStore(storeId);

                    if (!reader.HasRows)
                    {
                        richTextBoxStore.Text = "The store with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.deleteStore(storeId);
                        UpdateViewStore("Store");

                        richTextBoxStore.Text = "Store has successfully been deleted!";
                        clearAllTextBox();
                        updateCombobox();
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        richTextBoxStore.Text = "Cannot delete this store because it is referenced in an order.";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxStore.Text = "Could not connect to the database. Please check your connection and try again.";
                    }
                    else
                    {
                        richTextBoxStore.Text = "An error occurred while deleting the store.";
                    }
                }
                catch (FormatException)
                {
                    richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Store ID.";
                }
            }
        }


        //CREATE CUSTOMER
        private void buttonAddCostumer_Click(object sender, EventArgs e)
        {
            richTextBoxCostumer.Text = " ";
            string costumerName = textBoxCostumerName.Text;
            string costumerMail = textBoxCostumerMail.Text;
            string stringCostumerPhoneNumber = textBoxCostumerPhoneNumber.Text;
            string costumerUserName = textBoxCostumerUserName.Text;
            string costumerAddress = textBoxCostumerAddress.Text;
            string stringCustomerID = textBoxCustomerID.Text;

            if (string.IsNullOrWhiteSpace(costumerName) || string.IsNullOrWhiteSpace(costumerMail) || string.IsNullOrWhiteSpace(stringCostumerPhoneNumber)
               || string.IsNullOrWhiteSpace(costumerUserName) || string.IsNullOrWhiteSpace(costumerAddress) || string.IsNullOrWhiteSpace(stringCustomerID))
            {
                richTextBoxCostumer.Text = "Please enter all the fields!";
            }
            else
            {

                try
                {
                    int customerID = int.Parse(stringCustomerID);
                    int costumerPhoneNumber = int.Parse(stringCostumerPhoneNumber);

                    _layer.addCustomer(costumerName, customerID, costumerUserName, costumerAddress, costumerPhoneNumber, costumerMail);

                    richTextBoxCostumer.Text = "The Customer has been successfully created!" + "\n";

                    UpdateViewCustomer("Customer");

                    updateCombobox();



                    clearAllTextBox();
                }




                catch (FormatException)
                {
                    richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Customer ID, and Phone Number.";
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxCostumer.Text = "A Customer with the same ID already exists.";
                        textBoxCustomerID.Text = " ";
                    }

                    else if (ex.Number == 0)
                    {
                        richTextBoxCostumer.Text = "No connection with the server.";

                    }
                }

            }
        }




        //FIND CUSTOMER
        private void buttonFindCostumer_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxCostumer.Text = " ";
                string stringCustomerID = textBoxCustomerID.Text;
                int customerID = Int32.Parse(stringCustomerID);

                using (SqlDataReader readerFindCostumer = _layer.findCustomer(customerID))
                {
                    if (readerFindCostumer.HasRows)
                    {
                        while (readerFindCostumer.Read())
                        {
                            richTextBoxCostumer.Text += "Name: " + readerFindCostumer.GetString(0) + " " + "\n";
                            richTextBoxCostumer.Text += "CustomerID: " + readerFindCostumer.GetInt32(1) + " " + "\n";
                            richTextBoxCostumer.Text += "Username: " + readerFindCostumer.GetString(2) + " " + "\n";
                            richTextBoxCostumer.Text += "Address: " + readerFindCostumer.GetString(3) + "\n";
                            richTextBoxCostumer.Text += "Phonenumber: " + readerFindCostumer.GetInt32(4) + "\n";
                            richTextBoxCostumer.Text += "Mail: " + readerFindCostumer.GetString(5) + "\n";

                            clearAllTextBox();

                        }
                    }
                    else
                    {
                        richTextBoxCostumer.Text = "The CustomerID you have provided does not exist";
                    }
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 0)
                {

                    richTextBoxCostumer.Text = "No connection with server";
                }
            }
            catch (FormatException)
            {
                richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Customer ID";
            }




        }

        //UPDATE CUSTOMER
        private void buttonUpdateCostumer_Click(object sender, EventArgs e)
        {
            richTextBoxCostumer.Text = "";
            string costumerName = textBoxCostumerName.Text;
            string costumerMail = textBoxCostumerMail.Text;
            string stringCostumerPhoneNumber = textBoxCostumerPhoneNumber.Text;
            string costumerUserName = textBoxCostumerUserName.Text;
            string costumerAddress = textBoxCostumerAddress.Text;
            string stringCustomerID = textBoxCustomerID.Text;

            if (string.IsNullOrWhiteSpace(costumerName) || string.IsNullOrWhiteSpace(costumerMail) || string.IsNullOrWhiteSpace(stringCostumerPhoneNumber)
                || string.IsNullOrWhiteSpace(costumerUserName) || string.IsNullOrWhiteSpace(costumerAddress) || string.IsNullOrWhiteSpace(stringCustomerID))
            {
                richTextBoxCostumer.Text = "Please enter all the fields!";
            }
            else
            {
                try
                {
                    int customerID = int.Parse(stringCustomerID);
                    int costumerPhoneNumber = int.Parse(stringCostumerPhoneNumber);

                    SqlDataReader reader = _layer.findCustomer(customerID);

                    if (!reader.HasRows)
                    {
                        richTextBoxCostumer.Text = "The customer with the specified ID could not be found.";
                    }
                    else
                    {
                        _layer.updateCustomer(costumerName, customerID, costumerUserName, costumerAddress, costumerPhoneNumber, costumerMail);

                        richTextBoxCostumer.Text = "The customer has been successfully updated!" + "\n";

                        UpdateViewCustomer("Customer");

                        clearAllTextBox();

                        updateCombobox();
                    }
                }
                catch (FormatException)
                {
                    richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Customer ID, and Phone Number.";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxCostumer.Text = "A customer with the same ID already exists.";
                        textBoxCustomerID.Text = "";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxCostumer.Text = "No connection with the server.";
                    }
                    else
                    {
                        richTextBoxCostumer.Text = "An error occurred while updating the customer.";
                    }
                }
            }
        }

        //DELETE CUSTOMER
        private void buttonDeleteCostumer_Click(object sender, EventArgs e)
        {
            richTextBoxCostumer.Text = " ";
            string stringCustomerID = textBoxCustomerID.Text;

            if (string.IsNullOrWhiteSpace(stringCustomerID))
            {
                richTextBoxCostumer.Text = "Please enter the Customer ID that you want to delete!";
            }
            else
            {
                try
                {
                    int customerID = int.Parse(stringCustomerID);

                    
                    SqlDataReader reader = _layer.findCustomer(customerID);
                    if (!reader.HasRows)
                    {
                        richTextBoxCostumer.Text = $"Customer with ID {customerID} does not exist!";
                        return;
                    }
                    reader.Close();

                    _layer.deleteCustomer(customerID);

                    richTextBoxCostumer.Text = "Customer has successfully been deleted!";
                    UpdateViewCustomer("Customer");

                    clearAllTextBox();

                    updateCombobox();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        richTextBoxCostumer.Text = "Cannot delete this Customer because it is referenced in an order.";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxCostumer.Text = "Could not connect to the database. Please check your connection and try again.";
                    }
                    else
                    {
                        richTextBoxCostumer.Text = "An error occurred while deleting the product.";

                    }
                }
                catch (FormatException)
                {
                    richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Customer ID.";
                }

            }
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            OrderTextBox.Text = " ";
            string orderID = textOrderOrderID.Text;
            string date = textOrderDate.Value.ToString("yyyy-MM-dd");
            int supermarketID = 0;
            int customerID = 0;

            
            if (!int.TryParse(comboBoxOrderSupermarketID.Text, out supermarketID))
            {
                
                if (comboBoxOrderSupermarketID.SelectedItem != null)
                {
                    supermarketID = int.Parse(comboBoxOrderSupermarketID.SelectedValue.ToString());
                }
            }

            
            if (!int.TryParse(comboBoxOrderCustomerID.Text, out customerID))
            {
                if (comboBoxOrderCustomerID.SelectedItem != null)
                {
                    customerID = int.Parse(comboBoxOrderCustomerID.SelectedValue.ToString());
                }
            }

            string paymentMethod = comboBoxOrderPaymentMethod.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(orderID))
            {
                OrderTextBox.Text = "Please enter an Order ID!";
            }
            else if (supermarketID <= 0 || customerID <= 0 || string.IsNullOrWhiteSpace(paymentMethod))
            {
                OrderTextBox.Text = "Please select or enter a Store, Customer & Payment Method";
            }
            else
            {
                try
                {
                    int ID = int.Parse(orderID);

                    _layer.AddOrder(ID, date, supermarketID, customerID, paymentMethod);
                    UpdateViewOrder("Order_");

                    OrderTextBox.Text = "The order has been successfully created!" + "\n";

                    updateCombobox();


                    textOrderOrderID.Clear();
                    comboBoxOrderSupermarketID.SelectedIndex = -1;
                    comboBoxOrderCustomerID.SelectedIndex = -1;
                    comboBoxOrderPaymentMethod.SelectedIndex = -1;
                }
                catch (FormatException)
                {
                    OrderTextBox.Text = "Invalid input format. Please make sure to only insert numbers for the order id.";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        OrderTextBox.Text = "An order with the same ID already exists.";
                    }
                    else if (ex.Number == 547)
                    {
                        OrderTextBox.Text = "The order could not be created! Please verify if the Store or Customer that you have specified exist! ";

                    }
                }
            }
        }

        private void BtnFindOrder_Click(object sender, EventArgs e)
        {

            try
            {
                OrderTextBox.Text = "";
                string orderID = textOrderOrderID.Text;
                int tmpOrderID = int.Parse(orderID);


                using (SqlDataReader readerFindOrder = _layer.findOrder(tmpOrderID))
                {
                    if (readerFindOrder.HasRows)
                    {
                        while (readerFindOrder.Read())
                        {
                            OrderTextBox.Text += "--- ORDER FOUND ---" + "\n";
                            OrderTextBox.Text += "Order ID: " + readerFindOrder.GetInt32(0) + " " + "\n";
                            OrderTextBox.Text += "Customer ID: " + readerFindOrder.GetInt32(1) + "\n";
                            OrderTextBox.Text += "Customer Name: " + readerFindOrder.GetString(2) + "\n";
                            OrderTextBox.Text += "Customer Username: " + readerFindOrder.GetString(3) + "\n";
                            OrderTextBox.Text += "Customer Address: " + readerFindOrder.GetString(4) + "\n";
                            OrderTextBox.Text += "Customer Email: " + readerFindOrder.GetString(5) + "\n";
                            OrderTextBox.Text += "Store Name: " + readerFindOrder.GetString(6) + "\n";
                            OrderTextBox.Text += "Supermarket ID: " + readerFindOrder.GetInt32(7) + "\n";
                            OrderTextBox.Text += "Payment Method: " + readerFindOrder.GetString(8) + "\n";
                            OrderTextBox.Text += "Order Date: " + readerFindOrder.GetString(9) + "\n";
                            OrderTextBox.Text += "-----------------------" + "\n";

                            OrderTextBox.Text += "-----------------------" + "\n";

                            textOrderOrderID.Clear();

                        }
                    }
                    else
                    {
                        OrderTextBox.Text += "The OrderID you have provided does not exist";
                    }
                }
            }
            catch (SqlException ex)
            {

                if (ex.Number == 0)
                {

                    richTextBoxCostumer.Text = "No connection with server";
                }
            }
            catch (FormatException)
            {
                richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Order ID";
            }
        }

        private void BtnUpdateOrder_Click(object sender, EventArgs e)
        {
            OrderTextBox.Text = " ";
            string orderID = textOrderOrderID.Text;
            string date = textOrderDate.Value.ToString("yyyy-MM-dd");
            string paymentMethod = comboBoxOrderPaymentMethod.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(orderID))
            {
                OrderTextBox.Text = "Please enter an Order ID!";
            }
            else if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(paymentMethod))
            {
                OrderTextBox.Text = "Please select a date and payment method to update";
            }
            else
            {
                try
                {
                    int tmpOrderID = int.Parse(orderID);

                    SqlDataReader reader = _layer.findOrder(tmpOrderID);

                    if (!reader.HasRows)
                    {
                        OrderTextBox.Text = "The order with the specified ID could not be found.";

                    }
                    else
                    {
                        _layer.updateOrder(tmpOrderID, date, paymentMethod);
                        UpdateViewOrder("Order_");

                        OrderTextBox.Text = "The order has been updated!" + "\n";

                        updateCombobox();

                        comboBoxOrderPaymentMethod.SelectedIndex = -1;

                    }
                }
                catch (FormatException)
                {
                    OrderTextBox.Text = "Invalid input format. Please make sure to only insert numbers for the order id.";
                }
                catch (SqlException error)
                {
                    if (error.Number == 2627)
                    {
                        OrderTextBox.Text = "An order with the same ID already exists.";
                    }
                }
            }
        }


        private void BtnDeleteOrder_Click(object sender, EventArgs e)
        {
            OrderTextBox.Text = " ";
            string orderID = textOrderOrderID.Text;

            if (string.IsNullOrWhiteSpace(orderID))
            {
                OrderTextBox.Text = "Please enter the Order ID that you want to delete!";
            }

            else
            {
                try
                {
                    int tmpOrderID = Int32.Parse(orderID);

                    SqlDataReader reader = _layer.findOrder(tmpOrderID);

                    if (!reader.HasRows)
                    {

                        OrderTextBox.Text = "The Order with the specified ID could not be found";
                    }
                    else
                    {
                        _layer.deleteOrder(tmpOrderID);

                        updateCombobox();


                        UpdateViewOrder("Order_");
                        OrderTextBox.Text = "Order has successfully been deleted!";

                    }

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        OrderTextBox.Text = "Cannot delete this order because it is referenced in an orderline.";

                    }
                    else if (ex.Number == 0)
                    {
                        OrderTextBox.Text = "No connection with the database. Please try again later!";


                }
                }

                catch (FormatException)
                {
                    OrderTextBox.Text = "Invalid input format. Please make sure to provide a positive number for the Order ID.";
                }

            }
        }
         
    private void buttonOrderlineCreate_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxOrderline.Text = " ";
                string orderlineID = textBoxOrderlineID.Text;
                int orderID = int.Parse(comboBoxOrderlineOrderID.SelectedValue.ToString());
                int productID = int.Parse(comboBoxOrderlineProductID.SelectedValue.ToString());
                int quantity;

                if (comboBoxOrderlineOrderID.SelectedIndex == -1
                || comboBoxOrderlineProductID.SelectedIndex == -1
                || comboBoxOrderlineQuantity.SelectedIndex == -1)
                {
                    richTextBoxOrderline.Text = "Please select an A Orderline number, Order, Product, Quantity";
                    return;
                }

                else if (!int.TryParse(comboBoxOrderlineQuantity.SelectedItem.ToString(), out quantity))
                {
                    richTextBoxOrderline.Text = "Invalid input format. Please make sure to only insert numbers for the quantity.";
                    return;
 
                }

                else
                {
                    int tmpOrderlineID = int.Parse(orderlineID);
                    int count = _layer.CheckOrderline(orderID, tmpOrderlineID);
                    if (count > 0)
                    {
                        richTextBoxOrderline.Text = "An Orderline with the same ID already exists in the chosen Order. Please select another Orderline ID.";
                        return;
                    }
                    _layer.AddOrderline(orderID, productID, tmpOrderlineID, quantity);
                    UpdateView("Orderline");

                    updateCombobox();


                    richTextBoxOrderline.Text = "The Orderline has been successfully created!" + "\n";

                    comboBoxOrderlineQuantity.SelectedIndex = -1;
                    comboBoxOrderlineOrderID.SelectedIndex = -1;
                    comboBoxOrderlineProductID.SelectedIndex = -1;

                }
                
            }
            catch (SqlException error)
            {


                if (error.Number == 2627)
                {
                    richTextBoxOrderline.Text = "You have already added a product with the same id to the chosen Order please select another product.";
                }
}
        }
 

        private void buttonFindOrderline_Click(object sender, EventArgs e)
        {
            try
            {
                int orderID = int.Parse(comboBoxOrderlineOrderID.SelectedValue.ToString());
                int productID = int.Parse(comboBoxOrderlineProductID.SelectedValue.ToString());
                richTextBoxOrderline.Text = " ";

                using (SqlDataReader readerFindOrderlines = _layer.findOrderlinesByOrderIDandProductID(orderID, productID))
                {
                    if (readerFindOrderlines.HasRows)
                    {
                        richTextBoxOrderline.Text += "--- ORDERLINES ---" + "\n";
                        UpdateView("Orderline");

                        while (readerFindOrderlines.Read())
                        {
                            richTextBoxOrderline.Text += "Orderline Number: " + readerFindOrderlines.GetInt32(0) + "\n";
                            richTextBoxOrderline.Text += "Order ID: " + readerFindOrderlines.GetInt32(1) + " " + "\n";
                            richTextBoxOrderline.Text += "Product ID: " + readerFindOrderlines.GetInt32(2) + " " + "\n";
                            richTextBoxOrderline.Text += "Product Name: " + readerFindOrderlines.GetString(3) + "\n";
                            richTextBoxOrderline.Text += "Price: " + readerFindOrderlines.GetDecimal(4) + "\n";
                            richTextBoxOrderline.Text += "Order Date: " + readerFindOrderlines.GetString(5) + "\n";
                            richTextBoxOrderline.Text += "Store Name: " + readerFindOrderlines.GetString(6) + "\n";
                            richTextBoxOrderline.Text += "Supermarket ID: " + readerFindOrderlines.GetInt32(7) + "\n";
                            richTextBoxOrderline.Text += "Quantity: " + readerFindOrderlines.GetInt32(8) + "\n";
                            richTextBoxOrderline.Text += "Payment Method: " + readerFindOrderlines.GetString(9) + "\n";
                            richTextBoxOrderline.Text += "Total price: " + readerFindOrderlines.GetDecimal(10) + "\n";
                            richTextBoxOrderline.Text += "-----------------------" + "\n";

       

                        }
                    }
                    else
                    {
                        richTextBoxOrderline.Text += "No orderlines found for the given Order ID and Product ID.";
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxOrderline.Text = "No connection with server";
                }
            }
            catch (FormatException)
            {
                richTextBoxOrderline.Text = "Invalid input format. Please make sure to provide a positive number for the Order ID and Product ID.";
            }
        }
        private void buttonDeleteOrderline_Click(object sender, EventArgs e)
        {
            richTextBoxOrderline.Text = " ";

            try
            {
                if (comboBoxOrderlineOrderID.SelectedIndex == -1 ||  comboBoxOrderlineProductID.SelectedIndex == -1)
                {
                    richTextBoxOrderline.Text = "Please select an Order ID and Product ID to delete!!";
                }
                else
                {
                    int productID = int.Parse(comboBoxOrderlineProductID.SelectedValue.ToString());
                    int orderID = int.Parse(comboBoxOrderlineOrderID.SelectedValue.ToString());
                    SqlDataReader reader = _layer.findOrderlinesByOrderIDandProductID(orderID, productID);

                    if (!reader.HasRows)
                    {
                        richTextBoxOrderline.Text = "Please check if there is a Order ID with the selected Product ID or vice versa!";
                    }
                      
                    else
                    {
                        _layer.deleteOrderline(orderID, productID);
                        UpdateView("Orderline");
                        richTextBoxOrderline.Text = "The Product ID: " + productID + " was sucessfully deleted from the Order ID: " + orderID;

                        updateCombobox();

                    }
                }
            }
            catch (FormatException)
            {
                richTextBoxOrderline.Text = "Invalid input format. Please make sure to provide a positive number for the Order ID and Product ID";
            }
        }

        private void buttonUpdateOrderline_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBoxOrderline.Text = " ";
                string orderlineID = textBoxOrderlineID.Text;
                int orderID = int.Parse(comboBoxOrderlineOrderID.SelectedValue.ToString());
                int productID = int.Parse(comboBoxOrderlineProductID.SelectedValue.ToString());
                int quantity;

                if (comboBoxOrderlineOrderID.SelectedIndex == -1
                || comboBoxOrderlineProductID.SelectedIndex == -1
                || comboBoxOrderlineQuantity.SelectedIndex == -1)
                {
                    richTextBoxOrderline.Text = "Please select an Orderline number, Order, Product, Quantity & Payment method to update";
                    return;
                }
                else if (!int.TryParse(comboBoxOrderlineQuantity.SelectedItem.ToString(), out quantity))
                {
                    richTextBoxOrderline.Text = "Invalid input format. Please make sure to only insert numbers for the quantity.";
                    return;
                }
                else
                {
                    SqlDataReader reader = _layer.findOrderlinesByOrderIDandProductID(orderID, productID);
                    if (!reader.HasRows)
                    {
                        richTextBoxOrderline.Text = "Please check if there is an Orderline with the selected Order ID and Product ID!";
                        return;
                    }

                    int tmpOrderlineID = int.Parse(orderlineID);
                    _layer.updateOrderline(orderID, productID, tmpOrderlineID, quantity);
                    UpdateView("Orderline");

                    updateCombobox();


                    richTextBoxOrderline.Text = "The Orderline has been successfully updated!" + "\n";

                    comboBoxOrderlineQuantity.SelectedIndex = -1;
                    comboBoxOrderlineOrderID.SelectedIndex = -1;
                    comboBoxOrderlineProductID.SelectedIndex = -1;
                }
            }
            catch (FormatException)
            {
                richTextBoxOrderline.Text = "Invalid input format. Please make sure to provide a positive number for the Orderline ID, Order ID, and Product ID";
            }
            catch (SqlException error)
            {
                if (error.Number == 0)
                {
                    richTextBoxOrderline.Text = "Connection problems!";
                
            }
            }
        }
    }
}




























