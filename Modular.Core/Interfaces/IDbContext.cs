﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Modular.Core.Entities;

namespace Modular.Core.Interfaces
{
    public interface IDbContext : IDisposable
    {

        public DbSet<AuditEntry> AuditEntries { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public DbSet<Configuration> Configurations { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Country> Countries { get; set; }



        public int SaveChanges();

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

    }
}