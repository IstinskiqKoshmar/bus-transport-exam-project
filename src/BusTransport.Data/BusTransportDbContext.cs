using BusTransport.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTransport.Data;

public class BusTransportDbContext(DbContextOptions<BusTransportDbContext> options) : DbContext(options)
{
    public DbSet<City> Cities => Set<City>();
    public DbSet<Carrier> Carriers => Set<Carrier>();
    public DbSet<Trip> Trips => Set<Trip>();
    public DbSet<Passenger> Passengers => Set<Passenger>();
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Trip>().Property(x => x.Price).HasPrecision(10, 2);
        modelBuilder.Entity<Ticket>().Property(x => x.TotalPrice).HasPrecision(10, 2);
        modelBuilder.Entity<Trip>().HasOne(x => x.DepartureCity).WithMany().HasForeignKey(x => x.DepartureCityId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Trip>().HasOne(x => x.ArrivalCity).WithMany().HasForeignKey(x => x.ArrivalCityId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Trip>().HasOne(x => x.Carrier).WithMany().HasForeignKey(x => x.CarrierId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>().HasOne(x => x.Passenger).WithMany().HasForeignKey(x => x.PassengerId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Ticket>().HasOne(x => x.Trip).WithMany().HasForeignKey(x => x.TripId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<City>().HasIndex(x => x.Code).IsUnique();
        modelBuilder.Entity<Carrier>().HasIndex(x => x.CompanyCode).IsUnique();
        modelBuilder.Entity<Trip>().HasIndex(x => x.TripCode);
        modelBuilder.Entity<Passenger>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<Ticket>().HasIndex(x => x.TicketCode).IsUnique();
        BusTransportSeed.Configure(modelBuilder);
    }
}


