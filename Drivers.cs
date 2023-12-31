﻿using CMB_Delivery_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        }

       

        private void panel6_Click(object sender, EventArgs e)
        {
            Driver_details driverDetailsForm = new Driver_details();
            driverDetailsForm.Show();
            this.Close();
        }

      

        private void Panel_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.RoyalBlue;
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.White;
            }
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

       
        private void Drivers_Load(object sender, EventArgs e)
        {
            LoadDriverData();
        }

        private void LoadDriverData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(DAO.ConnectionString);

                SqlCommand command = new SqlCommand("SELECT * FROM DriverCred", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["DriverId"], reader["Driver_name"], reader["Driver_DateJoined"], reader["Driver_age"], reader["Driver_Status"]);
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void AddDriver_Click(object sender, EventArgs e)
        {
            AddDriver objaddDriver = new AddDriver();
            objaddDriver.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard objdashboard = new Dashboard();   
            objdashboard.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadDriverData();
        }

        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string driverId = selectedRow.Cells["Driver_ID"].Value.ToString();

                
                dataGridView1.Rows.Remove(selectedRow);

                
                DeleteDriverFromDatabase(driverId);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteDriverFromDatabase(string driverId)
        {
            SqlConnection connection = new SqlConnection(DAO.ConnectionString);
            
            try
            {
                connection.Open();

                string query = "DELETE FROM DriverCred WHERE DriverId = @DriverId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DriverId", driverId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Driver information deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Deletion failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDriver objupdatedr = new UpdateDriver();
                int RowIndex = dataGridView1.SelectedRows[0].Index;
                string DriverId = dataGridView1.Rows[RowIndex].Cells[0].Value.ToString();
                //Debug.WriteLine(DriverId);
                objupdatedr.SelectDriver(int.Parse(DriverId));
                objupdatedr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PendingDeliveries objPdeliveries = new PendingDeliveries();
            objPdeliveries.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Drivers objdriverpage = new Drivers();
            objdriverpage.Show();
            this.Hide();
        }
    }
}
