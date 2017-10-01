using System.Collections.Generic;
using System.Data;

namespace WebPool.DB.Mappers
{
    internal interface IResultSetMapper<T>
    {
        IEnumerable<T> Map(IDataReader r);
    }
}