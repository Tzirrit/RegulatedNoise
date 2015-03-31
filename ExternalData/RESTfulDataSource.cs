using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ExternalData
{
    public class RESTfulDataSource : IDataSource
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public Header AuthenticationHeader { get; set; }

        /// <summary>
        /// Test connection to given requestPath for set Url and AuthenticationHeader
        /// </summary>
        /// <param name="requestPath"></param>
        /// <returns></returns>
        public async Task<string> TestAuthentication(string requestPath)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                // Add authentication header
                client.DefaultRequestHeaders.Add(AuthenticationHeader.Name, AuthenticationHeader.Value);

                // Add an Accept header for JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make GET call and handle response
                HttpResponseMessage response = await client.GetAsync(requestPath);
                return response.StatusCode.ToString();
            }
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="requestPath"></param>
       /// <param name="destinationFile"></param>
       /// <returns></returns>
        public async Task<string> GetDataAndSaveToFileAsync(string requestPath, string destinationFile)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                // Add authentication header
                client.DefaultRequestHeaders.Add(AuthenticationHeader.Name, AuthenticationHeader.Value);

                // Add an Accept header for JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make GET call and handle response
                HttpResponseMessage response = await client.GetAsync(requestPath);
                if (response.IsSuccessStatusCode)
                {
                    using (StreamWriter destinationStream = File.CreateText(destinationFile))
                    {
                        await destinationStream.WriteAsync(response.Content.ReadAsStringAsync().Result);
                    }
                }
                return response.StatusCode.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<string> PostDataAsync(string requestPath, string json)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(Url);

                // Add authentication & content header
                client.DefaultRequestHeaders.Add(AuthenticationHeader.Name, AuthenticationHeader.Value);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make POST call and handle response
                HttpResponseMessage response = await client.PostAsync(
                    requestPath,
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));

                return response.StatusCode.ToString();
            }
        }
    }
}
