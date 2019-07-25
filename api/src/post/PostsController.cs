using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace gangueame.api
{
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("posts")]
        public IActionResult CreateNewPost(PostRequest request)
        {
            _mediator.Send(PostsCommand.Of(request.Body, request.Title, request.PublishedAt, request.PublishedBy, request.Image));

            return Ok();
        }
    }
}