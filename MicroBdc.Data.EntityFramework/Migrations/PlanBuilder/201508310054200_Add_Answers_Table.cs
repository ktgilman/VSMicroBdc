namespace MicroBdc.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Answers_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerId = c.Guid(nullable: false),
                        AnswerName = c.String(maxLength: 50),
                        AnswerContent = c.String(maxLength: 200),
                        AnswerVariable = c.String(maxLength: 20),
                        QuestionId = c.Guid(nullable: false),
                        ChoiceId = c.Guid(nullable: false),
                        PlanId = c.Guid(nullable: false),
                        Choice_ChoiceId = c.Guid(),
                    })
                .PrimaryKey(t => t.AnswerId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Choices", t => t.Choice_ChoiceId)
                .ForeignKey("dbo.Plans", t => t.PlanId, cascadeDelete: true)
                .Index(t => t.QuestionId)
                .Index(t => t.PlanId)
                .Index(t => t.Choice_ChoiceId);
            
            AddColumn("dbo.Choices", "AnswerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "PlanId", "dbo.Plans");
            DropForeignKey("dbo.Answers", "Choice_ChoiceId", "dbo.Choices");
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Answers", new[] { "Choice_ChoiceId" });
            DropIndex("dbo.Answers", new[] { "PlanId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropColumn("dbo.Choices", "AnswerId");
            DropTable("dbo.Answers");
        }
    }
}
