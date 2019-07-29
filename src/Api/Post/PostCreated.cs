using System;

namespace Gangueame.Api
{
    public class PostCreated
    {
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime PublishedAt { get; set; }
        public string PublishedBy { get; set; }
        public byte[] Image { get; set; }
    }
}