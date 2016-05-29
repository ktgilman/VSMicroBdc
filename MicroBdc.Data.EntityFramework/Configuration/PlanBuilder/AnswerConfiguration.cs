using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Configuration.PlanBuilder
{
    public class AnswerConfiguration: EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            ToTable("Answers");

            HasKey(x => x.AnswerId)
                .Property(x => x.AnswerId)
                .HasColumnName("AnswerId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.AnswerName)
                .HasColumnName("AnswerName")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);

            Property(x => x.AnswerContent)
                .HasColumnName("AnswerContent")
                .HasColumnType("nvarchar")
                .HasMaxLength(200);

            Property(x => x.AnswerVariable)
                .HasColumnName("AnswerVariable")
                .HasColumnType("nvarchar")
                .HasMaxLength(20);

            Property(x => x.ChoiceId)
                .HasColumnName("ChoiceId")
                .HasColumnType("uniqueidentifier")
                .IsOptional();

            Property(x => x.QuestionId)
                .HasColumnName("QuestionId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.PlanId)
                .HasColumnName("PlanId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasRequired(x => x.Plan)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.PlanId);

            HasRequired(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId);

            HasOptional(x => x.Choice)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.ChoiceId);

        }
    }
}
