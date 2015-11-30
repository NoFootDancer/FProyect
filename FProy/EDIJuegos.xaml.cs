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
    /// Lógica de interacción para EDIJuegos.xaml
    /// </summary>
    public partial class EDIJuegos : Window
    {
        public EDIJuegos()
        {
            InitializeComponent();
        }

        private void dbg_Loaded(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Instrucciones: \n 1.- Seleccionar ID del juego\n 2.- Realizar cambios y ajustes en cuadros de texto ó listas\n 3.- Clic en 'guardar cambios' ");
        
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Juegos.ToList();
            cb1.DisplayMemberPath = "idjuego";
            cb1.SelectedValuePath = "idjuego";

            cb2.ItemsSource = db.Generos.ToList();
            cb2.DisplayMemberPath = "nameg";
            cb2.SelectedValuePath = "codgen";

            cb3.ItemsSource = db.Consolas.ToList();
            cb3.DisplayMemberPath = "namecons";
            cb3.SelectedValuePath = "codcons";

            cb4.ItemsSource = db.Companias.ToList();
            cb4.DisplayMemberPath = "namec";
            cb4.SelectedValuePath = "codcomp";

            cb1.SelectedIndex = 0;
            cb2.SelectedIndex = 0;
            cb3.SelectedIndex = 0;
            cb4.SelectedIndex = 0;

            Ver1.IsEnabled = false;

        
        
        }

        private void Ver1_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            int idGame = (int)cb1.SelectedValue;

           var cons = from s in db.Juegos

                       where s.idjuego == idGame
                       select s;
           dbg.ItemsSource = cons.ToList();

            var cons1 = db.Juegos.SingleOrDefault(s => s.idjuego == idGame);
            t1.Text = cons1.namej;
            t2.Text = Convert.ToString(cons1.precio);
            t3.Text = Convert.ToString(cons1.rdate);

            
          

        

            
            
   
        }

        private void Ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Juegos
                       select s;
            dbg.ItemsSource = cons.ToList();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int id = (Int32)cb1.SelectedValue;

            if (String.IsNullOrEmpty(t1.Text))
            {

                MessageBox.Show("No se puede registrar un juego sin un nombre.");
            }
            else
            {
                if (Regex.IsMatch(t2.Text, "^[0-9]*$"))
                {

                    var cons = db.Juegos.SingleOrDefault(s => s.idjuego == id);
                    if (cons != null)
                    {
                        cons.namej = Convert.ToString(t1.Text);
                        cons.precio = Convert.ToSingle(t2.Text);
                        cons.rdate = t3.SelectedDate.Value;

                        cons.codgen = (String)cb2.SelectedValue;
                        cons.codcons = (String)cb3.SelectedValue;
                        cons.codcomp = (String)cb4.SelectedValue;

                        db.SaveChanges();
                    }
                }
                else { MessageBox.Show("Introduce solo números en el precio"); }
            }


          

            int idGame = (int)cb1.SelectedValue;

            var cons3 = from s in db.Juegos

                       where s.idjuego == idGame
                       select s;
            dbg.ItemsSource = cons3.ToList();



        }


        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {




            FProy.BD.MiBd db = new FProy.BD.MiBd();

            int idGame = (int)cb1.SelectedValue;

            var cons2 = from s in db.Juegos

                        where s.idjuego == idGame
                        select s;
            dbg.ItemsSource = cons2.ToList();

            var cons1 = db.Juegos.SingleOrDefault(s => s.idjuego == idGame);
            t1.Text = cons1.namej;
            t2.Text = Convert.ToString(cons1.precio);
            t3.Text = Convert.ToString(cons1.rdate);

            

        }
    }
}
