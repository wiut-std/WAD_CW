using System.Threading.Tasks;
using System;

namespace WebApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }
        public string Status { get; set; }
    }
}
