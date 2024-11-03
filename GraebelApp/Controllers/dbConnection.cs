using GraebelApp.Model;
using Microsoft.Data.SqlClient;
using System.Data;
namespace GraebelApp.Controller

{
    public class dbConnection
    {
        private static string connectionString = "Data Source=localhost;Integrated Security=True;TrustServerCertificate=true;Initial Catalog=Graebel;";
        private static SqlConnection? conn;

        public void connectDB()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        public void CloseDB()
        {
            conn.Close();

        }
        public void AddJobApplication(JobApplication application)
        {
            // create insert query
            var command = new SqlCommand("INSERT INTO Graebel.dbo.JobApplication (firstname, lastname, coverLetter, resume, state, country)" +
                " VALUES (@firstName, @lastName, @coverLetter, @resume, @state, @country)", conn);
            
            command.Parameters.Add("@firstName", SqlDbType.NVarChar);
            command.Parameters.Add("@lastName", SqlDbType.NVarChar);
            command.Parameters.Add("@coverLetter", SqlDbType.NVarChar);
            command.Parameters.Add("@resume", SqlDbType.NVarChar);
            command.Parameters.Add("@state", SqlDbType.NVarChar);
            command.Parameters.Add("@country", SqlDbType.NVarChar);

            command.Parameters["@firstName"].Value = application.firstName;
            command.Parameters["@lastName"].Value = application.lastName;
            command.Parameters["@coverLetter"].Value = application.coverLetter;
            command.Parameters["@resume"].Value = application.resume;
            command.Parameters["@state"].Value = application.state;
            command.Parameters["@country"].Value = application.country;
            try
            {
                Console.WriteLine("Inserting Job application");
                Int32 rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("RowsAffected: {0}", rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
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
                results.Read();

                string firstName = results.GetString(1);
                string lastName = results.GetString(2);
                string coverLetter = results.GetString(3);
                string resume = results.GetString(4);
                string state = results.GetString(5);
                string country = results.GetString(6);
                DateTime date = results.GetDateTime(7);

                JobApplication jobApp = new JobApplication(firstName, lastName, coverLetter, resume, state, country, date.ToString());
                return jobApp;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
