using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "FrontService" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez FrontService.svc ou FrontService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class FrontService : IFrontService
    {
        bdd test = new bdd();
        private BruteForceEngine bruteForceEngine;


        public delegate void OnResultJMSEventHandler(object source, ResultJMSEventArgrs args);

        public event OnResultJMSEventHandler JMSResultReceived;

        public FrontService()
        {
            bruteForceEngine = new BruteForceEngine();
            JMSResultReceived += bruteForceEngine.OnJMSResult;
        }

        public virtual void OnResultReceived(ResultJMS result)
        {
            if (JMSResultReceived != null)
                JMSResultReceived(this, new ResultJMSEventArgrs() { resultJMS = result });
        }


        public void getResult(string fileName, string secretInfo, string key)
        {
            ResultJMS result = new ResultJMS { FileName = fileName, SecretInfo = secretInfo, Key = key };
            System.Diagnostics.Debug.WriteLine("GET RESULT ! JMS CALLED ME " + fileName + secretInfo + key);
            OnResultReceived(result);
            //return "Information reçus";
        }

        public Message ProcessMessage(Message msg)
        {
            if (AppTokenChecker(msg.tokenApp))
            {
                switch (msg.operationName)
                {
                    case "Login":
                        msg.tokenUser = Login(new Credentials { username = msg.username, password = msg.password });
                        SOAPMessageSender sender = new SOAPMessageSender();
                        //sender.test();
                        break;
                    case "Decipher":
                        
                        List<string> fileNames = new List<string>();
                        List<string> fileData = new List<string>();

                        //cast le premier objet en byte array #ScotchOverScotch
                        byte[] dataNames = (byte[])msg.data[0];
                        byte[] dataContent = (byte[])msg.data[1];

                        fileNames = ByteDeserializer(dataNames);
                        fileData = ByteDeserializer(dataContent);

                        bruteForceEngine.DecipherEngine(fileNames, fileData);
                        
                        break;
                }

                return msg;
            }
            else
            {
                msg.tokenUser = "";
                return msg;
            }

        }

        private List<string> ByteDeserializer(byte[] data)
        {
            List<string> list = new List<string>();

            var mStream = new MemoryStream();
            var binFormatter = new BinaryFormatter();

            mStream.Write(data, 0, data.Length);
            mStream.Position = 0;

            list = binFormatter.Deserialize(mStream) as List<string>;

            return list;
        }

        public string Login(Credentials credentials)
        {
            //TODO : ADD A CHECK IN DATABASE FOR EXISTING USER

            string token;
            //System.Diagnostics.Debug.WriteLine(test.getTokenUser(credentials.username, credentials.password));
            //test.getTokenUser(credentials.username, credentials.password);
            if (test.getUserExist(credentials.username, credentials.password) == true)
            {
                //string token = "tokenUser";
                token = "tokenUser";
                return token;
            }
            else
            {
                token = "invalid";
                return token;
            }

        }

        //private bool StartDecipherEngine(Message)
        //{

        //    return false;
        //} 

        private bool UserTokenChecker(string username, string tokenUser)
        {
            //TODO : ADD A CHECK IN DATABASE FOR EXISTING USER WITH TOKEN

            if (username == "test" && tokenUser == "tokenUser")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool AppTokenChecker(string token)
        {
            if(token == "TokenApp")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


       

        
    }
}
