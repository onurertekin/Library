using Contract.Request.LibraryApi.Rezervation;
using Contract.Response.LibraryApi.Customer;
using Contract.Response.LibraryApi.Rezervation;
using Host.Filters;
using Host.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Host.Controllers.v1.LibraryApi.Rezervation
{
    [ApiController]
    [Route("library-api/rezervations")]
    public class RezervationsController : ControllerBase
    {
        private readonly HttpHelper httpHelper;
        private readonly string libraryApiUrl;
        public RezervationsController(HttpHelper httpHelper, IConfiguration configuration)
        {
            this.httpHelper = httpHelper;
            this.libraryApiUrl = configuration.GetValue<string>("Services:LibraryApi");
        }

        [HttpGet]
        //[Authorizable("Rezervations_List")]
        //[RequiredHeaderParameters("Token")]
        public async Task<ActionResult<SearchRezervationsResponse>> Search([FromQuery] SearchRezervationsRequest request)
        {
            SearchRezervationsResponse response = new SearchRezervationsResponse();
            string url = ($"{libraryApiUrl}/library-api/rezervations?rezervationStartDate={request.rezervationStartDate}&rezervationEndDate={request.rezervationEndDate}&customerId={request.customerId}&bookId={request.bookId}&createdOn={request.CreatedOn}&updatedOn={request.UpdatedOn}&status={request.status}&pageNumber={request.pageNumber}&pageSize={request.pageSize}&sortBy={request.sortBy}&sortDirection={request.sortDirection}");
            response = await httpHelper.Get<SearchRezervationsResponse>(url);
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        [Authorizable("Rezervations_GetSingle")]
        [RequiredHeaderParameters("Token")]
        public async Task<ActionResult<GetSingleRezervationResponse>> GetSingle(int id)
        {
            GetSingleRezervationResponse response = new GetSingleRezervationResponse();
            string url = ($"{libraryApiUrl}/library-api/rezervations/{id}");
            response = await httpHelper.Get<GetSingleRezervationResponse>(url);
            return new JsonResult(response);
        }

        [HttpPost]
        [Authorizable("Rezervations_Create")]
        [RequiredHeaderParameters("Token")]
        public async Task Create([FromBody] CreateRezervationRequest request)
        {
            await httpHelper.Create($"{libraryApiUrl}/library-api/rezervations", request);
        }

        [HttpPut("{id}")]
        [Authorizable("Rezervations_Update")]
        [RequiredHeaderParameters("Token")]
        public async Task Update(int id, [FromBody] UpdateRezervationRequest request)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/rezervations/{id}", request);
        }

        [HttpDelete("{id}")]
        [Authorizable("Rezervations_Delete")]
        [RequiredHeaderParameters("Token")]
        public async Task Delete(int id)
        {
            await httpHelper.Delete($"{libraryApiUrl}/library-api/rezervations/{id}");
        }

        [HttpDelete("{id}")]
        [Authorizable("Rezervations_Activate")]
        [HttpPut("{id}/activate")]
        public async Task Activate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/rezervations/{id}/activate");
        }

        [HttpDelete("{id}")]
        [Authorizable("Rezervations_Deactivate")]
        [HttpPut("{id}/deactivate")]
        public async Task Deactivate(int id)
        {
            await httpHelper.Update($"{libraryApiUrl}/library-api/rezervations/{id}/deactivate");
        }
    }
}
