using System.Data;

namespace WebPool.DB.Mappers
{
    internal interface IRowMapper<T>
    {
        T Map(IDataReader r);
    }
}