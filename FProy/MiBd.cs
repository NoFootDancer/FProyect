using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FProy.BD
{
   public class MiBd: DbContext{

       public DbSet<Game> Juegos {get; set;}
       public DbSet<Company> Companias { get; set; }
       public DbSet<Console> Consolas { get; set; }
       public DbSet<Genre> Generos { get; set; }
       public DbSet<Store> Tiendas { get; set; }
       public DbSet<Factura_Game> FacturaJuegos { get; set; }
       public DbSet<Factura> Facturas { get; set; }
   






    }
}
