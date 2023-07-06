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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = eCommerce; Integrated Security = True  ");

        string state = "Turkey";
        string city = "Balıkesir";
        string street = "Cengaver";
        int number = 12;
        private void addAddress(string state, string city, string street, int number)
        {
            listView1.Items.Clear();
            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO addresses (state, city, street, number) VALUES (@State, @City, @Street, @Number)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@State", state);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Street", street);
                    command.Parameters.AddWithValue("@Number", number);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            showInfoAddress();
        }

        private void deleteAddress()
        {

            listView1.Items.Clear();

            int id = Convert.ToInt32(textBox1.Text);

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM addresses WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            showInfoAddress();
        }

        private void updateAddress()
        {

            listView1.Items.Clear();

            int id = Convert.ToInt32(textBox1.Text);
            string newCity = textBox2.Text;

            // Veritabanı bağlantı dizesi
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE addresses SET city = @NewCity WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewCity", newCity);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            showInfoAddress();
        }


        private void showInfoAddress()
        {
            listView1.Items.Clear(); // ListView'i temizle

            baglan.Open();
            SqlCommand komut = new SqlCommand(@"SELECT * FROM addresses", baglan);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string addressId = reader["id"].ToString();
                string state = reader["state"].ToString();
                string city = reader["city"].ToString();
                string street = reader["street"].ToString();
                string number = reader["number"].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = addressId;
                ekle.SubItems.Add(state);
                ekle.SubItems.Add(city);
                ekle.SubItems.Add(street);
                ekle.SubItems.Add(number);

                listView1.Items.Add(ekle);
            }

            reader.Close();
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addAddress(state, city, street, number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showInfoAddress();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteAddress();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateAddress();
        }

        string name = "Bosch";
        string desc = "high quality";
        private void addBrand()
        {
            listView2.Items.Clear();

           
            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO brands (name, description) VALUES (@Name, @Description)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Description", desc);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoBrands();
        }


        private void deleteBrand()
        {
            listView2.Items.Clear();

            int id = Convert.ToInt32(textBox3.Text);

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM brands WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoBrands();
        }

        private void updateBrand()
        {
            listView2.Items.Clear();

            int id = Convert.ToInt32(textBox3.Text);
            string newDescription = textBox4.Text;

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE brands SET description = @NewDescription WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewDescription", newDescription);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoBrands();
        }




        private void showInfoBrands()
        {
            listView2.Items.Clear(); 

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM brands", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string brandId = reader["id"].ToString();
                    string brandName = reader["name"].ToString();
                    string brandDescription = reader["description"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = brandId;
                    item.SubItems.Add(brandName);
                    item.SubItems.Add(brandDescription);

                    listView2.Items.Add(item);
                }

                reader.Close();
            }
        }



        private void button7_Click(object sender, EventArgs e)
        {
            showInfoBrands();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            addBrand();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            deleteBrand();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateBrand();
        }


        private void addCustomer()
        {
            listView2.Items.Clear();

            string email = "burak@gmail.com";
            string firstName = "Burak";
            string lastName = "İnal";
            int addressId = Convert.ToInt32(textBox7.Text);

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO customers (email, first_name, last_name, addresses_id) VALUES (@Email, @FirstName, @LastName, @AddressId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@AddressId", addressId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoCustomers();
        }



        private void deleteCustomer()
        {
            listView3.Items.Clear();

            int id = Convert.ToInt32(textBox5.Text);

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM customers WHERE id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoCustomers();
        }

        private void updateCustomer()
        {
            listView3.Items.Clear();

            int customerId = Convert.ToInt32(textBox5.Text);
            string newFirstName = textBox6.Text;

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE customers SET first_name = @NewFirstName WHERE id = @CustomerId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewFirstName", newFirstName);
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            showInfoCustomers();
        }





        private void showInfoCustomers()
        {
            listView3.Items.Clear(); 

            string connectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=eCommerce;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM customers", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string customerId = reader["id"].ToString();
                    string email = reader["email"].ToString();
                    string firstName = reader["first_name"].ToString();
                    string lastName = reader["last_name"].ToString();
                    string addressId = reader["addresses_id"].ToString();

                    ListViewItem item = new ListViewItem();
                    item.Text = customerId;
                    item.SubItems.Add(email);
                    item.SubItems.Add(firstName);
                    item.SubItems.Add(lastName);
                    item.SubItems.Add(addressId);

                    listView3.Items.Add(item);
                }

                reader.Close();
            }
        }


        private void button11_Click(object sender, EventArgs e)
        {
            showInfoCustomers();
        }


        private void button12_Click(object sender, EventArgs e)
        {
            addCustomer();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            deleteCustomer();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            updateCustomer();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
