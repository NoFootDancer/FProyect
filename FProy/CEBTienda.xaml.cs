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
    /// Lógica de interacción para CEBTienda.xaml
    /// </summary>
    public partial class CEBTienda : Window
    {
        public CEBTienda()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Store st = new FProy.BD.Store();

            st.nameS = tx1.Text;
            db.Tiendas.Add(st);
            db.SaveChanges();

            cb1.ItemsSource = db.Tiendas.ToList();

            var cons = from s in db.Tiendas
                       select s;
            dbg.ItemsSource = cons.ToList();
            cb1.SelectedIndex = 0;

        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            
            cb1.ItemsSource = db.Tiendas.ToList();
            cb1.DisplayMemberPath = "nameS";
            cb1.SelectedValuePath = "idstore";
            cb1.SelectedIndex = 0;

            var cons = from s in db.Tiendas
                       select s;
            dbg.ItemsSource = cons.ToList();

        }

        private void borrar_Click(object sender, RoutedEventArgs e)
        {


            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int id = Convert.ToInt32(cb1.SelectedValue);

            var cons = db.Tiendas.SingleOrDefault(s => s.idstore == id);

            if (cons != null)
            {
                db.Tiendas.Remove(cons);
                db.SaveChanges();
            }
           

            var cons1 = from s in db.Tiendas
                       select s;
            dbg.ItemsSource = cons1.ToList();
            cb1.ItemsSource = db.Tiendas.ToList();
            cb1.SelectedIndex = 0;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int id = Convert.ToInt32(cb1.SelectedValue);

            var cons = db.Tiendas.SingleOrDefault(s => s.idstore == id);
            if (cons != null)
            {
                cons.nameS = Convert.ToString(tx2.Text);
                db.SaveChanges();


            }

            var cons1 = from s in db.Tiendas
                        select s;

            dbg.ItemsSource = cons1.ToList();
            cb1.ItemsSource = db.Tiendas.ToList();
            cb1.SelectedIndex = 0;
            
        }
    }
}

