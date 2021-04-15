using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Contracts;
using BookStoreAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Create(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            return await Save();
        }

        public async Task<IList<Book>> RetrieveAll()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> Retrieve(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<bool> Update(Book entity)
        {
            _dbContext.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(Book entity)
        {
            _dbContext.Remove(entity);
            return await Save();
        }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}