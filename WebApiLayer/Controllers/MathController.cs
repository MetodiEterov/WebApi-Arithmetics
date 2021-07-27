using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using EntitiesLayer;

namespace WebApiLayer.Controllers
{
    /// <summary>
    /// This class contains arithmetics methods
    /// </summary>
    public class MathController : ApiController
    {
        private readonly IMathWebClient _mathWebClient;

        public MathController(IMathWebClient mathWebClient)
        {
            _mathWebClient = mathWebClient;
        }

        /// <summary>
        /// This method adds two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public HttpResponseMessage Add(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(_mathWebClient.Add(a, b)))
            };

            return response;
        }

        /// <summary>
        /// This method divides two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public HttpResponseMessage Divide(int a, int b)
        {
            if (a == 0 || b == 0) return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Convert.ToString(_mathWebClient.Divide(a, b)))
            };

            return response;
        }

        /// <summary>
        /// This method mulyiplies two numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
