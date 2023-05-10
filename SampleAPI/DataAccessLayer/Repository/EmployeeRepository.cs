using SampleAPI.DataAccessLayer.Context;
using SampleAPI.DataAccessLayer.Interface;
using SampleAPI.DataAccessLayer.Models;

namespace SampleAPI.DataAccessLayer.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly DataContext _dataContext;

        public EmployeeRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;
        }

        public bool AddEmployee(Employee employee)
        {
            if (_dataContext.M_Employee == null)
                return false;

            if(_dataContext.M_Employee.Any(x=>x.Id== employee.Id)) {  return false; }

            _dataContext.M_Employee.Add(employee);
            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteEmployee(Employee employee)
        {
            if (_dataContext.M_Employee == null)
                return false;

            if (!_dataContext.M_Employee.Any(x => x.Id == employee.Id)) { return false; }

            _dataContext.M_Employee.Remove(employee);
            _dataContext.SaveChanges();
            return true;
        }

        public Employee GetEmployeeById(int id)
        {
            if (_dataContext.M_Employee == null)
                return null;

            return _dataContext.M_Employee.FirstOrDefault(x => x.Id == id);
        }

        public IList<Employee> GetEmployees()
        {
            if (_dataContext.M_Employee == null)
                return new List<Employee>();

            return _dataContext.M_Employee.ToList();
        }

        public bool UpdateEmployee(Employee employee)
        {
            if (_dataContext.M_Employee == null)
                return false;

            if (!_dataContext.M_Employee.Any(x => x.Id == employee.Id)) { return false; }

            _dataContext.M_Employee.Update(employee);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
