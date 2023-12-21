using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DomainService.Operations
{
    public class RoleOperation
    {
        private readonly MainDbContext mainDbContext;
        public RoleOperation(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Role> Search(string name, int status, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Role GetSingle(int id)
        {
            var roles = mainDbContext.Roles.AsQueryable().Include(x => x.Claims).Where(x => x.Id == id).SingleOrDefault();
            if (roles == null)
                throw new BusinessException(400, "Rol Bulunamadı.");

            return roles;
        }

        public void Create(string name, List<string> claims)
        {
            Role role = new Role();
            role.Name = name;
            role.CreatedOn = DateTime.Now;
            role.Status = DatabaseModel.Enumerations.RoleStatus.Active;
            mainDbContext.Roles.Add(role);

            mainDbContext.SaveChanges();

            #region Claims

            //Request'te gönderilen claim listesinde dönüyoruz
            foreach (var claim in claims)
            {
                //Bizde böyle bir code var mı diye kontrol ediyoruz.
                var _claim = mainDbContext.Claims.Where(x => x.Code == claim).SingleOrDefault();
                if (_claim == null)
                    throw new BusinessException(400, "InvalidClaim");

                //Vrsa role'ün claim'lerine ekliyoruz.
                role.Claims.Add(_claim);
            }

            mainDbContext.SaveChanges();

            #endregion
        }

        public void Update(int id, string name, List<string> claims)
        {
            var role = mainDbContext.Roles.AsQueryable().Include(x => x.Claims).Where(x => x.Id == id).SingleOrDefault();
            if (role == null)
                throw new BusinessException(400, "Rol Bulunamadı.");

            role.Name = name;
            role.UpdatedOn = DateTime.Now;
            #region Claims

            role.Claims.Clear();
            foreach (var claim in claims)
            {
                var _claim = mainDbContext.Claims.Where(x => x.Code == claim).SingleOrDefault();
                if (_claim == null)
                    throw new Exception("InvalidClaim");

                role.Claims.Add(_claim);
            }

            #endregion

            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = mainDbContext.Roles.AsQueryable().Include(x => x.Claims).Include(x => x.Users).Where(x => x.Id == id).SingleOrDefault();
            if (role == null)
                throw new BusinessException(404, "Role Bulunamadı.");

            role.Users.Clear();
            role.Claims.Clear();
            mainDbContext.Roles.Remove(role);
            mainDbContext.SaveChanges();
        }

        public void Activate(int id)
        {
            var role = mainDbContext.Roles.Where(x => x.Id == id).SingleOrDefault();
            if (role == null)
                throw new BusinessException(404, "Role Bulunamadı.");

            role.Status = RoleStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var role = mainDbContext.Roles.Where(x => x.Id == id).SingleOrDefault();
            if (role == null)
                throw new BusinessException(404, "Role Bulunamadı.");

            role.Status = RoleStatus.Passive;
            mainDbContext.SaveChanges();
        }
    }
}
