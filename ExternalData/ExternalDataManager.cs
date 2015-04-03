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
    public class ExternalDataManager
    {
        public const string CONFIG_FILE = "datasources.json";
        public List<DataSource> DataSources { get; private set; }
        public DataSource SelectedDataSource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExternalDataManager()
        {
            DataSources = new List<DataSource>();
            // Load available data sources from json file
            LoadAvailableDataSources(CONFIG_FILE);
        }

        /// <summary>
        /// Gets all from requestPath and saves it to destinationFile
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="destinationFile"></param>
        /// <returns></returns>
        public async Task<Response> GetDataAndSaveToFileAsync(string requestPath, string destinationFile)
        {
            Response response = new Response();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(SelectedDataSource.Url);

                // Add authentication header
                client.DefaultRequestHeaders.Add(SelectedDataSource.Authentication.Name, SelectedDataSource.Authentication.Value);

                // Add an Accept header for JSON format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make GET call and handle response
                HttpResponseMessage responseMessage = await client.GetAsync(requestPath);
                response.Status = responseMessage.StatusCode.ToString();
                if (responseMessage.IsSuccessStatusCode)
                {
                    using (StreamWriter destinationStream = File.CreateText(destinationFile))
                    {
                        await destinationStream.WriteAsync(responseMessage.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            return response;
        }

        /// <summary>
        /// Gets all data from requestPath and returns it as Response
        /// </summary>
        /// <param name="requestPath"></param>
        /// <returns></returns>
        public async Task<Response> GetDataAsync(string requestPath)
        {
            Response response = new Response();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(SelectedDataSource.Url);

                // Add authentication & content header
                client.DefaultRequestHeaders.Add(SelectedDataSource.Authentication.Name, SelectedDataSource.Authentication.Value);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make GET call and handle response
                HttpResponseMessage responseMessage = await client.GetAsync(requestPath);
                response.Status = responseMessage.StatusCode.ToString();
                if (responseMessage.IsSuccessStatusCode)
                {
                    response.Content = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

        /// <summary>
        /// Posts given json to requestPath and returns Response
        /// </summary>
        /// <param name="requestPath"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public async Task<Response> PostDataAsync(string requestPath, string json)
        {
            Response response = new Response();

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(SelectedDataSource.Url);

                // Add authentication & content header
                client.DefaultRequestHeaders.Add(SelectedDataSource.Authentication.Name, SelectedDataSource.Authentication.Value);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Make POST call and handle response
                HttpResponseMessage responseMessage = await client.PostAsync(
                    requestPath,
                    new StringContent(json.ToString(), Encoding.UTF8, "application/json"));

                response.Status = responseMessage.StatusCode.ToString();
                response.Content = await responseMessage.Content.ReadAsStringAsync();
                response.ContentType = ContentTypes.JSON;
            }

            return response;
        }

        /// <summary>
        /// Loads all data sources from json file
        /// </summary>
        /// <param name="fileName"></param>
        private void LoadAvailableDataSources(string fileName)
        {
            string sourceFile = Path.GetFullPath(fileName);

            if (File.Exists(sourceFile))
            {
                using (StreamReader streamReader = new StreamReader(sourceFile))
                {
                    try
                    {
                        foreach (var json in JArray.Parse(streamReader.ReadToEnd()))
                        {
                            DataSource dataSource = JsonConvert.DeserializeObject<DataSource>(json.ToString());
                            DataSources.Add(dataSource);
                        }
                    }
                    catch (Exception ex)
                    {
                        // todo: log exception
                    }
                }
            }
        }
    }
}