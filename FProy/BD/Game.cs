using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
  public class Game
    {
      [Key]
      public int idjuego  { get; set; }
      public string namej { get; set; }
      public float  precio{ get; set; }
      public DateTime? rdate { get; set; }
      public virtual string codcomp { get; set; }
      public virtual string codcons { get; set; }
      //public virtual ICollection<Console> Consolas { get; set; }
      public virtual string codgen  { get; set; }
      public virtual ICollection<Factura> Facturas { get; set; }


      

      internal void Show()
      {
          throw new NotImplementedException();
      }



    }
}
