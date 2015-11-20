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
    /// Lógica de interacción para BORGenero.xaml
    /// </summary>
    public partial class BORGenero : Window
    {
        public BORGenero()
        {
            InitializeComponent();
        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Generos.ToList();
            cb1.DisplayMemberPath = "nameg";
            cb1.SelectedValuePath = "codgen";




        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            String id = (String)cb1.SelectedValue;

            var cons = db.Generos.SingleOrDefault(s => s.codgen == id);

            if (cons != null)
            {
                db.Generos.Remove(cons);
                db.SaveChanges();
            } 
            

        }

        private void ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Generos
                       select s;
            dbg.ItemsSource = cons.ToList();
        }
    }
}
