using Contract.Request.Books;
using Contract.Response.Books;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using static Contract.Response.Authors.SearchAuthorsResponse;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/books")]
    public class BooksController : BaseController
    {
        private readonly BookOperations bookOperations;
        public BooksController(BookOperations bookOperations)
        {
            this.bookOperations = bookOperations;
        }

        [HttpGet]
        public ActionResult<SearchBooksResponse> Search([FromQuery] SearchBooksRequest request)
        {
            var books = bookOperations.Search(request.name, request.pageCount, request.isbn, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchBooksResponse response = new SearchBooksResponse();

            foreach (var book in books)
            {
                response.books.Add(new SearchBooksResponse.Books()
                {
                    id = book.Id,
                    name = book.Name,
                    pageCount = book.PageCount,
                    isbn = book.Isbn,
                    CreatedOn = book.CreatedOn,
                    UpdatedOn = book.UpdatedOn,
                    status = (int)book.Status
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleBookResponse> GetSingle(int id)
        {
            var book = bookOperations.GetSingle(id);
            GetSingleBookResponse response = new GetSingleBookResponse();

            response.id = book.Id;
            response.name = book.Name;
            response.isbn = book.Isbn;
            response.pageCount = book.PageCount;
            response.UpdatedOn = book.UpdatedOn;
            response.CreatedOn = book.CreatedOn;
            response.status = (int)book.Status;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateBookRequest request)
        {
            ValidateRequest<CreateBookRequest, CreateBookRequestValidator>(request);

            bookOperations.Create(request.name, request.pageCount, request.isbn, request.status);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateBookRequest request)
        {
            ValidateRequest<UpdateBookRequest, UpdateBookRequestValidator>(request);
            bookOperations.Update(id, request.name, request.pageCount, request.isbn, request.status);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bookOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            bookOperations.Activated(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            bookOperations.Deactivated(id);
        }
    }
}
