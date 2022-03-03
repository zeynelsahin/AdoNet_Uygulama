using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet_Uygulama
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CategorList();
           // CategoryAdd();

          // CategoryUpdate();
           //Console.WriteLine("******************");
           //CategorList();
            
         SqlConnection _connection =
            new SqlConnection(@"Server=DESKTOP-HNE43R2;Initial Catalog=Northwind;Integrated Security=true");
        SqlConnection ConnectionOpen()
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return _connection;
            }
             void ConnectionClose()
            {
                _connection.Close();
            }
             Dictionary<string, string> list = new Dictionary<string, string>();
             SqlCommand command = new SqlCommand("Select * from Products", ConnectionOpen());
             SqlDataReader dataReader = command.ExecuteReader();
             while (dataReader.HasRows)
             {
                 for (int i = 0; i < 10; i++)
                 {
                     list.Add(dataReader.GetName(i), dataReader.GetString(i));
                     Console.WriteLine($" {i + 1}. {dataReader.GetName(i)}");
                 }

                 dataReader.NextResult();
             }

             foreach (var item in list)
             {
                 Console.WriteLine($"{item.Key} : {item.Value}");      
             }
            Console.ReadKey();
        }

        private static void CategoryAdd()
        {
            CategoryDal.CategoryAdd(new Category() {CategoryName = "Zeynel", Description = "Zeynelin ürünleri"});
            Console.WriteLine("Eklendi");
        }

        private static void CategorList()
        {
            foreach (var category in CategoryDal.CategoryList())
            {
                Console.WriteLine("ID={0},CategoryName ={1}, Description ={2}", category.CategoryId, category.CategoryName,
                    category.Description);
            }
        }
        private static void CategoryUpdate()
        {
            CategoryDal.CategoryUpdate(new Category(){CategoryId = 14,CategoryName = "Muharrem",Description = "Hooop Güncellendi"});
        }
    }
}
