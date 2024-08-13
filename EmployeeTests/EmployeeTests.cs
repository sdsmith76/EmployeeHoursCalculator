using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeHoursCalculator.Employee;

namespace EmployeeTests
{
    public class EmployeeTests
    {
        [Fact]
        public void Employee_MaxVacationNotSet_Exception()
        {
            //setup
            Employee testEmployee = new TestEmployee();
            int testDaysWorked = 5;

            //assert
            Assert.Throws<InvalidOperationException>(
                    () => testEmployee.Work(testDaysWorked)
                );
        }

    }

    public class TestEmployee : Employee
    {
        public TestEmployee() { }
    }
}
