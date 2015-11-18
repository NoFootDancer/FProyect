using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
    public class Factura_Game
    {
        [Key]
        public int idFolioJ { get; set; }
        public int idFolio { get; set; }
        public int idjuego { get; set; }


    }
}
