namespace StudentPortalMVC.Models
{
    public class Mark
    {
        public int Id { get; set; }

        public int Semester { get; set; }

        public int Subject1 { get; set; }

        public int Subject2 { get; set; }

        public int Subject3 { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}