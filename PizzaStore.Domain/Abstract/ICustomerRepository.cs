using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Entities;

namespace PizzaStore.Domain.Abstract
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }
        void SaveCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        int FindCustomer(String uname, String pwd);
        string GetCustomerEmail(int CustID);
    }
}
