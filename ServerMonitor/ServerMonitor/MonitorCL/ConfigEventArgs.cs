using System;

namespace MonitorCL
{
    class ConfigEventArgs : EventArgs
    {
        public MonitoringConfigItem Config { get; set; }
        public ConfigEventArgs(MonitoringConfigItem config)
        {
            Config = config;
        }
    }
}