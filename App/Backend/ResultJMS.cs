using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend
{
    public class ResultJMSEventArgrs : EventArgs
    {
        public ResultJMS resultJMS { get; set; }

    }

    public class ResultJMS
    {
        public string FileName { get; set; }
        public string SecretInfo { get; set; }
        public string Key { get; set; }

    }
}