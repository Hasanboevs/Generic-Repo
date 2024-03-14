using BankCRM.Data.IRepositories;
using BankCRM.Domain.Configurations;
using BankCRM.Domain.Entities;

namespace BankCRM.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string path = DatabasePath.Path;
        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> InsertAsync(User user)
        {
            string str = $"{user.Id} | {user.FirstName} | {user.LastName} | {user.Email} | {user.Password} | {user.CreatedAt}\n";
            await File.AppendAllTextAsync(path, str);
            return user;
        }

        public Task<IEnumerable<User>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }

        public User SelectByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
