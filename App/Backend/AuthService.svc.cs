using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Backend
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AuthService" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AuthService.svc ou AuthService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AuthService : IAuthService
    {
        public string login(string login, string password, string tokenApp)
        {
            string login1 = "test";
            string pwd = "1234";
            string token = "test";

            string success = "Successfully connected";
            string failure = "Failed to connected";

            if (login == login1 && password == pwd && tokenApp == token)
            {
                return success;
            }

            return failure;
        }
    }
}
