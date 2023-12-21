using Contract.Request.LibraryApi.Customer;
using Contract.Response.LibraryApi.Author;
using Contract.Response.LibraryApi.Book;
using Contract.Response.LibraryApi.Customer;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.LibraryApi.Customer
{
    [ApiController]
    [Route("library-api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public CustomersController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
        }

        [HttpGet]
        [Authorizable("Customers_List")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchCustomersResponse>> Search([FromQuery] SearchCustomersRequest request)
        {
            SearchCustomersResponse response = new SearchCustomersResponse();
            string url = ($"{libraryApiUrl}/library-api/customers?name={request.name}&surname={request.surname}&identity={request.identity}&phoneNumber={request.phoneNumber}&createdOn={request.CreatedOn}&updatedOn={request.UpdatedOn}&status={request.status}&pageNumber={request.pageNumber}&pageSize={request.pageSize}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchCustomersResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Customers_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleCustomerResponse>> GetSingle(int id)
        {
            GetSingleCustomerResponse response = new GetSingleCustomerResponse();
            string url = ($"{libraryApiUrl}/library-api/customers/{id}");
            response = await httpHelper.Get<GetSingleCustomerResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Customers_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateCustomerRequest request)
        {
            await httpHelper.Create($"{libraryApiUrl}/library-api/customers", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Customers_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateCustomerRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/customers/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Customers_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{libraryApiUrl}/library-api/customers/{id}");
        }

        [Authorizable("Customers_Activate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/activate")]
        public async Task Activate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/customers/{id}/activate");
        }

        [Authorizable("Customers_Deactivate")]
        [RequiredHeaderParameters("Token")]
        [HttpPut("{id}/deactivate")]
        public async Task Deactivate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/customers/{id}/deactivate");
        }
    }

}
