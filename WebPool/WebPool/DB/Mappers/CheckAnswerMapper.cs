using System.Collections.Generic;
using System.Data;
using IDbDataRecordExtentionsLib;
using WebPool.DB.DBModels;

namespace WebPool.DB.Mappers
{
    class CheckAnswerMapper : IResultSetMapper<CheckAnswer>
    {
        public IEnumerable<CheckAnswer> Map(IDataReader r)
        {
            while (r.Read())
            {
                CheckAnswer result = new CheckAnswer();
                result.ID = r.GetInt32("ID");
                result.Answer = r.GetString("Answer");
                result.QuestionID = r.GetInt32("Question_ID");
                yield return result;
            }
        }
    }
}