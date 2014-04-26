using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace CBRemoteControl.Monitor.Manager
{
    public class ConfigManager
    {
        public static ConfigManager Instance;
        public int HeartBeat { get { return int.Parse(this.GetAppConfig("HeartBeat")); } }
        public string ServiceDomain { get { return this.GetAppConfig("ServiceDomain"); } }
        public string ServicePort { get { return this.GetAppConfig("ServicePort"); } }
        public string ServerBind { get { return String.Format("tcp://{0}:{1}", Utility.DomainName.Domain2IP(this.ServiceDomain), this.ServicePort); } }
        static ConfigManager()
        {
            Instance = new ConfigManager();
        }

        private string GetAppConfig(string strKey)
        {
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == strKey)
                {
                    return ConfigurationManager.AppSettings[strKey];
                }
            }
            return null;
        }

        private void UpdateAppConfig(string newKey, string newValue)
        {
            bool isModified = false;
            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key == newKey)
                {
                    isModified = true;
                }
            }
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (isModified)
            {
                config.AppSettings.Settings.Remove(newKey);
            }
            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
