using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetBatch14HWH.WebApp1.Model;

namespace DotNetBatch14HWH.WebApp1.Data
{
    public class DotNetBatch14HWHWebApp1Context : DbContext
    {
        public DotNetBatch14HWHWebApp1Context (DbContextOptions<DotNetBatch14HWHWebApp1Context> options)
            : base(options)
        {
        }

        public DbSet<DotNetBatch14HWH.WebApp1.Model.User> User { get; set; } = default!;
    }
}
