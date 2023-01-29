using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq.Expressions;
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



        private void Form1_Load(object sender, EventArgs e)
        {

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

                    textBoxProductID.Text = " ";
                    textBoxProductName.Text = " ";
                    textBoxProductPrice.Text = " ";
                    textBoxCategoryID.Text = " ";
                }
                
               catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    richTextBoxProduct.Text = "A product with the same ID already exists.";
                }
                else if (ex.Number == 547)
                    {
                        richTextBoxProduct.Text = "The category ID provided does not exist.";
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

                    textBoxProductID.Text = " ";
                    textBoxProductName.Text = " ";
                    textBoxProductPrice.Text = " ";
                    textBoxCategoryID.Text = " ";
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        richTextBoxProduct.Text = "A product with the same ID already exists.";
                    }
                }

                catch (FormatException)
                {
                    richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
                }

            }
        }

        //DELETE PRODUCT
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
                    if (readerFindProduct != null)
                    {
                        while (readerFindProduct.Read())
                        {
                            richTextBoxProduct.Text += "ID: " + readerFindProduct.GetInt32(0) + " " + "\n";
                            richTextBoxProduct.Text += "Name: " + readerFindProduct.GetString(1) + " " + "\n";
                            richTextBoxProduct.Text += "Cost: " + readerFindProduct.GetDecimal(2) + "kr " + " " + "\n";
                            richTextBoxProduct.Text += "ProductCategoryID: " + readerFindProduct.GetInt32(3) + "\n";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
               if(ex.Number == 0) {
                    richTextBoxProduct.Text = "No connection with server";
                }
            }
            catch (FormatException)
            {
                richTextBoxProduct.Text = "Invalid input format. Please make sure to provide a positive number for the product ID, and product price.";
            }
            catch (NullReferenceException)
            {
                richTextBoxProduct.Text = "ProductID does not exist";
            }


        }

        //ADD STORE
        private void buttonStoreAdd_Click(object sender, EventArgs e)
        {

        }

        //FIND STORE
        private void buttonStoreFind_Click(object sender, EventArgs e)
        {

        }

        //UPDATE STORE
        private void buttonStoreUpdate_Click(object sender, EventArgs e)
        {

        }

        //DELETE STORE
        private void buttonStoreDelete_Click(object sender, EventArgs e)
        {

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
                            richTextBoxStore.Text += "Store name: " + readerViewStores.GetString(2) + "kr " + " " + "\n";
                            richTextBoxStore.Text += "City: " + readerViewStores.GetString(3) + "\n";
                            richTextBoxStore.Text += "Address: " + readerViewStores.GetString(4) + "\n";
                            richTextBoxStore.Text += "-----------------------" + "\n";
                        

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
    }
    }
   
    




