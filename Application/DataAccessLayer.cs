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
            using (SqlConnection connection = GetDatabaseConnection())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM ProductCategory";
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    return reader;
                }
            }
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
    }
}
