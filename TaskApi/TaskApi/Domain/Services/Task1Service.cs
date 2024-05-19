using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using TaskApi.DAL;
using TaskApi.DAL.Entities;
using TaskApi.Domain.Interfaces;
using System.Linq;
namespace TaskApi.Domain.Services
{
    public class Task1Service : ITask1Service
    {
        private readonly DataContext _context;

        public Task1Service(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Task1>> GetTaskAsync()
        { 
            try
            {
                var tasks1 = await _context.Tasks1
                    .OrderBy(t => t.Priority == "High" ? 1 : (t.Priority == "Medium" ? 2 : 3)).ToListAsync();
                return tasks1;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Task1> GetTaskByIdAsync(Guid id)
        {
            try
            {
                var task1 = await _context.Tasks1.FirstOrDefaultAsync(t => t.Id == id);
                return task1;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<Task1> GetTaskByDueDateAsync(DateTime DueDate)
        {
                // Busca la tarea por la fecha de vencimiento
                var task1 = await _context.Tasks1.FindAsync(DueDate);
                return task1;
        }

        public async Task<Task1> CreateTaskAsync(Task1 task1)
        {
            try
            {
                if (task1.DueDate > DateTime.Now)
                {

                    task1.Id = Guid.NewGuid();
                    task1.CreatedDate = DateTime.Now;
                    _context.Tasks1.Add(task1); 
                    await _context.SaveChangesAsync();
                }
                return null;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Task1> EditTaskAsync(Task1 task1)
        {
            try
            {
                if (task1.IsCompleted)
                {
                    task1.CompletionDate = DateTime.Now;
                }
                task1.ModifiedDate = DateTime.Now;

                _context.Tasks1.Update(task1); //Virtualizo mi objeto
                    await _context.SaveChangesAsync();

                return task1;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Task1> DeleteTaskAsync(Guid id)
        {
            try
            {
                var task1 = await GetTaskByIdAsync(id);

                if (task1 == null)
                {
                    return null;
                }

                _context.Tasks1.Remove(task1); 
                await _context.SaveChangesAsync();

                return task1;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message + "La tarea aún está sin completar"); 
            }
        }
    }
}
