using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApplication1.sr;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            sr.DealServiceClient c = new DealServiceClient();
           
            int[] trades = {40133, 40135};
            string action = "RollOver";
            var p = new InterActionParams() { ignoreWarnings = true };
            p.formFields = new Dictionary<string, object>();
            p.formFields.Add("tradeId", trades[0]);
            p.formFields.Add("tradeId2", trades[1]);

            var i = new International();
            i.Locale = Thread.CurrentThread.CurrentUICulture.Name;
            i.TZ = TimeZone.CurrentTimeZone.StandardName;


         var session=   c.InitializeSession("atroepolskii", Environment.UserName, Environment.MachineName, "PName", i, ",", " ",
                CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
            c.InnerChannel.Extensions.Add(new MyExtension(session));

            c.BulkTryExecuteSTPAction(new []{trades[0]}, action, true, p);

        }
    }

    /// <summary>
    /// Type for sending SessionID to Message Interceptor by Channel Extension
    /// </summary>
    class MyExtension : IExtension<IContextChannel>
    {
        public MyExtension(string sessionid)
        {
            SessionID = sessionid;
        }
        public void Attach(IContextChannel owner)
        {
        }

        public void Detach(IContextChannel owner)
        {
        }

        public string SessionID { get; set; }
    }

}
