namespace TeacheradminPortal.Models
{
    public class UpdateTeacherDto
    {
        public required string Name { get; set; }

        public required string Department { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

        public decimal Salary { get; set; }

    }
}
