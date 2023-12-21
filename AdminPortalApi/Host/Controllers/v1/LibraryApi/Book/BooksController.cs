using Contract.Request.LibraryApi.Book;
using Contract.Response.GeekYaparApi.Categories;
using Contract.Response.LibraryApi.Book;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.LibraryApi.Book
{
    [ApiController]
    [Route("library-api/books")]
    public class BooksController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;

        public BooksController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        [Authorizable("Books_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchBooksResponse>> Search([FromQuery] SearchBooksRequest request)
        {
            SearchBooksResponse response = new SearchBooksResponse();
            string url = ($"{libraryApiUrl}/library-api/books?name={request.name}&pageCount={request.pageCount}&isbn={request.isbn}&status={request.status}&createdOn={request.CreatedOn}&updatedOn={request.UpdatedOn}&pageNumber={request.pageNumber}&pageSize={request.pageSize}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchBooksResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Books_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleBookResponse>> GetSingle(int id)
        {
            GetSingleBookResponse response = new GetSingleBookResponse();
            string url = ($"{libraryApiUrl}/library-api/books/{id}");
            response = await httpHelper.Get<GetSingleBookResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Books_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateBookRequest request)
        {
            await httpHelper.Create($"{libraryApiUrl}/library-api/books", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Books_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateBookRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/books/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Books_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {

            await httpHelper.Delete($"{libraryApiUrl}/library-api/books/{id}");
        }

        [Authorizable("Books_Activate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/activate")]
        public async Task Activate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/books/{id}/activate");
        }

        [Authorizable("Books_Deactivate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/deactivate")]
        public async Task Deactivate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/books/{id}/deactivate");
        }
    }
}
