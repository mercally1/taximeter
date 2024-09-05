using Microsoft.EntityFrameworkCore;
using taximeter.Entity;

namespace taximeter.Data;

public class TaximeterDbContext : DbContext
{
    public TaximeterDbContext(DbContextOptions<TaximeterDbContext> options) : base(options) 
    { 

    }

    public DbSet<Conductor> Conductores { get; set; }

    public DbSet<Taxi> Taxis { get; set; }

    public DbSet<Trayecto> Trayectos { get; set; }
}

