using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPool.DB.DBModels
{

    public class QuestionBase
    {
        public int ID { get; set; }
        public short PoolID { get; set; }
        public string Question { get; set; }
    }

    public enum QuestionType : byte
    {
        Open = 1, Checkboxed = 2
    }
    public class OpenQuestion : QuestionBase
    {

    }

    public class CheckedQuestion : QuestionBase
    {

    }
}