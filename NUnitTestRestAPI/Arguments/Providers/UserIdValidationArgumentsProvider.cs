using NUnitTestRestAPI.Arguments.Holders;
using RestSharp;
using System.Net;
using System.Collections;


namespace NUnitTestRestAPI.Arguments.Providers
{
    public class UserIdValidationArgumentsProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[]
            {
                new ValidationArgumentHolder
                {
                    ErrorMessage="",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParameters = Parameter.CreateParameter("Id",-10,ParameterType.UrlSegment)
                }
            };

            yield return new object[]
           {
                new ValidationArgumentHolder
                {
                    ErrorMessage="",
                    StatusCode = HttpStatusCode.NotFound,
                    PathParameters = Parameter.CreateParameter("Id",int.MinValue,ParameterType.UrlSegment)
                }
           };

            for (int i = 1; i < 20; i++)
            {
                yield return new object[]     
                {
                    new ValidationArgumentHolder
                    {
                        ErrorMessage="",
                        StatusCode = HttpStatusCode.OK,
                        PathParameters = Parameter.CreateParameter("Id",i,ParameterType.UrlSegment)
                    }
                };
            }
        }
    }
}
