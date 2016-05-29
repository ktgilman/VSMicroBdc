namespace MicroBdc.Data.EntityFramework.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MicroBdc.Entities.PlanBuilder;
    using MicroBdc.Data.EntityFramework.Configuration.PlanBuilder;

    public class PlanBuilderDbContext : DbContext
    {
        // Your context has been configured to use a 'PlanBuilderDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MicroBdc.Data.EntityFramework.Context.PlanBuilderDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PlanBuilderDbContext' 
        // connection string in the application configuration file.
        public PlanBuilderDbContext()
            : base("name=MicroBdcPlanBuilder")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Choice> Choices { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new ChoiceConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
        }
    }
}