using System;
using System.Linq;

using EntitiesLayer;

using RestSharp;

namespace ServiceLayer
{
    public class MathWebClient : IMathWebClient
    {
        private readonly ILoggerManager _loggerManager;
        private readonly IRestClient _restClient;

        public MathWebClient(ILoggerManager loggerManager)
        {
            _restClient = new RestClient("http://api.mathweb.com/");
            _loggerManager = loggerManager;
        }

        public int Add(int a, int b)
        {
            var sum = _restClient.Get(new RestRequest($"add?a={a}&b={b}", Method.GET)).Content;
            var result = _loggerManager.Insert($"a+b = {sum}");

            if (sum.All(char.IsDigit)) return Convert.ToInt32(sum);

            return a + b;
        }

        public int Divide(int a, int b)
        {
            var quotient = _restClient.Get(new RestRequest($"divide?a={a}&b={b}", Method.GET)).Content;
            var result = _loggerManager.Insert($"a/b = {quotient}");

            if (quotient.All(char.IsDigit)) return Convert.ToInt32(quotient);

            return a / b;
        }

        public int Multiply(int a, int b)
        {
            var product = _restClient.Get(new RestRequest($"multiply?a={a}&b={b}", Method.GET)).Content;
            var result = _loggerManager.Insert($"a*b = {product}");

            if (product.All(char.IsDigit)) return Convert.ToInt32(product);

            return a * b;
        }
    }
}
