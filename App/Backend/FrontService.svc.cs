using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public Message ProcessMessage(Message msg)
        {
            if (AppTokenChecker(msg.tokenApp))
            {
                switch (msg.operationName)
                {
                    case "Login":
                        msg.tokenUser = Login(new Credentials {username = msg.username, password = msg.password });
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



        public string Login(Credentials credentials)
        {
            //TODO : ADD A CHECK IN DATABASE FOR EXISTING USER

            string token;
            if (credentials.username == "test" && credentials.password == "1234")
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
