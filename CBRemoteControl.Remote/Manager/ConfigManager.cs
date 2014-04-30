using CBRemoteControl.Model;
using System;
using System.Configuration;

namespace CBRemoteControl.Remote.Manager
{
    public class ConfigManager
    {
        #region 字段
        private string _ServiceBind;
        #endregion

        #region 属性
        public static ConfigManager Instance;
        public string MachineName { get { return GetAppConfig("MachineName"); } }
        public int HeartBeat { get { return int.Parse(GetAppConfig("HeartBeat")); } }
        public string ServiceDomain { get { return GetAppConfig("ServiceDomain"); } }
        public string ServicePort { get { return GetAppConfig("ServicePort"); } }
        public string ServiceBind
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_ServiceBind))
                    _ServiceBind = String.Format("tcp://{0}:{1}", Utility.DomainName.Domain2IP(ServiceDomain), ServicePort);
                return _ServiceBind;
            }
        }
        public RemoteInfo RemoteData { get { return new RemoteInfo(MachineGuid, MachineName); } }
        public string MachineGuid
        {
            get
            {
                var guid = GetAppConfig("MachineGuid");
                if (String.IsNullOrWhiteSpace(guid))
                {
                    guid = Guid.NewGuid().ToString();
                    UpdateAppConfig("MachineGuid", guid);
                }
                return guid;
            }
        }
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
