using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour DecipherLauncher.xaml
    /// </summary>
    public partial class DecipherLauncher : Window
    {

        private string token;
        private string username;

        int i = 0;

        private List<string> fileNames = new List<string>();
        private List<string> fileData = new List<string>();

        public DecipherLauncher(string username, string tokenUser)
        {
            token = tokenUser;
            this.username = username;

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
                    string name = fileDialog.SafeFileName;

                    fileNames.Add(name);
                    fileData.Add(reader.ReadToEnd());
                    reader.Close();

                    FileListBox.Items.Add(name.ToString());
                    FileListBox.Items.Add(fileData.ElementAt(i).ToString());
                    i++;
                }
            }


        }


    }
}
