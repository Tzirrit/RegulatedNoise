using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalData
{
    public enum ContentType
    {
        None,   // expect anything or nothing
        JSON,   // expect content string to be valid json
        HTML    // expect content string to be valid html
    }

    public class Response
    {
        public string Status { get; private set; }
        public string Content { get; private set; }
        public ContentType ContentType { get; private set; }
    }
}