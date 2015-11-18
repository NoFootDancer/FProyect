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

namespace FProy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Game juego = new FProy.BD.Game();

            juego.idjuego = Convert.ToInt32(tx1.Text);
            juego.namej  = tx2.Text;
            juego.precio = Convert.ToSingle(tx3.Text);
            juego.rdate = tx4.Text;
            juego.codcomp = tx5.Text;
            juego.codgen = tx7.Text;

            db.Juegos.Add(juego);
            db.SaveChanges();


        }
    }
}
