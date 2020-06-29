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
                System.Diagnostics.Debug.WriteLine("endend at : " + DateTime.Now);

            }
            return result.ToString();
        }

        public static void DecryptLoop(Object args)
        {
            Array argArray = (Array)args;
            int first = 25;
            int second = 25;
            int third = 25;
            int fourth = 25;
            string attempt = "";
            string[] array = {
            "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
            };
            string text = (string)argArray.GetValue(1);
            string fileName = (string)argArray.GetValue(0);
            System.Diagnostics.Debug.WriteLine(fileName + text);


            while (!attempt.Equals("ZZZZ"))
            {
                if (first == 26)
                {
                    second++;
                    first = 0;
                }

                if (second == 26)
                {
                    third++;
                    second = 0;
                }

                if (third == 26)
                {
                    fourth++;
                    third = 0;
                }

                if (fourth == 26)
                {
                    break;
                }
                attempt = array[fourth] + array[third] + array[second] + array[first];
                Decrypt(text, attempt);
                first++;
            }
        }

        public void DecipherEngine(List<string> fileNames, List<string> fileContents)
        {
            System.Diagnostics.Debug.WriteLine("Started at : " + DateTime.Now);

            for (int i = 0; i < fileNames.Count(); i++)
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