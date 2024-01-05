namespace EFCoreTut.Migrations.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        // Relationship with sections M => N
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        // Intermediate
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
