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
    /// Lógica de interacción para BORCompania.xaml
    /// </summary>
    public partial class BORCompania : Window
    {
        public BORCompania()
        {
            InitializeComponent();
        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Companias.ToList();
            cb1.DisplayMemberPath = "namec";
            cb1.SelectedValuePath = "codcomp";
        }

        private void ver_Click(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Companias
                       select s;
            dbg.ItemsSource = cons.ToList();
        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();
            String id = (String)cb1.SelectedValue;

           var cons = db.Juegos.FirstOrDefault(s => s.codcomp == id);

           if (cons != null)
           {
               MessageBox.Show("No se puede borrar un dato que ya esta siendo usado en los registros.");
           }
           else {


               var con = db.Companias.FirstOrDefault(s => s.codcomp == id);
               db.Companias.Remove(con);
               db.SaveChanges();

               var cons1 = from s in db.Companias
                           select s;
               dbg.ItemsSource = cons1.ToList();
               cb1.ItemsSource = db.Companias.ToList();
               cb1.SelectedIndex = 0;
           } 
            
        }
    }
}
