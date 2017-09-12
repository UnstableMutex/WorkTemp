using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;
using ServerMonitor.Model;

namespace ServerMonitor
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            XmlSerializer s = new XmlSerializer(typeof(MonitoringConfigItem));

            DirectoryInfo di = new DirectoryInfo("Config");
            var files = di.GetFiles("*.xml");
            foreach (var file in files)
            {
                var mci = (MonitoringConfigItem)s.Deserialize(File.OpenRead(file.FullName));

              
                //RunWebMonitor(this, new ConfigEventArgs(mci));
                Thread th = new Thread(new ParameterizedThreadStart(RunWebMonitor));
                th.Start(mci);
                timers.Add(th);
            }


        }




        private void RunWebMonitor(object e)
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
            var wr = WebRequest.Create(mci.ServerAddress);
            try
            {
                var res = wr.GetResponse();
            }
            catch (WebException webException)
            {
                if (webException.Message.Contains("502"))
                {
                    MessageBox.Show(string.Format("{0} {1}", mci.ServerAddress, "502"));
                }
            }
        }

        List<Thread> timers = new List<Thread>();
    }

    class ConfigEventArgs : EventArgs
    {
        public MonitoringConfigItem Config { get; set; }
        public ConfigEventArgs(MonitoringConfigItem config)
        {
            Config = config;
        }
    }
}
