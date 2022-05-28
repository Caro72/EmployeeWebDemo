using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Entities
{

    public enum Departamentos
    {
        Seleccionar,
        RecursosHumanos,
        Gerencia,
        Produccion,
        Contabilidad,
        Secretaria
    }
    public class Empleados
    {
        public int Id { get; set; }
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