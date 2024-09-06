using Microsoft.EntityFrameworkCore;

namespace VotingApp.Entities;

public class VotingDbContext : DbContext
{
    public VotingDbContext() : base()
    {

    }
    public VotingDbContext(DbContextOptions<VotingDbContext> options) : base(options)
    {

    }

    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Voter> Voters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidate>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Voter>()
            .Property(v => v.Name)
            .IsRequired();
    }
}
