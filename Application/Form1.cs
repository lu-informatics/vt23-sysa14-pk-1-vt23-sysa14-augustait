using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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
        }

        public void clearAllTextBox()
        {
            List<TextBox> list = new List<TextBox>();
            list.Add(textBoxProductID);
            list.Add(textBoxProductName);
            list.Add(textBoxCategoryID);
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
            DataTable productData = _layer.GetProductData();
            DataTable supermarketData = _layer.GetSupermarketData();
            DataTable customerData = _layer.GetCustomerData();
            DataTable orderData = _layer.GetOrderData();


            //DataGridView for Orderline
            DataSet dataSet = _layer.View("Orderline");
            DataTable orderLineTable = dataSet.Tables["Orderline"];
            orderlineDataGridView.DataSource = orderLineTable;

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
            comboBoxOrderlineProductID.DataSource = productData;
            comboBoxOrderlineProductID.DisplayMember = "ProductID";
            comboBoxOrderlineProductID.ValueMember = "ProductID";

            comboBoxOrderlineOrderID.DataSource = orderData;
            comboBoxOrderlineOrderID.DisplayMember = "OrderID";
            comboBoxOrderlineOrderID.ValueMember = "OrderID";


            //Comboboxes for Orderline
            comboBoxOrderSupermarketID.DataSource = supermarketData;
            comboBoxOrderSupermarketID.ValueMember = "SupermarketID";

            comboBoxOrderCustomerID.DataSource = customerData;
            comboBoxOrderCustomerID.ValueMember = "CustomerID";

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
            richTextBoxProduct.Text = " ";
            string productIdString = textBoxProductID.Text;
            string productName = textBoxProductName.Text;
            string productPriceString = textBoxProductPrice.Text;
            string categoryIdString = textBoxCategoryID.Text;

            if (string.IsNullOrWhiteSpace(productIdString) || string.IsNullOrWhiteSpace(productName) || string.IsNullOrWhiteSpace(productPriceString)
                || string.IsNullOrWhiteSpace(categoryIdString))
            {
                richTextBoxProduct.Text = "Please enter all the fields!";
            }
            else
            {
                try
                {
                    int productId = int.Parse(productIdString);
                    int categoryId = int.Parse(categoryIdString);
                    decimal productPrice = decimal.Parse(productPriceString);

                    _layer.insertProduct(productId, productName, productPrice, categoryId);

                    UpdateViewProduct("Product");

                    richTextBoxProduct.Text = "The product has been successfully created!";

                    clearAllTextBox();



                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxProduct.Text = "A product with the same ID already exists.";
                        textBoxProductID.Text = " ";
                    }
                    else if (ex.Number == 547)
                    {
                        richTextBoxProduct.Text = "The category ID provided does not exist.";
                        textBoxCategoryID.Text = " ";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxProduct.Text = "No connection with the server.";

                    }
                }

                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, category ID, and product price.";
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
                    }
                }
                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID.";
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
                            richTextBoxProduct.Text += "Cost: " + readerFindProduct.GetDecimal(2) + "kr " + " " + "\n";
                            richTextBoxProduct.Text += "ProductCategoryID: " + readerFindProduct.GetInt32(3) + "\n";
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
                    int tmpID = int.Parse(storeID);

                    _layer.addStore(tmpID, regionName, storeName, storeCity, storeAddress);

                    richTextBoxStore.Text = "The Store has been successfully created!" + "\n";


                    clearAllTextBox();

                    UpdateViewStore("Store");
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
            richTextBoxStore.Text = " ";
            string storeID = textBoxStoreID.Text;
            string regionName = textBoxStoreRegionName.Text;
            string storeName = textBoxStoreName.Text;
            string storeCity = textBoxStoreCity.Text;
            string storeAddress = textBoxStoreAddress.Text;

            if (string.IsNullOrWhiteSpace(storeID) || string.IsNullOrWhiteSpace(regionName) || string.IsNullOrWhiteSpace(storeName)
                || string.IsNullOrWhiteSpace(storeCity) || string.IsNullOrWhiteSpace(storeAddress))
            {
                richTextBoxStore.Text = "Please enter all of the following fields: Store ID, Region Name, Store Name, Store City & Store Address.";
            }
            else
            {
                try
                {
                    richTextBoxStore.Text = " ";
                    int tmpStoreID = int.Parse(storeID);

                    _layer.updateStore(tmpStoreID, regionName, storeName, storeCity, storeAddress);

                    richTextBoxStore.Text = "The Store has been successfully been updated!";

                    clearAllTextBox();
                    UpdateViewStore("Store");
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
            richTextBoxStore.Text = " ";
            String storeID = textBoxStoreID.Text;

            if (string.IsNullOrWhiteSpace(storeID))
            {
                richTextBoxStore.Text = "Please enter the Store ID that you want to delete!";
            }

            else
            {
                try
                {
                    int tmpID = Int32.Parse(storeID);
                    _layer.deleteStore(tmpID);

                    richTextBoxStore.Text = "Store has successfully been deleted!";

                    clearAllTextBox();
                    UpdateViewStore("Store");

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
                    richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Supermarket ID.";
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

                    _layer.updateCustomer(costumerName, customerID, costumerUserName, costumerAddress, costumerPhoneNumber, costumerMail);

                    richTextBoxCostumer.Text = "The Customer has been successfully updated!" + "\n";

                    UpdateViewCustomer("Customer");

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

        //DELETE CUSTOMER
        private void buttonDeleteCostumer_Click(object sender, EventArgs e)
        {
            richTextBoxCostumer.Text = " ";
            String stringCustomerID = textBoxCustomerID.Text;

            if (string.IsNullOrWhiteSpace(stringCustomerID))
            {
                richTextBoxCostumer.Text = "Please enter the Customer ID that you want to delete!";
            }

            else
            {
                try
                {
                    int customerID = Int32.Parse(stringCustomerID);
                    _layer.deleteCustomer(customerID);

                    richTextBoxCostumer.Text = "Customer has successfully been deleted!";
                    UpdateViewCustomer("Customer");

                    clearAllTextBox();

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
                    richTextBoxCostumer.Text = "Invalid input format. Please make sure to provide a positive number for the Customer ID.";
                }

            }
        }


        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            OrderTextBox.Text = " ";
            string orderID = textOrderOrderID.Text;
            string date = textOrderDate.Value.ToString("yyyy-MM-dd");
            int supermarketID = int.Parse(comboBoxOrderSupermarketID.SelectedValue.ToString());
            int customerID = int.Parse(comboBoxOrderCustomerID.SelectedValue.ToString());



            if (string.IsNullOrWhiteSpace(orderID))
            {
                OrderTextBox.Text = "Please enter an Order ID!";
            }
            else if (comboBoxOrderSupermarketID.SelectedIndex == -1
                     || comboBoxOrderCustomerID.SelectedIndex == -1)
            {
                OrderTextBox.Text = "Please select a Store & Customer";
            }
            else
            {
                try
                {
                    int ID = int.Parse(orderID);

                    _layer.AddOrder(ID, date, supermarketID, customerID);
                    UpdateViewOrder("Order");

                    OrderTextBox.Text = "The order has been successfully created!" + "\n";

                    textOrderOrderID.Clear();
                    comboBoxOrderSupermarketID.SelectedIndex = -1;
                    comboBoxOrderCustomerID.SelectedIndex = -1;
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
                            OrderTextBox.Text += "Date: " + readerFindOrder.GetString(1) + " " + "\n";
                            OrderTextBox.Text += "Supermarket ID: " + readerFindOrder.GetInt32(2) + "\n";
                            OrderTextBox.Text += "Customer ID: " + readerFindOrder.GetInt32(3) + "\n";
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


            if (string.IsNullOrWhiteSpace(orderID) || string.IsNullOrWhiteSpace(date))
            {

                OrderTextBox.Text = "Please select a Order ID, Product, Store & Customer";
            }
            else
            {
                try
                {
                    int tmpOrderID = int.Parse(orderID);

                    SqlDataReader reader = _layer.findOrder(tmpOrderID);

                    if (!reader.HasRows)
                    {
                        OrderTextBox.Text = "The product with the specified ID could not be found.";

                    }
                    else
                    {
                        _layer.updateOrder(tmpOrderID, date);
                        UpdateViewOrder("Order");

                        OrderTextBox.Text = "The order has been updated!" + "\n";


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

                        UpdateViewOrder("Order");
                        OrderTextBox.Text = "Order has successfully been deleted!";

                    }

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        OrderTextBox.Text = "No connection with server";

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
                string orderlinePaymentmethod = comboBoxOrderlinePayment.Text;

                if (comboBoxOrderlineOrderID.SelectedIndex == -1
                || comboBoxOrderlineProductID.SelectedIndex == -1
                || comboBoxOrderlineQuantity.SelectedIndex == -1
                 || comboBoxOrderlinePayment.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxOrderlinePayment.Text))
                {
                    richTextBoxOrderline.Text = "Please select an A Orderline number, Order, Product, Quantity & Payment method";
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
                    _layer.AddOrderline(orderID, productID, tmpOrderlineID, quantity, orderlinePaymentmethod);
                    UpdateView("Orderline");


                    

                    richTextBoxOrderline.Text = "The Order has been successfully created!" + "\n";

                    comboBoxOrderlineQuantity.SelectedIndex = -1;
                    comboBoxOrderlineOrderID.SelectedIndex = -1;
                    comboBoxOrderlineProductID.SelectedIndex = -1;
                    comboBoxOrderlinePayment.SelectedIndex = -1;

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
                richTextBoxOrderline.Text = " ";

                using (SqlDataReader readerFindOrderlines = _layer.findOrderlinesByOrderID(orderID))
                {
                    if (readerFindOrderlines.HasRows)
                    {
                        richTextBoxOrderline.Text += "--- ORDERS ---" + "\n";
                        UpdateView("Orderline");


                        while (readerFindOrderlines.Read())
                        {
                            richTextBoxOrderline.Text += "Order ID: " + readerFindOrderlines.GetInt32(0) + " " + "\n";
                            richTextBoxOrderline.Text += "Product ID: " + readerFindOrderlines.GetInt32(1) + " " + "\n";
                            richTextBoxOrderline.Text += "Orderline ID: " + readerFindOrderlines.GetInt32(2) + "\n";
                            richTextBoxOrderline.Text += "Quantity ID: " + readerFindOrderlines.GetInt32(3) + "\n";
                            richTextBoxOrderline.Text += "Payment Method : " + readerFindOrderlines.GetString(4) + "\n";
                            richTextBoxOrderline.Text += "-----------------------" + "\n";

                            
                        }
                    }
                    else
                    {
                        richTextBoxOrderline.Text += "The OrderID you have provided does not exist";
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
                richTextBoxOrderline.Text = "Invalid input format. Please make sure to provide a positive number for the Order ID";
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
                string orderlinePaymentmethod = comboBoxOrderlinePayment.Text;

                if (comboBoxOrderlineOrderID.SelectedIndex == -1
                || comboBoxOrderlineProductID.SelectedIndex == -1
                || comboBoxOrderlineQuantity.SelectedIndex == -1
                 || comboBoxOrderlinePayment.SelectedIndex == -1 || string.IsNullOrEmpty(comboBoxOrderlinePayment.Text))
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
                    _layer.updateOrderline(orderID, productID, tmpOrderlineID, quantity, orderlinePaymentmethod);
                    UpdateView("Orderline");

                    richTextBoxOrderline.Text = "The Orderline has been successfully updated!" + "\n";

                    comboBoxOrderlineQuantity.SelectedIndex = -1;
                    comboBoxOrderlineOrderID.SelectedIndex = -1;
                    comboBoxOrderlineProductID.SelectedIndex = -1;
                    comboBoxOrderlinePayment.SelectedIndex = -1;
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




























