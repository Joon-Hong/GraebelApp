using GraebelApp.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace GraebelApp.Controller

{
    public class dbConnection
    {
        private static string connectionString = "a";
        private static SqlConnection? conn;

        public SqlConnection connectDB()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }
        public void CloseDB()
        {
            conn.Close();

        }
        public void AddJobApplication(JobApplication application)
        {
            // create insert query
            var command = new SqlCommand("INSERT INTO Graebel.dbo.JobApplication VALUES (@firstName, @lastName, @coverLetter, @resume, @state, @country, @date)", conn);
            
            command.Parameters.Add("@firstName", SqlDbType.NVarChar);
            command.Parameters.Add("@lastName", SqlDbType.NVarChar);
            command.Parameters.Add("@coverLetter", SqlDbType.NVarChar);
            command.Parameters.Add("@resume", SqlDbType.NVarChar);
            command.Parameters.Add("@state", SqlDbType.NVarChar);
            command.Parameters.Add("@country", SqlDbType.NVarChar);
            command.Parameters.Add("@date");

            command.Parameters["@firstName"].Value = application.firstName;
            command.Parameters["@lastName"].Value = application.lastName;
            command.Parameters["@coverLetter"].Value = application.coverLetter;
            command.Parameters["@resume"].Value = application.resume;
            command.Parameters["@state"].Value = application.state;
            command.Parameters["@country"].Value = application.country;
            command.Parameters["@date"].Value = "GETDATE()";
            try
            {
                Console.WriteLine("Inserting Job application");
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public JobApplication GetJobApplication(int id)
        {
            // select jobapp with id
            var command = new SqlCommand("SELECT * FROM Graebel.dbo.JobApplication WHERE id=@id", conn);
            command.Parameters.Add("@id", SqlDbType.Int);
            command.Parameters["@id"].Value = id;
            try
            {
                Console.WriteLine("Getting Job application with id:{0}", id);
                SqlDataReader results = command.ExecuteReader();
                string firstName = results.GetString(1);
                string lastName = results.GetString(2);
                string coverLetter = results.GetString(3);
                string resume = results.GetString(4);
                string state = results.GetString(5);
                string country = results.GetString(6);
                string date = results.GetString(7);

                JobApplication jobApp = new JobApplication(firstName, lastName, coverLetter, resume, state, country, date);
                return jobApp;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
