﻿namespace EFCoreTut.Migrations.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }

        // Many to Many
        public ICollection<Section> Sections { get; set; } = new List<Section>();
        // Intermediate Table
        public ICollection<SectionSchedule> SectionSchedules { get; set; } = new List<SectionSchedule>();
    }
}
