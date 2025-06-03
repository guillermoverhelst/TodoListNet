namespace Cositas.Factories
{
    using Cositas.Models;
    public class TodoPersonalFactory: ITodoFactory
    {
        public TodoItem CreateTodo(string name) {
            return new TodoItem
            {
                Name = name,
                IsComplete = false,
                Type = "personal"
            };
        }
    }
}
