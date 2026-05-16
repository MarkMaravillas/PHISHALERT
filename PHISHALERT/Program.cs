using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PHISHALERT
{
    internal static class Program
    {
        // Connection string targeting the application database
        private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=PhishAlertDB;Trusted_Connection=True;";

        // Connection string targeting the system master database to safely run creation checks
        private static string masterConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True;";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Safely set up database and tables on launch
            InitializeDatabase();

            Application.Run(new Form1());
        }

        private static void InitializeDatabase()
        {
            try
            {
                // Step 1: Connect to 'master' to ensure the database itself exists
                using (SqlConnection masterConnection = new SqlConnection(masterConnectionString))
                {
                    masterConnection.Open();

                    string createDbQuery = @"
                        IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PhishAlertDB')
                        BEGIN
                            CREATE DATABASE PhishAlertDB;
                        END;";

                    using (SqlCommand command = new SqlCommand(createDbQuery, masterConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                // Step 2: Now connect to 'PhishAlertDB' safely to build your table structure
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string createTableQuery = @"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
                        BEGIN
                            CREATE TABLE Users (
                                Id INT IDENTITY(1,1) PRIMARY KEY,
                                Username NVARCHAR(100) NOT NULL UNIQUE,
                                Email NVARCHAR(150) NOT NULL UNIQUE,
                                PasswordHash NVARCHAR(255) NOT NULL
                            );
                        END;";

                    using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Shows you exactly what went wrong if LocalDB fails to connect or initialize
                MessageBox.Show("Database Initialization Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}