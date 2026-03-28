namespace OnetoOneEFMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        // one student -> one room
        public HostelRoom AssignedRoom { get; set; }
    }
}
