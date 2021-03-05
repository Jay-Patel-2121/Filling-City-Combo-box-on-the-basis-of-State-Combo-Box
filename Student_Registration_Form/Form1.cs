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

namespace Student_Registration_Form
{
    public partial class Form1 : Form
    {
        Fetch ft = new Fetch();
        public Form1()
        {
            InitializeComponent();
        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataRow dr;
            DataTable dt = ft.states();
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select State--" };
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            // DataTable dt = ft.states();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                int id = Convert.ToInt32(comboBox1.SelectedValue);
                comboBox2.DataSource = ft.city(id);
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                
            }
            catch(Exception ex)
            {
                
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void tb_name_Leave(object sender, EventArgs e)
        {
            if (ft.isNameAvailable(tb_name.Text))
                MessageBox.Show("No such name is available");
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
