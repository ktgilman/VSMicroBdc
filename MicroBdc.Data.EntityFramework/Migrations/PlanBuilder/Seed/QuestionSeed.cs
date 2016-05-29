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
    public class QuestionSeed
    {
        public void Seed(MicroBdc.Data.EntityFramework.Context.PlanBuilderDbContext context)
        {
            context.Questions.AddOrUpdate(
                x => x.QuestionId,
                new Question
                {
                    QuestionId = Guid.Parse("d2176263-f638-462b-a311-501ff2527e0a"),
                    QuestionName = "Question 1",
                    QuestionContent = "What stage is your business in?",
                    ChoiceType = "R",
                    Section = 1,
                    Placement = 1,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                },
                new Question
                {
                    QuestionId = Guid.Parse("bb717aae-3d5e-49d7-a6b6-071c5d77b8d3"),
                    QuestionName = "Question 2",
                    QuestionContent = "What is/are your reason(s) for creating this Business Plan?",
                    ChoiceType = "C",
                    Section = 1,
                    Placement = 2,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                },
                new Question
                {
                    QuestionId = Guid.Parse("257b4b70-bf64-4285-9475-c08124511b60"),
                    QuestionName = "Question 3",
                    QuestionContent = "Describe your business as you currently perceive it in a couple sentences only (Answer the question: What do you do?).",
                    ChoiceType = "F",
                    Section = 1,
                    Placement = 3,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                },
                new Question
                {
                    QuestionId = Guid.Parse("5e7f94fb-e72b-433a-a26b-9ec98f179ad8"),
                    QuestionName = "Question 4",
                    QuestionContent = "What do you believe are your odds of success based off of what you know now? (1 - Least Likely, 10 - Most Likely)",
                    ChoiceType = "H",
                    Section = 1,
                    Placement = 4,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                },
                new Question
                {
                    QuestionId = Guid.Parse("125c1777-99e5-45e1-896b-6a36ff3c62be"),
                    QuestionName = "Question 5",
                    QuestionContent = "How confident are you in your assessment of your odds of success? (1 - Least Confident, 10 - Most Confident)",
                    ChoiceType = "H",
                    Section = 1,
                    Placement = 5,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                },
                new Question
                {
                    QuestionId = Guid.Parse("eda18518-0ec4-4345-b1b4-09898a63681f"),
                    QuestionName = "Question 6",
                    QuestionContent = "How confident are you that you will be able to create an effective business plan? (1 - Least Confident, 10 - Most Confident)",
                    ChoiceType = "H",
                    Section = 1,
                    Placement = 6,
                    ChoiceSource = "",
                    VideoAidUrl = ""
                }
            );
        }
    }
}
