using EmployeeMockupWebDemo.Entities;
using EmployeeMockupWebDemo.Services;
using EmployeeMockupWebDemo.VieModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private IEmpleadosData _empleadoData;

        public HomeController(IEmpleadosData empleadoData)
        {
            _empleadoData = empleadoData;
        }
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Empleado = _empleadoData.GetAll();
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _empleadoData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _empleadoData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, EmpleadoEditViewModel input)
        {
            var empleado = _empleadoData.Get(id);
            if (empleado != null && ModelState.IsValid)
            {
                empleado.Nombre = input.Nombre;
                empleado.Apellidos = input.Apellidos;
                empleado.Cedula = input.Cedula;
                empleado.Departamento = input.Departamento;
                empleado.Correo = input.Correo;
                empleado.Telefono = input.Telefono;

                _empleadoData.Commit();

                return RedirectToAction("Details", new { id = empleado.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmpleadoEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                var empleado = new Empleados();
                empleado.Nombre = model.Nombre;
                empleado.Apellidos = model.Apellidos;
                empleado.Cedula = model.Cedula;
                empleado.Departamento = model.Departamento;
                empleado.Correo = model.Correo;
                empleado.Telefono = model.Telefono;


                _empleadoData.Add(empleado);
                _empleadoData.Commit();

                return RedirectToAction("Details", new { id = empleado.Id });
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var model = _empleadoData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            _empleadoData.Delete(model);
            _empleadoData.Commit();
            return View();
        }
    }
}
