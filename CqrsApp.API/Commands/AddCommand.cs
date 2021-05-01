using CqrsApp.API.Domain;
using CqrsApp.API.Messaging.Sender;
using CqrsApp.API.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CqrsApp.API.Commands
{
    public class AddTodo
    {
        public record Command(string Name) : IRequest<Todo>;

        public class Handler : IRequestHandler<Command, Todo>
        {
            private readonly Repository _repository;
            private readonly ITodoSender _sender;

            public Handler(Repository repository, ITodoSender sender)
            {
                this._repository = repository;
                this._sender = sender;
            }

            public async Task<Todo> Handle(Command request, CancellationToken cancellationToken)
            {
                var item = new Todo(request.Name);
                _repository.Todos.Add(item);
                _sender.Send(item);

                return item;
            }
        }
    }
}