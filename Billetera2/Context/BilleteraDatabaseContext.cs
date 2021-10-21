using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billetera2.Models;

namespace Billetera2.Context
{
    public class BilleteraDatabaseContext : DbContext
    {
        public
       BilleteraDatabaseContext(DbContextOptions<BilleteraDatabaseContext> options)
       : base(options)
        {

        }
        public DbSet<Ingreso> Ingresos { get; set; }
    }

}
