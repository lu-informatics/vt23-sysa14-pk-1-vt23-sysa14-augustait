using System.Data;
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

            // Bind the data to each ComboBox


            // Bind the data to the ComboBox
            comboBoxOrderProductID.DataSource = productData;
            comboBoxOrderProductID.DisplayMember = "ProductID";
            comboBoxOrderProductID.ValueMember = "ProductID";



            comboBoxOrderSupermarketID.DataSource = supermarketData;
            comboBoxOrderSupermarketID.ValueMember = "SupermarketID";

            comboBoxOrderCustomerID.DataSource = customerData;
            comboBoxOrderCustomerID.ValueMember = "CustomerID";



        

    }

        //ADD PRODUCT
        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
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

        //VIEW ALL PRODUCT INFORMATION
        private void buttonViewAllProducts_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataReader readerViewProducts = _layer.printallProducts())
                {
                    while (readerViewProducts.Read())
                    {
                        richTextBoxProduct.Text += "ID: " + readerViewProducts.GetInt32(0) + " " + "\n";
                        richTextBoxProduct.Text += "Name: " + readerViewProducts.GetString(1) + " " + "\n";
                        richTextBoxProduct.Text += "Cost: " + readerViewProducts.GetDecimal(2) + "kr " + " " + "\n";
                        richTextBoxProduct.Text += "ProductCategoryID: " + readerViewProducts.GetInt32(3) + "\n";
                        richTextBoxProduct.Text += "-----------------------" + "\n";

                        clearAllTextBox();

                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxProduct.Text = "No connection with server";
                }
            }
            catch (NullReferenceException)
            {
                richTextBoxProduct.Text = "There are no Products to view!";
            }
        }




        //UPDATE PRODUCT
        private void buttonProductUpdate_Click(object sender, EventArgs e)
        {
            string productIdString = textBoxProductID.Text;
            string productName = textBoxProductName.Text;
            string productPriceString = textBoxProductPrice.Text;
            string categoryIdString = textBoxCategoryID.Text;

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

                    _layer.updateProduct(productId, productName, productPrice);

                    richTextBoxProduct.Text = "The product has been successfully been updated!";

                    clearAllTextBox();
                }



                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
                }

            }
        }

        //DELETE PRODUCTt
        private void buttonProductDelete_Click(object sender, EventArgs e)
        {
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
                    _layer.deleteProduct(productId);

                    richTextBoxProduct.Text = "Product has successfully been deleted!";
                    clearAllTextBox();
                }
                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID.";
                }

            }
        }

        //FIND PRODUCT
        private void buttonFindProduct_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (ex.Number == 0) {

                    richTextBoxProduct.Text = "No connection with server";
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

                    richTextBoxProduct.Text = "The product has been successfully created!";



                    clearAllTextBox();
                }

                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxProductCategory.Text = "A product with the same ID already exists.";
                        textBoxProductID.Text = " ";
                    }
                    else if (ex.Number == 547)
                    {
                        richTextBoxProductCategory.Text = "The category ID provided does not exist.";
                        textBoxCategoryID.Text = " ";
                    }
                    else if (ex.Number == 0)
                    {
                        richTextBoxProductCategory.Text = "No connection with the server.";

                    }
                }

                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, category ID, and product price.";
                }
            }


        }
        // UPDATE PRODUCTCATEGORY
        private void buttonUpdateProductCategory_Click(object sender, EventArgs e)
        {

            string productCategoryIdString = textBoxProductCategoryID.Text;
            string productCategoryName = textBoxProductCategoryName.Text;


            if (string.IsNullOrWhiteSpace(productCategoryIdString) || string.IsNullOrWhiteSpace(productCategoryName))
            {
                richTextBoxProductCategory.Text = "Please fill in a Product Category Name";
            }
            else
            {
                try
                {
                    int productCategoryId = int.Parse(productCategoryIdString);


                    _layer.updateProductCategory(productCategoryId, productCategoryName);

                    richTextBoxProductCategory.Text = "The product has been successfully been updated!";

                }

                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, category ID, and product price.";
                }
            }
        }


        // DELETE PRODUCTCATEGORY
        private void buttonProductCategoryDelete_Click(object sender, EventArgs e)
        {



            string productCategoryIdString = textBoxProductCategoryID.Text;

            if (string.IsNullOrWhiteSpace(productCategoryIdString))
            {
                richTextBoxProductCategory.Text = "Please enter the Product ID that you want to delete!";
            }

            else
            {
                try
                {
                    int productCategoryId = int.Parse(productCategoryIdString);
                    _layer.deleteProduct(productCategoryId);

                    richTextBoxProductCategory.Text = "Product has successfully been deleted!";
                    clearAllTextBox();
                }
                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the product ID.";
                }

            }


        }


        //FIND PRODUCTCATEGORY
        private void buttonFindProductCategory_Click(object sender, EventArgs e)
        {
            try
            {
                string productCategoryString = textBoxCategoryID.Text;
                int productCategoryID = Int32.Parse(productCategoryString);

                using (SqlDataReader readerFindProductCategory = _layer.findProduct(productCategoryID))
                {
                    if (readerFindProductCategory.HasRows)
                    {
                        while (readerFindProductCategory.Read())
                        {
                            richTextBoxProduct.Text += "ID: " + readerFindProductCategory.GetInt32(0) + " " + "\n";
                            richTextBoxProduct.Text += "Name: " + readerFindProductCategory.GetString(1) + " " + "\n";

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
                    richTextBoxProduct.Text = "No connection with server";
                }
            }
            catch (FormatException)
            {
                richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID";
            }


        }
        

        //ADD STORE
        private void buttonStoreAdd_Click(object sender, EventArgs e)
        {

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
                }




                catch (FormatException)
                {
                    richTextBoxProductCategory.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
                }

            }


        }







        //FIND STORE
        private void buttonStoreFind_Click(object sender, EventArgs e)
        {
            try
            {
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
                    richTextBoxStore.Text = "No connection with server";
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
            string storeID = textBoxStoreID.Text;
            string regionName = textBoxStoreRegionName.Text;
            string storeName = textBoxStoreName.Text;
            string storeCity = textBoxStoreCity.Text;
            string storeAddress = textBoxStoreAddress.Text;

            if (string.IsNullOrWhiteSpace(storeID) || string.IsNullOrWhiteSpace(regionName) || string.IsNullOrWhiteSpace(storeName) 
                || string.IsNullOrWhiteSpace(storeCity) || string.IsNullOrWhiteSpace(storeAddress))
                {
                    richTextBoxProduct.Text = "Please enter all of the following fields: Store ID, Region Name, Store Name, Store City & Store Address.";
                }
                else
                {
                    try
                    {
                        int tmpStoreID = int.Parse(storeID);

                        _layer.updateStore(tmpStoreID, regionName, storeName, storeCity, storeAddress);

                        richTextBoxProduct.Text = "The Store has been successfully been updated!";

                        clearAllTextBox();
                    }



                    catch (FormatException)
                    {
                        richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the Store ID";
                    }

                }
        }

        //DELETE STORE
        private void buttonStoreDelete_Click(object sender, EventArgs e)
        {
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

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        richTextBoxStore.Text = "No connection with server";

                    }
                }
                catch (FormatException)
                {
                    richTextBoxStore.Text = "Invalid input format. Please make sure to provide a positive number for the Supermarket ID.";
                }

            }
        }

        //VIEW ALL INFORMATION STORE
        private void buttonViewAllStore_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataReader readerViewStores = _layer.printallStores())
                {
                    while (readerViewStores.Read())
                    {
                        richTextBoxStore.Text += "ID: " + readerViewStores.GetInt32(0) + " " + "\n";
                        richTextBoxStore.Text += "Region Name: " + readerViewStores.GetString(1) + " " + "\n";
                        richTextBoxStore.Text += "Store name: " + readerViewStores.GetString(2) + " " + "\n";
                        richTextBoxStore.Text += "City: " + readerViewStores.GetString(3) + "\n";
                        richTextBoxStore.Text += "Address: " + readerViewStores.GetString(4) + "\n";
                        richTextBoxStore.Text += "-----------------------" + "\n";

                        
                        clearAllTextBox();

                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxProduct.Text = "No connection with server";
                }
            }
            catch (NullReferenceException)
            {
                richTextBoxProduct.Text = "There are no Products to view!";
            }


        }

        //CREATE CUSTOMER
        private void buttonAddCostumer_Click(object sender, EventArgs e)
        {

            string costumerName = textBoxCostumerName.Text;
            string costumerMail = textBoxCostumerMail.Text;
            string costumerPhoneNumber = textBoxProductPrice.Text;
            string costumerUserName = textBoxCostumerUserName.Text;
            string costumerAddress = textBoxCostumerAddress.Text;
            string customerID = textBoxCustomerID.Text;

            if (string.IsNullOrWhiteSpace(costumerName) || string.IsNullOrWhiteSpace(costumerMail) || string.IsNullOrWhiteSpace(costumerPhoneNumber)
               || string.IsNullOrWhiteSpace(costumerUserName) || string.IsNullOrWhiteSpace(costumerAddress) || string.IsNullOrWhiteSpace(customerID))
            {
                richTextBoxStore.Text = "Please enter all the fields!";
            }
            else
            {
                
                





                
                  
        }
        }

        //FIND CUSTOMER
        private void buttonFindCostumer_Click(object sender, EventArgs e)
        {

        }

        //UPDATE CUSTOMER
        private void buttonUpdateCostumer_Click(object sender, EventArgs e)
        {

        }

        //DELETE CUSTOMER
        private void buttonDeleteCostumer_Click(object sender, EventArgs e)
        {

        }

        //VIEW ALL COSTUMERS
        private void buttonViewAllCostumers_Click(object sender, EventArgs e)
        {

        }


        //VIEW ALL PRODUCT CATEGORY
        private void buttonViewAllProductCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlDataReader readerViewProductCategory = _layer.printallProductCategory())
                {
                    while (readerViewProductCategory.Read())
                    {
                        richTextBoxProductCategory.Text += "ID: " + readerViewProductCategory.GetInt32(0) + " " + "\n";
                        richTextBoxProductCategory.Text += "Category Name: " + readerViewProductCategory.GetString(1) + " " + "\n";
                        richTextBoxProductCategory.Text += "-----------------------" + "\n";


                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 0)
                {
                    richTextBoxProduct.Text = "No connection with server";
                }
            }
            catch (NullReferenceException)
            {
                richTextBoxProduct.Text = "There are no Product Categories to view!";
            }

          
        }

        private void BtnCreateOrder_Click(object sender, EventArgs e)
        {
            string orderID = textOrderOrderID.Text;
            string date = textOrderDate.Value.ToString("yyyy-MM-dd");
            int productId = int.Parse(comboBoxOrderProductID.SelectedValue.ToString());
            int supermarketID = int.Parse(comboBoxOrderSupermarketID.SelectedValue.ToString());
            int customerID = int.Parse(comboBoxOrderCustomerID.SelectedValue.ToString());



            if (string.IsNullOrWhiteSpace(orderID))
            {
                OrderTextBox.Text = "Please enter an Order ID!";
            }
            else if (comboBoxOrderProductID.SelectedIndex == -1 || comboBoxOrderSupermarketID.SelectedIndex == -1
                     || comboBoxOrderCustomerID.SelectedIndex == -1)
            {
                OrderTextBox.Text = "Please select a value from each of the comboboxes!";
            }
            else
            {
                try
                {
                    int ID = int.Parse(orderID);

                    _layer.AddOrder(ID, date, productId, supermarketID, customerID);

                    OrderTextBox.Text = "The order has been successfully created!" + "\n";

                    textOrderOrderID.Clear();
                    comboBoxOrderProductID.SelectedIndex = -1;
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

        }

        private void BtnUpdateOrder_Click(object sender, EventArgs e)
        {

        }

        private void BtnDeleteOrder_Click(object sender, EventArgs e)
        {

        }

        private void BtnViewAllOrders_Click(object sender, EventArgs e)
        {

        }
    }
}











