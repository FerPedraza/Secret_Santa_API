using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecretSanta.Infrastructure.Entities
{
    public class BDContext : DbContext
    {

        //No database context is needed, data persistence is not required
        public BDContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }


    }
}
