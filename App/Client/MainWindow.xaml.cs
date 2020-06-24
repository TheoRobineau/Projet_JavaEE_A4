using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Client.FrontService;

namespace Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string token = loginUser(UsernameBox.Text, PasswordBox.Password);
            
            if (token != "invalid")
            {
                logInResult.Text = "Success ! " + token.ToString();
            }
            else
            {
                logInResult.Text = "Failure ! Identifiant ou mot de passe incorrect " + token.ToString();
            }


        }

        private string loginUser(string username, string password)
        {

            FrontServiceClient service = new FrontServiceClient();

            Message message = service.ProcessMessage(new Message { operationName= log})


            //message = SendMessage();
            //if(credentials.token != "invalid")
            //{
            //    return credentials.token;
            //}
            //else
            //{
            //    return "invalid";
            //}
        }


        private Message MessageBuilder(List<object> paramList)
        {
            Message message = new Message();
            return message; 
        }

    }
}
