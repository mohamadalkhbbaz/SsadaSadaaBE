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
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _unitOfWork.Books.GetAll(take: 1);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var result = _unitOfWork.Books.GetById(id);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetByTitle(string title)
        {
            var result = _unitOfWork.Books.Where(x => x.Title.Contains(title)).ToList();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _unitOfWork.Books.Create(book);
            return Ok();
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            _unitOfWork.Books.Update(book);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Books.Delete(id);
            return Ok();
        }


    }
}
