using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FirstWebApp.Models;

namespace FirstWebApp
{
    public class ProductRepository
    {
        private static string connectionString = "Server=localhost;Database=bestbuy;uid=root;Pwd=password";

        public List<Product> GetAllProducts()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products;";

            using(conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                List<Product> allProducts = new List<Product>();

                while(reader.Read() == true)
                {
                    Product currentProduct = new Product();
                    currentProduct.ID = reader.GetInt32("ProductID");
                    currentProduct.Name = reader.GetString("Name");
                    currentProduct.Price = reader.GetDecimal("Price");
                    currentProduct.OnSale = reader.GetInt32("OnSale");
                    currentProduct.StockLevel = reader.GetString("StockLevel");
                    currentProduct.CategoryID = reader.GetInt32("CategoryID");

                    allProducts.Add(currentProduct);
                }
                return allProducts;
            }
        }
        public Product GetProduct(int id)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Products WHERE ProductID = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                var product = new Product();

                while (reader.Read() == true)
                {
                    Product currentProduct = new Product();
                    product.ID = reader.GetInt32("ProductID");
                    product.Name = reader.GetString("Name");
                    product.Price = reader.GetDecimal("Price");
                    product.OnSale = reader.GetInt32("OnSale");
                    product.StockLevel = reader.GetString("StockLevel");
                    product.CategoryID = reader.GetInt32("CategoryID");


                }
                return product;
            }
        }

        public void UpdateProduct(Product productToUpdate)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = ("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id");
            cmd.Parameters.AddWithValue("name", productToUpdate.Name);
            cmd.Parameters.AddWithValue("price", productToUpdate.Price);
            cmd.Parameters.AddWithValue("id", productToUpdate.ID);

            using(conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertProdyct(Product productToInsert)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);";

            cmd.Parameters.AddWithValue("name", productToInsert.Name);

        }
    }
}
