using System;

namespace CqrsApp.API.Domain
{
    public class Todo
    {
        public Todo()
        {
        }

        public Todo(Guid id, string name, bool completed)
        {
            this.Id = id;
            this.Name = name;
            this.Completed = completed;
        }

        public Todo(string name)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Completed = false;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}