using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace test
{
    public class HttpTestHelper
    {
        private static readonly IHttpClientFactory HttpClientFactory;

        static HttpTestHelper()
        {
            var servicesCollection = new ServiceCollection();

            var registry = servicesCollection.AddPolicyRegistry();

            var retry = Policy<HttpResponseMessage>
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(5, _ => TimeSpan.FromSeconds(5));

            registry.Add("retry", retry);

            servicesCollection
                .AddHttpClient("test")
                .AddPolicyHandlerFromRegistry("retry");

            var serviceProvider = servicesCollection.BuildServiceProvider();

            HttpClientFactory = (IHttpClientFactory)serviceProvider.GetService(typeof(IHttpClientFactory));
        }

        public static HttpClient GetClient()
        {
            return HttpClientFactory.CreateClient("test").SetBaseAddress();
        }
    }

    public static class ExtensionMethods
    {
        public static HttpClient SetBaseAddress(this HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:8080");
            return httpClient;
        }
    }
}