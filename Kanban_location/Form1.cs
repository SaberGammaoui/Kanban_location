using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Kanban_location
{
    public partial class Form1 : Form
    {
        SqlConnection cx = new SqlConnection(@"Data Source=DESKTOP-QP22EHC\SQLEXPRESS;Initial Catalog=Kanban_location;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listView1.Clear();
                cx.Open();
                SqlCommand cmd = new SqlCommand("select *  From Location where Material='" + textBox1.Text + "'",cx) ;
                SqlDataReader reader = cmd.ExecuteReader() ;
                bool hasrows = false;
                while (reader.Read())
                {
                    hasrows = true;
                    textBox2.Text = reader["Type"].ToString() ;
                    listView1.Items.Add(reader["Location"].ToString());
                    textBox5.Text = reader["Section"].ToString();
                    string color1 = reader["Color1"].ToString();
                    string color2 = reader["Color2"].ToString();
                    label7.Text = color1 +" | "+color2;
                    switch(color1.ToUpper())
                    {
                        case "RD":
                            textBox3.BackColor = Color.Red;                       
                            break;
                        case "YE":
                            textBox3.BackColor = Color.Yellow;                                               
                            break;
                        case "BU":
                            textBox3.BackColor = Color.Blue;
                            break;
                        case "WH":
                            textBox3.BackColor = Color.White;
                            break;
                        case "BN":
                            textBox3.BackColor = Color.Brown;
                            break;
                        case "VT":
                            textBox3.BackColor = Color.Purple;
                            break;
                        case "GN":
                            textBox3.BackColor = Color.Green;
                            break;
                        case "PK":
                            textBox3.BackColor = Color.Pink;
                            break;
                        case "BK":
                            textBox3.BackColor = Color.Black;
                            break;
                        case "GY":
                            textBox3.BackColor = Color.Gray;
                            break;
                        case "OG":
                            textBox3.BackColor = Color.Orange;
                            break;
                        case "BG":
                            textBox3.BackColor = Color.Beige;
                            break;

                        default:
                            textBox3.BackColor = Color.Transparent;
                            break;


                    }
                    switch (color2.ToUpper())
                    {
                        case "RD":
                            textBox4.BackColor = Color.Red;
                            break;
                        case "YE":
                            textBox4.BackColor = Color.Yellow;
                            break;
                        case "BU":
                            textBox4.BackColor = Color.Blue;
                            break;
                        case "WH":
                            textBox4.BackColor = Color.White;
                            break;
                        case "BN":
                            textBox4.BackColor = Color.Brown;
                            break;
                        case "VT":
                            textBox4.BackColor = Color.Purple;
                            break;
                        case "GN":
                            textBox4.BackColor = Color.Green;
                            break;
                        case "PK":
                            textBox4.BackColor = Color.Pink;
                            break;
                        case "BK":
                            textBox4.BackColor = Color.Black;
                            break;
                        case "GY":
                            textBox4.BackColor = Color.Gray;
                            break;
                        case "OG":
                            textBox4.BackColor = Color.Orange;
                            break;
                        case "BG":
                            textBox4.BackColor = Color.Beige;
                            break;

                        default:
                            textBox4.BackColor = Color.Transparent;
                            break;


                    }
                }
                reader.Close();             
                cx.Close();
                if (!hasrows)
                {
                    MessageBox.Show("The entered value does not exist");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox5.Clear();
                    textBox3.BackColor = Color.White;
                    textBox4.BackColor = Color.White;
                    textBox1.Focus();

                }
            }
        }

    }
}
