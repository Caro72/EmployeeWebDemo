using EmployeeMockupWebDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMockupWebDemo.Services
{
    public interface IEmpleadosData
    {
        IEnumerable<Empleados> GetAll();
        Empleados Get(int id);
        void Add(Empleados newEmpleado);

        void Delete(Empleados deleteEmpleado);
        int Commit();
    }


    public class SqlEmpleadoData : IEmpleadosData
    {
        private EmpleadoDBContext _context;

        public SqlEmpleadoData(EmpleadoDBContext context)
        {
            _context = context;
        }

        public void Add(Empleados newEmpleado)
        {
            _context.Add(newEmpleado);
        }

        public Empleados Get(int id)
        {
            return _context.Empleado.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Empleados> GetAll()
        {
            return _context.Empleado.ToList();
        }

        public void Delete(Empleados deleteEmpleado)
        {
            _context.Attach(deleteEmpleado);
            _context.Remove(deleteEmpleado);
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
