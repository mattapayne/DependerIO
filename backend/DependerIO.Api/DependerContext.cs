using System;
using DependerIO.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DependerIO.Api {
    public class DependerContext : DbContext
    {        
        public DependerContext(DbContextOptions<DependerContext> context) : base(context) { }

        public DbSet<Service> Services { get; set; }
        public DbSet<Handler> Handlers {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            var stripeId = Guid.NewGuid();
            var intercomId = Guid.NewGuid();
            var mixpanelId = Guid.NewGuid();

            modelBuilder.Entity<Service>().Property(s => s.Id).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Service>().HasIndex(s => s.Name).HasName("Idx_Service_Name");
            modelBuilder.Entity<Service>().HasData(new Service { Id = stripeId, Name = "Stripe", Description = "Stripe eCommerce service" });
            modelBuilder.Entity<Service>().HasData(new Service { Id = intercomId, Name = "Intercom", Description = "Intercom customer relationship management service" });
            modelBuilder.Entity<Service>().HasData(new Service { Id = mixpanelId, Name = "Mixpanel", Description = "Mixpan analytics service" });
            modelBuilder.Entity<Service>().HasMany(s => s.Handlers);

            modelBuilder.Entity<Handler>().Property(h => h.Id).HasDefaultValueSql("uuid_generate_v4()");
            modelBuilder.Entity<Handler>().HasIndex(h => h.Name).HasName("Idx_Handler_Name");
            modelBuilder.Entity<Handler>().HasOne(h => h.Service);

            modelBuilder.Entity<Handler>().HasData(new Handler { Id = Guid.NewGuid(), Name = "Webhook", ServiceId = stripeId });
            modelBuilder.Entity<Handler>().HasData(new Handler { Id = Guid.NewGuid(), Name = "Webhook", ServiceId = intercomId });
            modelBuilder.Entity<Handler>().HasData(new Handler { Id = Guid.NewGuid(), Name = "Webhook", ServiceId = mixpanelId });
        }
    }
}