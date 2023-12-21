using Azure;
using Contract.Request.Authors;
using Contract.Request.Books;
using Contract.Response.Authors;
using DomainService.Operations;
using Host.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace Host.Controllers
{
    [ApiController]
    [Route("library-api/authors")]
    public class AuthorsController : BaseController
    {
        private readonly AuthorOperations authorOperations;
        public AuthorsController(AuthorOperations authorOperations)
        {
            this.authorOperations = authorOperations;
        }

        [HttpGet]
        public ActionResult<SearchAuthorsResponse> Search([FromQuery] SearchAuthorsRequest request)
        {
            var authors = authorOperations.Search(request.name, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);
            SearchAuthorsResponse response = new SearchAuthorsResponse();

            foreach (var author in authors)
            {
                response.authors.Add(new SearchAuthorsResponse.Authors()
                {
                    id = author.Id,
                    name = author.Name,
                    CreatedOn = author.CreatedOn,
                    UpdatedOn = author.UpdatedOn,
                    status = (int)author.Status
                });
            }
            response.totalCount = totalCount;
            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleAuthorResponse> GetSingle(int id)
        {
            var author = authorOperations.GetSingle(id);
            GetSingleAuthorResponse response = new GetSingleAuthorResponse();
            response.id = author.Id;
            response.name = author.Name;
            response.UpdatedOn = author.UpdatedOn;
            response.CreatedOn = author.CreatedOn;
            response.status = (int)author.Status;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateAuthorRequest request)
        {
            ValidateRequest<CreateAuthorRequest, CreateAuthorRequestValidator>(request);
            authorOperations.Create(request.name);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateAuthorRequest request)
        {
            ValidateRequest<UpdateAuthorRequest, UpdateAuthorRequestValidator>(request);
            authorOperations.Update(id, request.name);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            authorOperations.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            authorOperations.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            authorOperations.Deactivate(id);
        }
    }
}
