using EFCoreTut.Migrations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreTut.Migrations.Data.Config
{
    public class SectionScheduleduleConfiguration : IEntityTypeConfiguration<SectionSchedule>
    {
        public void Configure(EntityTypeBuilder<SectionSchedule> builder)
        {
            builder.ToTable("SectionSchedules");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.StartTime)
                .IsRequired()
                .HasColumnType("TIME");

            builder.Property(x => x.EndTime)
                .IsRequired()
                .HasColumnType("TIME");
        }
    }
}
