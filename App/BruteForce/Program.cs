using System;
using System.Threading;

namespace BruteForce
{
    class Program
    {
        // The same function is used to encrypt and 
        // decrypt 
        static String encryptDecrypt(String inputString, String key)
        {
            // variable permettant 
            int j = 0;

            // string permetant de stocker la valeur de sorti
            String outputString = "";

            // calcule le nombre de caractère dans le fichier txt
            int len = inputString.Length;

            // Opération XOR sur tous les caractères du fichier txt
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

        static void decrypt1()
        {
            string text2 = System.IO.File.ReadAllText(@"C:\Users\Dhev\Desktop\test\test2.txt");

            for (Char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            encryptDecrypt(text2, "" + c1 + c2 + c3 + c4);
                            if (encryptDecrypt(text2, "" + c1 + c2 + c3 + c4) == "bonjour")
                            {
                                Console.WriteLine("Threadd 2 finished at : " + DateTime.Now);
                                Console.WriteLine("key : " + c1 + c2 + c3 + c4);
                            }
                        }
                    }
                }
            }
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Started at : " + DateTime.Now);
            //Thread t = new Thread(new ThreadStart(decrypt1));

            //t.Start();


            string text = System.IO.File.ReadAllText(@"C:\Users\Dhev\Desktop\test\test.txt");
            //int len = text.Length;
            for (Char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (Char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (Char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (Char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            encryptDecrypt(text, "" + c1 + c2 + c3 + c4);
                            if (encryptDecrypt(text, "" + c1 + c2 + c3 + c4) == "bonjour")
                            {
                                Console.WriteLine("Thread 1 finished at : " + DateTime.Now);
                                Console.WriteLine("key : " + c1 + c2 + c3 + c4);
                            }
                        }
                    }
                }
            }


        }
    }
}
