using Contract.Request.Users;
using Contract.Response.Users;
using DomainService.Operations;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("IAM/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserOperation userOperation;
        public UsersController(UserOperation userOperation)
        {
            this.userOperation = userOperation;
        }

        [HttpGet]
        public ActionResult<SearchUsersResponse> Search([FromQuery] SearchUsersRequest request)
        {
            var users = userOperation.Search(request.userName, request.firstName, request.lastName, request.email, request.status, request.sortBy, request.sortDirection, request.pageSize, request.pageNumber, out int totalCount);

            SearchUsersResponse response = new SearchUsersResponse();

            foreach (var user in users)
            {
                response.users.Add(new SearchUsersResponse.User()
                {
                    id = user.Id,
                    userName = user.UserName,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    email = user.Email,
                    password = user.Password,
                    CreatedOn = user.CreatedOn,  
                    UpdatedOn = user.UpdatedOn,
                    status = (int)user.Status,
                    isDeleted = user.IsDeleted
                });
            }

            response.totalCount = totalCount;

            return new JsonResult(response);
        }

        [HttpGet("{id}")]
        public ActionResult<GetSingleUsersResponse> GetSingle(int id)
        {
            var user = userOperation.GetSingle(id);

            GetSingleUsersResponse response = new GetSingleUsersResponse();
            response.id = user.Id;
            response.userName = user.UserName;
            response.firstName = user.FirstName;
            response.lastName = user.LastName;
            response.email = user.Email;
            response.password = user.Password;
            response.CreatedOn = user.CreatedOn;
            response.UpdatedOn = user.UpdatedOn;
            response.status = (int)user.Status;
            response.isDeleted = user.IsDeleted;

            return new JsonResult(response);
        }

        [HttpPost]
        public void Create([FromBody] CreateUsersRequest request)
        {
            userOperation.Create(request.firstName, request.lastName, request.userName, request.email, request.password);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] UpdateUsersRequest request)
        {
            userOperation.Update(id, request.firstName, request.lastName, request.userName, request.email, request.password);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userOperation.Delete(id);
        }

        [HttpPut("{id}/activate")]
        public void Activate(int id)
        {
            userOperation.Activate(id);
        }

        [HttpPut("{id}/deactivate")]
        public void Deactivate(int id)
        {
            userOperation.Deactivate(id);
        }
    }
}
