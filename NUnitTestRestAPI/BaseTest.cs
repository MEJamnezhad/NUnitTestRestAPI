using NUnitTestRestAPI.Const;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestRestAPI
{
    public class BaseTest
    {
        protected static RestClient client;
        [OneTimeSetUp]
        public void Setup()
        {
            client = new RestClient(UrlParamValues.BaseAddress);
        }

    }
}
