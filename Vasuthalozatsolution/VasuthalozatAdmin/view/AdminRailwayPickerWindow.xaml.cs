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
using VasuthalozatCommon.Model;
using VasuthalozatCommon.Repository;
using VasuthalozatAdmin.controller;
using System.IO;

namespace VasuthalozatAdmin.view
{
    /// <summary>
    /// Interaction logic for AdminRailwayPickerWindow.xaml
    /// </summary>
    public partial class AdminRailwayPickerWindow : Window
    {
        private RailwayPickerController railwayPickerController = new RailwayPickerController();
        private VasuthalozatContext Vasuthalozat = VasuthalozatContext.Instance;
        public AdminRailwayPickerWindow()
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
            AdminLoginWindow loginWindow = new AdminLoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            AdminLoginWindow.GetWindow(loginWindow).Show();
            railwayPickerController.UnsubscribeFromLogout(UserAuthenticator_LogoutEvent);
            this.Close();
        }

        public AdminRailwayPickerWindow(string userRealName) : this()
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

        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            NewCityPicker newCityPicker = new NewCityPicker();
            newCityPicker.ShowDialog();
        }

        private void Button_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_update_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("cities.txt"))
            {
                StreamReader sr = new StreamReader("cities.txt");
                while (!sr.EndOfStream)
                {
                    string h = sr.ReadLine();
                    var s = Vasuthalozat.Cities.FirstOrDefault(r => r.Name.ToLower() == h.ToLower());
                    if (s == null)
                    {
                        Vasuthalozat.CreateCity(new Cities() { Name = h });
                    }
                }
            }

            if (File.Exists("railways.txt"))
            {
                StreamReader sr = new StreamReader("railways.txt");
                while (!sr.EndOfStream)
                {
                    string[] h = sr.ReadLine().Split(';');
                    var s = Vasuthalozat.Railways.FirstOrDefault(r => r.FromCity.ToLower() == h[0].ToLower() && r.ToCity.ToLower() == h[1].ToLower() || r.FromCity.ToLower() == h[1].ToLower() && r.ToCity.ToLower() == h[0].ToLower());
                    if (s == null)
                    {
                        Vasuthalozat.CreateRailway(new Railway()
                        {
                            FromCity = h[0],
                            ToCity = h[1],
                            Distance = int.Parse(h[2])
                        });
                    }
                }
            }
            ListView.ItemsSource = Vasuthalozat.GetRailways();
        }
    }
}
