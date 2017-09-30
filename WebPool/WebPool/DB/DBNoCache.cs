using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebPool.DB.DBModels;

namespace WebPool.DB
{
    public class DBNoCache
    {
        //public IReadOnlyList<Question> GetQuestions()
        //{
            
        //}
        //public IReadOnlyList<User> GetUsers()
        //{ }
        void tmp(IDataRecord r)
        {
            var colcount = r.FieldCount;
            for (int i = 0; i < colcount; i++)
            {
                var colName = r.GetName(i);

                r.GetDataTypeName(i)
            }

            
        }

        string DBTypeNameToCSTypeName(string dbtypename)
        {
            var cmd = new SqlCommand();
            cmd.ExecuteReader(CommandBehavior.SchemaOnly)
        }
    }
}