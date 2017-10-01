using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPool
{
    static class Ext
    {
        public static string Surr(this string s)
        {
            return "[" + s + "]";
        }
        public static string Surr(this int s)
        {
            return "[" + s + "]";
        }
    }
}