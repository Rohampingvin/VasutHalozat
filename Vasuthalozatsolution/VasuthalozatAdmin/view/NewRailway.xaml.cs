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

namespace VasuthalozatAdmin.view
{
    /// <summary>
    /// Interaction logic for NewRailway.xaml
    /// </summary>
    public partial class NewRailway : Window
    {
        VasuthalozatContext vonat = VasuthalozatContext.Instance;
        public NewRailway()
        {
            InitializeComponent();
            foreach (var city in vonat.GetCities())
            {
                cbFrom.Items.Add(city.Name);
                cbTo.Items.Add(city.Name);
            }
        }

        private void AddRailway_OnClick(object sender, RoutedEventArgs e)
        {
            var railway = new Railway()
            {
                FromCity = cbFrom.SelectedItem.ToString(),
                ToCity = cbTo.SelectedItem.ToString(),
                Distance = int.Parse(TbDis.Text)
            };
            var s = vonat.Railways.FirstOrDefault(r => r.FromCity.ToLower() == railway.FromCity.ToLower() && r.ToCity.ToLower() == railway.ToCity.ToLower() || r.FromCity.ToLower() == railway.ToCity.ToLower() && r.ToCity.ToLower() == railway.FromCity.ToLower());
            if (s == null)
            {
                vonat.CreateRailway(railway);
            }
            else
            {
                MessageBox.Show("Ilyen útvonal már létezik!", "Exists", MessageBoxButton.OK);
            }
        }

        private void Back_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
