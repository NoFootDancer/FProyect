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

    }
}
