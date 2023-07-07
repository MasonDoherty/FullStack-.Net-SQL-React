using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNet_React_ReadyForCode.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection string configuration
        optionsBuilder.UseSqlServer("YourConnectionStringGoesHere");
    }

    public DbSet<DotNet_React_ReadyForCode.Models.SignUp> SignUp { get; set; } = default!;
    }
