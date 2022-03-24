using CharacterMatch.Server.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharacterMatch.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CharacterTrait>()
                .HasKey(c => new { c.CharacterId, c.TraitId });
        }

        public DbSet<Series> Series { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<CharacterTrait> CharacterTraits { get; set; }
    }
}
