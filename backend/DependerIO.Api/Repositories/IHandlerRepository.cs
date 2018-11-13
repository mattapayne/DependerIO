using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DependerIO.Api.Models;

namespace DependerIO.Api.Repositories {
    public interface IHandlerRepository
    {
        Task<IEnumerable<Handler>>  GetAllAsync(Guid serviceId);
    }
}