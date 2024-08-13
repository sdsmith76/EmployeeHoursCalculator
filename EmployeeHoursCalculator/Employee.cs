namespace EmployeeHoursCalculator.Employee
{
    /// <summary>
    /// Abstract class representing shared Employee functionality
    /// </summary>
    public abstract class Employee
    {
        private double _vacationAccumulationFactor;
        protected const int _maxDaysInYear = 260;

        /// <summary>
        /// Vacation days accrued
        /// </summary>
        public double VacationDays
        {
            get; protected set;
        }

        /// <summary>
        /// Factor by which vacation days accrue relative to days worked
        /// </summary>
        protected double VacationAccumulationFactor
        {
            get
            {
                return _vacationAccumulationFactor;
            }
            set
            {
                _vacationAccumulationFactor = value / _maxDaysInYear;
            }
        }
        


        /// <summary>
        /// Updates total of vacation days accrued by working
        /// </summary>
        /// <param name="days">days worked for vacation accrual</param>
        /// <exception cref="ArgumentOutOfRangeException">inputs must be positive, and at most the days worked in a full year</exception>
        public virtual void Work(int days)
        {
            if (days < 0 || days > _maxDaysInYear)
            {
                throw new ArgumentOutOfRangeException("Days must be a value between 0 and 260");
            }

            VacationDays += days * VacationAccumulationFactor;
        }

        /// <summary>
        /// Updates total of vacation days after some are used 
        /// </summary>
        /// <param name="daysUsed">vacation days to be deducted</param>
        /// <exception cref="ArgumentOutOfRangeException">inputs must be positive, and not exceeding total accrued vacation</exception>
        public virtual void TakeVacation(double daysUsed)
        {
            if (daysUsed > VacationDays)
            {
                throw new ArgumentOutOfRangeException("Cannot use more vacation days than have been accrued");
            }
            if (daysUsed < 0 || double.IsNaN(daysUsed))
            {
                throw new ArgumentOutOfRangeException("Days used must be a positive number");
            }

            VacationDays -= daysUsed;
        }
    }

    /// <summary>
    /// Class representing an hourly employee for vacation accrual
    /// </summary>
    public class HourlyEmployee: Employee
    {
        private const double _maxAnnualVacationDays = 10;

        public HourlyEmployee()
        {
            VacationAccumulationFactor = _maxAnnualVacationDays;
        }
    }

    /// <summary>
    /// Class representing a salaried employee for vacation accrual
    /// </summary>
    public class SalariedEmployee: Employee
    {
        private const double _maxAnnualVacationDays = 15;
        public SalariedEmployee()
        {
            VacationAccumulationFactor = _maxAnnualVacationDays;
        }

        protected SalariedEmployee(double vacationAccumulationFactor)
        {
            VacationAccumulationFactor = vacationAccumulationFactor;
        }
    }

    /// <summary>
    /// Class representing a manager for vacation accrual
    /// </summary>
    public class Manager: SalariedEmployee
    {
        private const double _maxAnnualVacationDays = 30;
        public Manager() : base(_maxAnnualVacationDays)
        {
            
        }
    }
}