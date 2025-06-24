using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Model
{
    public class MedicoContext: DbContext
    {
        public MedicoContext(DbContextOptions<MedicoContext> options) : base(options)
        {

        }
        public DbSet<Login> login { get; set; }
        public DbSet<Items> items { get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<Orderhistory> orderhistory { get; set; }
        //Items Cartitem
        public class Login
        {
            [Key]
            public int userid { get; set; }

            public string username { get; set; }

            public string password { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
        }
    }
}
