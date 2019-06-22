﻿using System.Collections.Generic;
using DockerApiDemo.Models;

namespace DockerApiDemo.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> Get();
        Customer GetById(int id);
        void Create(Customer customer);
        bool Delete(int id);
    }

    public class CustomersRepository : ICustomersRepository
    {
        private readonly DockerApiDemoContext _context;

        public CustomersRepository(DockerApiDemoContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> Get()
        {
            return _context.Customers;
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var customer = GetById(id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}