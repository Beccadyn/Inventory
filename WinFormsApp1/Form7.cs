using InventoryManagement;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void fetchProduct()
        {
            string query = "select * from product";
            DataSet ds = new DataSet();
            DataView dv;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {
                DatabaseClass.openConnection();
                MySqlCommand command = new MySqlCommand(query, DatabaseClass.connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                DatabaseClass.closeConnection();

                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where ProductID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Product already exists!");
                    }
                    else
                    {
                        string query = "insert into product(ProductID, ProductName, ProductQuantity, ProductCategory, ProductPrice) values ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New product added succesfully!");
                        
                        DatabaseClass.closeConnection();
                    }
                }
                catch (Exception st)
                {
                    MessageBox.Show(st.Message);
                }

            }
            else
            {
                MessageBox.Show("All fields are required!");
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where ProductID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from product where ProductID= '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product is removed!");
                        
                        DatabaseClass.closeConnection();
                    }
                    else
                    {


                        MessageBox.Show("Product doesn't exist!");
                        DatabaseClass.closeConnection();
                    }
                }
                catch (Exception st)
                {
                    MessageBox.Show(st.Message);
                }

            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where ProductID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "update table product where ProductID = '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product information updated!");

                        DatabaseClass.closeConnection();
                    }
                    else
                    {


                        MessageBox.Show("Product doesn't exist!");
                        DatabaseClass.closeConnection();
                    }
                }
                catch (Exception st)
                {
                    MessageBox.Show(st.Message);
                }

            }
            else
            {
                MessageBox.Show("All fields are required!");
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            fetchProduct();
        }
    }
}
