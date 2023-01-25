using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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

    }
}
