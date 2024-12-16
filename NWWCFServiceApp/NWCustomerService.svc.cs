using NWWCFServiceApp.Entities;
using NWWCFServiceApp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Diagnostics;

namespace NWWCFServiceApp
{
    public class NWCustomerService : INWCustomerService
    {

        public List<Country> GetCustomerCountries()
        {
            List<Country> countries;

            try
            {
                using (var dbContext = new NWDBContext())
                {
                    countries = dbContext.Customers
                        .Select(x => x.Country)
                        .Distinct()
                        .OrderBy(country => country)
                        .Select(country => new Country
                        {
                            Name = country
                        })
                        .ToList();
                }

                var result = Tracker.RegisterTrackingInfo(Tracker.GetCurrentMethodName());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return countries;
        }

        public List<Customers> GetCustomers()
        {
            List<Customers> customers;

            try
            {
                using (var dbContext = new NWDBContext())
                {
                    customers = dbContext.Customers
                        .OrderBy(c => c.ContactName)
                        .ToList();
                }

                var result = Tracker.RegisterTrackingInfo(Tracker.GetCurrentMethodName());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customers;
        }

        public List<Customers> GetCustomersByCountry(string countryName)
        {
            List<Customers> customers;

            try
            {
                using (var dbContext = new NWDBContext())
                {
                    customers = dbContext.Customers
                        .Where(c => c.Country.ToUpper().Contains(countryName.ToUpper()))
                        .OrderBy(c => c.ContactName)
                        .ToList();
                }

                var result = Tracker.RegisterTrackingInfo(Tracker.GetCurrentMethodName());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customers;
        }

        public List<Orders> GetOrdersByCustomer(string customerId)
        {
            List<Orders> orders;

            try
            {
                using (var dbContext = new NWDBContext())
                {

                    orders = dbContext.Orders
                        .Where(o => o.CustomerID == customerId)
                        .OrderBy(o => o.ShippedDate)
                        .ToList();
                }

                var result = Tracker.RegisterTrackingInfo(Tracker.GetCurrentMethodName());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return orders;
        }

    }
}
