using RepoPattern.Core.Domains;
using RepoPattern.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.EF.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<Author> Authors { get; private set; }
        public IBookRepository Books { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Authors = new BaseRepository<Author>(_context);
            Books = new BookRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
