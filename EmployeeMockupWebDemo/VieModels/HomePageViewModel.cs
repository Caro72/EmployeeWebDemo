using EmployeeMockupWebDemo.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.VieModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Empleados> Empleado { get; set; }
    }
}
