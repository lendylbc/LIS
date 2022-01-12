using System;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class ApiBase
	{
      public string Request { get; set; }
      public string Response { get; set; }

      public string Base64Encode(string plainText) {
         var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
         return System.Convert.ToBase64String(plainTextBytes);
      }

      protected void AddParamString(ref string paramString, string paramKey, string paramData) {

         if(string.IsNullOrWhiteSpace(paramString)) {
            paramString = string.Format(paramKey, paramData);
         } else {
            paramString += "&" + string.Format(paramKey, paramData);
         }
      }
      protected void LogRequest(RestClient client, RestRequest request, RestResponse response) {
         if(request != null) {
            var requestToLog = new {
               resource = request.Resource,
               // Parameters are custom anonymous objects in order to have the parameter type as a nice string
               // otherwise it will just show the enum value
               parameters = request.Parameters.Select(parameter => new {
                  name = parameter.Name,
                  value = (parameter.Value is byte[]) ? BitConverter.ToString((byte[])parameter.Value).Replace("-", "") : parameter.Value,
                  type = parameter.Type.ToString()
               }),
               // ToString() here to have the method as a nice string otherwise it will just show the enum value
               method = request.Method.ToString(),
               // This will generate the actual Uri used in the request
               uri = client.BuildUri(request),
            };
            Request = JsonConvert.SerializeObject(requestToLog, Formatting.Indented);
         }

         if(request != null) {
            var responseToLog = new {
               statusCode = response.StatusCode,
               content = response.Content,
               headers = response.Headers,
               // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
               responseUri = response.ResponseUri,
               errorMessage = response.ErrorMessage,
            };
            Response = JsonConvert.SerializeObject(responseToLog, Formatting.Indented);
         }
      }
   }
}
