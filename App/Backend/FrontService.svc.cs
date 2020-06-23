using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.UI.WebControls;

namespace Backend
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "FrontService" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez FrontService.svc ou FrontService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class FrontService : IDecipherService
    {
        public Credentials Login(Credentials credentials)
        {
            //TODO : ADD CHECK IN DATABASE FOR EXISTING USER


            if (credentials.username == "test" && credentials.password == "1234")
            {
                string token = "tokenUser";

                credentials.token = token;
                return credentials;
            }
            else
            {
                credentials.token = "";
                return credentials;
            }
            
        }


    }
}
