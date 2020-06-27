using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace BruteForce
{
    class Program
    {
        
        public string EncryptOrDecrypt(string text, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < text.Length; c++)
                result.Append((char)((uint)text[c] ^ (uint)key[c % key.Length]));

            if (key == "ZZZZ")
            {
                System.Diagnostics.Debug.WriteLine(result.ToString());
            }
            return result.ToString();
        }


        static void decryptloop(Object args)
        {
            Array argArray = new object[2];
            argArray = (Array)args;
            string text = (string)argArray.GetValue(0);
            string compteur = (string)argArray.GetValue(1);
            Program p = new Program();
            
            for (Char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            p.EncryptOrDecrypt(text, "" + c1 + c2 + c3 + c4);
                            //Console.WriteLine("Thread : " + compteur +  "    " + c1 + c2 + c3 + c4);
                            if ("" + c1 + c2 + c3 + c4 == "ZZZZ")
                            {
                                Console.WriteLine("Thread " + compteur + " finished at : " + DateTime.Now);
                            }
                        }
                    }
                }
            }

        }


        public static void Main(String[] args)
        {
            Console.WriteLine("Started at : " + DateTime.Now);

            string[] stringArray = new string[2];

            for (int i = 1; i < Directory.GetFiles(@"C:\Users\Dhev\Desktop\test").Length + 1; i++)
            {
                stringArray[0] = File.ReadAllText(@"C:\Users\Dhev\Desktop\test\fichier" + i + ".txt");
                stringArray[1] = "" + i;


                Thread t2 = new Thread(Program.decryptloop);
                t2.Start(stringArray);
                Thread.Sleep(10);
            }



        }
    }
}
