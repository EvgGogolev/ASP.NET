using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Customer> _dbSetCustomer;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSetCustomer = _context.Set<Customer>();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken httpContextRequestAborted = default)
        {
            return await _dbSetCustomer
                .Where(c => c.Id == id)
                .Include(c => c.CustomerPreferences)
                .ThenInclude(cp => cp.Preference)
                .FirstOrDefaultAsync(httpContextRequestAborted);
        }

        public async Task CreateCustomersAsync(Customer customer, CancellationToken httpContextRequestAborted = default)
        {
            if (customer.CustomerPreferences != null)
            {
                foreach (var customerPreference in customer.CustomerPreferences)
                {

                    _context.CustomerPreferences.Add(customerPreference);
                }
            }

            await _dbSetCustomer.AddAsync(customer, httpContextRequestAborted);
            await _context.SaveChangesAsync(httpContextRequestAborted);
        }

        public async Task DeleteCustomerAsync(Guid id, CancellationToken httpContextRequestAborted = default)
        {
            var customer = await GetCustomerByIdAsync(id, httpContextRequestAborted);

            // Удаляем связанные CustomerPreference записи
            _context.CustomerPreferences.RemoveRange(customer.CustomerPreferences);
            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(httpContextRequestAborted);
        }

        public async Task<List<Preference>> GetPreferenceByNamesAsync(List<string> names,
            CancellationToken httpContextRequestAborted = default)
        {

            return await _context.Preferences
                .Where(x => names.Contains(x.Name))
                .Distinct()
                .ToListAsync(httpContextRequestAborted);
        }

        public async Task UpdatePrefernceInCustomerAsync(Customer customer,
            CancellationToken httpContextRequestAborted = default)
        {

            var existingCustomer = GetCustomerByIdAsync(customer.Id, httpContextRequestAborted).Result;

            var newPrefences = customer.CustomerPreferences.Select(x => x.Preference).ToList();

            await _context.CustomerPreferences.Where(x => x.CustomerId == customer.Id)
                .ForEachAsync(x => _context.CustomerPreferences.Remove(x), httpContextRequestAborted);

            await _context.SaveChangesAsync(httpContextRequestAborted);

        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken httpContextRequestAborted)
        {
            return await _dbSetCustomer.ToListAsync(httpContextRequestAborted);
        }
    }
}

    
