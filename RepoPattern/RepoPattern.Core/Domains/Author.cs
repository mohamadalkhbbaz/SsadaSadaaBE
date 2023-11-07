using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Core.Domains
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book>? Books { get; set; }
    }
}
