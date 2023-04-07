using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.DAL
{
    public interface ITaskRepository
    {
        void Insert(Task task);
        void Update(Task task);
        void Delete(int Id);
        Task GetTaskById(int Id);
        IEnumerable<Task> GetAll();
    }
}
