﻿using System;
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
        public const int FRESHNESS_DAYS_THERESHOLD = 5;

        public List<DataSource> DataSources { get; private set; }
        public DataSource SelectedDataSource { get; set; }
        public TimeSpan FreshnessTimeTreshold { get; set; }

        /// <summary>
        /// Initialize ExternalDataManager
        /// </summary>
        /// <returns></returns>
        public Response Initialize()
        {
            DataSources = new List<DataSource>();
            FreshnessTimeTreshold = new TimeSpan(FRESHNESS_DAYS_THERESHOLD, 0, 0, 0);

            // Load available data sources from json file and return response
            return LoadAvailableDataSources(CONFIG_FILE);
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
                if (responseMessage.IsSuccessStatusCode)
                {
                    using (StreamWriter destinationStream = File.CreateText(destinationFile))
                    {
                        await destinationStream.WriteAsync(responseMessage.Content.ReadAsStringAsync().Result);
                    }
                }
                response.Status = responseMessage.StatusCode.ToString();
                response.IsSuccessStatus = responseMessage.IsSuccessStatusCode;
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
                if (responseMessage.IsSuccessStatusCode)
                {
                    response.Content = await responseMessage.Content.ReadAsStringAsync();
                }
                response.Status = responseMessage.StatusCode.ToString();
                response.IsSuccessStatus = responseMessage.IsSuccessStatusCode;
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

                response.Content = await responseMessage.Content.ReadAsStringAsync();
                response.Status = responseMessage.StatusCode.ToString();
                response.IsSuccessStatus = responseMessage.IsSuccessStatusCode;
            }
            return response;
        }

        /// <summary>
        /// Loads all data sources from json file
        /// </summary>
        /// <param name="fileName"></param>
        private Response LoadAvailableDataSources(string fileName)
        {
            Response response = new Response();

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
                        response.IsSuccessStatus = true;
                    }
                    catch (Exception ex)
                    {
                        response.IsSuccessStatus = false;
                        response.Status = "Failed";
                        response.Content = ex.Message.ToString();
                    }
                }
            }
            return response;
        }
    }
}