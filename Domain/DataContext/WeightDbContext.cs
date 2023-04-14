using Domain.DomainClasses;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DataContext
{
    public class WeightDbContext : IdentityDbContext
    {
        // define the DbSet
        public DbSet<WeightHistory> WeightHistory { get; set; }
        //public DbSet<User> Users { get; set; }
        public WeightDbContext
            (DbContextOptions<WeightDbContext> options) : base(options)
        {
        }

    }
}
