using System;
using MediatR;

namespace Gangueame.Api
{
    public class PostsCommand : IRequest<bool>
    {
        private PostsCommand(string body, string title, DateTime publishedAt, string publishedBy, byte[] image)
        {
            Body = body;
            Title = title;
            PublishedAt = publishedAt;
            PublishedBy = publishedBy;
            Image = image;
        }

        public string Body { get; }
        public string Title { get; }
        public DateTime PublishedAt { get; }
        public string PublishedBy { get; }
        public byte[] Image { get; }

        public static PostsCommand Of(string body, string title, DateTime publishedAt, string publishedBy, byte[] image)
        {
            return new PostsCommand(body, title, publishedAt, publishedBy, image);
        }
    }
}