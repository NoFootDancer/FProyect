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
    /// Lógica de interacción para CAPGenero.xaml
    /// </summary>
    public partial class CAPGenero : Window
    {
        public CAPGenero()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db = new FProy.BD.MiBd();
            FProy.BD.Genre gen = new FProy.BD.Genre();

            if (tx1.Text.Length > 3)
            {
                MessageBox.Show("El codigo de la consola solo requiere 3 caracteres. Vuelva a intentarlo");
            }//Validar longitud
            else
            {

                if (Regex.IsMatch(tx1.Text, "[a-zA-Z]") && Regex.IsMatch(tx2.Text, "[a-zA-Z0-9]+$"))
                {

                    gen.codgen = tx1.Text;
                    gen.nameg = tx2.Text;

                    db.Generos.Add(gen);
                    db.SaveChanges();


                    MessageBox.Show("Captura Realizada correctamente");


                }
                else { MessageBox.Show("No se admiten numeros o caracteres especiales"); }//Validar texto

            }



        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            EDIGenero vent=new EDIGenero();
            vent.Show();
            this.Close();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            BORGenero vent1 = new BORGenero();
            vent1.Show();
            this.Close();
        }
    }
}
