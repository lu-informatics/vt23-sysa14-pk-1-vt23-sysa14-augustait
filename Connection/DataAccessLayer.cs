﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection
{
    public class DataAccessLayer
    {
        public SqlConnection GetDatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings
              ["ICAStoreDBConnectionString"].ConnectionString;
           
            SqlConnectionStringBuilder builder = new(connectionString);
            
            SqlConnection connection = new(builder.ConnectionString);

            return connection;     
        }
      
        //Prints 
        public void printallProducts()
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ProductCategory";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();          
            
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));

            }
            reader.Close();
            connection.Dispose();
            connection.Close();
            reader.Close();

        }
        public void insertProduct(int productId, string productName, double productPrice, int categoryId)
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

       
        public void deleteProduct (int productId) 
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
        public void findProduct(int productId)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Product WHERE ProductId = @ProductId";
            command.Parameters.Add(new SqlParameter("@ProductId", productId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetDecimal(2));
                Console.WriteLine(reader.GetInt32(3));

            }
            reader.Close();
            connection.Dispose();
            connection.Close();
        }

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

        public void findProductCategory(int categoryId)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM ProductCategory WHERE CategoryId = @CategoryId";
            command.Parameters.Add(new SqlParameter("@CategoryId", categoryId));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
             

            }
            reader.Close();
            connection.Dispose();
            connection.Close();
        }

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

        public void findStore(int supermarketID)
        {
            SqlConnection connection = GetDatabaseConnection();

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Store WHERE SupermarketID = @SupermarketID";
            command.Parameters.Add(new SqlParameter("@SupermarketID", supermarketID));
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader.GetInt32(0));
                Console.WriteLine(reader.GetString(1));
                Console.WriteLine(reader.GetString(2));
                Console.WriteLine(reader.GetString(3));
                Console.WriteLine(reader.GetString(4));
            }
            reader.Close();
            connection.Dispose();
            connection.Close();
        }



    }
}
