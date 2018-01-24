using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Mvc
{
    public static class GenelDegiskenler
    {

        public static HttpClient WepApiClient = new HttpClient();

        static    GenelDegiskenler()
        {
            WepApiClient.BaseAddress = new Uri("http://localhost:56857/api/Calisan");
            WepApiClient.DefaultRequestHeaders.Clear();
            WepApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json") );


        }
    }
}