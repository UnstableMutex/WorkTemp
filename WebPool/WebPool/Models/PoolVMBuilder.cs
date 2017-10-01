using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPool.DB;
using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public static class PoolVMBuilder
    {
        public static PoolViewModel Build(short id)
        {
            var pool = DBNoCache.GetPool(id);
            return Build(pool);
        }

        public static PoolViewModel Build()
        {
            var pool = DBNoCache.GetPool();
            return Build(pool);
        }
        public static PoolViewModel Build(Pool pool)
        {
            var res = new PoolViewModel(pool);
            var questions = DBNoCache.GetQuestions(pool.ID).ToList();
            var vms = new List<QuestionViewModel<QuestionBase>>();
            foreach (var q in questions)
            {
                if (q is OpenQuestion)
                {
                    vms.Add(new OpenQuestionViewModel(q as OpenQuestion));
                    continue;
                }
                if (q is CheckedQuestion)
                {
                    vms.Add(Build(q as CheckedQuestion, pool.ID));
                    continue;
                }
                throw new NotImplementedException();
            }
            res.Questions = vms;
            return res;
        }

        static CheckedQuestionViewModel Build(CheckedQuestion model, short poolid)
        {
            var db = new DBCache();
            var answers = db.GetCheckedAnswers(poolid);
            var q = new CheckedQuestionViewModel(model);
            var answersVMs = new List<CheckedAnswerViewModel>();
            var a = answers.Single(x => x.Key == model.ID);
            foreach (var item in a)
            {
                answersVMs.Add(new CheckedAnswerViewModel(item, q));
            }
            q.Answers = answersVMs;
            return q;
        }
    }
}