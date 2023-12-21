using Contract.Request.LibraryApi.BookAuthor;
using Contract.Response.GeekYaparApi.Categories;
using Contract.Response.IAM.UsersRoles;
using Contract.Response.LibraryApi.BookAuthor;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contract.Response.Users.SearchUsersResponse;

namespace Host.Controllers.v1.LibraryApi.BookAuthor
{
    [ApiController]
    [Route("library-api/books/{bookId}")]
    public class BookAuthorsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public BookAuthorsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
        }

        [HttpGet]
        [Route("authors")]
        [Authorizable("BookAuthors_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetBookAuthorsResponse>> GetBookAuthors([FromRoute] int bookId)
        {
            GetBookAuthorsResponse response = new GetBookAuthorsResponse();
            response = await httpHelper.Get<GetBookAuthorsResponse>($"{libraryApiUrl}/library-api/books/{bookId}/authors");
            return new JsonResult(response);
        }

        [HttpPut]
        [Route("authors")]
        [Authorizable("BookAuthors_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int bookId, [FromBody] BookAuthorsUpdateRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/books/{bookId}/authors", request);
        }
    }
}
