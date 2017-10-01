using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class PoolViewModel
    {
        public Pool Pool { get; set; }
        public IReadOnlyList<QuestionViewModel> Questions { get; set; }
    }

    public class QuestionViewModel
    {

        public string Indexer { get; set; }
    }

    public class OpenQuestionViewModel : QuestionViewModel, IControlName
    {
        public string Index { get; }
        public string Name { get; }
    }

    public class CheckedQuestionViewModel : QuestionViewModel, IControlName
    {
        private readonly Question _model;

        public CheckedQuestionViewModel(Question model)
        {
            _model = model;
        }
        public string Index => _model.ID.Surr();
        public string Name { get; }
    }

    public class CheckedAnswerViewModel : IControlName
    {
        private readonly CheckAnswer _model;
        private readonly IControlName _parent;

        public CheckedAnswerViewModel(CheckAnswer model, IControlName parent)
        {
            _model = model;
            _parent = parent;
        }
        public string Answer { get; }
        public string Index => _parent.Index + _model.ID.Surr();
        public string Name => "CheckedAnswer";
    }



    public interface IControlName
    {
        string Index { get; }
        string Name { get; }
    }

}