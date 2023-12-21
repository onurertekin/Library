using Contract.Request.LibraryApi.BookCategory;
using Contract.Response.LibraryApi.BookAuthor;
using Contract.Response.LibraryApi.BookCategory;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.LibraryApi.BookCategory
{
    [ApiController]
    [Route("library-api/books/{bookId}")]
    public class BookCategoriesController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public BookCategoriesController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
        }


        [HttpGet]
        [Route("categories")]
        [Authorizable("BookCategories_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetBookCategoriesResponse>> GetBookCategories([FromRoute] int bookId)
        {
            GetBookCategoriesResponse response = new GetBookCategoriesResponse();
            response = await httpHelper.Get<GetBookCategoriesResponse>($"{libraryApiUrl}/library-api/books/{bookId}/categories");
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("categories")]
        [Authorizable("BookCategories_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int bookId, [FromBody] BookCategoriesUpdateRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/books/{bookId}/categories", request);
        }

    }
}
