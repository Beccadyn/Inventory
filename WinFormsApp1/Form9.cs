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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DatabaseClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from usermanagement where UserName = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "update table usermanagement where UserName = '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Attendant information updated!");
                        
                        DatabaseClass.closeConnection();
                    }
                    else
                    {


                        MessageBox.Show("User doesn't exist!");
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

        private void button6_Click(object sender, EventArgs e)
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
                    string countQuerry = "select count(*) from usermanagement where UserName = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("User already exists!");
                    }
                    else
                    {
                        string query = "insert into usermanagement(UserID, UserName, UserEmail, UserPhone, UserPassword) values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New attendant added succesfully!");
                        
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
                    string countQuerry = "select count(*) from usermanagement where UserName = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from usermanagement where UserName = '" + textBox1.Text + "')";
                        command = new MySqlCommand(query, DatabaseClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Attendant removed!");
                       
                        DatabaseClass.closeConnection();
                    }
                    else
                    {
                        
                        
                        MessageBox.Show("User doesn't exist!");
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
