using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contract.Response.Authors.SearchAuthorsResponse;

namespace DomainService.Operations
{
    public class BookOperations
    {
        private readonly MainDbContext mainDbContext;
        public BookOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public IList<Book> Search(string? name, int? pageCount, int? isbn, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Books.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);
            if (pageCount != 0)
                query = query.Where(x => x.PageCount == pageCount);
            if (isbn != 0)
                query = query.Where(x => x.Isbn == isbn);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Book GetSingle(int id)
        {
            var book = mainDbContext.Books.Where(x => x.Id == id).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap Bulunamadı");

            return book;
        }

        public void Create(string name, int pageCount, int isbn,int status)
        {
            #region Validations
            var currentBook = mainDbContext.Books.Where(x => x.Name == name).SingleOrDefault();
            if (currentBook != null)
                throw new BusinessException(400, "Bu kitap adı mevcut.");
            #endregion

            Book book = new Book();
            book.Name = name;
            book.Isbn = isbn;
            book.PageCount = pageCount;
            book.Status = (DatabaseModel.Enumerations.BookStatus)status;
            book.CreatedOn = DateTime.Now;
            mainDbContext.SaveChanges();
            mainDbContext.Books.Add(book);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string name, int pageCount, int isbn,int status)
        {
            #region Validations
            var currentBook = mainDbContext.Books.Where(x => x.Name == name & x.Id != id).SingleOrDefault();
            if (currentBook != null)
                throw new BusinessException(400, "Bu kitap adı mevcut.");
            #endregion

            var book = mainDbContext.Books.Where(x => x.Id == id).SingleOrDefault();

            if (book == null)
                throw new BusinessException(404, "Bu kitap bulunamadı.");

            book.Name = name;
            book.Isbn = isbn;
            book.PageCount = pageCount;
            book.Status = (DatabaseModel.Enumerations.BookStatus)status;
            book.UpdatedOn = DateTime.Now;
            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = mainDbContext.Books.Include(x => x.Authors).Include(x => x.Categories).Include(x => x.Rezervations).Where(x => x.Id == id).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Bu kitap bulunamadı");

            book.Authors.Clear();
            book.Categories.Clear();
            book.Rezervations.Clear();

            mainDbContext.Books.Remove(book);
            mainDbContext.SaveChanges();
        }

        public void Activated(int id)
        {
            var book = mainDbContext.Books.Where(x => x.Id == id).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Bu kitap bulunamadı");

            book.Status = BookStatus.Kutuphanede;
            mainDbContext.SaveChanges();
        }
        public void Deactivated(int id)
        {
            var book = mainDbContext.Books.Where(x => x.Id == id).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Bu kitap bulunamadı");

            book.Status = BookStatus.Musteride;
            mainDbContext.SaveChanges();
        }

    }
}
