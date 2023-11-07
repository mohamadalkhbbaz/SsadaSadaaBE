using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPattern.Core.Domains
{
    public class Book
    {
        public int ID { get; set; }
        public string Title  { get; set; }
        public int AuthorID { get; set; }
        public Author? Author { get; set; }
    }
}
