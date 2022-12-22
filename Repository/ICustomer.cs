using OMS74019FINALCSB.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMS74019FINALCSB.Repository
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> Login(int CustId, string CustPass);

        Task<Customer> Login(string data, string CustPass);

        Task<Customer> GetCustomerByEmail(string email);
        Task<Customer> GetCustomerByCustId(int CustId);
        Task<Customer> GetCustomerByCustEmail(string custEmail);
        Task<Customer> AddCustomer(Customer Customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Customer> UpdateCustomerByEmail(Customer customer);
        Task<Customer> DeleteCustomer(int id);

    }
}
