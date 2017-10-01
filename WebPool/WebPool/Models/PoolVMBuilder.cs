using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPool.DB;
using WebPool.DB.DBModels;

namespace WebPool.Models
{
    public class PoolVMBuilder
    {
        public PoolViewModel Build(short id)
        {
            var pool = DBNoCache.GetPool(id);
            return Build(pool);
        }

        public PoolViewModel Build()
        {
            var pool = DBNoCache.GetPool();
            return Build(pool);
        }
        public PoolViewModel Build(Pool pool)
        {
            var res = new PoolViewModel(pool);
            var questions = DBNoCache.GetQuestions(pool.ID);
            return res;
        }
    }
}