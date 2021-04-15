using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Contracts;
using BookStoreAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Create(Author entity)
        {
            await _dbContext.AddAsync(entity);
            return await Save();
        }

        public async Task<IList<Author>> RetrieveAll()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<Author> Retrieve(int id)
        {
            return await _dbContext.Authors.FindAsync(id);
        }

        public async Task<bool> Update(Author entity)
        {
            _dbContext.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(Author entity)
        {
            _dbContext.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var changes = await _dbContext.SaveChangesAsync();
            return changes > 0;
        }
    }
}