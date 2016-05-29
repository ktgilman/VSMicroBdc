namespace MicroBdc.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Choices_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choices",
                c => new
                    {
                        ChoiceId = c.Guid(nullable: false),
                        ChoiceName = c.String(maxLength: 50),
                        ChoiceContent = c.String(maxLength: 200),
                        ChoiceType = c.String(maxLength: 4000),
                        Placement = c.Int(nullable: false),
                        QuestionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choices", "QuestionId", "dbo.Questions");
            DropIndex("dbo.Choices", new[] { "QuestionId" });
            DropTable("dbo.Choices");
        }
    }
}
