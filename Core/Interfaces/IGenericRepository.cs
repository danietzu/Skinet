using Core.Entities;
using Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> GetEntityWithSpecification(ISpecification<T> specification);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

        Task<int> CountAsync(ISpecification<T> specification);
    }
}