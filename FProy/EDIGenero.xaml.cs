using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para EDIGenero.xaml
    /// </summary>
    public partial class EDIGenero : Window
    {
        public EDIGenero()
        {
            InitializeComponent();
        }

       

        private void ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Generos
                       select s;
            dbg1.ItemsSource = cons.ToList();
        }

        private void dbg1_Loaded(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            cb1.ItemsSource = db.Generos.ToList();
            cb1.DisplayMemberPath = "nameg";
            cb1.SelectedValuePath = "codgen";
        }

        private void cba_Click(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();
            String id = (String)cb1.SelectedValue;

            if (String.IsNullOrEmpty(txt.Text.Trim()) && Regex.IsMatch(txt.Text, "[a-zA-Z]"))
            {

                MessageBox.Show("No se puede registrar una tienda sin un nombre valido. No use números");
            }
            else
            { //}

                var cons = db.Generos.SingleOrDefault(s => s.codgen == id);


                if (cons != null)
                {
                    cons.nameg = Convert.ToString(txt.Text);
                    db.SaveChanges();
                }
            }
        }

    }
}
