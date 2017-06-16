using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using IDbDataRecordExtentionsLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapper = new Mapper<User>();
            User u;
            using (var conn = new SqlConnection("Server=.;Database=Test;Trusted_Connection=True;"))
            {
                string q = "select Name,Value from sys.extended_properties where class=4 and major_id=7";
                conn.Open();
                using (var cmd=new SqlCommand(q,conn))
                {
                    using (var r=cmd.ExecuteReader())
                    {
                        u = mapper.Map(r);
                    }
                }
            }
        }
    }

    class User
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
    }

    class Mapper<T> where T:new()
    {
        public T Map(SqlDataReader r)
        {
            T item = new T();
          var props=  item.GetType().GetProperties();

            while (r.Read())
            {
             var name=   r.GetString("Name");
                var p = props.SingleOrDefault(x => x.Name == name);
                if (p != null)
                {
                    p.SetValue(item,r.GetString("Value"),null);
                }

            }
            return item;
        }
    }

    [Flags]
    enum test:int
    {
        one =1, two =2 , four=4,e=8,s=16,b=32,c=64,d=128,e1=256
    }
}
