using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Configuration.PlanBuilder
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            ToTable("Questions");

            HasKey(x => x.QuestionId)
                .Property(x => x.QuestionId)
                .HasColumnName("QuestionId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.QuestionName)
                .HasColumnName("QuestionName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(x => x.QuestionContent)
                .HasColumnName("QuestionContent")
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            Property(x => x.ChoiceType)
                .HasColumnName("ChoiceType")
                .HasColumnType("nvarchar");

            Property(x => x.Section)
                .HasColumnName("Section")
                .HasColumnType("int");

            Property(x => x.Placement)
                .HasColumnName("Placement")
                .HasColumnType("int");

            Property(x => x.ChoiceSource)
                .HasColumnName("ChoiceSource")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);

            Property(x => x.VideoAidUrl)
                .HasColumnName("VideoAidUrl")
                .HasColumnType("nvarchar")
                .HasMaxLength(100);

            HasMany(x => x.Choices)
                .WithRequired(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

            HasMany(x => x.Answers)
                .WithRequired(x => x.Question)
                .HasForeignKey(x => x.QuestionId);
        }
    }
}
