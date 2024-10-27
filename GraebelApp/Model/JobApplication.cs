namespace GraebelApp.Model
{
    public class JobApplication
    {
        public JobApplication(string firstName, string lastName, string coverLetter, string resume, string state, string country, string date = null) { 

        } 
        public int id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? coverLetter { get; set; }
        public string? resume { get; set; }
        public string? state { get; set; }
        public string? country { get; set; }
        public string? date { get; set; }
    }
}