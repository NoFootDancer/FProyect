using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
   public class Company
    {

       [Key]
       public string codcomp { get; set; }
       public string namec { get; set; }
   }


}
