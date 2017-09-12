using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MonitorCL
{
    [Serializable]
    public class MonitoringConfigItem
    {
        public string ServerAddress { get; set; }
    }
    class ConfigEventArgs : EventArgs
    {
        public MonitoringConfigItem Config { get; set; }
        public ConfigEventArgs(MonitoringConfigItem config)
        {
            Config = config;
        }
    }

   public static class Monitor
    {
        public static TextWriter Out { get; set; }
        public static void Run()
        {
            XmlSerializer s = new XmlSerializer(typeof(MonitoringConfigItem));

            DirectoryInfo di = new DirectoryInfo("Config");
            var files = di.GetFiles("*.xml");
            foreach (var file in files)
            {
                var mci = (MonitoringConfigItem)s.Deserialize(File.OpenRead(file.FullName));
                Thread th = new Thread(RunWebMonitor);
                th.Start(mci);
                timers.Add(th);
            }
        }
        private static void RunWebMonitor(object e)
        {
            while (true)
            {

                RunMonitorOnce(e);
                Thread.Sleep(3000);
            }

        }

        private static void RunMonitorOnce(object e)
        {
            var mci = (MonitoringConfigItem)e;
            var wr = (HttpWebRequest)WebRequest.Create(mci.ServerAddress);
            wr.AllowAutoRedirect = false;

            try
            {
                var res = (HttpWebResponse)wr.GetResponse();

            }
            catch (WebException webException)
            {
                var resp = (HttpWebResponse)webException.Response;
                var b = resp.StatusCode == HttpStatusCode.BadGateway;
                if (b)
                {
                    var s = string.Format("{0} {1}", mci.ServerAddress, "502");
                    Out.WriteLine(s);
                }

            }
        }

        static List<Thread> timers = new List<Thread>();
    }
}
