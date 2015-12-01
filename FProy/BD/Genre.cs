using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FProy.BD
{
    public class Genre
    {
        [Key]
        public string codgen { get; set; }
        public string nameg { get; set; }

        internal void Show()
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<Game> Games { get; set; }
    }
}
