using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EntitiesLayer;

namespace WebApiLayer.Controllers
{
    public class MathController : ApiController
    {
        private readonly IMathWebClient _mathWebClient;

        public MathController(IMathWebClient mathWebClient)
        {
            _mathWebClient = mathWebClient;
        }

        public HttpResponseMessage Add(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(_mathWebClient.Add(a, b)))
            };

            return response;
        }

        public HttpResponseMessage Divide(int a, int b)
        {
            if (a == 0 || b == 0) return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(_mathWebClient.Divide(a, b)))
            };

            return response;
        }

        public HttpResponseMessage Multiply(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(_mathWebClient.Multiply(a, b)))
            };

            return response;
        }
    }
}
