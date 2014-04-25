using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class DomainName
    {
        /// <summary>
        /// 域名转换为IP地址
        /// </summary>
        /// <param name="domain">域名或IP地址</param>
        /// <returns>IP地址</returns>
        public static string Domain2IP(string domain)
        {
            try
            {
                IPAddress ip;
                if (IPAddress.TryParse(domain, out ip))
                    return ip.ToString();
                else
                    return Dns.GetHostEntry(domain).AddressList[0].ToString();
            }
            catch (Exception)
            {
                throw new Exception("IP Address Error");
            }
        }
    }
}
