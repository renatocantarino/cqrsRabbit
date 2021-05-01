using CqrsApp.API.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsApp.API.Queries
{
    public class GetAll
    {
        public record Query() : IRequest<Response>;
        public record Response(object data, bool sucess);

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository _repository;

            public Handler(Repository repository)
            {
                this._repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var todos = _repository.Todos.ToList();

                return todos == null ? null : new Response(todos, true);
            }
        }
    }
}