using Contract.Request.GeekYaparApi.Categories;
using Contract.Response.GeekYaparApi;
using Contract.Response.GeekYaparApi.Categories;
using Contract.Response.Users;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.GeekYaparApi.Categories
{
    [ApiController]
    [Route("library-api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public CategoriesController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
            this.httpHelper = httpHelper;
        }

        [HttpGet]
        [Authorizable("Categories_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchCategoriesResponse>> Search([FromQuery] SearchCategoriesRequest request)
        {
            SearchCategoriesResponse response = new SearchCategoriesResponse();
            string url = ($"{libraryApiUrl}/library-api/categories?name={request.name}&createdOn={request.CreatedOn}&updatedOn={request.UpdatedOn}&status={request.status}&pageNumber={request.pageNumber}&pageSize={request.pageSize}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchCategoriesResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Categories_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleCategoriesResponse>> GetSingle(int id)
        {
            GetSingleCategoriesResponse response = new GetSingleCategoriesResponse();
            string url = ($"{libraryApiUrl}/library-api/categories/{id}");
            response = await httpHelper.Get<GetSingleCategoriesResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Categories_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateCategoriesRequest request)
        {
            await httpHelper.Create($"{libraryApiUrl}/library-api/categories", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Categories_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateCategoriesRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/categories/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Categories_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{libraryApiUrl}/library-api/categories/{id}");
        }

        [Authorizable("Categories_Activate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/activate")]
        public async Task Activate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/categories/{id}/activate");
        }

        [Authorizable("Categories_Deactivate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/deactivate")]
        public async Task Deactivate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/categories/{id}/deactivate");
        }

    }
}
