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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VasuthalozatPublic.Controller;
using VasuthalozatCommon.RailwayException;

namespace VasuthalozatPublic.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private LoginController loginController = new LoginController();
        public LoginWindow()
        {
            WindowStartupLocation = WindowStartupLocation.Manual;
            Left = 500;
            Top = 200;
            InitializeComponent();
        }

        public LoginWindow(string usernameText) : this()
        {
            tb_Username.Text = usernameText;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = loginController.HandleLoginAttempt(tb_Username.Text, tb_Password.Password);
                RailwayPicker railwayPicker = new RailwayPicker(user.Name);
                railwayPicker.Left = this.Left;
                railwayPicker.Top = this.Top;
                RailwayPicker.GetWindow(railwayPicker).Show();
                this.Close();
            }
            catch (VasuthalozatException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen bejelentkezés", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Left = this.Left;
            registerWindow.Top = this.Top;
            RegisterWindow.GetWindow(registerWindow).Show();
            this.Close();
        }
    }
}
