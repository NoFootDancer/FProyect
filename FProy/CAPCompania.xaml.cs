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
    /// Lógica de interacción para CAPCompania.xaml
    /// </summary>
    public partial class CAPCompania : Window
    {
        public CAPCompania()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Company com = new FProy.BD.Company();

            com.codcomp = tx1.Text;
            com.namec = tx2.Text;

            db.Companias.Add(com);
            db.SaveChanges();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EDICompania vent = new EDICompania();
            vent.Show();
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BORCompania vent1 = new BORCompania();
            vent1.Show();
            this.Close();
        }
    }
}
