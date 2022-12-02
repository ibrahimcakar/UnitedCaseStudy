using Microsoft.Extensions.Configuration;
using RestSharp;
using UnitedCaseStudy.Data.Abstract;
using UnitedCaseStudy.Entity.Entities;

namespace UnitedCaseStudy.Web.Services
{
    public class RestService : IRestService
    {
        private readonly IConfiguration _configuration;
        private string _baseUrl;
        public RestService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("API_Base_Url");
        }
        
        public bool RestCreateMethod(string action, string body)
        {
            var client = new RestClient(_baseUrl + action);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
        public string RestGetAllMethod(string action)
        {
            var client = new RestClient(_baseUrl+action);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content;
            else
                return null;
        }
        public bool RestDeleteMethod(string action, string body)
        {
            var client = new RestClient(_baseUrl + action);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else
                return false;
        }
        public string RestUpdateMethod(string action, string body)
        {
            var client = new RestClient(_baseUrl + action);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content;
            else
                return null;
        }
    }
}
