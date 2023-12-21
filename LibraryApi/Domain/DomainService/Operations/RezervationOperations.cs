using Azure.Core;
using Castle.Components.DictionaryAdapter.Xml;
using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class RezervationOperations
    {
        private readonly MainDbContext mainDbContext;
        public RezervationOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public IList<Rezervation> Search(string rezervationStartDate, string rezervationEndDate, int customerId, int bookId, string customerName, string bookName, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Rezervations.Include(x => x.Customer).Include(x => x.Book).AsQueryable();

            if (!string.IsNullOrEmpty(rezervationStartDate))
                query = query.Where(x => x.RezervationStartDate == rezervationStartDate);

            if (!string.IsNullOrEmpty(rezervationEndDate))
                query = query.Where(x => x.RezervationEndDate == rezervationEndDate);

            if (!string.IsNullOrEmpty(rezervationEndDate))
                query = query.Where(x => x.RezervationEndDate == rezervationEndDate);

            if (customerId != 0)
                query = query.Where(x => x.CustomerId == customerId);

            if (bookId != 0)
                query = query.Where(x => x.BookId == bookId);

            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Rezervation GetSingle(int id)
        {
            var rezervation = mainDbContext.Rezervations.Where(x => x.Id == id).SingleOrDefault();
            if (rezervation == null)
                throw new BusinessException(404, "Rezervasyon bulunamadı.");
            return rezervation;
        }

        public void Create(string rezervationStartDate, string rezervationEndDate, int customerId, int bookId)
        {
            #region Controls

            var customer = mainDbContext.Customers.Where(x => x.Id == customerId).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı.");

            var book = mainDbContext.Books.Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap bulunamadı.");

            if (book.Status == BookStatus.Musteride)
                throw new BusinessException(404, "Kitap bulunamadı.");

            #endregion

            Rezervation rezervation = new Rezervation();
            rezervation.RezervationStartDate = rezervationStartDate;
            rezervation.RezervationEndDate = rezervationEndDate;
            rezervation.CustomerId = customerId;
            rezervation.BookId = bookId;
            rezervation.CreatedOn = DateTime.Now;
            rezervation.Status = RezervationStatus.Active;
            mainDbContext.Rezervations.Add(rezervation);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string rezervationStartDate, string rezervationEndDate, int customerId, int bookId)
        {
            #region Controls

            var customer = mainDbContext.Customers.Where(x => x.Id == customerId).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı.");

            var book = mainDbContext.Books.Where(x => x.Id == bookId).SingleOrDefault();
            if (book == null)
                throw new BusinessException(404, "Kitap bulunamadı.");

            #endregion

            var rezervation = mainDbContext.Rezervations.Where(x => x.Id == id).SingleOrDefault();
            if (rezervation == null)
                throw new BusinessException(404, "Rezervasyon bulunamadı.");

            rezervation.RezervationStartDate = rezervationStartDate;
            rezervation.RezervationEndDate = rezervationEndDate;
            rezervation.CustomerId = customerId;
            rezervation.BookId = bookId;
            rezervation.UpdatedOn = DateTime.Now;
            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var rezervation = mainDbContext.Rezervations.Where(x => x.Id == id).SingleOrDefault();

            if (rezervation == null)
                throw new BusinessException(404, "Rezervasyon bulunamadı.");

            mainDbContext.Rezervations.Remove(rezervation);
            mainDbContext.SaveChanges();
        }

        public void Activate(int id)
        {
            var rezervation = mainDbContext.Rezervations.Where(x => x.Id == id).SingleOrDefault();
            if (rezervation==null)
                throw new BusinessException(404, "Rezervasyon bulunamadı.");

            rezervation.Status=RezervationStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var rezervation = mainDbContext.Rezervations.Where(x => x.Id == id).SingleOrDefault();
            if (rezervation == null)
                throw new BusinessException(404, "Rezervasyon bulunamadı.");

            rezervation.Status = RezervationStatus.Passive;
            mainDbContext.SaveChanges();
        }
    }
}
