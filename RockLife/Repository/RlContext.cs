using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyMysicStore.Classes;
using RockLife.Classes;

namespace RockLife.Repository;

public partial class RlContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public RlContext()
    {
    }

    public RlContext(DbContextOptions<RlContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\dyaro\\Desktop\\Prog\\C#\\Mymrina\\RLdb\\RL");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
