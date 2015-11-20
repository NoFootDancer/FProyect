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
using System.Text.RegularExpressions;

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

            juego.namej = tx2.Text;
            juego.precio = Convert.ToSingle(tx3.Text);
            juego.rdate = tx4.Text;
            juego.codgen =  (String)cb1.SelectedValue;
            juego.codcomp = (String)cb2.SelectedValue;
            juego.codcons = (String)cb3.SelectedValue;
            //juego.codcons = (String)cb3.SelectedValue;

            db.Juegos.Add(juego);
            db.SaveChanges();


           

        }

        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tx3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_Loaded_1(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            cb1.ItemsSource = db.Generos.ToList();
            cb1.DisplayMemberPath = "nameg";
            cb1.SelectedValuePath = "codgen";

            cb2.ItemsSource = db.Companias.ToList();
            cb2.DisplayMemberPath = "namec";
            cb2.SelectedValuePath = "codcomp";

            cb3.ItemsSource = db.Consolas.ToList();
            cb3.DisplayMemberPath = "namecons";
            cb3.SelectedValuePath = "codcons";
            

        }

        private void ver_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            var cons = from s in db.Juegos
                       select s;
            dbg.ItemsSource = cons.ToList();
        }

        private void Borrar_juegos_Click(object sender, RoutedEventArgs e)
        {
            BORJuegos vent = new BORJuegos();
            vent.Show();
            this.Close();
        }

        private void Editar_juegos_Click(object sender, RoutedEventArgs e)
        {
            EDIJuegos vent1 = new EDIJuegos();
            vent1.Show();
            this.Close();
        }
    }
}
