using System;
using System.CodeDom.Compiler;
 
namespace WebPool.DB.DBModels
{
    /// <summary>
    /// UserOpenAnswer auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public class UserOpenAnswer
    {
		public int ID  { get; set; }
		public string Answer  { get; set; }
		public int QuestionID  { get; set; }
		public short UserID  { get; set; }
	}
}
