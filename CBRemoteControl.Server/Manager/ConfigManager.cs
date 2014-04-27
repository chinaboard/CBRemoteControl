using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Xml;

namespace CBRemoteControl.Server.Manager
{
    public class ConfigManager
    {
        #region 字段
        public static ConfigManager Instance;
        public int HeartBeat { get { return int.Parse(GetAppConfig("HeartBeat")); } }
        public string ServicePort { get { return GetAppConfig("ServicePort"); } }
        public string LocalBind { get { return String.Format("tcp://*:{0}", ConfigManager.Instance.ServicePort); } }
        #endregion

        #region 构造方法
        static ConfigManager()
        {
            Instance = new ConfigManager();
        }
        #endregion

        #region 私有方法
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
        #endregion
    }
}
