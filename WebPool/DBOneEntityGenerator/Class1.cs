using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TextTemplating.VSHost;

namespace DBOneEntityGenerator
{
    [ComVisible(true)]
    // TODO: Replace with your GUID
    [Guid("6EFB8340-DCA7-4FE7-8B42-4BB170A3948F")]
    public class OneEntityGenerator : BaseCodeGeneratorWithSite
    {
        public override string GetDefaultExtension()
        {
            // TODO: Replace with your implementation
            return ".cs";
        }

        protected override byte[] GenerateCode(string inputFileName, string inputFileContent)
        {
            // TODO: Replace with your implementation


            // TODO: Replace with your implementation
            var generatedText = string.Format(@"{1}{0}{0}Filename: {2}{0}{0}Timestamp: {3}", Environment.NewLine, inputFileContent, inputFileName, DateTime.Now);
            return Encoding.UTF8.GetBytes(generatedText);

            //var lines = inputFileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            //var server = lines[0];
            //var dbname = lines[1];
            //SqlConnectionStringBuilder b = new SqlConnectionStringBuilder();
            //b.DataSource = server;
            //b.InitialCatalog = dbname;
            //b.IntegratedSecurity = true;
            //string res;
            //using (SqlConnection conn = new SqlConnection(b.ConnectionString))
            //{
            //    conn.Open();
            //    string sql = "SELECT TOP 1 AddressLine1  FROM [Person].[Address]";
            //    using (var cmd = conn.CreateCommand())
            //    {
            //        cmd.CommandText = sql;
            //        using (var r = cmd.ExecuteReader())
            //        {
            //            r.Read();
            //            res = r.GetString(0);
            //        }
            //    }

            //}



            //var generatedText = string.Format("{0} {1} {2}", res, Environment.NewLine, DateTime.Now);
            //return Encoding.UTF8.GetBytes(generatedText);
        }
    }
    /*
     * 
; TODO: Replace with your GUID
[HKEY_CURRENT_USER\SOFTWARE\Microsoft\VisualStudio\11.0_Config\CLSID\{6EFB8340-DCA7-4FE7-8B42-4BB170A3948F}]
"InprocServer32"="C:\\Windows\\System32\\mscoree.dll"
"ThreadingModel"="Both"
; TODO: Replace with your class
"Class"="DBOneEntityGenerator.OneEntityGenerator"
; TODO: Replace with your assembly
"Assembly"="DBOneEntityGenerator, Version=1.0.0.0, Culture=neutral"
; TODO: Replace with your dll file
"CodeBase"="file:///C:\\Program Files\\DBOneEntityGenerator\\OneEntityGenerator.dll"
 
; TODO: Replace with your tool name
[HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\11.0_Config\Generators\{6EFB8340-DCA7-4FE7-8B42-4BB170A3948F}\DBOneEntityGenerator]
; TODO: Replace with your GUID
"CLSID"="{6EFB8340-DCA7-4FE7-8B42-4BB170A3948F}"
"GeneratesDesignTimeSource"=dword:00000001
; TODO: Replace with your description
@="DBOneEntityGenerator description"
     * 
     * 
     * 
     * 
     */
}
