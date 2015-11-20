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
    /// Lógica de interacción para BORConsola.xaml
    /// </summary>
    public partial class BORConsola : Window
    {
        public BORConsola()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Consolas.ToList();
            cb1.DisplayMemberPath = "namecons";
            cb1.SelectedValuePath = "codcons";

        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();
            String id = (String)cb1.SelectedValue;

           var cons = db.Consolas.SingleOrDefault(s => s.codcons == id);

           if (cons != null)
           {
               db.Consolas.Remove(cons);
               db.SaveChanges();
           }
        }

        private void ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Consolas
                       select s;
            dbg.ItemsSource = cons.ToList();
        }
    }
}
