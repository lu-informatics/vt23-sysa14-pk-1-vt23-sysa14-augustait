using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            command.CommandText = "SELECT * FROM Product WHERE ProductId = @ProductId";
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



        //METHOD ADD STOREe
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

        public void showAllCustomers()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Customer";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
                Console.WriteLine(reader.GetInt32(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine(reader.GetString(3));
                Console.WriteLine(reader.GetInt32(4));
                Console.WriteLine(reader.GetString(5));

            }
            reader.Close();
            connection.Dispose();
            connection.Close();
            reader.Close();

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
        public void AddOrder(int orderID, string orderDate, int productID, int supermarketID, int customerID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Order_ VALUES (@orderID, @orderDate, @productID, @supermarketID, @customerID)";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@orderDate", orderDate));
            command.Parameters.Add(new SqlParameter("@productID", productID));
            command.Parameters.Add(new SqlParameter("@supermarketID", supermarketID));
            command.Parameters.Add(new SqlParameter("@customerID", customerID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

    
        public SqlDataReader findOrder(int orderID)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Order_ WHERE orderID = @orderID";
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

       
        public void updateOrder(int productID, int supermarketID, int customerID)
        {
            SqlConnection connection = GetDatabaseConnection();


            SqlCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Order_ SET supermarketID = @supermarketID, customerID = @customerID, WHERE orderID = @orderID";
            command.Parameters.Add(new SqlParameter("@productID", productID));
            command.Parameters.Add(new SqlParameter("@supermarketID", supermarketID));
            command.Parameters.Add(new SqlParameter("@customerID", customerID));

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

        public void AddCheckout(int checkoutID, string orderID, int totCost, String paymentMethod)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Checkout VALUES (@checkoutID, @orderID, @totCost, @paymentMethod)";
            command.Parameters.Add(new SqlParameter("@checkoutID", checkoutID));
            command.Parameters.Add(new SqlParameter("@orderID", orderID));
            command.Parameters.Add(new SqlParameter("@totCost", totCost));
            command.Parameters.Add(new SqlParameter("@paymentMethod", paymentMethod));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        public void deleteCheckout(int checkoutID)
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Checkout WHERE CheckoutID = @chekoutID";
            command.Parameters.Add(new SqlParameter("@chekoutID", checkoutID));

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }

        public SqlDataReader findCheckout(int checkoutID)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Checkout WHERE CheckoutID = @checkoutID";
            command.Parameters.Add(new SqlParameter("@checkoutID", checkoutID));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader printallCheckouts()
        {
            SqlConnection connection = GetDatabaseConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Checkout";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            return reader;


        }

        public DataTable GetProductData()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT ProductID FROM Product";
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
            command.CommandText = "SELECT SupermarketID FROM Store";
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
            command.CommandText = "SELECT CustomerID FROM Customer";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable customerData = new DataTable();
            customerData.Load(reader);
            connection.Close();
            return customerData;
        }



    }







}
