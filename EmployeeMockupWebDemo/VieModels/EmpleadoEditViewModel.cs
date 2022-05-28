using EmployeeMockupWebDemo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.VieModels
{
    public class EmpleadoEditViewModel
    {
        [Required, MaxLength(30)]
        public string Nombre { get; set; }
        [Required, MaxLength(30)]
        public string Apellidos { get; set; }
        [Required]
        public int Cedula { get; set; }
        public Departamentos Departamento { get; set; }
        [Required, EmailAddress]
        public string Correo { get; set; }
        [Required]
        public int Telefono { get; set; }
    }
}
