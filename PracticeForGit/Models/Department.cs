namespace PracticeForGit.Models
{
    public class Department
    {
        public int Id { get; set; } = Guid.NewGuid().GetHashCode();
        public string DeprtName { get; set; }
        public string Description { get; set; }
    }
}
