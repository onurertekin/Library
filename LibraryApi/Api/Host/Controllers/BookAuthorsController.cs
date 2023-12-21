using Contract.Request.BookAuthors;
using Contract.Response.BooksAuthors;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/books/{bookId}")]
    public class BookAuthorsController : ControllerBase
    {
        private readonly BookAuthorsOperations bookAuthorsOperations;
        public BookAuthorsController(BookAuthorsOperations bookAuthorsOperations)
        {
            this.bookAuthorsOperations = bookAuthorsOperations;
        }

        [HttpGet]
        [Route("authors")]
        public ActionResult<GetBookAuthorsResponse> GetBookAuthors([FromRoute] int bookId)
        {
            var authors = bookAuthorsOperations.GetBookAuthor(bookId);
            GetBookAuthorsResponse response = new GetBookAuthorsResponse();

            foreach (var author in authors)
            {
                response.bookAuthors.Add(new GetBookAuthorsResponse.BookAuthors()
                {
                    id = author.Id,
                    name = author.Name,
                });
            }

            return new JsonResult(response);
        }

        [HttpPut]
        [Route("authors")]
        public void Update(int bookId, [FromBody] BookAuthorsUpdateRequest request)
        {
            bookAuthorsOperations.Update(bookId, request.authors);
        }
    }
}
