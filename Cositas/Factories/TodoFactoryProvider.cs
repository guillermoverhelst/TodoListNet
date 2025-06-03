namespace Cositas.Factories
{
    public class TodoFactoryProvider
    {
        private readonly Dictionary<string,ITodoFactory> _factories;
        public TodoFactoryProvider() {
            _factories = new Dictionary<string, ITodoFactory>(StringComparer.OrdinalIgnoreCase) {
                {"personal", new TodoPersonalFactory() },
                {"work", new TodoWorkFactory()}
            };
        }

        public ITodoFactory GetFactory(string Type) { 
            if (_factories.TryGetValue(Type, out var factory)) return factory;

            throw new ArgumentException($"Todo type is not supporting: {Type}");
              
        }
    }
}
