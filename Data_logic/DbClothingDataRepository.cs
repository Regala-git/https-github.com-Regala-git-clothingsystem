using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClothingSystem.Common;

namespace ClothingSystem.DataLogic
{
    class DbRepository : IClothingRepository
    {
        
        static string connectionString = "Data Source=REGALA\\SQLEXPRESS;Initial Catalog=ClothingDB;Integrated Security=True;TrustServerCertificate=True;";
        static SqlConnection sqlConnection;

        public DbRepository()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void AddItem(ClothingItem item)
        {
            string insertStatement = "INSERT INTO ClothingItems (CustomerName, Type, Size, Color, Price) VALUES (@CustomerName, @Type, @Size, @Color, @Price)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

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
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var clothingItems = new List<ClothingItem>();

            while (reader.Read())
            {
                ClothingItem item = new ClothingItem();
                item.CustomerName = reader["CustomerName"].ToString();
                item.Type = reader["Type"].ToString();
                item.Size = reader["Size"].ToString();
                item.Color = reader["Color"].ToString();
                item.Price = Convert.ToDecimal(reader["Price"]);

                clothingItems.Add(item);
            }

            sqlConnection.Close();
            return clothingItems;
        }

        public bool RemoveItem(string customerName)
        {
            string deleteStatement = "DELETE FROM ClothingItems WHERE CustomerName = @CustomerName";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            deleteCommand.Parameters.AddWithValue("@CustomerName", customerName);

            sqlConnection.Open();
            int rows = deleteCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rows > 0;
        }

        public List<ClothingItem> SearchByType(string type)
        {
            string selectStatement = "SELECT CustomerName, Type, Size, Color, Price FROM ClothingItems WHERE Type = @Type";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            selectCommand.Parameters.AddWithValue("@Type", type);

            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var result = new List<ClothingItem>();
            while (reader.Read())
            {
                ClothingItem item = new ClothingItem();
                item.CustomerName = reader["CustomerName"].ToString();
                item.Type = reader["Type"].ToString();
                item.Size = reader["Size"].ToString();
                item.Color = reader["Color"].ToString();
                item.Price = Convert.ToDecimal(reader["Price"]);

                result.Add(item);
            }

            sqlConnection.Close();
            return result;
        }
    }
}

