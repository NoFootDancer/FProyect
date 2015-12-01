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
using FProy.BD;

namespace FProy
{
    /// <summary>
    /// Lógica de interacción para Compra.xaml
    /// </summary>
    public partial class Compra : Window
    {
        private FProy.BD.Game tmpG = null;
        private List<Game> Carrito;
        public Compra()
        {
            InitializeComponent();
            Carrito = new List<Game>();
        }

        private void dg_Loaded(object sender, RoutedEventArgs e)
        {
            MiBd db = new  MiBd();
            Store st = new Store();
            Game gm = new  Game();

           

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
            MiBd db = new MiBd();

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
            MiBd db = new MiBd();
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

        private void borrar() {
            Carrito = new List<FProy.BD.Game>();
            tx1.Text = string.Empty;
            tx2.Text = string.Empty;
            tx3.Text = string.Empty;

            cb1.SelectedIndex = 0;
            cb2.SelectedIndex = 0;

            dg.ItemsSource = null;
            dg.Items.Refresh();
            tmpG = null;
        
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void com_Click(object sender, RoutedEventArgs e)
        {
            //Asegurarse de que el carro tenga por lo menos un juego
            if (Carrito.Count > 0 && cb2.SelectedIndex > -1)
            {
                using (FProy.BD.MiBd db = new FProy.BD.MiBd()) {
                    using (var trans = db.Database.BeginTransaction()) {
                        try
                        {
                            //Objeto de factura
                            FProy.BD.Factura fact = new FProy.BD.Factura();
                            FProy.BD.Game gm = new FProy.BD.Game();
                            fact.Fecha = DateTime.Now;
                            fact.idStore = (int)cb2.SelectedValue;
                            fact.datos = Convert.ToString("Juego: " + cb1.SelectedValue + " Para consola: " + tx1.Text + " Del genero: " + tx2.Text + "Precio: " + tx3.Text);
                           
                            
                            
                            foreach (var juego in Carrito)
                            {
                                //FProy.BD.Game Gg = db.Juegos.SingleOrDefault(s => s.idjuego == juego.idjuego);
                                Game g = db.Juegos.SingleOrDefault(s => s.idjuego == juego.idjuego);
                                fact.Juegos.Add(g);
                            }

                            db.Facturas.Add(fact);
                            db.SaveChanges();
                            trans.Commit();
                            MessageBox.Show(string.Format("Transaction #{0}  completada", fact.idFolio), "exitosamente", MessageBoxButton.OK,
                                MessageBoxImage.Information);

                        }//try
                        catch {


                            //if an error is produced, we rollback everything
                            trans.Rollback();
                            //We notify the user of the error
                            MessageBox.Show("Error de compra, imposible procesar compra", "Error Fatal", MessageBoxButton.OK,
                                MessageBoxImage.Error);
                        
                        }
                         
                    
                    
                                }//Crear transacción

                                }//Crear enlace a bd
            }//Contador de items en carro

           
        }

        private void emp_Click(object sender, RoutedEventArgs e)
        {
            borrar();
        }
    }
}
