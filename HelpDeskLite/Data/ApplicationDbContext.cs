using HelpDeskLite.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskLite.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Ticket> Tickets => Set<Ticket>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ticket>()
            .Property(ticket => ticket.RowVersion)
            .IsRowVersion();

        modelBuilder.Entity<Ticket>()
            .HasIndex(ticket => ticket.Status);

        modelBuilder.Entity<Ticket>()
            .HasIndex(ticket => ticket.Priority);

        modelBuilder.Entity<Ticket>()
            .HasIndex(ticket => ticket.CreatedAt);
    }
}
