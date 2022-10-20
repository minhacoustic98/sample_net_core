using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class NortwindDbContextFactory : DesginTimeDbContextFactoryBase<NortwindDbContext>
    {
        protected override NortwindDbContext CreateNewInstance(DbContextOptions<NortwindDbContext> options)
        {
            return new NortwindDbContext(options);
        }
    }
}
