using Contract.Request.BookCategories;
using Contract.Response.BookCategories;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/books/{bookId}")]
    public class BookCategoriesController : ControllerBase
    {
        private readonly BookCategoriesOperations bookCategoriesOperations;
        public BookCategoriesController(BookCategoriesOperations bookCategoriesOperations)
        {
            this.bookCategoriesOperations = bookCategoriesOperations;
        }


        [HttpGet]
        [Route("categories")]
        public ActionResult<GetBookCategoriesResponse> GetBookCategories([FromRoute] int bookId)
        {
            var categories = bookCategoriesOperations.GetBookCategories(bookId);
            GetBookCategoriesResponse response = new GetBookCategoriesResponse();

            foreach (var category in categories)
            {
                response.bookCategories.Add(new GetBookCategoriesResponse.BookCategories()
                {
                    id = category.Id,
                    name = category.Name,
                });
            }
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("categories")]
        public void Update(int bookId, [FromBody] BookCategoriesUpdateRequest request)
        {
            bookCategoriesOperations.Update(bookId, request.categories);
        }

    }
}
