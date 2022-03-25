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
using VasuthalozatCommon.RailwayException;
using VasuthalozatAdmin.controller;

namespace VasuthalozatAdmin.view
{
    /// <summary>
    /// Interaction logic for AdminLoginWindow.xaml
    /// </summary>
    public partial class AdminLoginWindow : Window
    {
        
        private LoginController loginController = new LoginController();
        public AdminLoginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = 500;
            Top = 200;
            InitializeComponent();
        }

        public AdminLoginWindow(string usernameText) : this()
        {
            tb_Username.Text = usernameText;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = loginController.HandleLoginAttempt(tb_Username.Text, tb_Password.Password);
                AdminRailwayPickerWindow railwayPicker = new AdminRailwayPickerWindow(user.Name);
                railwayPicker.Left = this.Left;
                railwayPicker.Top = this.Top;
                AdminRailwayPickerWindow.GetWindow(railwayPicker).Show();
                this.Close();
            }
            catch (VasuthalozatException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen bejelentkezés", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            AdminRegisterWindow registerWindow = new AdminRegisterWindow();
            registerWindow.Left = this.Left;
            registerWindow.Top = this.Top;
            AdminRegisterWindow.GetWindow(registerWindow).Show();
            this.Close();
        }
    }
}
