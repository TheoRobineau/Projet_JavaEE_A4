using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend
{
    public class ResultJSFEventArgrs : EventArgs
    {
        public ResultJSF resultJSF { get; set; }

    }

    public class ResultJSF
    {
        public string FileName { get; set; }
        public string SecretInfo { get; set; }
        public string Key { get; set; }

    }
}