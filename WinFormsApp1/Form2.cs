using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
                    string countQuerry = "select count(*) from userlogin where Username = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, DatabaseClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        Form14 form14 = new Form14();
                        form14.Show();
                        Visible = false;
                        DatabaseClass.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect credentials, please try again");
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
