using Contract.Request.LibraryApi.Author;
using Contract.Response.LibraryApi.Author;
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

namespace Host.Controllers.v1.LibraryApi.Author
{
    [ApiController]
    [Route("library-api/authors")]
    public class AuthorsController
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public AuthorsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        [Authorizable("Authors_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchAuthorsResponse>> Search([FromQuery] SearchAuthorsRequest request)
        {
            SearchAuthorsResponse response = new SearchAuthorsResponse();
            string url = ($"{libraryApiUrl}/library-api/authors?name={request.name}&createdOn={request.CreatedOn}&updatedOn={request.UpdatedOn}&status={request.status}&pageNumber={request.pageNumber}&pageSize={request.pageSize}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchAuthorsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Authors_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleAuthorResponse>> GetSingle(int id)
        {
            GetSingleBookResponse response = new GetSingleBookResponse();
            string url = ($"{libraryApiUrl}/library-api/authors/{id}");
            response = await httpHelper.Get<GetSingleBookResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Authors_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateAuthorRequest request)
        {
            await httpHelper.Create($"{libraryApiUrl}/library-api/authors", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Authors_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateAuthorRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/authors/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Authors_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{libraryApiUrl}/library-api/authors/{id}");
        }

        [Authorizable("Authors_Activate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/activate")]
        public async Task Activate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/authors/{id}/activate");
        }

        [Authorizable("Authors_Deactivate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/deactivate")]
        public async Task Deactivate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/authors/{id}/deactivate");
        }
    }
}
