namespace GraebelApp.Model
{
    public class JobApplication
    {
        public JobApplication(string firstName, string lastName, string coverLetter, string resume, string state, string country, string date = null) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.coverLetter = coverLetter;
            this.resume = resume;
            this.state = state;
            this.country = country;
            this.date = date;
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