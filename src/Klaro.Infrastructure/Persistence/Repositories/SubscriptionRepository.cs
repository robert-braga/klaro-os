using Klaro.Application.Common.Interfaces;
using Klaro.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Infrastructure.Persistence.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly KlaroDbContext _context;

        public SubscriptionRepository(KlaroDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
        }

        public Task DeleteAsync(Subscription subscription)
        {
            _context.Subscriptions.Remove(subscription);
            return Task.CompletedTask;
        }

        public async Task<List<Subscription>> GetAllByUserIdAsync(Guid id)
        {
            return await _context.Subscriptions
                                 .Where(x => x.UserId == id)
                                 .ToListAsync();
        }

        /// <summary>
        /// Search the entity with the primary key equal with the given id
        /// </summary>
        /// <param name="id">Subscription ID to search by</param>
        /// <returns></returns>
        public async Task<Subscription?> GetByIdAsync(Guid id)
        {
            return await _context.Subscriptions.FindAsync(id); 
        }

        public Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription); //EF Core already follows the entity, so it will modify it
            return Task.CompletedTask;
        }
    }
}
