namespace Cositas.Models
{
    public  class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}
