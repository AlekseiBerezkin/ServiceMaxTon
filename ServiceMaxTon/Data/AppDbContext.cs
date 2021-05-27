using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using ServiceMaxTon.Model.DataBase;

namespace ServiceMaxTon.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<CompletedWork> CompletedWork { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Material> Material { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=MaxtonDb.db");
        }
    }
}
