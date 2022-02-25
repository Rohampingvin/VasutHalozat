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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VasuthalozatPublic.Controller;

namespace VasuthalozatPublic.View
{
    /// <summary>
    /// Interaction logic for RailwayPicker.xaml
    /// </summary>
    public partial class RailwayPicker : Window
    {
        private RailwayPickerController railwayPickerController = new RailwayPickerController();
        public RailwayPicker()
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = 100;
            Top = 200;
            InitializeComponent();
            railwayPickerController.SubscibeToLogout(UserAuthenticator_LogoutEvent);
        }

        private void UserAuthenticator_LogoutEvent()
        {
            LoginWindow loginWindow = new LoginWindow();
            
            LoginWindow.GetWindow(loginWindow).Show();
            railwayPickerController.UnsubscribeFromLogout(UserAuthenticator_LogoutEvent);
            this.Close();
        }

        public RailwayPicker(string userRealName) : this()
        {
            la_title.Content += " " + userRealName;
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            railwayPickerController.Logout();
        }
    }
}
