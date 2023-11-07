using RepoPattern.Core.Domains;
using RepoPattern.Core.Repositories;

namespace RepoPattern.EF.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Set<Book>();
        }
    }
}
