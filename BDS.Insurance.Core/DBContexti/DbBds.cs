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
        public DbSet<Car> Cars { get; set; }
        public DbSet<Policy> Policys { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<_2StepVerification> _2StepVerification { get; set; }
        public DbSet<PolicySchedule> PolicySchedules { get; set; }

    }
}
