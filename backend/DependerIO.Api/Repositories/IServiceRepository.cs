using System.Collections.Generic;
using System.Threading.Tasks;
using DependerIO.Api.Models;

namespace DependerIO.Api.Repositories {
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
    }
}