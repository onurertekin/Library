using DatabaseModel;
using DatabaseModel.Entities;
using DatabaseModel.Enumerations;
using DomainService.Exceptions;
using DomainService.Extensions;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Operations
{
    public class CustomerOperations
    {
        private readonly MainDbContext mainDbContext;
        public CustomerOperations(MainDbContext mainDbContext)
        {
            this.mainDbContext = mainDbContext;
        }
        public IList<Customer> Search(string name, string surname, string identity, string phoneNumber, string sortBy, string sortDirection, int pageSize, int pageNumber, out int totalCount)
        {
            var query = mainDbContext.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
                query = query.Where(x => x.Name == name);

            if (!string.IsNullOrEmpty(surname))
                query = query.Where(x => x.Surname == surname);

            if (!string.IsNullOrEmpty(identity))
                query = query.Where(x => x.Identity == identity);

            if (!string.IsNullOrEmpty(phoneNumber))
                query = query.Where(x => x.PhoneNumber == phoneNumber);


            return query.GetPagedAndSorted(pageNumber, pageSize, sortDirection, sortBy, out totalCount);
        }

        public Customer GetSingle(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı.");
            return customer;
        }

        public void Create(string name, string surname, string identity, string phoneNumber)
        {
            #region Validations

            var currentlyCustomer = mainDbContext.Customers.Where(x => x.Identity == identity).SingleOrDefault();
            if (currentlyCustomer != null)
                throw new BusinessException(400, "Müşteri kimlik numarası mevcut.");

            var currentlyPhone = mainDbContext.Customers.Where(x => x.PhoneNumber == phoneNumber).SingleOrDefault();
            if (currentlyPhone != null)
                throw new BusinessException(400, "Telefon numarası mevcut.");

            #endregion

            Customer customer = new Customer();
            customer.Name = name;
            customer.Surname = surname;
            customer.Identity = identity;
            customer.PhoneNumber = phoneNumber;
            customer.CreatedOn= DateTime.Now;
            customer.Status = CustomerStatus.Active;
            mainDbContext.Customers.Add(customer);
            mainDbContext.SaveChanges();
        }

        public void Update(int id, string name, string surname, string identity, string phoneNumber)
        {
            #region Validations

            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            #endregion

            customer.Name = name;
            customer.Surname = surname;
            customer.Identity = identity;
            customer.PhoneNumber = phoneNumber;
            customer.UpdatedOn= DateTime.Now;   
            mainDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.IsDeleted = true;
            mainDbContext.SaveChanges();

        }

        public void Activate(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.Status = CustomerStatus.Active;
            mainDbContext.SaveChanges();
        }

        public void Deactivate(int id)
        {
            var customer = mainDbContext.Customers.Where(x => x.Id == id).SingleOrDefault();
            if (customer == null)
                throw new BusinessException(404, "Müşteri bulunamadı");

            customer.Status = CustomerStatus.Passive;
            mainDbContext.SaveChanges();
        }


    }
}
