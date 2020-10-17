using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _socialMediaContext;
        private readonly DbSet<T> _entities;
        public BaseRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
            _entities = _socialMediaContext.Set<T>();
        }

        public async Task Add(T obj)
        {
            _entities.Add(obj);
            await _socialMediaContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var obj = await GetById(id);
            _entities.Remove(obj);
            await _socialMediaContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Update(T obj)
        {
            _entities.Update(obj);
            await _socialMediaContext.SaveChangesAsync(); 
        }
    }
}
