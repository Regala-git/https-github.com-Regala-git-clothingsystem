using System;
using System.Collections.Generic;
using ClothingSystem.Common;
using Microsoft.Data.SqlClient;

namespace ClothingSystem.DataLogic
{
    public class DbDataService : IClothingDataService
    {
        private readonly string connectionString =
            "Data Source=DESKTOP-1JB1MNV\\SQLEXPRESS;Initial Catalog=ClothingDB;Integrated Security=True;TrustServerCertificate=True;";
        private static SqlConnection sqlConnection;

        public DbDataService()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddItem(ClothingItem item)
        {
            string query = "INSERT INTO ClothingItems (CustomerName, Type, Size, Color, Price) VALUES (@CustomerName, @Type, @Size, @Color, @Price)";
            using SqlCommand insertCommand = new SqlCommand(query, sqlConnection);
            insertCommand.Parameters.AddWithValue("@CustomerName", item.CustomerName);
            insertCommand.Parameters.AddWithValue("@Type", item.Type);
            insertCommand.Parameters.AddWithValue("@Size", item.Size);
            insertCommand.Parameters.AddWithValue("@Color", item.Color);
            insertCommand.Parameters.AddWithValue("@Price", item.Price);

            sqlConnection.Open();
            insertCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<ClothingItem> GetAllItems()
        {
            string selectStatement = "SELECT CustomerName, Type, Size, Color, Price FROM ClothingItems";
            using SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var clothingItems = new List<ClothingItem>();
            while (reader.Read())
            {
                ClothingItem item = new ClothingItem
                {
                    CustomerName = reader["CustomerName"].ToString(),
                    Type = reader["Type"].ToString(),
                    Size = reader["Size"].ToString(),
                    Color = reader["Color"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"])
                };
                clothingItems.Add(item);
            }

            sqlConnection.Close();
            return clothingItems;
        }

        public bool RemoveItem(string customerName)
        {
            string deleteStatement = "DELETE FROM ClothingItems WHERE CustomerName = @CustomerName";
            using SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@CustomerName", customerName);

            sqlConnection.Open();
            int rows = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rows > 0;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            string selectStatement = "SELECT CustomerName, Type, Size, Color, Price FROM ClothingItems WHERE Type = @Type";
            using SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Type", type);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var result = new List<ClothingItem>();
            while (reader.Read())
            {
                ClothingItem item = new ClothingItem
                {
                    CustomerName = reader["CustomerName"].ToString(),
                    Type = reader["Type"].ToString(),
                    Size = reader["Size"].ToString(),
                    Color = reader["Color"].ToString(),
                    Price = Convert.ToDecimal(reader["Price"])
                };
                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }

        public bool Exists(string customerName)
        {
            string query = "SELECT COUNT(*) FROM ClothingItems WHERE CustomerName = @CustomerName";
            using SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@CustomerName", customerName);

            sqlConnection.Open();
            int count = (int)command.ExecuteScalar();
            sqlConnection.Close();

            return count > 0;
        }
    }
}
