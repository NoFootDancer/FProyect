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
    /// Lógica de interacción para CAPConsola.xaml
    /// </summary>
    public partial class CAPConsola : Window
    {
        public CAPConsola()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            FProy.BD.MiBd db=new FProy.BD.MiBd();
            FProy.BD.Console con=new FProy.BD.Console();


            if (tx1.Text.Length > 3)
            {
                MessageBox.Show("El codigo de la consola solo requiere 3 caracteres. Vuelva a intentarlo");
            }//Validar longitud
            else {

                if (Regex.IsMatch(tx1.Text, "[a-zA-Z]"))
                {

                    con.codcons = tx1.Text;
                    con.namecons = tx2.Text;

                    db.Consolas.Add(con);
                    db.SaveChanges();

                    MessageBox.Show("Captura Realizada correctamente");


                }
                else { MessageBox.Show("No se admiten numeros o caracteres especiales"); }//Validar texto
            
            }
           
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            EDIConsola vent = new EDIConsola();
            vent.Show();
            this.Close();

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            BORConsola vent1 = new BORConsola();
            vent1.Show();
            this.Close();
        }
    }
}
