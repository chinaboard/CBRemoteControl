using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class JsonSerialization
    {
        public static string Object2Json(object vaule)
        {
            return JsonConvert.SerializeObject(vaule);
        }

        public static object Json2Object(string jsonStr,Type objectType)
        {
            return JsonConvert.DeserializeObject(jsonStr, objectType);
        }
    }
}
