using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace test
{
    public static class HttpClientExtensions
    {
        public static async Task CreatePost(this HttpClient client)
        {
            var response = await client.PostAsJsonAsync($"/posts", new PostRequest { Body = "whatever", Title = "title test", PublishedAt = DateTime.UtcNow, PublishedBy = "admin" });
        }

        public class PostRequest
        {
            public string Body { get; set; }
            public string Title { get; set; }
            public DateTime PublishedAt { get; set; }
            public string PublishedBy { get; set; }
            public byte[] Image { get; set; }
        }
    }
}