using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source = (localdb)\\mssqllocaldb; Initial Catalog = eCommerce; Integrated Security = True  ");

        private void showInfo()
        {
            listView1.Items.Clear(); 

            baglan.Open();
            SqlCommand komut = new SqlCommand(@"SELECT * FROM customer_details_view;", baglan);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string customerId = reader["id"].ToString();
                string email = reader["email"].ToString();
                string firstName = reader["first_name"].ToString();
                string lastName = reader["last_name"].ToString();
                string state = reader["state"].ToString();
                string city = reader["city"].ToString();
                string street = reader["street"].ToString();
                string number = reader["number"].ToString();
                string rating = reader["rating"].ToString();
                string description = reader["description"].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = customerId;
                ekle.SubItems.Add(email);
                ekle.SubItems.Add(firstName);
                ekle.SubItems.Add(lastName);
                ekle.SubItems.Add(state);
                ekle.SubItems.Add(city);
                ekle.SubItems.Add(street);
                ekle.SubItems.Add(number);
                ekle.SubItems.Add(rating);
                ekle.SubItems.Add(description);

                listView1.Items.Add(ekle);
            }

            reader.Close();
            baglan.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            showInfo();
        }

  

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView4.Items.Clear();
        }
        private void showProductDetails()
        {
            listView2.Items.Clear();

            baglan.Open();
            SqlCommand komut = new SqlCommand(@"SELECT * FROM product_details_view", baglan);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string productId = reader["id"].ToString();
                string productName = reader["name"].ToString();
                string productDescription = reader["description"].ToString();
                string productPrice = reader["price"].ToString();
                string productWarranty = reader["warranty"].ToString();
                string category = reader["category"].ToString();
                string brand = reader["brand"].ToString();
                string productionDate = reader["production_date"].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = productId;
                ekle.SubItems.Add(productName);
                ekle.SubItems.Add(productDescription);
                ekle.SubItems.Add(productPrice);
                ekle.SubItems.Add(productWarranty);
                ekle.SubItems.Add(category);
                ekle.SubItems.Add(brand);
                ekle.SubItems.Add(productionDate);

                listView2.Items.Add(ekle);
            }

            reader.Close();
            baglan.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showProductDetails();
        }

        private void showProductDetails2()
        {
            listView3.Items.Clear(); // ListView'i temizle

            baglan.Open();
            SqlCommand komut = new SqlCommand(@"SELECT *FROM product_details_with_cond_view", baglan);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string productId = reader["id"].ToString();
                string productName = reader["name"].ToString();
                string productDescription = reader["description"].ToString();
                string productPrice = reader["price"].ToString();
                string productWarranty = reader["warranty"].ToString();
                string category = reader["category"].ToString();
                string brand = reader["brand"].ToString();
                string productionDate = reader["production_date"].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = productId;
                ekle.SubItems.Add(productName);
                ekle.SubItems.Add(productDescription);
                ekle.SubItems.Add(productPrice);
                ekle.SubItems.Add(productWarranty);
                ekle.SubItems.Add(category);
                ekle.SubItems.Add(brand);
                ekle.SubItems.Add(productionDate);

                listView3.Items.Add(ekle);
            }

            reader.Close();
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showProductDetails2();
        }


        private void showDetailsReview()
        {
            listView4.Items.Clear(); 
            baglan.Open();
            SqlCommand komut = new SqlCommand(@"SELECT *From review_details_view", baglan);

            SqlDataReader reader = komut.ExecuteReader();

            while (reader.Read())
            {
                string productId = reader["id"].ToString();
                string productName = reader["product_name"].ToString();
                string productDescription = reader["product_description"].ToString();
                string productPrice = reader["price"].ToString();
                string productWarranty = reader["warranty"].ToString();
                string customerFirstName = reader["first_name"].ToString();
                string customerLastName = reader["last_name"].ToString();
                string rating = reader["rating"].ToString();
                string reviewDescription = reader["review_description"].ToString();

                ListViewItem ekle = new ListViewItem();
                ekle.Text = productId;
                ekle.SubItems.Add(productName);
                ekle.SubItems.Add(productDescription);
                ekle.SubItems.Add(productPrice);
                ekle.SubItems.Add(productWarranty);
                ekle.SubItems.Add(customerFirstName);
                ekle.SubItems.Add(customerLastName);
                ekle.SubItems.Add(rating);
                ekle.SubItems.Add(reviewDescription);

                listView4.Items.Add(ekle);
            }

            reader.Close();
            baglan.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            showDetailsReview();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 hedefForm = new Form2();
            hedefForm.Show(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 hedefForm = new Form3(); 
            hedefForm.Show(); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form4 hedefForm = new Form4();
            hedefForm.Show();
        }
    }
}
