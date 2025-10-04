using Klaro.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Application.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(Guid id);
        Task<List<Subscription>> GetAllByUserIdAsync(Guid id);
        Task AddAsync(Subscription subscription);
        Task UpdateAsync(Subscription subscription);
        Task DeleteAsync(Subscription subscription);
    }
}
