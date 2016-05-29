namespace MicroBdc.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionId = c.Guid(nullable: false),
                        QuestionName = c.String(maxLength: 50),
                        QuestionContent = c.String(maxLength: 500),
                        ChoiceType = c.String(maxLength: 4000),
                        Section = c.Int(nullable: false),
                        Placement = c.Int(nullable: false),
                        ChoiceSource = c.String(maxLength: 250),
                        VideoAidUrl = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.QuestionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
        }
    }
}
