using Contract.Request.Categories;
using Contract.Response.Categories;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/categories")]
    public class CategoriesController : BaseController
    {
        private readonly CategoryOperations categoryOperations;

        public CategoriesController(CategoryOperations categoryOperations)
        {
            this.categoryOperations = categoryOperations;
        }

        //..
        [HttpGet]
        public ActionResult<SearchCategoriesResponse> Search([FromQuery] SearchCategoriesRequest request)
        {
            var categories = categoryOperations.Search(request.name, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchCategoriesResponse response = new SearchCategoriesResponse();
            foreach (var category in categories)
            {
                response.categories.Add(new SearchCategoriesResponse.Categories()
                {
                    name = category.Name,
                    id = category.Id,
                    CreatedOn = category.CreatedOn,
                    UpdatedOn = category.UpdatedOn,
                    status = (int)category.Status

                });
            }

            response.totalCount = totalCount;

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleCategoriesResponse> GetSingle(int id)
        {
            var category = categoryOperations.GetSingle(id);
            GetSingleCategoriesResponse response = new GetSingleCategoriesResponse();
            response.id = category.Id;
            response.name = category.Name;
            response.CreatedOn = category.CreatedOn;
            response.UpdatedOn = category.UpdatedOn;
            response.status = (int)category.Status;
            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateCategoriesRequest request)
        {
            ValidateRequest<CreateCategoriesRequest, CreateCategoriesRequestValidator>(request);
            categoryOperations.Create(request.name);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateCategoriesRequest request)
        {
            ValidateRequest<UpdateCategoriesRequest, UpdateCategoriesRequestValidator>(request);
            categoryOperations.Update(id, request.name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            categoryOperations.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            categoryOperations.Deactivate(id);
        }

    }
}
