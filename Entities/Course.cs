namespace EFCoreTut.Migrations.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string? CourseName { get; set; }
        public decimal Price { get; set; }

        // One => Many With Section Entity
        public ICollection<Section> Sections { get; set; } = new List<Section>();
    }
}
