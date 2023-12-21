using Contract.Request.Authors;
using Contract.Request.Customers;
using Contract.Response.Customers;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/customers")]
    public class CustomersController : BaseController
    {
        private readonly CustomerOperations customerOperations;
        public CustomersController(CustomerOperations customerOperations)
        {
            this.customerOperations = customerOperations;
        }

        [HttpGet]
        public ActionResult<SearchCustomersResponse> Search([FromQuery] SearchCustomersRequest request)
        {
            var customers = customerOperations.Search(request.name, request.surname, request.phoneNumber, request.identity, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchCustomersResponse response = new SearchCustomersResponse();

            foreach (var customer in customers)
            {
                response.customers.Add(new SearchCustomersResponse.Customers()
                {
                    id = customer.Id,
                    identity = customer.Identity,
                    name = customer.Name,
                    phoneNumber = customer.PhoneNumber,
                    surname = customer.Surname,
                    CreatedOn = customer.CreatedOn,
                    UpdatedOn = customer.UpdatedOn,
                    isDeleted = customer.IsDeleted,
                    status = (int)customer.Status
                });
            }

            response.totalCount = totalCount;

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCustomerResponse> GetSingle(int id)
        {
            var customer = customerOperations.GetSingle(id);
            GetSingleCustomerResponse response = new GetSingleCustomerResponse();
            response.id = customer.Id;
            response.identity = customer.Identity;
            response.name = customer.Name;
            response.phoneNumber = customer.PhoneNumber;
            response.surname = customer.Surname;
            response.CreatedOn = customer.CreatedOn;
            response.UpdatedOn = customer.UpdatedOn;
            response.isDeleted = customer.IsDeleted;
            response.status = (int)customer.Status;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateCustomerRequest request)
        {
            ValidateRequest<CreateCustomerRequest, CreateCustomerRequestValidator>(request);
            customerOperations.Create(request.name, request.surname, request.identity, request.phoneNumber);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCustomerRequest request)
        {
            ValidateRequest<UpdateCustomerRequest, UpdateCustomerRequestValidator>(request);
            customerOperations.Update(id, request.name, request.surname, request.identity, request.phoneNumber);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            customerOperations.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            customerOperations.Deactivate(id);
        }
    }
}
