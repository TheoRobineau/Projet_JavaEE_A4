using Client.FrontService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour DecipherLauncher.xaml
    /// </summary>
    public partial class DecipherLauncher : Window
    {

        private string token;
        private string username;
        private string tokenApp;

        int i = 0;

        private bool processIsRunning = false;

        private List<string> fileNames = new List<string>();
        private List<string> fileData = new List<string>();

        public DecipherLauncher(string username, string tokenUser, string tokenApp)
        {
            token = tokenUser;
            this.username = username;
            this.tokenApp = tokenApp;

            InitializeComponent();
            WelcomeText.Text = "Bienvenue sur votre outil de décryptage, " + this.username + ". \nVeuillez sélectionnez les fichiers à décrypter.";

        }

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.DefaultExt = ".txt";
            fileDialog.Filter = "Text documents (.txt)|*.txt";

            var result = fileDialog.ShowDialog();
            if ( result == true)
            {
                
                foreach (string file in fileDialog.FileNames)
                {
                    StreamReader reader = new StreamReader(file);
                    string name = Path.GetFileName(file);
                    
                    fileNames.Add(name);
                    fileData.Add(reader.ReadToEnd());
                    reader.Close();
                    FileListBox.Items.Add(name.ToString());

                    //debug
                    FileListBox.Items.Add(fileData.ElementAt(i).ToString());
                    i++;
                    //debug
                }

                StartButton.IsEnabled = true;
            }


        }

        private void Start_Decipher_Button_Click(object sender, RoutedEventArgs e)
        {
            byte[][] arrayData = new byte[2][];

            //convertis les objets list en tableau de tableaux byte[] #Scotch
            arrayData[0] = ByteSerializer(fileNames);
            arrayData[1] = ByteSerializer(fileData);


            if (!processIsRunning)
            {
                FrontServiceClient service = new FrontServiceClient();
                Message message = service.ProcessMessage(new Message { operationName = "Decipher", tokenUser = this.token, tokenApp = this.tokenApp, data = arrayData });//, data = arrayData
                processIsRunning = true;
            }
            else
            {
                MessageBox.Show("Le processus est déjà en cours !", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private byte[] ByteSerializer(List<string> list)
        {
            var binFormatter = new BinaryFormatter();
            var mStream = new MemoryStream();
            binFormatter.Serialize(mStream, fileNames);
            byte[] data = new byte[0];
            data = mStream.ToArray();

            return data;
        }
    }
}
