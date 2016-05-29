namespace MicroBdc.Data.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correct_Add_Choice_Tables : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Answers", new[] { "Choice_ChoiceId" });
            DropColumn("dbo.Answers", "ChoiceId");
            RenameColumn(table: "dbo.Answers", name: "Choice_ChoiceId", newName: "ChoiceId");
            AlterColumn("dbo.Answers", "ChoiceId", c => c.Guid());
            CreateIndex("dbo.Answers", "ChoiceId");
            DropColumn("dbo.Choices", "AnswerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Choices", "AnswerId", c => c.Guid(nullable: false));
            DropIndex("dbo.Answers", new[] { "ChoiceId" });
            AlterColumn("dbo.Answers", "ChoiceId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Answers", name: "ChoiceId", newName: "Choice_ChoiceId");
            AddColumn("dbo.Answers", "ChoiceId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Answers", "Choice_ChoiceId");
        }
    }
}
