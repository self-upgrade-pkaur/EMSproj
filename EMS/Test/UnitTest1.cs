using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EmployeeLib.Abstractions;
using System.Linq;
using EMS_Data.Repository;
using EMS_Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Test
{
    [TestClass]
    public class EmployeeRepositoryTest_WithMockData_WithRealData
    {
        [TestMethod]
        public void GetEmployees_TypeofEmployees_WithMockData()
        {
            // Arrange
            IRepositoryEmployee<EmployeeLib.Employee> mockRepository = new MockRepository();
            
            // Act
            var emp=mockRepository.GetEmployees();
            // Assert -> checking the type of the repo
            Assert.AreEqual(typeof(List<EmployeeLib.Employee>), emp.GetType());
            }
        [TestMethod]
        public void GetEmployees_TypeofEmployees_WithRealData()
        {
            // Arrange
            IRepositoryEmployee<EmployeeLib.Employee> realRepository = new RepositoryEmployee();
            EmployeeController controller = new EmployeeController(realRepository);
            var result = controller.Index() as ViewResult;
            var modelType=result.Model.GetType();
            Assert.AreEqual(typeof(IQueryable), modelType.GetType());

            // Act
            var emp = realRepository.GetEmployees();
            // Assert -> checking the type of the repo
            Assert.AreEqual(typeof(List<EmployeeLib.Employee>), emp.GetType());
        }
        [TestMethod]
        public void GetEmployees_Fullname_WithMockData()
        {
            // Arrange
            MockRepository mockRepository = new MockRepository();
            // Act
            var emp = mockRepository.GetEmployees();
            // Assert -> checking the tfull name
            Assert.AreEqual("Carol Baxtor", emp.First().FullName);
        }
    }
}
