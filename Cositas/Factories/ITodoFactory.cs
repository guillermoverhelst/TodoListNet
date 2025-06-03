namespace Cositas.Factories
{
    using Cositas.Models;
    public interface ITodoFactory
    {
        TodoItem CreateTodo(string Name);
    }
}
