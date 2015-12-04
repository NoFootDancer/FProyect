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
    /// Lógica de interacción para EDIConsola.xaml
    /// </summary>
    public partial class EDIConsola : Window
    {
        public EDIConsola()
        {
            InitializeComponent();
        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Consolas.ToList();
            cb1.DisplayMemberPath = "namecons";
            cb1.SelectedValuePath = "codcons";
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Consolas
                       select s;
            dbg.ItemsSource = cons.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            String id = (String)cb1.SelectedValue;

            if (String.IsNullOrEmpty(txt.Text.Trim()) && Regex.IsMatch(txt.Text, "[a-zA-Z]"))
            {

                MessageBox.Show("No se puede registrar una tienda sin un nombre valido. No use números");
            }
            else
            { //}

                var cons = db.Consolas.SingleOrDefault(s => s.codcons == id);


                if (cons != null)
                {
                    cons.namecons = Convert.ToString(txt.Text);
                    db.SaveChanges();
                }
            }
        }
    }
}
