using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApp.Models;
using MySql.Data.MySqlClient;

namespace FirstWebApp
{
    public class CategoryRepository
    {
        private static string connectionString = "Server=localhost;Database=bestbuy;uid=root;Pwd=password";

        public List<Category> GetCategories()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Categories;";

            using(conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                var allCategories = new List<Category>();

                while(reader.Read() == true)
                {
                    var currentCategory = new Category();
                    currentCategory.CategoryID = reader.GetInt32("CategoryID");
                    currentCategory.Name = reader.GetString("Name");
                    currentCategory.DepartmentID = reader.GetInt32("DepartmentID");
                    allCategories.Add(currentCategory);
                }
                return allCategories;
            }
        }
    }
}
