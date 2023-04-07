using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using WebApp.DAL;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/Tasks
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(_taskRepository.GetAll());
        }

        // GET api/Tasks/5
        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            return new OkObjectResult(_taskRepository.GetTaskById(id));
        }

        // POST api/Tasks
        [HttpPost]
        public IActionResult CreatNewTask([FromBody] Task task)
        {
            using (var scope = new TransactionScope())
            {
                _taskRepository.Insert(task);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
            }
        }

        // PUT api/Tasks/5
        [HttpPut("{id}")]
        public IActionResult UpdateTask([FromBody] Task task)
        {
            if(task != null)
            {
                using (var scope = new TransactionScope())
                {
                    _taskRepository.Update(task);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/Tasks/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskRepository.Delete(id);
            return new OkResult();
        }
    }
}
