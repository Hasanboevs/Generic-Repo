using Educative.Data.IRepositories;
using Educative.Domain.Commons;
using Educative.Domain.Configurations;
using Educative.Domain.Entities;
using Newtonsoft.Json;
using OpenQA.Selenium;

namespace Educative.Data.Repositories
{
    public class Repsoitory<entity> : IRepository<entity> where entity : Auditable
    {
        private readonly string Path;

        public Repsoitory()
        {
            if (typeof(entity) == typeof(Student))
            {
                Path = DatabasePath.StudentDb;
            }

            Path = DatabasePath.SubjectDb;

            var str = File.ReadAllText(Path);
            if (string.IsNullOrEmpty(str))
                File.WriteAllText(Path, "[]");
        }


        public async Task<entity> Add(entity model)
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<entity>>(str);
            entities.Add(model);
            string result = JsonConvert.SerializeObject(entities, Formatting.Indented);

            await File.WriteAllTextAsync(Path, result);

            return model;
        }

        public async Task<bool> Delete(long id)
        {
            
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<entity>>(str);
            entity st = entities.FirstOrDefault(x => x.Id == id);
            string result = JsonConvert.SerializeObject(entities, Formatting.Indented);
            entities.Remove(st);
            await File.WriteAllTextAsync(Path, result);

            return true;
        }

        public async Task<IEnumerable<entity>> GetAll()
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<entity>>(str);
            return entities;
        }

        public async Task<entity> GetByIdAsync(long id)
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<entity>>(str);

            return entities.FirstOrDefault(x => x.Id == id);

        }

        public async Task<entity> Update(entity model)
        {
            var str = await File.ReadAllTextAsync(Path);
            var entities = JsonConvert.DeserializeObject<List<entity>>(str);

            // Find the index of the entity to update
            var indexToUpdate = entities.FindIndex(x => x.Id == model.Id);
            if (indexToUpdate == -1)
            {
                throw new NotFoundException("Entity not found");
            }

            entities[indexToUpdate] = model;

            string result = JsonConvert.SerializeObject(entities, Formatting.Indented);
            await File.WriteAllTextAsync(Path, result);

            return model;
        }

    }
}
