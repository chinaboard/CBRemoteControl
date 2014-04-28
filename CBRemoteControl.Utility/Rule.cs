using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CBRemoteControl.Utility
{
    public class Rule
    {
        public static bool Compare(int a,int b)
        {
            return (a & b) == b;
        }
    }
}
