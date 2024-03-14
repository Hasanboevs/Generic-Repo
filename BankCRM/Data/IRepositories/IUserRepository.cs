using BankCRM.Domain.Entities;
using System.Collections.Generic;

namespace BankCRM.Data.IRepositories
{
    public interface IUserRepository
    {
        public Task<User> InsertAsync(User user);
        public Task<User> UpdateAsync(User user);
        public Task<bool> DeleteAsync(long id);
        public User SelectByIdAsync(long id);
        public Task<IEnumerable<User>> SelectAllAsync();
    }
}
