using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelUI
{
    public class Context : DbContext
    {
        public DbSet<Characters> Characters { get; set; }
        public Context() : base("name=CodeFirstCS")
        {

        }

    }
}
