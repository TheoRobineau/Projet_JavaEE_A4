using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
namespace BruteForce
{
    class Program
    {
        static String Decrypt(String inputString, String key)
        {
            int j = 0;

            String outputString = "";

            int len = inputString.Length;

            for (int i = 0; i < len; i++)
            {
                if (j == 4)
                {
                    j = 0;
                }

                outputString = outputString + char.ToString((char)(inputString[i] ^ key[j]));

                j = j + 1;

            }
            return outputString;
        }

        
        static void decryptloop(Object args)
        {
            Array argArray = new object[2];
            argArray = (Array)args;
            string text = (string)argArray.GetValue(0);
            string compteur = (string)argArray.GetValue(1);
            

            for (Char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            Decrypt(text, "" + c1 + c2 + c3 + c4);
                           
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

            for (int i = 1; i < Directory.GetFiles(@"C:\Users\Dhev\Desktop\test").Length+1; i++)
            {
                stringArray[0] = File.ReadAllText(@"C:\Users\Dhev\Desktop\test\fichier" + i + ".txt");
                stringArray[1] = ""+i;

               
                Thread t2 = new Thread(Program.decryptloop);
                t2.Start(stringArray);
                Thread.Sleep(10);
            }


            
        }
    }
}
