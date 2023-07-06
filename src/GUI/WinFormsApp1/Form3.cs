using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void showInfoProducts()
        {
            listView1.Items.Clear();

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM products", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string productId = reader["id"].ToString();
                    string productName = reader["name"].ToString();
                    string productPrice = reader["price"].ToString();
                    string productDescription = reader["description"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = productId;
                    item.SubItems.Add(productName);
                    item.SubItems.Add(productPrice);
                    item.SubItems.Add(productDescription);

                    listView1.Items.Add(item);
                }

                reader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            string updateQuery = "UPDATE products SET price = 19.99 WHERE id = 9";

        
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
        
                SqlCommand command = new SqlCommand(updateQuery, connection);

                try
                {
                   
                    connection.Open();

                    command.ExecuteNonQuery();

                   
                    MessageBox.Show("Ürün fiyatı güncellendi!");
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";
            int categoryId = 1009;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand($"DELETE FROM categories WHERE id = {categoryId}", connection);

                try
                {
                
                    connection.Open();

                  
                    command.ExecuteNonQuery();
                  
                    MessageBox.Show("Kate4gori silindi!");
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";
            int orderId = 1010;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
            
                SqlCommand command = new SqlCommand($"DELETE FROM orders WHERE id = {orderId}", connection);

                try
                {
              
                    connection.Open();

                    command.ExecuteNonQuery();

                    MessageBox.Show("Sipariş silindi!");
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showInfoProducts();
        }

        private void showInfoPriceChangeLogs()
        {
            listView2.Items.Clear(); 

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM price_change_logs", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string logId = reader["id"].ToString();
                    string productId = reader["product_id"].ToString();
                    string oldPrice = reader["old_price"].ToString();
                    string newPrice = reader["new_price"].ToString();
                    string changeDate = reader["change_date"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = logId;
                    item.SubItems.Add(productId);
                    item.SubItems.Add(oldPrice);
                    item.SubItems.Add(newPrice);
                    item.SubItems.Add(changeDate);

                    listView2.Items.Add(item);
                }

                reader.Close();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            showInfoPriceChangeLogs();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void showInfoCategories()
        {
            listView3.Items.Clear();

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM categories", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryId = reader["id"].ToString();
                    string categoryName = reader["name"].ToString();
                    string categoryDescription = reader["description"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = categoryId;
                    item.SubItems.Add(categoryName);
                    item.SubItems.Add(categoryDescription);

                    listView3.Items.Add(item);
                }

                reader.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            showInfoCategories();
        }


        private void showInfoCategoriesHasProduct()
        {
            listView4.Items.Clear(); 
    
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM categories_has_products", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string categoryId = reader["categories_id"].ToString();
                    string productId = reader["products_id"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = categoryId;
                    item.SubItems.Add(productId);

                    listView4.Items.Add(item);
                }

                reader.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            showInfoCategoriesHasProduct();
        }


        private void showInfoOrders()
        {
            listView5.Items.Clear(); 

          
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM orders", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string orderId = reader["id"].ToString();
                    string customerId = reader["customers_id"].ToString();
                    string purchaseDate = reader["purchase_date"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = orderId;
                    item.SubItems.Add(customerId);
                    item.SubItems.Add(purchaseDate);

                    listView5.Items.Add(item);
                }

                reader.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showInfoOrders();
        }


        private void showInfoOrderItems()
        {
            listView6.Items.Clear(); 

         
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM order_items", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string orderId = reader["orders_id"].ToString();
                    string itemId = reader["items_id"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = orderId;
                    item.SubItems.Add(itemId);

                    listView6.Items.Add(item);
                }

                reader.Close();
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            showInfoOrderItems();
        }

        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
