using System.ComponentModel.DataAnnotations;

namespace TaskApi.DAL.Entities
{
    public class Task : AuditBase
    {
        [Display(Name = "Título")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Title { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caracteres.")]
        public string Description { get; set; }

        [Display(Name = "Completado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string IsCompleted { get; set; }

        [Display(Name = "Prioridad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Priority { get; set; }
    }
}
