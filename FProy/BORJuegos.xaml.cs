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
    /// Lógica de interacción para BORJuegos.xaml
    /// </summary>
    public partial class BORJuegos : Window
    {
        public BORJuegos()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Juegos
                       select s;
            dbg.ItemsSource = cons.ToList();


            cb1.ItemsSource = db.Juegos.ToList();
            cb1.DisplayMemberPath = "idjuego";
            cb1.SelectedValuePath = "idjuego";




        }

        private void dbg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int id = (Int32)cb1.SelectedValue;

            var cons = db.Juegos.SingleOrDefault(s => s.idjuego== id);

            if (cons != null)
            {
                db.Juegos.Remove(cons);
                db.SaveChanges();
            } 

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Juegos
                       select s;
            dbg.ItemsSource = cons.ToList();
        }
    }
}
