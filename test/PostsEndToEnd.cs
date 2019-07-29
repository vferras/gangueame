using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace test
{
    public class PostsEndToEnd
    {
        private static HttpClient _client;

        public PostsEndToEnd()
        {
            _client = HttpTestHelper.GetClient();
        }

        [Fact]
        public async Task Test()
        {
            await _client.CreatePost();
        }
    }
}
