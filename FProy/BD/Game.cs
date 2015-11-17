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
      public int idjuego { get; set; }
      public string namej { get; set; }
      public float precio { get; set; }
      public string rdate { get; set; }
      public string codcomp { get; set; }
      public string codcons { get; set; }
      public string codgen { get; set; }


    }
}
