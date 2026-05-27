namespace MzansiPayrollSystem
{
    /// <summary>
    /// Handles all payroll calculations for Mzansi Tech Contractors.
    /// Separates business logic from the UI layer for testability.
    /// </summary>
    public class PayrollCalculator
    {
        // Constants for payroll calculation
        public const double HourlyRate = 950.00;
        public const double UifRate = 0.01;          // 1% of gross pay
        public const double MembershipRate = 0.13;    // 13% of gross pay
        public const double PayeRate = 0.25;          // 25% tax rate
        public const double DependentRelief = 0.0575; // 5.75% relief per dependent
        public const int MaxDependents = 10;          // Maximum allowed dependents

        /// <summary>
        /// Calculates gross pay based on hours worked.
        /// Gross Pay = Hours Worked × Hourly Rate
        /// </summary>
        /// <param name="hoursWorked">Number of hours worked</param>
        /// <returns>Gross pay amount in Rands</returns>
        public double CalculateGrossPay(double hoursWorked)
        {
            if (hoursWorked < 0)
                throw new ArgumentException("Hours worked cannot be negative.");

            return hoursWorked * HourlyRate;
        }

        /// <summary>
        /// Calculates UIF deduction.
        /// UIF = 1% of Gross Pay
        /// </summary>
        /// <param name="grossPay">Gross pay amount</param>
        /// <returns>UIF deduction amount in Rands</returns>
        public double CalculateUif(double grossPay)
        {
            if (grossPay < 0)
                throw new ArgumentException("Gross pay cannot be negative.");

            return grossPay * UifRate;
        }

        /// <summary>
        /// Calculates PAYE deduction using simplified SARS-based rule.
        /// PAYE = (Gross Pay - (Gross Pay × 0.0575 × Number of Dependents)) × 25%
        /// </summary>
        /// <param name="grossPay">Gross pay amount</param>
        /// <param name="numberOfDependents">Number of dependents</param>
        /// <returns>PAYE deduction amount in Rands</returns>
        public double CalculatePaye(double grossPay, int numberOfDependents)
        {
            if (grossPay < 0)
                throw new ArgumentException("Gross pay cannot be negative.");

            if (numberOfDependents < 0)
                throw new ArgumentException("Number of dependents cannot be negative.");

            if (numberOfDependents > MaxDependents)
                throw new ArgumentException($"Number of dependents cannot exceed {MaxDependents}.");

            double taxableAmount = grossPay - (grossPay * DependentRelief * numberOfDependents);
            return taxableAmount * PayeRate;
        }

        /// <summary>
        /// Calculates membership fee deduction.
        /// Membership Fee = 13% of Gross Pay
        /// </summary>
        /// <param name="grossPay">Gross pay amount</param>
        /// <returns>Membership fee amount in Rands</returns>
        public double CalculateMembershipFee(double grossPay)
        {
            if (grossPay < 0)
                throw new ArgumentException("Gross pay cannot be negative.");

            return grossPay * MembershipRate;
        }

        /// <summary>
        /// Calculates total deductions (UIF + PAYE + Membership Fee).
        /// </summary>
        /// <param name="uif">UIF deduction</param>
        /// <param name="paye">PAYE deduction</param>
        /// <param name="membershipFee">Membership fee</param>
        /// <returns>Total deductions in Rands</returns>
        public double CalculateTotalDeductions(double uif, double paye, double membershipFee)
        {
            return uif + paye + membershipFee;
        }

        /// <summary>
        /// Calculates net pay.
        /// Net Pay = Gross Pay − UIF − PAYE − Membership Fee
        /// </summary>
        /// <param name="grossPay">Gross pay amount</param>
        /// <param name="uif">UIF deduction</param>
        /// <param name="paye">PAYE deduction</param>
        /// <param name="membershipFee">Membership fee</param>
        /// <returns>Net pay amount in Rands</returns>
        public double CalculateNetPay(double grossPay, double uif, double paye, double membershipFee)
        {
            return grossPay - uif - paye - membershipFee;
        }
    }
}
