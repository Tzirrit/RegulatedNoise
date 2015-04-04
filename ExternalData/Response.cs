using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ExternalData
{
    public class Response
    {
        /// <summary>
        /// String describing the response status (e.g. HTTP status phrase).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Wether or not the request leading to the response was successful.
        /// </summary>
        public bool IsSuccessStatus { get; set; }

        /// <summary>
        /// String containg the response content (e.g. JSON encoded, raw text, etc.).
        /// </summary>
        public string Content { get; set; }
    }
}