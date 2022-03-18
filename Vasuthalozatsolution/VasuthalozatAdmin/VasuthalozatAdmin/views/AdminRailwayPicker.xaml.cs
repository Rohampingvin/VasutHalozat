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

namespace VasuthalozatAdmin.views
{
    /// <summary>
    /// Interaction logic for AdminRailwayPicker.xaml
    /// </summary>
    public partial class AdminRailwayPicker : Window
    {
        private VonatContext vonat = VonatContext.Instance;
        private RailwayController railwayController = new RailwayController();
        public AdminRailwayPicker()
        {
            InitializeComponent();
        }
    }
}
