using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.DAL
{
    public class TaskContext : DbContext
    {
        // Constructer
        public TaskContext(DbContextOptions<TaskContext> o) : base(o)
        {
            Database.EnsureCreated();
        }
        // Tasks Table
        public DbSet<Task> Tasks { get; set; }
        // Task Priorities table
        public DbSet<TaskPriority> TaskPriorities { get; set; }
    }
}
