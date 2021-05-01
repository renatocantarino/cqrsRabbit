using CqrsApp.API.Domain;
using System;
using System.Collections.Generic;

namespace CqrsApp.API.Repositories
{
    public class Repository
    {
        public List<Todo> Todos { get; } = new List<Todo>
        {
            new Todo(Guid.Parse("539242BE-3AF4-4059-B60E-07E320B2C29C"), "atv 1" , true),
            new Todo(Guid.NewGuid(), "atv 2" , false),
            new Todo(Guid.NewGuid(), "atv 3" , true),
        };
    }
}