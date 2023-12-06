using BDS.Insurance.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDS.Insurance.Core.DBContexti
{
    public class DbBds:DbContext
    {
        public DbBds(DbContextOptions<DbBds>ops):base(ops) { }
        public DbSet<User> Users { get; set; }

    }
}
