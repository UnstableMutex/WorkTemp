using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using IDbDataRecordExtentionsLib;
using WebPool.DB.DBModels;
using WebPool.DB.Mappers;

namespace WebPool.DB
{
    public class DBNoCache
    {
        private static string cs = "Server=.;Database=Pool;Integrated security=true";

        public static IEnumerable<CheckAnswer> GetCheckedAnswers(short poolid)
        {
            const string spName = "GetCheckedAnswers";
            using (var conn = new SqlConnection(cs))
            {
                conn.Open();
                using (var r = conn.ExecuteReader(spName, new { PoolID = poolid }, commandType: CommandType.StoredProcedure))
                {
                    var mapper = new CheckAnswerMapper();
                    var result = mapper.Map(r).ToList();
                    return result;
                }
            }

        }
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
                using (var r = conn.ExecuteReader(spName, new { PoolID = poolId }, commandType: CommandType.StoredProcedure))
                {
                    var mapper = new QuestionMapper();
                    var result = mapper.Map(r);
                    return result.ToList();
                }
            }
        }
    }
}


