using CqrsApp.API.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsApp.API.Queries
{
    public static class GetTodosById
    {
        public record Query(Guid id) : IRequest<Response>;
        public record Response(object data, bool sucess);

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository _repository;

            public Handler(Repository repository) => this._repository = repository;

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var todos = _repository.Todos.FirstOrDefault(x => x.Id == request.id);

                return todos == null ? null : new Response(todos, true);
            }
        }
    }
}