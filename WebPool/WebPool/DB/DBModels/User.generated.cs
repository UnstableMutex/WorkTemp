using System;
using System.CodeDom.Compiler;
 
namespace WebPool.DB.DBModels
{
    /// <summary>
    /// User auto generated enumeration
    /// </summary>
    [GeneratedCode("TextTemplatingFileGenerator", "10")]
    public class User
    {
		public short ID  { get; set; }
		public string Name  { get; set; }
		public string Password  { get; set; }
		public Guid GoogleID  { get; set; }
	}
}
