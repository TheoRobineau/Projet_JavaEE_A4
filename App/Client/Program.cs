using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string Upload(Stream input);
        [OperationContract]
        Stream Download(String file);
    }

    public class ServiceImp : IService
    {
        string path = @"C:\Users\Dhev\Desktop\test";
        public Stream Download(string file)
        {
            MemoryStream stream = new MemoryStream();
            var bytes = File.ReadAllBytes(file);
            stream.Write(bytes, 0, bytes.Length);
            stream.Position = 0;
            return stream;
        }

        public string Upload(Stream input)
        {
            string fileName = String.Format(@"{0}\{1}.txt", path, Guid.NewGuid().ToString());
            StreamReader reader = new StreamReader(input);
            var content = reader.ReadToEnd();
            File.WriteAllText(fileName, content);
            return fileName;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceImp));
            host.Open();
            Console.WriteLine("Service is ready");
            Console.ReadLine();
        }
    }
}
