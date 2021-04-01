using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyCityAPI.Models;

namespace MyCityAPI.Data
{
    public class MyCityContext:DbContext
    {

        public MyCityContext( DbContextOptions<MyCityContext> opt ) : base(opt)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

    }
}
