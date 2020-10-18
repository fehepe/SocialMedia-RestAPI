using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _socialMediaContext;
        protected readonly DbSet<T> _entities;
        public BaseRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
            _entities = _socialMediaContext.Set<T>();
        }

        public async Task Add(T obj)
        {
            await _entities.AddAsync(obj);
            
        }

        public async Task Delete(int id)
        {
            var obj = await GetById(id);
            _entities.Remove(obj);
            
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void Update(T obj)
        {
            _entities.Update(obj);
            
        }
    }
}
