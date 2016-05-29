using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Configuration.PlanBuilder
{
    public class ChoiceConfiguration: EntityTypeConfiguration<Choice>
    {
        public ChoiceConfiguration()
        {
            ToTable("Choices");

            HasKey(x => x.ChoiceId)
                .Property(x => x.ChoiceId)
                .HasColumnName("ChoiceId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.ChoiceName)
                .HasColumnName("ChoiceName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(x => x.ChoiceContent)
                .HasColumnName("ChoiceContent")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);

            Property(x => x.ChoiceType)
                .HasColumnName("ChoiceType")
                .HasColumnType("nvarchar");

            Property(x => x.Placement)
                .HasColumnName("Placement")
                .HasColumnType("int");

            Property(x => x.QuestionId)
                .HasColumnName("QuestionId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasRequired(x => x.Question)
                .WithMany(x => x.Choices)
                .HasForeignKey(x => x.QuestionId);

            HasMany(x => x.Answers)
                .WithOptional(x => x.Choice);
        }
    }
}
