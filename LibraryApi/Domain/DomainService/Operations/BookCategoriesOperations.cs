using DatabaseModel;
using DatabaseModel.Entities;
using DomainService.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Contract.Response.Authors.SearchAuthorsResponse;

namespace DomainService.Operations
{
    public class BookCategoriesOperations
    {
        private readonly MainDbContext mainDbContext;
        public BookCategoriesOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }

        public List<Category> GetBookCategories(int bookId)
        {
            var book = mainDbContext.Books.Include(x => x.Categories).Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap Bulunamadı.");

            return book.Categories.ToList();
        }

        public void Update(int bookId,List<int> categories)
        {
            var book = mainDbContext.Books.Include(x => x.Categories).Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap Bulunamadı.");

            book.Categories.Clear();
            foreach (var categoryId in categories)
            {
                var category = mainDbContext.Categories.Where(x => x.Id == categoryId).SingleOrDefault();
                if (category == null)
                    throw new BusinessException(404, "Böyle bir yazar bulunamadı.");

                book.Categories.Add(category);
            }
            mainDbContext.SaveChanges();

        }
    }
}
