using System.Collections.Generic;
using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class CheckedQuestionViewModel : QuestionViewModel<QuestionBase>, IControlName
    {


        public CheckedQuestionViewModel(CheckedQuestion model) : base(model)
        {

        }
        public string Index => Model.ID.Surr();
        public string Name { get; }
        public IEnumerable<CheckedAnswerViewModel> Answers { get; set; }
    }
}