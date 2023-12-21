using Contract.Request.Customers;
using Contract.Request.Rezervations;
using Contract.Response.Rezervations;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/rezervations")]
    public class RezervationsController : BaseController
    {
        private readonly RezervationOperations rezervationOperations;
        public RezervationsController(RezervationOperations rezervationOperations)
        {
            this.rezervationOperations = rezervationOperations;
        }

        [HttpGet]
        public ActionResult<SearchRezervationsResponse> Search([FromQuery] SearchRezervationsRequest request)
        {
            var rezervations = rezervationOperations.Search(request.rezervationEndDate, request.rezervationStartDate, request.customerId, request.bookId, request.customerName, request.bookName, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchRezervationsResponse response = new SearchRezervationsResponse();
            foreach (var rezervation in rezervations)
            {
                response.rezervations.Add(new SearchRezervationsResponse.Rezervation()
                {
                    id = rezervation.Id,
                    rezervationStartDate = rezervation.RezervationStartDate,
                    rezervationEndDate = rezervation.RezervationEndDate,
                    customerId = rezervation.CustomerId,
                    bookId = rezervation.BookId,
                    customerName = rezervation.Customer.Name,
                    bookName = rezervation.Book.Name,
                    CreatedOn = rezervation.CreatedOn,
                    UpdatedOn = rezervation.UpdatedOn,
                    status = (int)rezervation.Status
                });
            }

            response.totalCount = totalCount;

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleRezervationResponse> GetSingle(int id)
        {
            var rezervation = rezervationOperations.GetSingle(id);

            GetSingleRezervationResponse response = new GetSingleRezervationResponse();

            response.id = rezervation.Id;
            response.rezervationStartDate = rezervation.RezervationStartDate;
            response.rezervationEndDate = rezervation.RezervationEndDate;
            response.bookId = rezervation.BookId;
            response.customerId = rezervation.CustomerId;
            response.CreatedOn = rezervation.CreatedOn;
            response.UpdatedOn = rezervation.UpdatedOn;
            response.status = (int)rezervation.Status;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateRezervationRequest request)
        {
            ValidateRequest<CreateRezervationRequest, CreateRezervationRequestValidator>(request);
            rezervationOperations.Create(request.rezervationStartDate, request.rezervationEndDate, request.customerId, request.bookId);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateRezervationRequest request)
        {
            ValidateRequest<UpdateRezervationRequest, UpdateRezervationRequestValidator>(request);
            rezervationOperations.Update(id, request.rezervationStartDate, request.rezervationEndDate, request.customerId, request.bookId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rezervationOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            rezervationOperations.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            rezervationOperations.Deactivate(id);
        }
    }
}
