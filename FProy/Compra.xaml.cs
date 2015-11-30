using System;
using System.Data.Entity;
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
using System.Windows.Navigation;

namespace FProy
{
    /// <summary>
    /// Lógica de interacción para Compra.xaml
    /// </summary>
    public partial class Compra : Window
    {
        private FProy.BD.Game tmpG = null;
        private List<FProy.BD.Game> Carrito;
        public Compra()
        {
            InitializeComponent();
            Carrito = new List<BD.Game>();
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Store st = new FProy.BD.Store();
            FProy.BD.Game gm = new FProy.BD.Game();

           

            cb1.ItemsSource = db.Juegos.ToList();
            cb1.DisplayMemberPath = "namej";
            cb1.SelectedValuePath = "idjuego";
            cb1.SelectedIndex = 0;

            cb2.ItemsSource = db.Tiendas.ToList();
            cb2.DisplayMemberPath = "nameS";
            cb2.SelectedValuePath = "idstore";
            cb2.SelectedIndex = 0;


        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();

            int idGame = (int)cb1.SelectedValue;

            var cons2 = from s in db.Juegos

                        where s.idjuego == idGame
                        select s;
       

            var cons1 = db.Juegos.SingleOrDefault(s => s.idjuego == idGame);
            tx1.Text = cons1.codcons;
            tx2.Text = cons1.codgen;
            tx3.Text = Convert.ToString(cons1.precio);
         

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            int Id = (int)cb1.SelectedValue;
            FProy.BD.Game Gg = db.Juegos.SingleOrDefault(x => x.idjuego == Id);
            tmpG = Gg;

            Carrito.RemoveAll(s => s.idjuego == tmpG.idjuego);
            Carrito.Add(new FProy.BD.Game() { 
            
            idjuego = tmpG.idjuego,
            namej = tmpG.namej,
            codcons = tmpG.codcons,
            precio = tmpG.precio,
            
            
            });

            BindDataGrid();
            tmpG = null;


        }

        private void BindDataGrid() {

            var llenarCarrito = from s in Carrito
                                select new { 
                                s.idjuego,
                                s.namej,
                                s.codcons,
                                s.precio
                                
                                };
            dg.ItemsSource = null;
            dg.ItemsSource = llenarCarrito;
            
            //Añadir columna de total
            cTotal.Content = string.Format("Total: {0}",Carrito.Sum(x => x.precio).ToString("C"));

        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void com_Click(object sender, RoutedEventArgs e)
        {
            //FProy.BD.MiBd db = new BD.MiBd();
            //FProy.BD.Factura fact = new FProy.BD.Factura();

            //fact.datos = "meh";
            //fact.Fecha = DateTime.Now;
            //fact.idStore = (int)cb2.SelectedValue;

            ////db.Facturas.Add(fact);
            ////db.SaveChanges();
            
            
            //fact.Juegos = db.Juegos.SingleOrDefault(x => x.idjuego == (int)cb1.SelectedValue);


            if (Carrito.Count > 0)
            {

                using (FProy.BD.MiBd db = new FProy.BD.MiBd())
                {
                    using (var dbtrans = db.Database.BeginTransaction())
                    {

                        try
                        {
                            FProy.BD.Factura fact = new FProy.BD.Factura();
                            fact.Fecha = DateTime.Now;
                            fact.idStore = (int)cb2.SelectedValue;
                            fact.datos = "ETC";
                           // fact.Juegos = db.Juegos.SingleOrDefault(w => w.idjuego == (int)cb1.SelectedValue);
                            //fact.Juegos= db.Juegos.SingleOrDefault(s => s.idjuego == (int)cb1.SelectedValue);

                           // db.Facturas.Add(fact);
                           // db.SaveChanges();
                           // dbtrans.Commit();



                            foreach (var juego in Carrito)
                             {
                                 FProy.BD.Game g = db.Juegos.SingleOrDefault(i => i.idjuego == juego.idjuego);
                                 

                                 db.Facturas.Add(fact);
                                 db.SaveChanges();
                                 dbtrans.Commit();


                             }
                        }
                        catch
                        {
                            dbtrans.Rollback();
                            MessageBox.Show("Transaction Error, unable to generate invoice", "Fatal Error", MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select at least one product and a Sales Person", "Data Error",
                        MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}
