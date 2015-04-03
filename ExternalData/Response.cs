using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalData
{
    public enum ContentTypes
    {
        Empty,      // no content   
        JSON,       // expect content string to be valid json
        HTML,       // expect content string to be valid html
        Undefined   // expect anything or nothing
    }

    public class Response
    {
        public string Status { get; set; }

        string content;
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                if (value != null && value.Length > 0)
                {
                    this.ContentType = ContentTypes.Undefined;
                }
                else
                {
                    this.ContentType = ContentTypes.Empty;
                }
            }
        }

        public ContentTypes ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Response()
        {
            ContentType = ContentTypes.Empty;
        }
    }
}