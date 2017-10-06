using System;
using System.Collections.Generic;
using System.Data;
using IDbDataRecordExtentionsLib;
using WebPool.DB.DBModels;

namespace WebPool.DB.Mappers
{
    class QuestionMapper : IResultSetMapper<QuestionBase>
    {
        public IEnumerable<QuestionBase> Map(IDataReader r)
        {
            while (r.Read())
            {
                var questionType = (QuestionType)r.GetByte("QuestionType_ID");
                QuestionBase result;
                switch (questionType)
                {
                    case QuestionType.Open:
                        result = new OpenQuestion();
                        break;
                    case QuestionType.Checkboxed:
                        result = new CheckedQuestion();
                        break;
                    default:
                        throw new NotImplementedException();
                }
                result.ID = r.GetInt32("ID");
                result.Question = r.GetString("Question");
                result.PoolID = r.GetInt16("Pool_ID");
                yield return result;
            }
        }
    }
}