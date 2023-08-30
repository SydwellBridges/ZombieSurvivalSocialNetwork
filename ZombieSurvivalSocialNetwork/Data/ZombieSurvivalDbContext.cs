using Microsoft.EntityFrameworkCore;
using ZombieSurvivalSocialNetwork.Models;

namespace ZombieSurvivalSocialNetwork.Data
{
    /// <summary>
    /// Represents the database context for the Zombie Survival API.
    /// </summary>
    public class ZombieSurvivalDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the DbSet of survivors.
        /// </summary>
        public DbSet<Survivor> Survivors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZombieSurvivalDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public ZombieSurvivalDbContext(DbContextOptions<ZombieSurvivalDbContext> options)
            : base(options)
        {
        }
    }
}

