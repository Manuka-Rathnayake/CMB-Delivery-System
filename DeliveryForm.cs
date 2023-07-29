using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CMB_Delivery_Management
{
    public partial class DeliveryForm : Form
    {
        public DeliveryForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Address.Text = "";
            Baggage.Text = "";
            contact.Text = "";
            tempbox.Text = "";
            description.Text = "";
            status.Text = "STATUS : PENDING";
            status.BackColor = Color.RoyalBlue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Close();

        }

        private void contact_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            status.ForeColor = Color.Black;
            status.BackColor = Color.DarkSeaGreen;
            status.Text = "STATUS : SUBMITTED";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            description.Text = tempbox.Text;
        }
    }
}
