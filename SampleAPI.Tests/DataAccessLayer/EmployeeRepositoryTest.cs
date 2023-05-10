using SampleAPI.DataAccessLayer.Interface;
using SampleAPI.DataAccessLayer.Models;
using SampleAPI.Tests.DataAccessLayer.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Tests.DataAccessLayer
{
    public class EmployeeRepositoryTest
    {
        private IEmployeeRepository employeeRepository;

        [SetUp]
        public void SetUp()
        {
            employeeRepository = IEmployeeRepositoryMock.GetMock();
        }

        [Test]
        public void GetEmployees()
        {
            //Arrange


            //Act
            IList<Employee> lstData = employeeRepository.GetEmployees();


            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(lstData, Is.Not.Null);
                Assert.That(lstData.Count, Is.GreaterThan(0));
            });
        }

        [Test]
        public void GetEmployeeById()
        {
            //Arrange
            int id = 1;

            //Act
            Employee data = employeeRepository.GetEmployeeById(id);            

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.Not.Null);
                Assert.That(data.Id, Is.EqualTo(id));
            });
        }

        [Test]
        public void AddEmployee()
        {
            //Arrange
            Employee employee = new Employee()
            {
                Id = 100,
                Name = "New User",
                Age = 10
            };

            //Act
            bool data = employeeRepository.AddEmployee(employee);
            Employee expectedData = employeeRepository.GetEmployeeById(employee.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Not.Null);
                Assert.That(expectedData.Id,Is.EqualTo(expectedData.Id));
            });
        }

        [Test]
        public void UpdateEmployee()
        {
            //Arrange
            int id = 2;
            Employee actualData = employeeRepository.GetEmployeeById(id);
            actualData.Name = "Update User";
            actualData.Age = 1500;

            //Act
            bool data = employeeRepository.UpdateEmployee(actualData);
            Employee expectedData = employeeRepository.GetEmployeeById(actualData.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Not.Null);
                Assert.That(expectedData, Is.EqualTo(actualData));
            });
        }

        [Test]
        public void DeleteEmployee()
        {
            //Arrange
            int id = 2;
            Employee actualData = employeeRepository.GetEmployeeById(id);
            

            //Act
            bool data = employeeRepository.DeleteEmployee(actualData);
            Employee expectedData = employeeRepository.GetEmployeeById(actualData.Id);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(data, Is.True);
                Assert.That(expectedData, Is.Null);                
            });
        }
    }
}
