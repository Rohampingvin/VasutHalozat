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
using VasuthalozatCommon.Repository;

namespace VasuthalozatPublic.View
{
    /// <summary>
    /// Interaction logic for RailwayPicker.xaml
    /// </summary>
    public partial class RailwayPicker : Window
    {
        private RailwayPickerController railwayPickerController = new RailwayPickerController();
        private VasuthalozatContext Vasuthalozat = VasuthalozatContext.Instance;
        public RailwayPicker()
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = 100;
            Top = 200;
            InitializeComponent();
            railwayPickerController.SubscibeToLogout(UserAuthenticator_LogoutEvent);
            foreach (var item in railwayPickerController.GetCities())
            {
                fromcb.Items.Add(item.Name);
                wherecb.Items.Add(item.Name);
            }
        }

        private void UserAuthenticator_LogoutEvent()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
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

        private void fromcb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            if (fromcb.SelectedIndex != null)
            {
                var s = Vasuthalozat.Railways.FirstOrDefault(r => r.FromCity.ToLower() == fromcb.SelectedItem.ToString().ToLower() && r.ToCity.ToLower() == wherecb.SelectedItem.ToString().ToLower() || r.FromCity.ToLower() == fromcb.SelectedItem.ToString().ToLower() && r.ToCity.ToLower() == fromcb.SelectedItem.ToString().ToLower());
                ListView.Items.Add(s);
            }
        }

        private void wherecb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView.Items.Clear();
            if (fromcb.SelectedIndex != null)
            {
                var s = Vasuthalozat.Railways.FirstOrDefault(r => r.FromCity.ToLower() == fromcb.SelectedItem.ToString().ToLower() && r.ToCity.ToLower() == wherecb.SelectedItem.ToString().ToLower() || r.FromCity.ToLower() == wherecb.SelectedItem.ToString().ToLower() && r.ToCity.ToLower() == fromcb.SelectedItem.ToString().ToLower());
                ListView.Items.Add(s);
            }
        }
    }
}
