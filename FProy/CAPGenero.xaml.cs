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
    /// Lógica de interacción para CAPGenero.xaml
    /// </summary>
    public partial class CAPGenero : Window
    {
        public CAPGenero()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Genre gen = new FProy.BD.Genre();

            gen.codgen = tx1.Text;
            gen.nameg = tx2.Text;

            db.Generos.Add(gen);
            db.SaveChanges();
        }
    }
}
