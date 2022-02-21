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
using VasuthalozatCommon.RailwayException;

namespace VasuthalozatPublic.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private RegisterController registerController = new RegisterController();
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Left = this.Left;
            loginWindow.Top = this.Top;
            LoginWindow.GetWindow(loginWindow).Show();
            this.Close();
        }

        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                registerController.HandleRegister(tb_username.Text, tb_password1.Password, tb_password2.Password, tb_email.Text, tb_name.Text);
                LoginWindow loginWindow = new LoginWindow(tb_username.Text);
                loginWindow.Left = this.Left;
                loginWindow.Top = this.Top;
                LoginWindow.GetWindow(loginWindow).Show();
                this.Close();
            }
            catch (VasuthalozatException exc)
            {
                MessageBox.Show(exc.Message, "Sikertelen regisztráció", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
