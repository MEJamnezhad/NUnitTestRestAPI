using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestRestAPI.Arguments.Holders
{
    public class ValidationArgumentHolder
    {
        public Parameter? PathParameters { get; set; }

        public HttpStatusCode  StatusCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
