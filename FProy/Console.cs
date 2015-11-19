using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FProy.BD
{
   public class Console
    {
        [Key]
        public string codcons { get; set; }
        public string namecons { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
