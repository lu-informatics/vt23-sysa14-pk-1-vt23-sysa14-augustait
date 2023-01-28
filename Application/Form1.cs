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

            if (!productPriceString.Equals("[0-9]+"))
            {

                int productId = Int32.Parse(productIdString);
                int categoryId = Int32.Parse(categoryIdString);
                decimal productPrice = Decimal.Parse(productPriceString);

                _layer.insertProduct(productId, productName, productPrice, categoryId);

                richTextBoxProduct.Text = "The Product has successfully been created!";

                textBoxProductID.Text = " ";
                textBoxProductName.Text = " ";
                textBoxProductPrice.Text = " ";
                textBoxCategoryID.Text = " ";


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