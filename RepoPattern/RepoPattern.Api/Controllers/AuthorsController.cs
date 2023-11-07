using Microsoft.AspNetCore.Mvc;
using RepoPattern.Core.Domains;
using RepoPattern.Core.Repositories;

namespace RepoPattern.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _repository;

        public AuthorsController(IBaseRepository<Author> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll(new[] { "Books" });
            //var result = _repository.GetAll(new[] {"Author")} );
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _repository.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var result = _repository.Where(x => x.Name.Contains(name)).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            _repository.Create(author);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(Author author)
        {
            _repository.Update(author);
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
