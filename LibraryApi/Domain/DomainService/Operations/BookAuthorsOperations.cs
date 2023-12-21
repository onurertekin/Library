using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class BookAuthorsOperations
    {
        private readonly MainDbContext mainDbContext;
        public BookAuthorsOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public List<Author> GetBookAuthor(int bookId)
        {
            var book = mainDbContext.Books.Include(x => x.Authors).Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap bulunamadı.");

            return book.Authors.ToList();
        }

        public void Update(int bookId, List<int> authors)
        {
            var book = mainDbContext.Books.Include(x => x.Authors).Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap bulunamadı.");

            book.Authors.Clear();
            foreach (var authorId in authors)
            {
                var author = mainDbContext.Authors.Where(x => x.Id == authorId).SingleOrDefault();
                if (author == null)
                    throw new BusinessException(404, "Böyle bir yazar bulunamadı.");

                book.Authors.Add(author);
            }
            mainDbContext.SaveChanges();
        }
    }
}
