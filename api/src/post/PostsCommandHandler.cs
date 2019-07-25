using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace gangueame.api
{
    public class PostsCommandHandler : IRequest<bool>
    {
        public Task<bool> Handle(PostsCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}