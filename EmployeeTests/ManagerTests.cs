using EmployeeHoursCalculator.Employee;

namespace EmployeeTests.ManagerTests
{
    public class ManagerTests
    {
        [Fact]
        public void Work_Success()
        {
            //setup
            Employee testEmployee = new Manager();
            int testDaysWorked = 130;
            double expected = 30;

            //execute
            testEmployee.Work(testDaysWorked);
            testEmployee.Work(testDaysWorked);

            //assert
            Assert.Equal(expected, testEmployee.VacationDays);
        }

        [Fact]
        public void Work_Over260_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            int testDaysWorked = 261;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => testEmployee.Work(testDaysWorked)
                );
        }

        [Fact]
        public void Work_NegativeValue_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            int testDaysWorked = -1;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => testEmployee.Work(testDaysWorked)
                );
        }

        [Fact]
        public void TakeVacation_Success()
        {
            //setup
            Employee testEmployee = new Manager();
            int testDaysWorked = 130;
            double testVacationDays = 15;
            double expected = 0;

            testEmployee.Work(testDaysWorked);

            //execute
            testEmployee.TakeVacation(testVacationDays);

            //assert
            Assert.Equal(expected, testEmployee.VacationDays);
        }

        [Fact]
        public void TakeVacation_UseUnaccruedVacation_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            double testVacationDays = 5;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => testEmployee.TakeVacation(testVacationDays)
                );
        }

        [Fact]
        public void TakeVacation_NegativeValue_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            double testVacationDays = -5;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                    () => testEmployee.TakeVacation(testVacationDays)
                );
        }

        [Fact]
        public void TakeVacation_NaN_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            double testVacationDays = double.NaN;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testEmployee.TakeVacation(testVacationDays)
            );
        }

        [Fact]
        public void TakeVacation_Infinity_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            double testVacationDays = double.PositiveInfinity;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testEmployee.TakeVacation(testVacationDays)
            );
        }

        [Fact]
        public void TakeVacation_NegInfinity_Exception()
        {
            //setup
            Employee testEmployee = new Manager();
            double testVacationDays = double.NegativeInfinity;

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => testEmployee.TakeVacation(testVacationDays)
            );
        }
    }
}