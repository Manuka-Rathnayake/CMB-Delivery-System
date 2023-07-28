using CMB_Delivery_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMB_Delivery_Management
{
    public partial class Drivers : Form
    {
        public Drivers()
        {
            InitializeComponent();

            panel2.Paint += panel2_Paint;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Driver_details driverDetailsForm = new Driver_details();
            driverDetailsForm.Show();
            this.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
                 
        }

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            var panel = sender as DriverCard;
            if (panel != null)
            {
                panel.BackColor = Color.RoyalBlue;
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            var panel = sender as DriverCard;
            if (panel != null)
            {
                panel.BackColor = Color.White;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            using (Pen pen = new Pen(Color.RoyalBlue))
            {
                pen.DashStyle = DashStyle.Dash;
 
                pen.DashOffset = 4;

                e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, panel.Width - 1, panel.Height - 1));
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Drivers_Load(object sender, EventArgs e)
        {
            var drivers = DAO.FetchDrivers();
            Debug.WriteLine(drivers.Count);

            foreach(var driver in drivers)
            {
                DriverCard driverCard = new DriverCard();
                driverCard.DriverName.Text = driver.driverName;
                driverCard.DriverID.Text = $"#{driver.driverID.ToString().PadLeft(4, '0')}";
                driverCard.MouseEnter += Panel_MouseEnter;
                driverCard.MouseLeave += Panel_MouseLeave;

                DriverList.Controls.Add(driverCard);
            }

        }
    }
}
