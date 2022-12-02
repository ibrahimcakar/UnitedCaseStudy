namespace UnitedCaseStudy.Web.Services
{
    public interface IRestService
    {
        bool RestCreateMethod(string action, string body);
        string RestGetAllMethod(string action);
        bool RestDeleteMethod(string action, string body);
        string RestUpdateMethod(string action, string body);
    }
}
