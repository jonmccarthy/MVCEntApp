using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaStore.Domain.Abstract;
using PizzaStore.Domain.Entities;
using System.Data.Linq;

namespace PizzaStore.Domain.Concrete
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private Table<Customer> customersTable;

            public SqlCustomerRepository(string connectionString)
            {
                customersTable = (new DataContext(connectionString)).GetTable<Customer>();
            }

            public IQueryable<Customer> Customers
            {
                get { return customersTable; }
            }

            public void SaveCustomer(Customer customer)
            {
                // If its a new Customer, just attach it to the DataContext
                if (customer.CustomerID == 0)
                    customersTable.InsertOnSubmit(customer);
                else if (customersTable.GetOriginalEntityState(customer) == null)
                {
                    // Were updating an existing Customer, but its not attached to the
                    // this data context, so attach it and detect the changes
                    customersTable.Attach(customer);
                    customersTable.Context.Refresh(RefreshMode.KeepCurrentValues, customer);
                }
                customersTable.Context.SubmitChanges();
            }

            public int FindCustomer(String uname, String pwd)
            {
                int cid = 0;
                try { Customer c = customersTable.First(x => x.Email == uname);
                    if (c.LoginPassword == pwd)
                    {
                        cid = c.CustomerID;
                    }
                    else
                    {
                        // Invalid Login
                    }
                }
                catch { }
                return cid;
            }

            public string GetCustomerEmail(int CustID)
            {
                string email="";
                try
                {
                    Customer c = customersTable.First(x => x.CustomerID == CustID);
                    email = c.Email;
                }
                catch { }
                return email;
            }

            public void DeleteCustomer(Customer customer)
            {
                customersTable.DeleteOnSubmit(customer);
                customersTable.Context.SubmitChanges();
            }
    }
}
