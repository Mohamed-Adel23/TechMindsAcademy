using EFCoreTut.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTut.Migrations.Data.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            //builder.Property(x => x.Name)
            //    .IsRequired()
            //    .HasColumnType("VARCHAR")
            //    .HasMaxLength(50);

            builder.Property(x => x.FName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.LName)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            // Relationshiop Between Instructor and Office 1 => 1
            builder.HasOne(e => e.Office)
                   .WithOne(e => e.Instructor)
                   .HasForeignKey<Instructor>(e => e.OfficeId)
                   .IsRequired(false);

            // Relationship Between Instructor and Section 1 => N
            builder.HasMany(e => e.Sections)
                   .WithOne(e => e.Instructor)
                   .HasForeignKey(e => e.InstructorId)
                   .IsRequired(false);
        }
    }
}
