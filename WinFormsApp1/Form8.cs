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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from productcategory where PCatID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Category already exists!");
                    }
                    else
                    {
                        string query = "insert into productcategory(PCatID, PCatName) values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New product category added succesfully!");
                       
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
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from productcategory where PCatID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from productcategory where PCatID = '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product category removed!");
                        
                        DatabaseClass.closeConnection();
                    }
                    else
                    {


                        MessageBox.Show("Product category doesn't exist!");
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
                    string countQuerry = "select count(*) from productcategory where PCatID = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "update table productcategory where PCatID = '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product category information updated!");
                        
                        DatabaseClass.closeConnection();
                    }
                    else
                    {


                        MessageBox.Show("Product category doesn't exist!");
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
    }
}
