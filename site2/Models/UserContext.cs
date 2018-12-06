using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace site2.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("platinumTourEntities")
        {

        }

        public DbSet<Registration> Users { get; set; }
    }
}