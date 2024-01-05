namespace EFCoreTut.Migrations.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }

        // One => One With Office Entity
        public int? OfficeId { get; set; } // Foreign Key To The Office Entity
        public Office? Office { get; set; } // Navigation Property To The Parent Entity (Office)

        // One => Many With Section Entity
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
