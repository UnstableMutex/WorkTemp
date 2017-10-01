using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using IDbDataRecordExtentionsLib;
using WebPool.DB.DBModels;

namespace WebPool.DB
{
    public class DBNoCache
    {
        private static string cs;
        public static Pool GetPool()
        {
            const string spName = "GetPool";
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                using (var r = conn.ExecuteReader(spName, commandType: CommandType.StoredProcedure))
                {
                    var mapper = new PoolMapper();
                    var result = mapper.Map(r);
                    return result.FirstOrDefault();
                }
            }
        }

        internal static Pool GetPool(short id)
        {
            const string spName = "GetPool";
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                using (var r = conn.ExecuteReader(spName, id, commandType: CommandType.StoredProcedure))
                {
                    var mapper = new PoolMapper();
                    var result = mapper.Map(r);
                    return result.FirstOrDefault();
                }
            }
        }

        public static IReadOnlyList<QuestionBase> GetQuestions(short poolId)
        {
            const string spName = "GetQuestions";
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                using (var r = conn.ExecuteReader(spName, poolId, null, null, CommandType.StoredProcedure))
                {
                    var mapper = new QuestionMapper();
                    var result = mapper.Map(r);
                    return result.ToList();
                }
            }
        }
    }

    class PoolMapper : IResultSetMapper<Pool>
    {
        public IEnumerable<Pool> Map(IDataReader r)
        {
            while (r.Read())
            {
                var p = new Pool();
                p.ID = r.GetByte("ID");
                p.Name = r.GetString("Name");
                yield return p;
            }
        }
    }
    class QuestionMapper : IResultSetMapper<QuestionBase>
    {
        public IEnumerable<QuestionBase> Map(IDataReader r)
        {
            while (r.Read())
            {
                var questionType = (QuestionType)r.GetByte("QuestionType");
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
                result.PoolID = r.GetByte("Pool_ID");
                yield return result;
            }
        }
    }

    internal interface IResultSetMapper<T>
    {
        IEnumerable<T> Map(IDataReader r);
    }
    internal interface IRowMapper<T>
    {
        T Map(IDataReader r);
    }
}