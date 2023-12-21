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
using static Contract.Response.Books.SearchBooksResponse;

namespace DomainService.Operations
{
    public class AuthorOperations
    {
        private readonly MainDbContext mainDbContext;

        public AuthorOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Author> Search(string? name, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Authors.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Author GetSingle(int id)
        {
            var author = mainDbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (author == null)
                throw new BusinessException(404, "Yazar bulunamadı.");

            return author;
        }

        public void Create(string name)
        {
            var currentAuthor = mainDbContext.Authors.Where(x => x.Name == name).SingleOrDefault();
            if (currentAuthor != null)
                throw new BusinessException(400, "Bu yazar adı mevcut.");

            Author author = new Author();
            author.Name = name;
            author.CreatedOn = DateTime.Now;
            author.Status = DatabaseModel.Enumerations.AuthorStatus.Active;
            mainDbContext.Authors.Add(author);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string name)
        {
            var author = mainDbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (author == null)
                throw new BusinessException(404, "Yazar bulunamadı.");

            author.Name = name;
            author.UpdatedOn = DateTime.Now;
            mainDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var author = mainDbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (author == null)
                throw new BusinessException(404, "Bu yazar bulunamadı");

            mainDbContext.Authors.Remove(author);
            mainDbContext.SaveChanges();
        }

        public void Activate(int id)
        {
            var author = mainDbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (author == null)
                throw new BusinessException(404, "Yazar bulunamadı");

            author.Status = AuthorStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var author = mainDbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (author == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            author.Status = AuthorStatus.Passive;
            mainDbContext.SaveChanges();
        }
    }
}
