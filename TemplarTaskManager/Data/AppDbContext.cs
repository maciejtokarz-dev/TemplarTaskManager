using Microsoft.EntityFrameworkCore;
using TemplarTaskManager.Models;

namespace TemplarTaskManager.Data

{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}
