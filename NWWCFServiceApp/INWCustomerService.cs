using NWWCFServiceApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NWWCFServiceApp
{
    [ServiceContract]
    public interface INWCustomerService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetCustomerCountries", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Country> GetCustomerCountries();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCustomers", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Customers> GetCustomers();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCustomersByCountry/{countryName}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Customers> GetCustomersByCountry(string countryName);

        [OperationContract]
        [WebGet(UriTemplate = "/GetOrdersByCustomer/{customerId}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<Orders> GetOrdersByCustomer(string customerId);
    }

}
