using Contract.Request.Categories;
using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class CategoryOperations
    {
        private readonly MainDbContext mainDbContext;

        public CategoryOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Category> Search(string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(name)) //adam gönderdiyse.
                query = query.Where(x => x.Name == name);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }
        public Category GetSingle(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori Bulunamadı.");

            return category;
        }
        public void Create(string name)
        {
            #region Validations

            var currentCategory = mainDbContext.Categories.Where(x => x.Name == name).SingleOrDefault();
            if (currentCategory != null)
                throw new BusinessException(400, "Bu kategori adı kullanılıyor.");

            #endregion

            Category category = new Category();
            category.Name = name;
            category.CreatedOn = DateTime.Now;
            category.Status = CategoryStatus.Active;
            mainDbContext.Categories.Add(category);

            mainDbContext.SaveChanges();
        }
        public void Update(int id, string name)
        {
            #region Validations

            var currentCategory = mainDbContext.Categories.Where(x => x.Id != id && x.Name == name).SingleOrDefault();
            if (currentCategory != null)
                throw new BusinessException(400, "Bu kategori adı kullanılıyor.");

            #endregion

            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori bulunamadı.");

            category.Name = name;
            category.UpdatedOn = DateTime.Now;

            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori bulunamadı.");

            mainDbContext.Categories.Remove(category);
            mainDbContext.SaveChanges();
        }
        public void Activate(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori bulunamadı.");

            category.Status = CategoryStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var category = mainDbContext.Categories.Where(x => x.Id == id).SingleOrDefault();
            if (category == null)
                throw new BusinessException(404, "Kategori bulunamadı.");

            category.Status = CategoryStatus.Passive;
            mainDbContext.SaveChanges();
        }
    }
}
