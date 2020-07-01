using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backend.SOAPReceptionMessage;

namespace Backend
{
    public class SOAPMessageSender
    {

        public void test()
        {
            ReceptionEndpointClient client = new ReceptionEndpointClient();

            string result;

            //result = client.ReceptionOperation("test", "test", "test");

            //System.Diagnostics.Debug.WriteLine(result.ToString());
        }


    }
}