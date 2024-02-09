using Microsoft.EntityFrameworkCore;
using P_DotNetCoreApi_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_DotNetCoreApi_DAL.DBContextF
{
    public class DBContextFiledb : DbContext
    {
        public DBContextFiledb(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TodoMaster> TodoMasters { get; set; }
    }
}
