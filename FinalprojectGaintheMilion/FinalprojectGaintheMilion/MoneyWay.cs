using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalprojectGaintheMilion
{
    public partial class MoneyWay : Form
    {
        public MoneyWay()
        {
            InitializeComponent();

            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 10;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ff1 = new Form1(textBox1.Text);
            if (textBox1.Text == ""||textBox2.Text=="")
            {
                MessageBox.Show("Please Enter Username and Password Maximum 10 length");

            }
            else
            {

                this.Hide();
                Form1 f1 = new Form1(textBox1.Text);
                f1.ShowDialog();
            }
           
               
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoneyWayRule mr = new MoneyWayRule();
            mr.ShowDialog();
        }
    }
}
