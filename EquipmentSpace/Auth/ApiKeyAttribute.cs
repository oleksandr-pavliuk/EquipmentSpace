using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;
using EquipmentSpace.Models;

namespace EquipmentSpace.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter
    {
        private const string API_KEY_HEADER_NAME = "X-API-Key";
        //System.IO.FileNotFoundException: 'Could not find file 'D:\apiKey.json'.'
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var submittedApiKey = GetSubmittedApiKey(context.HttpContext);
            ApiKey apiKey = new ApiKey();
            using (StreamReader sr = new StreamReader("./apiKey.json"))
            {
                var json = sr.ReadToEnd();
                apiKey = JsonConvert.DeserializeObject<ApiKey>(json);
            }

            if (!IsApiKeyValid(apiKey.Key, submittedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private static string GetSubmittedApiKey(HttpContext context)
        {
            return context.Request.Headers[API_KEY_HEADER_NAME];
        }

        private static bool IsApiKeyValid(string apiKey, string submittedApiKey)
        {
            if (string.IsNullOrEmpty(submittedApiKey)) return false;

            return apiKey.Equals(submittedApiKey) ? true : false ;
        }
    }
}
