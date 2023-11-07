using Microsoft.AspNetCore.Mvc;
using RepoPattern.Core.Domains;
using RepoPattern.Core.Repositories;
using System.Linq.Expressions;

namespace RepoPattern.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _repository;

        public BooksController(IBaseRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll(take:1);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _repository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByTitle(string title)
        {
            var result = _repository.Where(x => x.Title.Contains(title)).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _repository.Create(book);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            _repository.Update(book);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }


    }
}
