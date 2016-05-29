using MicroBdc.Entities.PlanBuilder;
using System.Data.Entity.ModelConfiguration;

namespace MicroBdc.Data.EntityFramework.Configuration.PlanBuilder
{
    public class PlanConfiguration : EntityTypeConfiguration<Plan>
    {
        public PlanConfiguration()
        {
            ToTable("Plans");

            HasKey(x => x.PlanId)
                .Property(x => x.PlanId)
                .HasColumnName("PlanId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.PlanName)
                .HasColumnName("PlanName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.ShortDescription)
                .HasColumnName("ShortDescription")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            Property(x => x.LongDescription)
                .HasColumnName("LongDescription")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            Property(x => x.ImageLocation)
                .HasColumnName("ImageLocation")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            Property(x => x.CreationDate)
                .HasColumnName("CreationDate")
                .HasColumnType("DateTime");

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasMany(x => x.Answers)
                .WithRequired(x => x.Plan)
                .HasForeignKey(x => x.PlanId);
        }
    }
}
