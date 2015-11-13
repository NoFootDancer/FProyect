using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProy.BD
{
   public class MiBd: DbContext{

       public DbSet<Game> Game {get; set;}




    }
}
