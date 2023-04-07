using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.DAL
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _dbContext;
        public TaskRepository(TaskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int Id)
        {
            var task = _dbContext.Tasks.Find(Id);
            _dbContext.Tasks.Remove(task);
            Save();
        }

        public IEnumerable<Task> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }

        public Task GetTaskById(int Id)
        {
            return _dbContext.Tasks.Find(Id);
        }

        public void Insert(Task task)
        {
            _dbContext.Add(task);
            Save();
        }

        public void Update(Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
