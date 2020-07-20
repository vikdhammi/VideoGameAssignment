using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GameAssignment.Models;

namespace GameAssignment.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") {}

        public DbSet<Game> Games { get; set; }
    }
}