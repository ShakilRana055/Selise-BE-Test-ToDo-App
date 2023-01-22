using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppDomain.Model;

namespace OnsiteDataAccess.AppDataContest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
