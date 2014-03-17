using CBRemoteControl.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CBRemoteControl.Service
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => Caching.Instance.ServerListTimeOut());
            Task.Factory.StartNew(() => Caching.Instance.ScreenListTimeOut());
        }
    }
}