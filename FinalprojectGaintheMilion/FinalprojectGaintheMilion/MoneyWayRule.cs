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
    public partial class MoneyWayRule : Form
    {
        public MoneyWayRule()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoneyWay m2 = new MoneyWay();
            m2.ShowDialog();
        }

        private void MoneyWayRule_Load(object sender, EventArgs e)
        {

        }
    }
}
