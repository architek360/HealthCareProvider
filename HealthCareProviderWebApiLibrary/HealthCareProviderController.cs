using FactualDriver.Exceptions;
using HealthCareProvider.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;

namespace HealthCareProvider.Controllers
{
    public class HealthCareProviderController : ApiController
    {
        private readonly IRepository repository = new HealthCareProviderRepository();

        public HttpResponseMessage GetProvidersData([FromUri]Filter filter)
        {
            string factualJsonData;
            try
            {
                factualJsonData = repository.GetHealthCareProviderData(filter);
            }
            catch (FactualApiException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(ex.Message) });
            }

            // Get the IContentNegotiator
            IContentNegotiator negotiator = Configuration.Services.GetContentNegotiator();

            // Run content negotiation to select a formatter
            ContentNegotiationResult result = negotiator.Negotiate(
              typeof(string), this.Request, this.Configuration.Formatters);

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (result.MediaType.MediaType.Equals("application/xml"))
            {
                string json = string.Format("{0}{1}{2}", "{Root: ", factualJsonData, "}");

                var doc = (XDocument)JsonConvert.DeserializeXNode(json);
                response.Content = new StringContent(doc.ToString(), Encoding.UTF8, result.MediaType.MediaType);
            }
            else
                response.Content = new StringContent(factualJsonData, Encoding.UTF8, "application/json");

            return response;
        }

        public HttpResponseMessage GetAutoCompleteData(string searchTerm)
        {
            string factualJsonData;
            try
            {
                factualJsonData = repository.GetHealthCareProviderAutocomplete(searchTerm);
            }
            catch (FactualApiException ex)
            {
                throw new HttpResponseException(new HttpResponseMessage { Content = new StringContent(ex.Message) });
            }

            // Get the IContentNegotiator
            IContentNegotiator negotiator = Configuration.Services.GetContentNegotiator();

            // Run content negotiation to select a formatter
            ContentNegotiationResult result = negotiator.Negotiate(
              typeof(string), this.Request, this.Configuration.Formatters);

            var response = new HttpResponseMessage(HttpStatusCode.OK);

            if (result.MediaType.MediaType.Equals("application/xml"))
            {
                string json = string.Format("{0}{1}{2}", "{Root: ", factualJsonData, "}");

                var doc = (XDocument)JsonConvert.DeserializeXNode(json);
                response.Content = new StringContent(doc.ToString(), Encoding.UTF8, result.MediaType.MediaType);
            }
            else
                response.Content = new StringContent(factualJsonData, Encoding.UTF8, "application/json");

            return response;
        }
    }
}
