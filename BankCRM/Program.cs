using BankCRM.Data.Repositories;
using System;
using BankCRM.Domain.Entities;
using BankCRM.Data.IRepositories;

namespace BankCRM
{
    public class MyBankCRM
    {
        public static void Main(string[] args)
        {
            IUserRepository repo = new UserRepository();

            repo.InsertAsync(new User()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Test",
                CreatedAt = DateTime.UtcNow
            }
            );
        }
    }
}

