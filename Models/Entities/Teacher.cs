namespace TeacheradminPortal.Models.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Department { get; set; }

        public required string Email { get; set; }   

        public string? Phone { get; set; }   

        public decimal Salary { get; set; } 
    }
}
