using CMB_Delivery_Management.Helpers;
using CMB_Delivery_Management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMB_Delivery_Management
{
    public partial class AddDriver : Form
    {
        public AddDriver()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DriverId.Text = "";
            DriverName.Text = "";
            Driver_DateJoined.Text = "";
            DriverAge.Text = "";
        }

        private bool CheckDriverExists(string driverId)
        {
            try
            {

                SqlConnection connection = new SqlConnection(DAO.ConnectionString);
                {
                    connection.Open();

                    string query = $"SELECT COUNT(*) FROM DriverCred WHERE DriverId = '{driverId}'";
                    SqlCommand command = new SqlCommand(query, connection);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }

            return false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string Did = DriverId.Text;

            try
            {
                bool driverExists = CheckDriverExists(Did);

                if (driverExists)
                {
                    MessageBox.Show("A driver with the same ID already exists.");
                    return;
                }

                (String, String) cred = GenerateCredentials(Did);

                string DName = DriverName.Text;
                string Date = Driver_DateJoined.Text;
                string Age = DriverAge.Text;

                SqlConnection connection = new SqlConnection(DAO.ConnectionString);

                connection.Open();


                string query = $"INSERT INTO DriverCred (DriverId,Driver_name,Driver_DateJoined,Driver_age) VALUES ('{Did}', '{DName}','{Date}','{Age}')";
                SqlCommand command = new SqlCommand(query, connection);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Driver information inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Insertion failed.");
                }

                string query_cred = $"INSERT INTO Driver VALUES (@driverId, @username, @password)";
                SqlCommand command_cred = new SqlCommand(query_cred, connection);
                command_cred.Parameters.AddWithValue("@driverId", Did);
                command_cred.Parameters.AddWithValue("@username", cred.Item1);
                command_cred.Parameters.AddWithValue("@password", cred.Item2);


                int rowsAffected_cred = command_cred.ExecuteNonQuery();
                if (rowsAffected_cred > 0)
                {
                    MessageBox.Show("Driver Login information inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Insertion failed.");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }


        }

        private (String, String) GenerateCredentials(String id)
        {
            return ($"driver{id}", Hashing.CalculateMD5($"driverpass{id}"));
        }
    }
}
