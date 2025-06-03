using Cositas.Models;
using Microsoft.EntityFrameworkCore;

namespace Cositas.DataAccess
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) { 
        
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
