using System;
using System.Collections.Generic;
using System.Configuration;
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




    }
}
