using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using TaskApi.DAL.Entities;
using TaskApi.Domain.Interfaces;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tasks1Controller : Controller
    {
        private readonly ITask1Service _task1Service;

        public Tasks1Controller(ITask1Service task1Service)
        {
            _task1Service = task1Service;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Task1>>> GetTaskAsync()
        {
            var tasks1 = await _task1Service.GetTaskAsync();

            if (tasks1 == null || !tasks1.Any()) return NotFound();

            return Ok(tasks1);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] 
        public async Task<ActionResult<Task1>> GetTaskByIdAsync(Guid id)
        {
            var task1 = await _task1Service.GetTaskByIdAsync(id);

            if (task1 == null) return NotFound(); 

            return Ok(task1); 
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByDueDate/{DueDate}")] 
        public async Task<ActionResult<Task1>> GetTaskByDueDateAsync(DateTime DueDate)
        {
            var task1 = await _task1Service.GetTaskByDueDateAsync(DueDate);

            if (task1 == null) return NotFound(); 

            return Ok(task1); 
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<Task1>> CreateTaskAsync(Task1 task1)
        {
            try
            {
                var newTask1 = await _task1Service.CreateTaskAsync(task1);
                if (newTask1 == null) return NotFound();
                return Ok(newTask1);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", task1.Title));

                return Conflict(ex.Message);
            }
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<Task1>> EditTaskAsync(Task1 task1)
        {
            try
            {
                var editedTask1 = await _task1Service.EditTaskAsync(task1);
                if (editedTask1 == null) return NotFound();
                return Ok(editedTask1);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", task1.Title));

                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<Task1>> DeleteTaskAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedTask1 = await _task1Service.DeleteTaskAsync(id);

            if (deletedTask1 == null) return NotFound();

            return Ok("Borrado satisfactoriamente");

        }
    }
}