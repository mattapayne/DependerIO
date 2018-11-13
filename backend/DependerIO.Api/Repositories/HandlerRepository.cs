using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependerIO.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DependerIO.Api.Repositories {
    public class HandlerRepository : IHandlerRepository, IDisposable
    {
        private readonly DependerContext _context;
        private bool disposed = false;

        public HandlerRepository(DependerContext context)
        {
            _context = context;
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

        public async Task<IEnumerable<Handler>> GetAllAsync(Guid serviceId) {
            return await _context.Handlers.Where(h => h.ServiceId == serviceId).Include(h => h.Service).ToListAsync();
        } 
    }
}