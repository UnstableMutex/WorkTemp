using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Expression<Func<Entity, bool>> f = e => e.Test == "5";
            var aa = f.Body as BinaryExpression;
            var l = aa.Left as MemberExpression;
            var method = aa.Method.Name;
            var property = l.Member.Name;
            var r = aa.Right as ConstantExpression;
            var v = r.Value.ToString();
            string Cond=string.Empty;
            if (method == "op_Equality")
            {

                Cond = property + surr("=") + r;
            }
            string sel = string.Empty;

            var t = typeof(Entity);
         var props =  t.GetProperties().Select(x => x.Name);





            Cond = "WHERE " + Cond;
        }

        static string surr(string s)
        {
            return " " + s + " ";
        }

    }

    class Entity
    {
        public int ID { get; set; }
        public string Test { get; set; }
    }
}
