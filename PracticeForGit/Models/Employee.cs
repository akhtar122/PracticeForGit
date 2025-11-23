namespace PracticeForGit.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public decimal Salary { get; set; }

        // Added FK to Department. Nullable so existing employees without a department are allowed.
        public int? DepartmentId { get; set; }

        // Navigation property
        public Department? Department { get; set; }
    }
}
