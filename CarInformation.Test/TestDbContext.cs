using CarInformation.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInformation.Test
{
    public class TestDbContext : CompanyDbContext
    {
        public TestDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }
    }
}
