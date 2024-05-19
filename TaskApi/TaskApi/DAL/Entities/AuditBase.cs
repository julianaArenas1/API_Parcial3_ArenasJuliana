using System.ComponentModel.DataAnnotations;

namespace TaskApi.DAL.Entities
{
    public class AuditBase
    {
        [Key]
        public virtual Guid Id { get; set; } //PK
        public virtual DateTime? DueDate { get; set; } //Fecha de vencimiento de la tarea
        public virtual DateTime? CreatedDate { get; set; } //Fecha creación de la tarea
        public virtual DateTime? CompletionDate { get; set; } //Fecha finalización de la tarea
    }
}
