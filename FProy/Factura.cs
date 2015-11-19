using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
   public class Factura
    {
       [Key]
       public int idFolio { get; set; }
       public string Fecha { get; set; }
       public int idStore { get; set; }

    }
}
