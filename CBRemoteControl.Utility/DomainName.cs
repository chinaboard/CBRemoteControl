using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

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
            for (int i = 0; i < 5; i++)
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
                    Thread.Sleep(5000);
                    continue;
                }
            }
            throw new Exception("IP Address Error");
        }
    }
}
