using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPool.DB.DBModels;

namespace WebPool.DB
{
    public class DBCache
    {
        private IEnumerable<IGrouping<int, CheckAnswer>> a;

        public IEnumerable<IGrouping<int, CheckAnswer>> GetCheckedAnswers(short poolid)
        {
            if (a == null)
            {
                a = DBNoCache.GetCheckedAnswers(poolid).GroupBy(x => x.QuestionID);
            }
            return a;
        }
    }
}