﻿using Microsoft.EntityFrameworkCore;
using API_Usage.Models;

namespace API_Usage.DataAccess
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Equity> Equities { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<Crypto> Cryptos { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<News> TNews { get; set; }
    }
}