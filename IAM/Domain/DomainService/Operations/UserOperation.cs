using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DomainService.Operations
{
    public class UserOperation
    {
        private readonly MainDbContext mainDbContext;

        public UserOperation(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public IList<User> Search(string userName, string firstName, string lastName, string email, int status, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Users.AsQueryable();

            #region Where Conditions

            query = query.Where(x => !x.IsDeleted);

            if (!string.IsNullOrEmpty(userName))
                query = query.Where(x => x.UserName == userName);

            if (!string.IsNullOrEmpty(firstName))
                query = query.Where(x => x.FirstName == firstName);

            if (!string.IsNullOrEmpty(lastName))
                query = query.Where(x => x.LastName == lastName);

            if (!string.IsNullOrEmpty(email))
                query = query.Where(x => x.Email == email);

            #endregion

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public User GetSingle(int id)
        {
            var currentUser = mainDbContext.Users.Where(x => x.Id == id && !x.IsDeleted).SingleOrDefault();
            if (currentUser == null)
                throw new BusinessException(404, "Kullanıcı Bulunamadı.");

            return currentUser;
        }
        public void Create(string firstName, string lastName, string userName, string email, string password)
        {
            #region Validations

            //username'i bertekin olan kullanıcıyı çekiyoruz
            var currentUser = mainDbContext.Users.Where(x => x.UserName == userName).SingleOrDefault();
            if (currentUser != null)
                throw new BusinessException(400, "Bu username kullanılıyor.");

            #endregion

            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = userName;
            user.Email = email;
            user.Password = password;
            user.CreatedOn = DateTime.Now;
            user.Status = DatabaseModel.Enumerations.UserStatus.Active;

            mainDbContext.Users.Add(user);
            mainDbContext.SaveChanges();
        }
        public void Update(int id, string firstName, string lastName, string userName, string email, string password)
        {
            #region Validations

            //username'i bertekin olan kullanıcıyı çekiyoruz
            var currentUser = mainDbContext.Users.Where(x => x.Id != id && x.UserName == userName).SingleOrDefault();
            if (currentUser != null)
                throw new BusinessException(400, "Bu username kullanılıyor.");

            #endregion

            var user = mainDbContext.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
                throw new BusinessException(404, "Kullanıcı Bulunamadı.");

            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = userName;
            user.Email = email;
            user.Password = password;
            user.UpdatedOn = DateTime.Now;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var user = mainDbContext.Users.Include(x => x.Roles).Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
                throw new BusinessException(404, "Kullanıcı Bulunamadı.");

            user.IsDeleted = true;

            //user.Roles.Clear();

            //mainDbContext.Users.Remove(user);
            mainDbContext.SaveChanges();
        }

        public void Activate(int id)
        {
            var user = mainDbContext.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
                throw new BusinessException(404, "Kullanıcı Bulunamadı.");

            user.Status = UserStatus.Active;

            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var user = mainDbContext.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
                throw new BusinessException(404, "Kullanıcı Bulunamadı.");

            user.Status = UserStatus.Passive;
            mainDbContext.SaveChanges();
        }
    }
}
