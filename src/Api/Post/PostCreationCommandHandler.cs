using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Gangueame.Api
{
    public class PostCreationCommandHandler : IRequest<bool>
    {
        public Task<bool> Handle(PostCreationCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}