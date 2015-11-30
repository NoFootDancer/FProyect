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
       public DateTime Fecha { get; set; }
       public int idStore { get; set; }
       public string datos { get; set; }

       

       public virtual ICollection<Game> Juegos { get; set; }
    }
}
