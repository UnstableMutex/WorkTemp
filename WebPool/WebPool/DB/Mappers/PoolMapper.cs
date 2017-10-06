using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using IDbDataRecordExtentionsLib;
using WebPool.DB.DBModels;

namespace WebPool.DB.Mappers
{
    class PoolMapper : IResultSetMapper<Pool>
    {
        public IEnumerable<Pool> Map(IDataReader r)
        {
            while (r.Read())
            {
                var p = new Pool();
                p.ID = r.GetInt16("ID");
                p.Name = r.GetString("Name");
                yield return p;
            }
        }
    }
}