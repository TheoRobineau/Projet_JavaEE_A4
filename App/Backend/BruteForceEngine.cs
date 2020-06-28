using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

namespace Backend
{
    public class BruteForceEngine
    {
        static string Decrypt(string inputString, string key)
        {
            var result = new StringBuilder();

            for (int c = 0; c < inputString.Length; c++)
                result.Append((char)((uint)inputString[c] ^ (uint)key[c % key.Length]));

            if (key == "ZZZZ")
            {
                System.Diagnostics.Debug.WriteLine(result.ToString());
            }
            return result.ToString();
        }

        static void DecryptLoop(Object args)
        {
            Array argArray = (Array)args;

            string fileName = (string)argArray.GetValue(0);
            string text = (string)argArray.GetValue(1);


            for (Char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            string key = "" + c1 + c2 + c3 + c4;
                            Decrypt(text, key);

                            //SEND RESULT TO JAVA EE HERE

                            //System.Diagnostics.Debug.WriteLine("Fichier : " + fileName + "décrypter avec la clé :" + key);

                            if ("" + c1 + c2 + c3 + c4 == "ZZZZ")
                            {
                                System.Diagnostics.Debug.WriteLine("Thread " + fileName + " finished at : " + DateTime.Now);
                            }
                        }
                    }
                }
            }

        }

        public void DecipherEngine(List<string> fileNames, List<string> fileContents)
        {
            Console.WriteLine("Started at : " + DateTime.Now);


            for(int i = 0; i < fileNames.Count(); i++)
            {
                string name = fileNames.ElementAt(i);
                string content = fileContents.ElementAt(i);
                string[] parameters = new string[2];

                parameters[0] = name;
                parameters[1] = content;


                Thread t2 = new Thread(DecryptLoop);
                t2.Start(parameters);
                Thread.Sleep(10);
            }

        }




    }
}