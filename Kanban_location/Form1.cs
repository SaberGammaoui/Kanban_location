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
        SqlConnection cx = new SqlConnection(@"Data Source=DESKTOP-QP22EHC\SQLEXPRESS;Initial Catalog=Kanban_location;User id=DESKTOP-QP22EHC\admis;Password=;");
        public Form1()
        {
            InitializeComponent();
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                cx.Open();
                SqlCommand cmd = new SqlCommand("select Type  From Table_location where Material='" + textBox1.Text + "'",cx) ;
                SqlDataReader reader = cmd.ExecuteReader() ;
                if (reader.Read())
                {
                    textBox2.Text = reader["Type"].ToString() ;
                }
                reader.Close();
            }
        }
    }
}
