using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
  public  class Store
    { [Key]
      public int idstore { get; set; }
      public string nameS { get; set; }

      internal void Show()
      {
          throw new NotImplementedException();
      }

    }
}
