using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPool.DB.DBModels;

// ReSharper disable once CheckNamespace
namespace WebPool.Models
{
    public class PoolViewModel
    {
        public PoolViewModel(Pool pool)
        {
            Pool = pool;
        }

        public Pool Pool { get; set; }
        public IReadOnlyList<QuestionViewModel<QuestionBase>> Questions { get; set; }
    }
}