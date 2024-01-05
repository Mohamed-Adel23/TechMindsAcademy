using EFCoreTut.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTut.Migrations.Data.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.SectionName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            // Relationshiop Between Courses and Sections 1 => N
            builder.HasOne(x => x.Course)
                   .WithMany(e => e.Sections)
                   .HasForeignKey(e => e.CourseId)
                   .IsRequired();

            // Relationship Between Sections And Schedules M => N
            builder.HasMany(e => e.Schedules)
                   .WithMany(e => e.Sections)
                   .UsingEntity<SectionSchedule>(); // Foreign Key will be configured automatically

            // Relationship Between Sections And Students M => N
            builder.HasMany(e => e.Students)
                   .WithMany(e => e.Sections)
                   .UsingEntity<Enrollment>( // Explicit Configuring of Foreign Keys
                        l => l.HasOne(e => e.Student).WithMany(e => e.Enrollments).HasForeignKey(e => e.StudentId),
                        r => r.HasOne(e => e.Section).WithMany(e => e.Enrollments).HasForeignKey(e => e.SectionId)
                    );
        }
    }
}
