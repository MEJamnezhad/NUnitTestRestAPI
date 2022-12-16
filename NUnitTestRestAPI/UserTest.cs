using NUnit.Framework;
using NUnitTestRestAPI.Arguments.Holders;
using NUnitTestRestAPI.Arguments.Providers;
using NUnitTestRestAPI.Const;
using RestSharp;
using System.Net;

namespace NUnitTestRestAPI
{
    public class UserTest : BaseTest
    {
        

        [Test]
        public void TestGetAllUsersWithpagination()
        {
            RestRequest request = new RestRequest(UrlParamValues.UserGetAllByPaging);
            request.AddQueryParameter("size", "0");
            request.AddQueryParameter("page", "1");
            Console.WriteLine($"{request.Method} {client.Options.BaseUrl}{request.Resource}");
            var response = client.Get(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void TestGetAllUsers()
        {
            RestRequest request = new RestRequest(UrlParamValues.UserGetAll);
            Console.WriteLine($"{request.Method} {client.Options.BaseUrl}{request.Resource}");
            var response = client.Get(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void TestGetByRandomId()
        {
            RestRequest request = new RestRequest(UrlParamValues.UserGetById);
            Random random = new Random();

            int rand = random.Next(-10, int.MaxValue);


            request.AddUrlSegment("Id", rand);
            var response = client.Get(request);

            Assert.IsNotNull(response);
            Assert.That((HttpStatusCode.OK == response.StatusCode) || (HttpStatusCode.NotFound == response.StatusCode));
            // Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Console.WriteLine($"{request.Method} {response.StatusCode.ToString()} {response.ResponseUri}");
        }


        [Test]
        public void TestGetByError()
        {
            RestRequest request = new RestRequest(UrlParamValues.UserGetById);

            request.AddUrlSegment("Id", -10);
            var response = client.Get(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Console.WriteLine($"{request.Method} {response.StatusCode.ToString()} {response.ResponseUri}");
        }


        // 
        [Test]
        [TestCaseSource(typeof(UserIdValidationArgumentsProvider))]
        public void TestGetIDByError(ValidationArgumentHolder validationArgument)
        {
            RestRequest request = new RestRequest(UrlParamValues.UserGetById);

            request.AddOrUpdateParameter(validationArgument.PathParameters);
            var response = client.Get(request);

            Assert.IsNotNull(response);
            Assert.That(validationArgument.StatusCode == response.StatusCode);
            Assert.True(response.Content.Contains(validationArgument.ErrorMessage));
            Console.WriteLine($"{request.Method} {response.StatusCode.ToString()} {response.ResponseUri}");
        }

    }
}
