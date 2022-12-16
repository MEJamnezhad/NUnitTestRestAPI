using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestRestAPI.Const
{
    public class UrlParamValues
    {
        public static string BaseAddress = @"http://127.0.0.1:5186/api/";

        public static string UserGetAll = "users/all";
        public static string UserGetAllByPaging = "users";
        public static string UserGetById = "users/{Id}";


    }
}
