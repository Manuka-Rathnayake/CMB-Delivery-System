using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CMB_Delivery_Management.Model
{
    internal class DAO
    {
        internal static String ConnectionString { get; set; } = $"Data Source={Server.Name};Initial Catalog=BaggageDeliverySystem;Integrated Security=True";

        internal static bool VerifyUser(String username, String passwordHash, AccountType type)
        {
            if (username == null || passwordHash == null) { return false; }

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    if (Connection.State == System.Data.ConnectionState.Closed)
                        Connection.Open();

                    String ValidationQueury = "SELECT * FROM [dbo].[User] WHERE username=@uname";
                    SqlCommand ValidationCommand = new SqlCommand(ValidationQueury, Connection);
                    ValidationCommand.Parameters.AddWithValue("@uname", username);

                    

                    SqlDataReader ValidationData = ValidationCommand.ExecuteReader();

                    if (!ValidationData.HasRows) 
                    {
                        if (Connection.State == System.Data.ConnectionState.Open)
                        {
                            Connection.Close();
                        }
                        return false; 
                    }

                    while (ValidationData.Read())
                    {
                        User tempUser = new User();
                        tempUser.username = username;
                        tempUser.passwordHash = ValidationData.GetString(1).Trim();
                        tempUser.type = User.ParseAccountType(ValidationData.GetString(2));

                        if (passwordHash.Equals(tempUser.passwordHash)
                            && type.Equals(tempUser.type))
                        {
                            Instances.LoggedUser = tempUser;

                            if (Connection.State == System.Data.ConnectionState.Open)
                            {
                                Connection.Close();
                            }

                            return true;
                        }

                        if (Connection.State == System.Data.ConnectionState.Open)
                        {
                            Connection.Close();
                        }

                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            return false;
        }

        internal static List<Driver> FetchDrivers()
        {
            var drivers = new List<Driver>(); 
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionString))
                {
                    if (Connection.State == System.Data.ConnectionState.Closed)
                        Connection.Open();
                    // DriverID, DriverName, DriverDateJoined, DriverAge
                    String ReadDriverQueury = "SELECT * FROM [dbo].[Driver]";
                    SqlCommand ReadDriverCommand = new SqlCommand(ReadDriverQueury, Connection);



                    SqlDataReader DriverData = ReadDriverCommand.ExecuteReader();

                    while (DriverData.Read())
                    {
                        Driver driver = new Driver()
                        {
                            driverID = DriverData.GetInt32(0),
                            driverName = DriverData.GetString(1),
                            driverDateJoined = DriverData.GetDateTime(2),
                            driverAge = DriverData.GetInt32(3)
                        };

                        drivers.Add(driver);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return drivers;
        }
    }
}
