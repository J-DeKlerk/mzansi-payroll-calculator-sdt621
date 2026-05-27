namespace MzansiPayrollSystem
{
    /// <summary>
    /// Main payroll form for Mzansi Tech Contractors Payroll System.
    /// Handles user input, validation, and displays calculated payroll results.
    /// </summary>
    public partial class FrmPayroll : Form
    {
        // Instance of the PayrollCalculator class for separated business logic
        private readonly PayrollCalculator _calculator;

        public FrmPayroll()
        {
            InitializeComponent();
            _calculator = new PayrollCalculator();
        }

        /// <summary>
        /// Validates all user input fields before performing calculations.
        /// </summary>
        /// <param name="contractorName">Output: validated contractor name</param>
        /// <param name="hoursWorked">Output: validated hours worked</param>
        /// <param name="dependents">Output: validated number of dependents</param>
        /// <returns>True if all inputs are valid, false otherwise</returns>
        private bool ValidateInput(out string contractorName, out double hoursWorked, out int dependents)
        {
            contractorName = string.Empty;
            hoursWorked = 0;
            dependents = 0;

            // Validate contractor name - must not be empty
            if (string.IsNullOrWhiteSpace(txtContractorName.Text))
            {
                MessageBox.Show("Please enter the contractor's name.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContractorName.Focus();
                return false;
            }
            contractorName = txtContractorName.Text.Trim();

            // Validate hours worked - must be numeric
            if (!double.TryParse(txtHoursWorked.Text, out hoursWorked))
            {
                MessageBox.Show("Please enter a valid numeric value for hours worked.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoursWorked.Focus();
                return false;
            }

            // Validate hours worked - must not be negative
            if (hoursWorked < 0)
            {
                MessageBox.Show("Hours worked cannot be negative.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoursWorked.Focus();
                return false;
            }

            // Validate dependents - must be numeric (integer)
            if (!int.TryParse(txtDependents.Text, out dependents))
            {
                MessageBox.Show("Please enter a valid whole number for dependents.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDependents.Focus();
                return false;
            }

            // Validate dependents - must not be negative
            if (dependents < 0)
            {
                MessageBox.Show("Number of dependents cannot be negative.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDependents.Focus();
                return false;
            }

            // Validate dependents - must not exceed maximum limit (10)
            if (dependents > PayrollCalculator.MaxDependents)
            {
                MessageBox.Show($"Number of dependents cannot exceed {PayrollCalculator.MaxDependents}.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDependents.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Calculate button click handler.
        /// Validates input, performs payroll calculations, and displays results.
        /// </summary>
        private void BtnCalculate_Click(object? sender, EventArgs e)
        {
            // Validate input
            if (!ValidateInput(out string contractorName, out double hoursWorked, out int dependents))
                return;

            try
            {
                // Perform calculations using the PayrollCalculator class
                double grossPay = _calculator.CalculateGrossPay(hoursWorked);
                double uif = _calculator.CalculateUif(grossPay);
                double paye = _calculator.CalculatePaye(grossPay, dependents);
                double membershipFee = _calculator.CalculateMembershipFee(grossPay);
                double totalDeductions = _calculator.CalculateTotalDeductions(uif, paye, membershipFee);
                double netPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

                // Display results formatted as South African Rand
                txtGrossPay.Text = grossPay.ToString("R#,##0.00");
                txtPayeDeduction.Text = paye.ToString("R#,##0.00");
                txtUifDeduction.Text = uif.ToString("R#,##0.00");
                txtMembershipFee.Text = membershipFee.ToString("R#,##0.00");
                txtTotalDeductions.Text = totalDeductions.ToString("R#,##0.00");
                txtNetPay.Text = netPay.ToString("R#,##0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during calculation: {ex.Message}",
                    "Calculation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset button click handler.
        /// Clears all input and output fields.
        /// </summary>
        private void BtnReset_Click(object? sender, EventArgs e)
        {
            // Clear input fields
            txtContractorName.Clear();
            txtHoursWorked.Clear();
            txtDependents.Clear();

            // Clear output fields
            txtGrossPay.Clear();
            txtPayeDeduction.Clear();
            txtUifDeduction.Clear();
            txtMembershipFee.Clear();
            txtTotalDeductions.Clear();
            txtNetPay.Clear();

            // Set focus to the first input field
            txtContractorName.Focus();
        }

        /// <summary>
        /// Exit button click handler.
        /// Closes the application with confirmation.
        /// </summary>
        private void BtnExit_Click(object? sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
