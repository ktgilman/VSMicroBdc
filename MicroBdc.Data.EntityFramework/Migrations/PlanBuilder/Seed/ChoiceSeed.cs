using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using MicroBdc.Entities.PlanBuilder;

namespace MicroBdc.Data.EntityFramework.Migrations.PlanBuilder.Seed
{
    public class ChoiceSeed
    {
        public void Seed(MicroBdc.Data.EntityFramework.Context.PlanBuilderDbContext context)
        {
            context.Choices.AddOrUpdate(
                x => x.ChoiceId,

            //Question 1: What stage is your business in? d2176263-f638-462b-a311-501ff2527e0a
                new Choice
                {
                    ChoiceId = Guid.Parse("9499b89d-3d06-43b5-a8f9-da86bbdad513"),
                    ChoiceName = "Choice 1",
                    ChoiceContent = "Startup (From Concept to < 1 month)",
                    ChoiceType = "R",
                    Placement = 1,
                    QuestionId = Guid.Parse("d2176263-f638-462b-a311-501ff2527e0a")
                },
                new Choice
                {
                    ChoiceId = Guid.Parse("9a94bdd1-eb6b-469e-b029-8a2121c3f2d4"),
                    ChoiceName = "Choice 2",
                    ChoiceContent = "Young (Established but under 5 years)",
                    ChoiceType = "R",
                    Placement = 2,
                    QuestionId = Guid.Parse("d2176263-f638-462b-a311-501ff2527e0a")
                },
                new Choice
                {
                    ChoiceId = Guid.Parse("7d85855b-2da3-4ce4-a0f3-86adc5f4ea63"),
                    ChoiceName = "Choice 3",
                    ChoiceContent = "Mature (Established > 5 years)",
                    ChoiceType = "R",
                    Placement = 3,
                    QuestionId = Guid.Parse("d2176263-f638-462b-a311-501ff2527e0a")
                },
                //Question 2: What is/are your reason(s) for creating this Business Plan? bb717aae-3d5e-49d7-a6b6-071c5d77b8d3

                new Choice
                {
                    ChoiceId = Guid.Parse("e9a3cf8b-8f99-4644-8552-41b3ac390ba6"),
                    ChoiceName = "Choice 1",
                    ChoiceContent = "To improve my business",
                    ChoiceType = "C",
                    Placement = 1,
                    QuestionId = Guid.Parse("bb717aae-3d5e-49d7-a6b6-071c5d77b8d3")
                },
                new Choice
                {
                    ChoiceId = Guid.Parse("1bf66572-a35c-4a63-a192-c41cde7fc616"),
                    ChoiceName = "Choice 2",
                    ChoiceContent = "To improve chances of getting a loan from a bank or other lender",
                    ChoiceType = "C",
                    Placement = 2,
                    QuestionId = Guid.Parse("bb717aae-3d5e-49d7-a6b6-071c5d77b8d3")
                },
                new Choice
                {
                    ChoiceId = Guid.Parse("b0a3b6f6-205a-4410-961d-7b04e28c20ae"),
                    ChoiceName = "Choice 3",
                    ChoiceContent = "To improve chances of receiving capital from an investor",
                    ChoiceType = "C",
                    Placement = 3,
                    QuestionId = Guid.Parse("bb717aae-3d5e-49d7-a6b6-071c5d77b8d3")
                },
            
                //Question 3: Describe your business as you currently perceive it in a couple sentences only (Answer the question: What do you do?).  
                //257b4b70-bf64-4285-9475-c08124511b60

                new Choice
                {
                    ChoiceId = Guid.Parse("2093d7e4-9bf5-4738-a02f-736cf25345a1"),
                    ChoiceName = "Choice 1",
                    ChoiceType = "F",
                    Placement = 1,
                    QuestionId = Guid.Parse("257b4b70-bf64-4285-9475-c08124511b60")
                }

            );
        }
    }
}
