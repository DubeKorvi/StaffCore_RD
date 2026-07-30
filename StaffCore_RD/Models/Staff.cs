using System.ComponentModel.DataAnnotations;

namespace StaffCoreRD.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria")]
        public string Cedula { get; set; } // Formato: 001-0000000-0

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "El departamento es obligatorio")]
        public string Departamento { get; set; } // Tecnología / RRHH / Finanzas / Operaciones

        [Required]
        [Range(23223, double.MaxValue, ErrorMessage = "Mínimo RD$23,223")]
        public decimal Salario { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; } = true;
    }
}