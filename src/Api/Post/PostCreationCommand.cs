using System;
using MediatR;

namespace Gangueame.Api
{
    public class PostCreationCommand : IRequest<bool>
    {
        private PostCreationCommand(string body, string title, DateTime publishedAt, string publishedBy, byte[] image)
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

        public static PostCreationCommand Of(string body, string title, DateTime publishedAt, string publishedBy, byte[] image)
        {
            return new PostCreationCommand(body, title, publishedAt, publishedBy, image);
        }
    }
}