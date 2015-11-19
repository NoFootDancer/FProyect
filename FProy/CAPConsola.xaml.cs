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

            con.codcons = tx1.Text;
            con.namecons = tx2.Text;

            db.Consolas.Add(con);
            db.SaveChanges();
        }
    }
}
