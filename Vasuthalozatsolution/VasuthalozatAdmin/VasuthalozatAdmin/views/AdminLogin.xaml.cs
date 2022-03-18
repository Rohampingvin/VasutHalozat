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
using VasuthalozatPublic.Controller;

namespace VasuthalozatAdmin.views
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        private LoginController loginController = new LoginController();
        public AdminLogin()
        {
            InitializeComponent();
        }

        public AdminLogin(string usernameText) : this()
        {
            tb_Username.Text = usernameText;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = loginController.HandleLoginAttempt(tb_Username.Text, tb_Password.Password);
                AdminRailwayPicker railwayPicker = new AdminRailwayPicker(user.Name);
                railwayPicker.Left = this.Left;
                railwayPicker.Top = this.Top;
                AdminRailwayPicker.GetWindow(railwayPicker).Show();
                this.Close();
            }
            catch (VasuthalozatException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen bejelentkezés", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            AdminRegister registerWindow = new AdminRegister();
            registerWindow.Left = this.Left;
            registerWindow.Top = this.Top;
            AdminRegister.GetWindow(registerWindow).Show();
            this.Close();
        }
    }
}
