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

namespace FProy
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CAPCompania vent=new CAPCompania();
            vent.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow vent1 = new MainWindow();
            vent1.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            CAPGenero vent2 = new CAPGenero();
            vent2.Show();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            CAPConsola vent3 = new CAPConsola();
            vent3.Show();
        }
    }
}
