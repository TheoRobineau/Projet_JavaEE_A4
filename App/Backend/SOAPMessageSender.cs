using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void SendFileToJMS(string decryptedFile, string fileName, string key)
        {
            ReceptionEndpointClient client = new ReceptionEndpointClient();
            //Encoding.ASCII.GetBytes(decryptedFile);

            byte[] bytes = Encoding.UTF8.GetBytes(decryptedFile);
            //BinaryReader binaryReader = new BinaryReader(bytes.);
            //Read(bytes,  )
            // string text = ;
            //string text = decryptedFile.Replace("")

            client.ReceptionOperation(bytes, key, fileName);
                
        }


    }
}