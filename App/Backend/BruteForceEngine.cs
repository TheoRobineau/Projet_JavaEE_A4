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
        static string Decrypt(string inputString, string key, string filename)
        {
            //bdd test = new bdd();
            var result = new StringBuilder();

            for (int c = 0; c < inputString.Length; c++)
                result.Append((char)((uint)inputString[c] ^ (uint)key[c % key.Length]));

            if (key == "ZZZZ")
            {
            System.Diagnostics.Debug.WriteLine("Thread " + filename + " endend at : " + DateTime.Now + " : " + result.ToString());
            }
            return result.ToString();
        }
        public static void DecryptLoop(Object args)
        {
            
            Array argArray = new object[2];
            argArray = (Array)args;
            string text = (string)argArray.GetValue(1);
            string compteur = (string)argArray.GetValue(0);
            string key = (string)argArray.GetValue(2);
            System.Diagnostics.Debug.WriteLine("Thread " + compteur + " started at : " + DateTime.Now);
            if (key == "")
            {
                for (Char c1 = 'A'; c1 <= 'Z'; c1++)
                {
                    for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                    {
                        for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                        {
                            for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                            {
                                Decrypt(text, "" + c1 + c2 + c3 + c4, compteur);
                                SOAPMessageSender sender = new SOAPMessageSender();
                               // sender.SendFileToJMS();

                                if ("" + c1 + c2 + c3 + c4 == "ZZZZ")
                                {
                                    //Console.WriteLine("Thread "+ compteur + " finished at : " + DateTime.Now);
                                    //System.Diagnostics.Debug.WriteLine("Thread " + compteur + " finished at : " + DateTime.Now);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Decrypt(text, key, compteur);
            }
        }

        
        public string Truncate(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text.Length <= maxLength ? text : text.Substring(0, maxLength);
        }
        
        public void DecipherEngine(List<string> fileNames, List<string> fileContents, string key = "")
        {
            System.Diagnostics.Debug.WriteLine("Started at : " + DateTime.Now);
            for (int i = 0; i < fileNames.Count(); i++)
            {
                string[] parameters = new string[3];
                string name = fileNames.ElementAt(i);

                parameters[0] = name;
                if (key == "")
                {
                    string content = Truncate(fileContents.ElementAt(i), 8000);
                    parameters[1] = content;
                }
                else
                {
                    string content = fileContents.ElementAt(i);
                    parameters[1] = content;
                }
                parameters[2] = key;

                ThreadManager(new Thread(DecryptLoop), name, parameters);
                //Thread t2 = new Thread(DecryptLoop);
                //t2.Start(parameters);
                Thread.Sleep(100);
            }
        }

        public Dictionary<string, Thread> threadList = new Dictionary<string, Thread>();
        public void ThreadManager(Thread thread, string fileName, object[] parameters)
        {
            Console.WriteLine("Thread Manager");
            threadList.Add(fileName, thread);
            thread.Start(parameters);
            Thread.Sleep(100);
        }
        public void ThreadStopper(ResultJMSEventArgrs result)
        {
            //if (result.resultBool == true)
            //{
            if (result != null)
            {
                if (threadList.TryGetValue(result.resultJMS.FileName.ToString(), out Thread thread))
                {
                    if (thread.IsAlive)
                    {
                        Console.WriteLine("THREAD FOR FILE : " + result.resultJMS.FileName + " STOPPED ! RESULT FOUND !");
                        thread.Join();
                        thread.Interrupt();
                        //thread.Abort();

                        Console.WriteLine("THREAD FOR FILE : " + result.resultJMS.FileName + " Status is : " + thread.IsAlive);
                    }
                }
            }
                

            }

        public void OnJMSResult(object source, ResultJMSEventArgrs e)
        {
            Console.WriteLine("OnJSFResult In BruteForceEngine ");
            ThreadStopper(e);
        }

    }
}