using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface ICosmosRepository
    {
        Task AddAuthorsAsync();
        Task<ICollection<Author>> GetAuthorsAsync();
    }
}