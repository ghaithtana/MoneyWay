using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;




namespace FinalprojectGaintheMilion
{
    public partial class Form1 : Form
    {
        String source = @"Data Source=HP\SQLEXPRESS;Initial Catalog=ghaitht;Integrated Security=True";
        SqlConnection con;
        int total, Question, trueChoice, money;
        
        

        public Form1(String username)
        {
            InitializeComponent();
            label1.Text = username;
            con = new SqlConnection(source);
            con.Open();
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        SqlDataReader query(String sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader = null;

            try
            {
                con.Close();
                con.Open();

                reader = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                reader = null;
            }

            return reader;
        }

        void loadQuestion(int order)
        {
            labelLevel.Text = "Question: " + Question;
            

            SqlDataReader dr = query("select TOP 1 * from [Question] where QOrder = " + order + " ORDER BY NEWID()");

            if (dr.Read())
            {
                labelQuestion.Text = dr["Qtext"].ToString();
                radioChoice1.Text = dr["Choice1"].ToString();
                radioChoice2.Text = dr["Choice2"].ToString();
                radioChoice3.Text = dr["Choice3"].ToString();
                radioChoice4.Text = dr["Choice4"].ToString();
                trueChoice = (int)dr["TrueChoice"];
                money = (int)dr["Money"];

                
            }

        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoneyWay m1 = new MoneyWay();
            m1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
           
            
            buttonNext.Enabled = true;
            Question = 1;
            total = 0;
            loadQuestion(Question);
            buttonStart.Enabled = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (radioChoice1.Checked == false && radioChoice2.Checked == false && radioChoice3.Checked == false && radioChoice4.Checked == false)
            {
                MessageBox.Show("You didnt pressed on any choice! ");
                
            }
            int userChoice = 0;
            if (radioChoice1.Checked)
            {
                userChoice = 1;
            }
            else if (radioChoice2.Checked)
            {
                userChoice = 2;
            }
            else if (radioChoice3.Checked)
            {
                userChoice = 3;
            }
            else
            {
                userChoice = 4;
            }
            

            if (userChoice == trueChoice)
            {
                
                total = total + money;

                labelTotal.Text = total+"TL".ToString();

                Question++;
                loadQuestion(Question);
 
                if (Question > 10)
                {
                    buttonNext.Enabled = false;
                    labelLevel.Text = "";
                    MessageBox.Show("Congrats! You won the Milion TL!!");
                }

                
                  
            }
            else
            {
                buttonStart.Enabled = true;
                if (Question <= 4)
                {
                    MessageBox.Show("Wrong answer you lost!");
                }
                labelQuestion.Text = "";
                labelTotal.Text = "0";
                radioChoice1.Text = "";
                radioChoice2.Text = "";
                radioChoice3.Text = "";
                radioChoice4.Text = "";
                buttonNext.Enabled = false;
                if (Question > 4&&Question<=8 )
                {
                    MessageBox.Show("Congrats! You won 200K TL !!");
                }
                else if (Question > 8 )
                {
                    MessageBox.Show("Congrats! You won 550K TL !!");

                }


            }

           



            radioChoice1.Checked = false;
            radioChoice2.Checked = false;
            radioChoice3.Checked = false;
            radioChoice4.Checked = false;
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
