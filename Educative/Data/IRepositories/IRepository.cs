using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Educative.Data.IRepositories
{
    public interface IRepository<entity>
    {
        public Task<entity> GetByIdAsync(long id);
        public Task<IEnumerable<entity>> GetAll();
        public Task<entity> Add(entity model);
        public Task<entity> Update(entity model);
        public Task<bool> Delete(long id);
    }
}
