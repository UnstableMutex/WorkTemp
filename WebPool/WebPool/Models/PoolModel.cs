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

    public class OpenQuestionViewModel : QuestionViewModel
    {
        
    }

    public class CheckedQuestionViewModel : QuestionViewModel
    {
        
    }
    public class CheckedAnswerViewModel
    { }
}