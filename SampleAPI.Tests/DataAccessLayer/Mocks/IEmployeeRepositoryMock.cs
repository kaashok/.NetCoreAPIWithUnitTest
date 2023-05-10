using Microsoft.AspNetCore.Identity;
using SampleAPI.DataAccessLayer.Context;
using SampleAPI.DataAccessLayer.Interface;
using SampleAPI.DataAccessLayer.Models;
using SampleAPI.DataAccessLayer.Repository;
using SampleAPI.Tests.DataAccessLayer.ContextMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPI.Tests.DataAccessLayer.Mocks
{
    public class IEmployeeRepositoryMock
    {
        public static IEmployeeRepository GetMock()
        {
            List<Employee> lstUser = GenerateTestData();
            DataContext dbContextMock = DbContextMock.GetMock<Employee, DataContext>(lstUser, x => x.M_Employee);
            return new EmployeeRepository(dbContextMock);
        }

        private static List<Employee> GenerateTestData()
        {
            List<Employee> lstUser = new();
            Random rand = new Random();
            for (int index = 1; index <= 10; index++)
            {                
                lstUser.Add(new Employee
                {
                    Id = index,
                    Name = "User-" + index,
                    Age = rand.Next(1, 100)

                });
            }
            return lstUser;
        }
    }
}
