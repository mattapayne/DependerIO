using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependerIO.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DependerIO.Api.Repositories {
    public class ServiceRepository : IServiceRepository, IDisposable
    {
        private readonly DependerContext _context;
        private bool disposed = false;

        public ServiceRepository(DependerContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync() {
            return await _context.Services.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}