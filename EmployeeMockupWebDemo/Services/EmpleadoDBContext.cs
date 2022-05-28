using EmployeeMockupWebDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Services
{
    public class EmpleadoDBContext : DbContext
    {
        public DbSet<Empleados> Empleado { get; set; }

        public EmpleadoDBContext(DbContextOptions<EmpleadoDBContext> options) : base(options)
        { }
    }
}
