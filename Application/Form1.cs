using System.Data.SqlClient;
using System.Drawing.Text;
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

private void buttonViewAllProducts_Click(object sender, EventArgs e)
        {
            using (SqlDataReader readerViewProducts = _layer.printallProducts())
            {
                while (readerViewProducts.Read())
                {
                    richTextBoxProduct.Text += "ID: " + readerViewProducts.GetInt32(0) + " ";
                    richTextBoxProduct.Text += "Name: " + readerViewProducts.GetString(1) + " ";
                    richTextBoxProduct.Text += "Cost: " + readerViewProducts.GetDecimal(2) + "kr " + " ";
                    richTextBoxProduct.Text += "ProductCategoryID: " + readerViewProducts.GetInt32(3) + "\n";
                }
            }
        }






    }
}