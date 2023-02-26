using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Security.Cryptography.X509Certificates;

namespace Application
{
    internal class DataAccessLayer
    {
        public SqlConnection GetDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings
              ["ICAStoreDBConnectionString"].ConnectionString;

            SqlConnectionStringBuilder builder = new(connectionString);

            SqlConnection connection = new(builder.ConnectionString);

            return connection;
        }

        //Prints all from Product Category
        public SqlDataReader printallProductCategory()
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ProductCategory";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        //Prints All Products
        public SqlDataReader printallProducts()
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Product";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;

        }

        //METHOD ADD PRODUCT
        public void insertProduct(int productId, string productName, decimal productPrice, int categoryId)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Product VALUES (@ProductId, @ProductName, @ProductPrice, @CategoryId)";
            command.Parameters.Add(new SqlParameter("@ProductId", productId));
            command.Parameters.Add(new SqlParameter("@ProductName", productName));
            command.Parameters.Add(new SqlParameter("@ProductPrice", productPrice));
            command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        //METHOD DELETE PRODUCT
        public void deleteProduct(int productId)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Product WHERE ProductId = @ProductId";
            command.Parameters.Add(new SqlParameter("@ProductId", productId));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();


        }

        //METHOD UPDATE PRODUCT
        public void updateProduct(int productId, string productName, decimal price)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Product SET ProductName = @ProductName, Price = @Price WHERE ProductID = @ProductId";
            command.Parameters.Add(new SqlParameter("@ProductId", productId));
            command.Parameters.Add(new SqlParameter("@ProductName", productName));
            command.Parameters.Add(new SqlParameter("@Price", price));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }
        
        //METHOD FIND PRODUCT
        public SqlDataReader findProduct(int productId)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Product.ProductID, Product.ProductName, Product.Price, Product.CategoryID, ProductCategory.CategoryName " +
                      "FROM Product " +
                      "JOIN ProductCategory ON Product.CategoryID = ProductCategory.CategoryID  " +
                      "WHERE Product.ProductID = @ProductId";
            command.Parameters.Add(new SqlParameter("@ProductId", productId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        //METHOD ADD ProductCategory
        public void insertProductCategory(int categoryId, string categoryName)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO ProductCategory VALUES (@CategoryId, @CategoryName)";
            command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
            command.Parameters.Add(new SqlParameter("@CategoryName", categoryName));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        //METHOD DELETE ProductCategory
        public void deleteProductCategory(int categoryID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM ProductCategory WHERE CategoryId = @CategoryId";
            command.Parameters.Add(new SqlParameter("@CategoryId", categoryID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();


        }

        //METHOD FIND ProductCategory
        public SqlDataReader findProductCategory(int categoryId)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ProductCategory WHERE CategoryId = @CategoryId";
            command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }


        // METHOD UPDATE ProductCategory
        public void updateProductCategory(int categoryID, string categoryName)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE ProductCategory SET CategoryName = @CategoryName WHERE CategoryID = @CategoryId";
            command.Parameters.Add(new SqlParameter("@CategoryID", categoryID));
            command.Parameters.Add(new SqlParameter("@CategoryName", categoryName));
            ;

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }



        //METHOD ADD STORE
        public void addStore(int supermarketID, string regionName, string storeName, string city, string storeAddress)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Store VALUES (@SupermarketID, @RegionName, @StoreName, @City, @StoreAddress)";
            command.Parameters.Add(new SqlParameter("@SupermarketID", supermarketID));
            command.Parameters.Add(new SqlParameter("@RegionName", regionName));
            command.Parameters.Add(new SqlParameter("@StoreName", storeName));
            command.Parameters.Add(new SqlParameter("@City", city));
            command.Parameters.Add(new SqlParameter("@StoreAddress", storeAddress));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        //METHOD FIND STORE
        public SqlDataReader findStore(int supermarketID)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Store WHERE SupermarketID = @SupermarketID";
            command.Parameters.Add(new SqlParameter("@SupermarketID", supermarketID));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        //METHOD UPDATE STORE
        public void updateStore(int supermarketID, string regionName, string storeName, string city, string storeAddress)
        {
            SqlConnection connection = GetDatabaseConnection();


            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Store SET regionName = @regionName, storeName = @storeName, city = @city, storeAddress = @storeAddress WHERE supermarketID = @supermarketID";
            command.Parameters.Add(new SqlParameter("@SupermarketID", supermarketID));
            command.Parameters.Add(new SqlParameter("@regionName", regionName));
            command.Parameters.Add(new SqlParameter("@storeName", storeName));
            command.Parameters.Add(new SqlParameter("@city", city));
            command.Parameters.Add(new SqlParameter("@storeAddress", storeAddress));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }

        //METHOD DELETE STORE
        public void deleteStore(int supermarketID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Store WHERE SupermarketID = @SupermarketID";
            command.Parameters.Add(new SqlParameter("@SupermarketID", supermarketID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        //METHOD VIEW ALL INFORMATION ABOUT STORE
        public SqlDataReader printallStores()
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Store";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;

        }

        public void addCustomer(string name, int customerId, string userName, string address, int phoneNumber, string eMail)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Customer VALUES (@Name, @CustomerID, @UserName, @Address, @PhoneNumber, @Email)";
            command.Parameters.Add(new SqlParameter("@Name", name));
            command.Parameters.Add(new SqlParameter("@CustomerID", customerId));
            command.Parameters.Add(new SqlParameter("@UserName", userName));
            command.Parameters.Add(new SqlParameter("@Address", address));
            command.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            command.Parameters.Add(new SqlParameter("@Email", eMail));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        public void deleteCustomer(int customerId)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
            command.Parameters.Add(new SqlParameter("@CustomerID", customerId));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        public SqlDataReader findCustomer(int customerId)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
            command.Parameters.Add(new SqlParameter("@CustomerID", customerId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

     

        public void updateCustomer(string name, int customerId, string userName, string address, int phoneNumber, string eMail)
        {
            SqlConnection connection = GetDatabaseConnection();


            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Customer SET Name = @Name, UserName = @UserName, Address = @Address, PhoneNumber = @PhoneNumber, Email = @Email WHERE CustomerID = @CustomerID";
            command.Parameters.Add(new SqlParameter("@CustomerID", customerId)); 

            command.Parameters.Add(new SqlParameter("@Name", name));
            command.Parameters.Add(new SqlParameter("@UserName", userName));
            command.Parameters.Add(new SqlParameter("@Address", address));
            command.Parameters.Add(new SqlParameter("@PhoneNumber", phoneNumber));
            command.Parameters.Add(new SqlParameter("@Email", eMail));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }

        public SqlDataReader showAllCustomers()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Customer";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;

        }
        public SqlDataReader printallOrders()
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Order_";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;


        }
        public void AddOrder(int orderID, string orderDate, int supermarketID, int customerID, string paymentMethod)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Order_ VALUES (@orderID, @orderDate, @supermarketID, @customerID, @paymentMethod)";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@orderDate", orderDate));
            command.Parameters.Add(new SqlParameter("@supermarketID", supermarketID));
            command.Parameters.Add(new SqlParameter("@customerID", customerID));
            command.Parameters.Add(new SqlParameter("@paymentMethod", paymentMethod));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }


        public SqlDataReader findOrder(int orderID)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Order_.OrderID, Order_.CustomerID, Customer.Name, Customer.UserName, Customer.Address, Customer.Email, Store.StoreName, Order_.SupermarketID, Order_.PaymentMethod, Order_.OrderDate FROM Order_" +
                " JOIN Store ON Order_.SupermarketID = Store.SupermarketID " +
                                  " JOIN Customer ON Order_.CustomerID = Customer.CustomerID " +
                                  " WHERE Order_.OrderID = @orderID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }


        public void updateOrder(int orderID, string orderDate, string paymentMethod)
        {
            SqlConnection connection = GetDatabaseConnection();


            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Order_ SET orderDate = @orderDate, paymentMethod = @paymentMethod WHERE orderID = @orderID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@orderDate", orderDate));
            command.Parameters.Add(new SqlParameter("@paymentMethod", paymentMethod));


            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }

       
        public void deleteOrder(int orderID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Order_ WHERE orderID = @orderID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }


      
        //ORDERLINE METHODS
        public void AddOrderline(int orderID, int productID, int orderlineID, int quantity)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Orderline VALUES (@orderID, @productID, @orderlineID, @quantity)";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@productID", productID));
            command.Parameters.Add(new SqlParameter("@orderlineID", orderlineID));
            command.Parameters.Add(new SqlParameter("@quantity", quantity));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }


           public void deleteOrderline(int orderID, int productID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Orderline WHERE OrderID = @orderID AND ProductID = @productID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@productID", productID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        public void updateOrderline(int orderID, int productID, int orderlineID, int quantity)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Orderline SET orderlineNumber = @orderlineID, quantity = @quantity WHERE OrderID = @orderID AND ProductID = @productID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@productID", productID));
            command.Parameters.Add(new SqlParameter("@orderlineID", orderlineID));
            command.Parameters.Add(new SqlParameter("@quantity", quantity));
          
            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }

    public SqlDataReader findOrderlinesByOrderID(int orderID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Orderline WHERE OrderID = @orderID ORDER BY OrderID";
            command.Parameters.AddWithValue("@orderID", orderID);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader findOrderlinesByOrderIDandProductID(int orderID, int productID)
        {
            {
                SqlConnection connection = GetDatabaseConnection();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT Orderline.OrderlineNumber, Orderline.OrderID, Orderline.ProductID, 
                        Product.ProductName, Product.Price, Order_.OrderDate, Store.StoreName, 
                        Order_.SupermarketID, Orderline.Quantity, Order_.PaymentMethod,
                        Orderline.Quantity * Product.Price AS TotalPrice
                        FROM Orderline 
                        JOIN Order_ ON Orderline.OrderID = Order_.OrderID 
                        JOIN Product ON Orderline.ProductID = Product.ProductID 
                        JOIN Store ON Order_.SupermarketID = Store.SupermarketID 
                        WHERE Orderline.OrderID = @orderID AND Orderline.ProductID = @productID";
                command.Parameters.AddWithValue("@orderID", orderID);
                command.Parameters.AddWithValue("@productID", productID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
        }

        //METHODS FOR COLLECTING DATA
        public DataTable GetProductData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT ProductID, ProductName FROM Product";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable productData = new DataTable();
            productData.Load(reader);
            connection.Close();
            return productData;
        }

        public DataTable GetSupermarketData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT SupermarketID, StoreName FROM Store";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable supermarketData = new DataTable();
            supermarketData.Load(reader);
            connection.Close();
            return supermarketData;
        }

        public DataTable GetCustomerData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CustomerID, Name FROM Customer";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable customerData = new DataTable();
            customerData.Load(reader);
            connection.Close();
            return customerData;
        }

        public DataTable GetProductCategoryData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CategoryID, CategoryName FROM ProductCategory";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable categoryData = new DataTable();
            categoryData.Load(reader);
            connection.Close();
            return categoryData;
        }


        public DataTable GetOrderData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT OrderID FROM Order_";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
           
            DataTable orderData = new DataTable();
            orderData.Load(reader);
            connection.Close();
            return orderData;
        }

        //Data for GridView
        public DataSet View(string type)
        {
            DataSet dataSet = new();

            if (type == "Orderline")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT Orderline.OrderlineNumber, Orderline.OrderID, Orderline.ProductID, ProductName, OrderDate, StoreName, " +
                        "Order_.SupermarketID, Orderline.Quantity, Order_.PaymentMethod,  (Price * Quantity) AS TotalAmount " +
                        "FROM Orderline JOIN Order_ ON Orderline.OrderID = Order_.OrderID " +
                        "JOIN Product ON Orderline.ProductID = Product.ProductID " +
                        "JOIN Store ON Order_.SupermarketID = Store.SupermarketID";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "Orderline");

                    return dataSet;
                }
            }

            
            return dataSet;
        }

        public DataSet ViewOrder(string type)
        {
            DataSet dataSet = new();

            if (type == "Order_")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT Order_.OrderID, Order_.CustomerID, Customer.Name, Customer.UserName, Customer.Address, Customer.Email, Store.StoreName, Order_.SupermarketID, Order_.PaymentMethod FROM Order_" +
                        " JOIN Store ON Order_.SupermarketID = Store.SupermarketID " +
                        " JOIN Customer ON Order_.CustomerID = Customer.CustomerID ";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "Order_");

                    return dataSet;
                }
            }


            return dataSet;
        }

        public DataSet ViewProduct(string type)
        {
            DataSet dataSet = new();

            if (type == "Product")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT Product.ProductID, Product.ProductName, Product.Price, Product.CategoryID, ProductCategory.CategoryName FROM Product " +
                        "JOIN ProductCategory ON Product.CategoryID = ProductCategory.CategoryID";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "Product");

                    return dataSet;
                }
            }


            return dataSet;
        }

        public DataSet ViewStore(string type)
        {
            DataSet dataSet = new();

            if (type == "Store")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT  * FROM Store";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "Store");

                    return dataSet;
                }
            }


            return dataSet;
        }

        public DataSet ViewCustomer(string type)
        {
            DataSet dataSet = new();

            if (type == "Customer")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT  * FROM Customer";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "Customer");

                    return dataSet;
                }
            }


            return dataSet;
        }

        public DataSet ViewProductCategory(string type)
        {
            DataSet dataSet = new();

            if (type == "ProductCategory")
            {
                using (SqlConnection connection = GetDatabaseConnection())
                {
                    SqlCommand command = GetDatabaseConnection().CreateCommand();
                    command.CommandText = "SELECT  * FROM ProductCategory";

                    SqlDataAdapter dataAdapter = new(command);
                    dataAdapter.Fill(dataSet, "ProductCategory");

                    return dataSet;
                }
            }


            return dataSet;
        }

        //METHODS FOR UPDATING COMBOBOXES
        public List<string> GetProductDataCombobox()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT ProductName FROM Product";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> productData = new List<string>();

            while (reader.Read())
            {
                string productName = reader.GetString(0);
                productData.Add(productName);
            }

            connection.Close();
            return productData;
        }

        public List<string> GetSupermarketDataCombobox()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT StoreName FROM Store";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> supermarketData = new List<string>();

            while (reader.Read())
            {
                string storeName = reader.GetString(0);
                supermarketData.Add(storeName);
            }

            connection.Close();
            return supermarketData;
        }

        public List<string> GetCustomerDataCombobox()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT Name FROM Customer";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> customerData = new List<string>();

            while (reader.Read())
            {
                string customerName = reader.GetString(0);
                customerData.Add(customerName);
            }

            connection.Close();
            return customerData;
        }

        public List<string> GetProductCategoryDataCombobox()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT CategoryName FROM ProductCategory";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<string> categoryData = new List<string>();

            while (reader.Read())
            {
                string categoryName = reader.GetString(0);
                categoryData.Add(categoryName);
            }

            connection.Close();
            return categoryData;
        }

        public List<int> GetOrderDataCombobox()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT OrderID FROM Order_";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<int> orderData = new List<int>();
            while (reader.Read())
            {
                int orderID = reader.GetInt32(0);
                orderData.Add(orderID);
            }

            connection.Close();
            return orderData;
        }
        public int CheckOrderline(int orderID, int orderlineNumber)
        {
            SqlConnection connection = GetDatabaseConnection();
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM Orderline WHERE OrderID = @OrderID AND OrderlineNumber = @OrderlineNumber";
                command.Parameters.AddWithValue("@OrderID", orderID);
                command.Parameters.AddWithValue("@OrderlineNumber", orderlineNumber);
                connection.Open();

                int count = (int)command.ExecuteScalar();
                connection.Close();

                return count;
            }
        }

    
        }
    }


