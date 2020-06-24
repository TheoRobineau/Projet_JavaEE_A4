using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Backend
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IFrontService
    {


        // TODO: ajoutez vos opérations de service ici

        //

        [OperationContract]
        Message ProcessMessage(Message msg);

        [OperationContract]
        string Login(Credentials credentials);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class Credentials
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }
    }

    [DataContract]
    public class Message
    {
        [DataMember]
        public string operationName { get; set; }

        [DataMember]
        public string tokenApp { get; set; }

        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
        [DataMember]
        public string tokenUser { get; set; }

        [DataMember]
        public object[] data { get; set; }
        public string appVersion;
        public string operationVersion;
        public string info;
        public bool statutOp;
    }
    
}
