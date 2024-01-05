using EFCoreTut.Migrations.Data.Config;
using EFCoreTut.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreTut.Migrations.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SectionSchedule> SectionSchedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var constr = config.GetSection("ConnectionString").Value;

            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);

            modelBuilder.Entity<Course>().HasData(LoadCourses());
            modelBuilder.Entity<Instructor>().HasData(LoadInstructors());
            modelBuilder.Entity<Office>().HasData(LoadOffices());
            modelBuilder.Entity<Section>().HasData(LoadSections());
            modelBuilder.Entity<Schedule>().HasData(LoadSchedules());
            modelBuilder.Entity<SectionSchedule>().HasData(LoadSectionSchedules());
            modelBuilder.Entity<Student>().HasData(LoadStudents());
            modelBuilder.Entity<Enrollment>().HasData(LoadEnrollments());
        }

        private static List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, CourseName = "Mathmatics", Price = 1000m},
                new Course { Id = 2, CourseName = "Physics", Price = 2000m},
                new Course { Id = 3, CourseName = "Chemistry", Price = 1500m},
                new Course { Id = 4, CourseName = "Biology", Price = 1200m},
                new Course { Id = 5, CourseName = "CS-50", Price = 3000m},
            };
        }

        private static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor { Id = 1, FName = "Ahmed", LName = "Abdullah", OfficeId = 1},
                new Instructor { Id = 2, FName = "Yasmeen", LName = "Shawky", OfficeId = 3},
                new Instructor { Id = 3, FName = "Khalid", LName = "Hassan", OfficeId = 2},
                new Instructor { Id = 4, FName = "Nadia", LName = "Ali", OfficeId = 4},
                new Instructor { Id = 5, FName = "Ahmed", LName = "Abdullah", OfficeId = 5},
                //new Instructor { Id = 1, Name = "Ahmed"},
                //new Instructor { Id = 2, Name = "Yasmeen"},
                //new Instructor { Id = 3, Name = "Khalid"},
                //new Instructor { Id = 4, Name = "Nadia"},
                //new Instructor { Id = 5, Name = "Ahmed"},
            };
        }

        private static List<Office> LoadOffices()
        {
            return new List<Office>
            {

                    new Office { Id = 1, OfficeName = "Off_05", OfficeLocation = "building A"},
                    new Office { Id = 2, OfficeName = "Off_12", OfficeLocation = "building B"},
                    new Office { Id = 3, OfficeName = "Off_32", OfficeLocation = "Adminstration"},
                    new Office { Id = 4, OfficeName = "Off_44", OfficeLocation = "IT Department"},
                    new Office { Id = 5, OfficeName = "Off_43", OfficeLocation = "IT Department"}
            };
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", CourseId = 1, InstructorId = 1},
                new Section { Id = 2, SectionName = "S_MA2", CourseId = 1, InstructorId = 2},
                new Section { Id = 3, SectionName = "S_PH1", CourseId = 2, InstructorId = 1},
                new Section { Id = 4, SectionName = "S_PH2", CourseId = 2, InstructorId = 3},
                new Section { Id = 5, SectionName = "S_CH1", CourseId = 3, InstructorId =2},
                new Section { Id = 6, SectionName = "S_CH2", CourseId = 3, InstructorId = 3},
                new Section { Id = 7, SectionName = "S_BI1", CourseId = 4, InstructorId = 4},
                new Section { Id = 8, SectionName = "S_BI2", CourseId = 4, InstructorId = 5},
                new Section { Id = 9, SectionName = "S_CS1", CourseId = 5, InstructorId = 4},
                new Section { Id = 10, SectionName = "S_CS2", CourseId = 5, InstructorId = 5},
                new Section { Id = 11, SectionName = "S_CS3", CourseId = 5, InstructorId = 4}
            };
        }

        private static List<Schedule> LoadSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, Title = "Daily", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 2, Title = "DayAfterDay", SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 3, Title = "Twice-a-Week", SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, Title = "Weekend", SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
                new Schedule { Id = 5, Title = "Compact", SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
            };
        }

        private static List<SectionSchedule> LoadSectionSchedules()
        {
            return new List<SectionSchedule>
            {
                new SectionSchedule { Id = 1, SectionId = 1, ScheduleId = 1, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
                new SectionSchedule { Id = 2, SectionId = 2, ScheduleId = 3, StartTime = TimeSpan.Parse("14:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
                new SectionSchedule { Id = 3, SectionId = 3, ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
                new SectionSchedule { Id = 4, SectionId = 4, ScheduleId = 1, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("12:00:00") },
                new SectionSchedule { Id = 5, SectionId = 5, ScheduleId = 1, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
                new SectionSchedule { Id = 6, SectionId = 6, ScheduleId = 2, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00") },
                new SectionSchedule { Id = 7, SectionId = 7, ScheduleId = 3, StartTime = TimeSpan.Parse("11:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
                new SectionSchedule { Id = 8, SectionId = 8, ScheduleId = 4, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("14:00:00") },
                new SectionSchedule { Id = 9, SectionId = 9, ScheduleId = 4, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00") },
                new SectionSchedule { Id = 10, SectionId = 10, ScheduleId = 3, StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("15:00:00") },
                new SectionSchedule { Id = 11, SectionId = 11, ScheduleId = 5, StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("11:00:00") }
            };
        }

        private static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                 new Student() { Id = 1, FName = "Fatima", LName = "Ali" },
                 new Student() { Id = 2, FName = "Noor" , LName = "Saleh" },
                 new Student() { Id = 3, FName = "Omar" , LName = "Youssef" },
                 new Student() { Id = 4, FName = "Huda" , LName = "Ahmed" },
                 new Student() { Id = 5, FName = "Amira" , LName = "Tariq" },
                 new Student() { Id = 6, FName = "Zainab" , LName = "Ismail" },
                 new Student() { Id = 7, FName = "Yousef" , LName = "Farid" },
                 new Student() { Id = 8, FName = "Layla" , LName = "Mustafa" },
                 new Student() { Id = 9, FName = "Mohammed" , LName = "Adel" },
                 new Student() { Id = 10, FName = "Samira" , LName = "Nabil" }
            };
        }

        private static List<Enrollment> LoadEnrollments()
        {
            return new List<Enrollment>
            {
                new Enrollment() { StudentId = 1, SectionId = 6 },
                new Enrollment() { StudentId = 2, SectionId = 6 },
                new Enrollment() { StudentId = 3, SectionId = 7 },
                new Enrollment() { StudentId = 4, SectionId = 7 },
                new Enrollment() { StudentId = 5, SectionId = 8 },
                new Enrollment() { StudentId = 6, SectionId = 8 },
                new Enrollment() { StudentId = 7, SectionId = 9 },
                new Enrollment() { StudentId = 8, SectionId = 9 },
                new Enrollment() { StudentId = 9, SectionId = 10 },
                new Enrollment() { StudentId = 10, SectionId = 10 }
            };
        }
    }
}
