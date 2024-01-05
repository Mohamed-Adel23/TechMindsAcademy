namespace EFCoreTut.Migrations.Entities
{
    public class Section
    {
        public int Id { get; set; }
        public string? SectionName { get; set; }

        // One => Many With Course Entity (Required)
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        // One => Many With Instructor Entity (Optional)
        public int? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }

        // Many to Many
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
        // Intermediate Tables
        public ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();

        // Relationship With Students M => N
        public ICollection<Student> Students { get; set; } = new List<Student>();
        // Intermediate
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
