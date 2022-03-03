using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet_Uygulama
{
    public class CategoryDal
    {
        public static SqlConnection connection =
            new SqlConnection(@"Server=DESKTOP-HNE43R2;Initial Catalog=Northwind;Integrated Security=true");
        public static SqlConnection ConnectionOpen()
        {
            
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
              
            }
            return connection;
        }
        public static void ConnectionClose()
        {
            connection.Close();
        }
        public static List<Category> CategoryList()
        {
            

            SqlCommand command = new SqlCommand("Select CategoryId,CategoryName,Description from Categories", ConnectionOpen());
            SqlDataReader dr = command.ExecuteReader();

            List<Category> categories = new List<Category>();
            Category category;
            while (dr.Read())
            {
                category = new Category();
                category.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                category.CategoryName = dr["CategoryName"].ToString();
                category.Description=dr["Description"].ToString();
                categories.Add(category);
            }
            dr.Close();
            ConnectionClose();
            return categories;
        }
        public static void CategoryAdd(Category category)
        {
            SqlCommand command = new SqlCommand("Insert into Categories (CategoryName,Description) values (@p1,@p2)",
                ConnectionOpen());

            command.Parameters.AddWithValue("@p1", category.CategoryName);
            command.Parameters.AddWithValue("@p2", category.Description);
            command.ExecuteNonQuery();
            ConnectionClose();
        }
        public static void CategoryUpdate(Category category)
        {
            SqlCommand command = new SqlCommand("Update Categories set CategoryName=@p1,Description=@p2 where CategoryId=@p3",
                ConnectionOpen());

            command.Parameters.AddWithValue("@p1", category.CategoryName);
            command.Parameters.AddWithValue("@p2", category.Description);
            command.Parameters.AddWithValue("@p3", category.CategoryId);
            command.ExecuteNonQuery();
            ConnectionClose();
        }
    }
}