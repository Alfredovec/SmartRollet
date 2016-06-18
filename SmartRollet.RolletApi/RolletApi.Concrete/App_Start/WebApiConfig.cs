using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Providers;
using Newtonsoft.Json.Serialization;

namespace RolletApi.Concrete
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "{controller}/{id}",
          defaults: new { controller = "Rollet", id = RouteParameter.Optional }
      );

      config.EnableSystemDiagnosticsTracing();

      config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

      GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
          new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

      GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
          new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

      GlobalConfiguration.Configuration.Services.RemoveAll(
          typeof(ModelValidatorProvider),
          v => v is InvalidModelValidatorProvider);

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }
}
