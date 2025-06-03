namespace Cositas.Factories
{
    using Cositas.Models;
    public class TodoWorkFactory:ITodoFactory
    {
        public TodoItem CreateTodo(string name) { 
            return new TodoItem { 
                Name = name,
                IsComplete = false,
                Type = "work"
            };
        }
    }
}
