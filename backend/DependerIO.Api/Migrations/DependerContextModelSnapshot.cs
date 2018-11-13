﻿// <auto-generated />
using System;
using DependerIO.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DependerIO.Api.Migrations
{
    [DbContext(typeof(DependerContext))]
    partial class DependerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", "'uuid-ossp', '', ''")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("DependerIO.Api.Models.Handler", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<Guid>("ServiceId");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("Idx_Handler_Name");

                    b.HasIndex("ServiceId");

                    b.ToTable("Handlers");

                    b.HasData(
                        new { Id = new Guid("cfa2fe87-c9fe-4e2c-9390-578354256735"), Name = "Webhook", ServiceId = new Guid("a33b9430-6dd1-404c-80e6-fd2e5e275cff") },
                        new { Id = new Guid("cf9fe886-95b2-44de-b880-6d30f1c9a881"), Name = "Webhook", ServiceId = new Guid("f346408d-fad1-4689-a21b-a62435482620") },
                        new { Id = new Guid("f4dad83c-69c5-4507-81db-bfcc998e5dae"), Name = "Webhook", ServiceId = new Guid("8aee5013-25fe-4d2c-b720-efbe83b33b5b") }
                    );
                });

            modelBuilder.Entity("DependerIO.Api.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasName("Idx_Service_Name");

                    b.ToTable("Services");

                    b.HasData(
                        new { Id = new Guid("a33b9430-6dd1-404c-80e6-fd2e5e275cff"), Description = "Stripe eCommerce service", Name = "Stripe" },
                        new { Id = new Guid("f346408d-fad1-4689-a21b-a62435482620"), Description = "Intercom customer relationship management service", Name = "Intercom" },
                        new { Id = new Guid("8aee5013-25fe-4d2c-b720-efbe83b33b5b"), Description = "Mixpan analytics service", Name = "Mixpanel" }
                    );
                });

            modelBuilder.Entity("DependerIO.Api.Models.Handler", b =>
                {
                    b.HasOne("DependerIO.Api.Models.Service", "Service")
                        .WithMany("Handlers")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
