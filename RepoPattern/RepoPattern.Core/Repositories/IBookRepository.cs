using RepoPattern.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Core.Repositories
{
    public interface IBookRepository : IBaseRepository<Book> 
    {
        IEnumerable<Book> GetAllBooks();
    }
}
