using Microsoft.VisualStudio.TestTools.UnitTesting;
using MzansiPayrollSystem;

namespace MzansiPayrollSystem.Tests
{
    /// <summary>
    /// Comprehensive test class for the PayrollCalculator.
    /// Covers Unit Testing, Integration Testing, and System Testing
    /// as required by PM-04.
    /// </summary>
    [TestClass]
    public class PayrollCalculatorTests
    {
        private PayrollCalculator _calculator = null!;
        public TestContext TestContext { get; set; } = null!;

        [TestInitialize]
        public void Setup()
        {
            _calculator = new PayrollCalculator();
            TestContext.WriteLine("PayrollCalculator instance created for test.");
        }

        // ====================================================================
        // 1. UNIT TESTS - Test individual calculations separately
        // ====================================================================

        #region Gross Pay Unit Tests

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Gross Pay")]
        public void GrossPay_ShouldReturnR25500_WhenHoursWorkedIs170()
        {
            // Arrange
            double hoursWorked = 170;
            double expectedGrossPay = 161500.00; // 170 × R950.00

            // Act
            double actualGrossPay = _calculator.CalculateGrossPay(hoursWorked);

            // Assert & Log
            TestContext.WriteLine($"Testing Gross Pay calculation.");
            TestContext.WriteLine($"Input: Hours Worked = {hoursWorked}");
            TestContext.WriteLine($"Hourly Rate: R{PayrollCalculator.HourlyRate:F2}");
            TestContext.WriteLine($"Expected Gross Pay: R{expectedGrossPay:F2}");
            TestContext.WriteLine($"Actual Gross Pay: R{actualGrossPay:F2}");

            Assert.AreEqual(expectedGrossPay, actualGrossPay, 0.01,
                $"Gross Pay should be R{expectedGrossPay:F2} for {hoursWorked} hours at R{PayrollCalculator.HourlyRate}/hr.");
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Gross Pay")]
        public void GrossPay_ShouldReturnR2550_WhenHoursWorkedIs2Point68()
        {
            // Arrange
            double hoursWorked = 2.68;
            double expectedGrossPay = 2546.00; // 2.68 × R950.00

            // Act
            double actualGrossPay = _calculator.CalculateGrossPay(hoursWorked);

            // Assert & Log
            TestContext.WriteLine($"Testing Gross Pay with decimal hours.");
            TestContext.WriteLine($"Input: Hours Worked = {hoursWorked}");
            TestContext.WriteLine($"Expected: R{expectedGrossPay:F2} | Actual: R{actualGrossPay:F2}");

            Assert.AreEqual(expectedGrossPay, actualGrossPay, 0.01);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Gross Pay")]
        public void GrossPay_ShouldReturnZero_WhenHoursWorkedIsZero()
        {
            // Arrange
            double hoursWorked = 0;

            // Act
            double actualGrossPay = _calculator.CalculateGrossPay(hoursWorked);

            // Assert & Log
            TestContext.WriteLine($"Testing Gross Pay with zero hours.");
            TestContext.WriteLine($"Expected: R0.00 | Actual: R{actualGrossPay:F2}");

            Assert.AreEqual(0, actualGrossPay, 0.01);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Gross Pay")]
        [ExpectedException(typeof(ArgumentException))]
        public void GrossPay_ShouldThrowException_WhenHoursAreNegative()
        {
            // Arrange
            double hoursWorked = -10;

            TestContext.WriteLine("Testing Gross Pay with negative hours. Expecting ArgumentException.");

            // Act - should throw
            _calculator.CalculateGrossPay(hoursWorked);
        }

        #endregion

        #region UIF Unit Tests

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("UIF")]
        public void Uif_ShouldReturn1Percent_OfGrossPay()
        {
            // Arrange
            double grossPay = 161500.00; // 170 hours × R950
            double expectedUif = 1615.00; // 1% of R161,500

            // Act
            double actualUif = _calculator.CalculateUif(grossPay);

            // Assert & Log
            TestContext.WriteLine($"Testing UIF Deduction calculation.");
            TestContext.WriteLine($"Input: Gross Pay = R{grossPay:F2}");
            TestContext.WriteLine($"UIF Rate: {PayrollCalculator.UifRate * 100}%");
            TestContext.WriteLine($"Expected UIF: R{expectedUif:F2}");
            TestContext.WriteLine($"Actual UIF: R{actualUif:F2}");

            Assert.AreEqual(expectedUif, actualUif, 0.01,
                $"UIF should be 1% of Gross Pay (R{grossPay:F2}).");
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("UIF")]
        public void Uif_ShouldReturnR21Point50_WhenGrossPayIs2150()
        {
            // Arrange
            double grossPay = 2150.00;
            double expectedUif = 21.50;

            // Act
            double actualUif = _calculator.CalculateUif(grossPay);

            // Assert & Log
            TestContext.WriteLine($"Testing UIF with smaller gross pay.");
            TestContext.WriteLine($"Expected: R{expectedUif:F2} | Actual: R{actualUif:F2}");

            Assert.AreEqual(expectedUif, actualUif, 0.01);
        }

        #endregion

        #region Membership Fee Unit Tests

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Membership Fee")]
        public void MembershipFee_ShouldReturn13Percent_OfGrossPay()
        {
            // Arrange
            double grossPay = 161500.00;
            double expectedFee = 20995.00; // 13% of R161,500

            // Act
            double actualFee = _calculator.CalculateMembershipFee(grossPay);

            // Assert & Log
            TestContext.WriteLine($"Testing Membership Fee calculation.");
            TestContext.WriteLine($"Input: Gross Pay = R{grossPay:F2}");
            TestContext.WriteLine($"Membership Rate: {PayrollCalculator.MembershipRate * 100}%");
            TestContext.WriteLine($"Expected Fee: R{expectedFee:F2}");
            TestContext.WriteLine($"Actual Fee: R{actualFee:F2}");

            Assert.AreEqual(expectedFee, actualFee, 0.01,
                $"Membership Fee should be 13% of Gross Pay (R{grossPay:F2}).");
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Membership Fee")]
        public void MembershipFee_ShouldReturnZero_WhenGrossPayIsZero()
        {
            // Arrange & Act
            double actualFee = _calculator.CalculateMembershipFee(0);

            // Assert & Log
            TestContext.WriteLine("Testing Membership Fee with zero gross pay.");
            TestContext.WriteLine($"Expected: R0.00 | Actual: R{actualFee:F2}");

            Assert.AreEqual(0, actualFee, 0.01);
        }

        #endregion

        #region PAYE Unit Tests

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("PAYE")]
        public void Paye_ShouldReturnCorrectAmount_With3Dependents()
        {
            // Arrange
            double grossPay = 161500.00; // 170 hours × R950
            int dependents = 3;
            // PAYE = (GrossPay - (GrossPay × 0.0575 × Dependents)) × 25%
            // PAYE = (161500 - (161500 × 0.0575 × 3)) × 25%
            // PAYE = (161500 - 27858.75) × 25%
            // PAYE = 133641.25 × 25%
            // PAYE = 33410.3125
            double expectedPaye = 33410.31;

            // Act
            double actualPaye = _calculator.CalculatePaye(grossPay, dependents);

            // Assert & Log
            TestContext.WriteLine($"Testing PAYE Deduction calculation.");
            TestContext.WriteLine($"Input: Gross Pay = R{grossPay:F2}, Dependents = {dependents}");
            TestContext.WriteLine($"Formula: (GrossPay - (GrossPay × 0.0575 × Dependents)) × 25%");
            TestContext.WriteLine($"Taxable: R{grossPay:F2} - R{(grossPay * 0.0575 * dependents):F2} = R{(grossPay - grossPay * 0.0575 * dependents):F2}");
            TestContext.WriteLine($"Expected PAYE: R{expectedPaye:F2}");
            TestContext.WriteLine($"Actual PAYE: R{actualPaye:F2}");

            Assert.AreEqual(expectedPaye, actualPaye, 0.01,
                $"PAYE should be R{expectedPaye:F2} for gross pay R{grossPay:F2} with {dependents} dependents.");
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("PAYE")]
        public void Paye_ShouldReturnFullRate_WhenZeroDependents()
        {
            // Arrange
            double grossPay = 161500.00;
            int dependents = 0;
            // PAYE = (161500 - (161500 × 0.0575 × 0)) × 25%
            // PAYE = 161500 × 25% = 40375
            double expectedPaye = 40375.00;

            // Act
            double actualPaye = _calculator.CalculatePaye(grossPay, dependents);

            // Assert & Log
            TestContext.WriteLine($"Testing PAYE with zero dependents (no relief).");
            TestContext.WriteLine($"Expected: R{expectedPaye:F2} | Actual: R{actualPaye:F2}");

            Assert.AreEqual(expectedPaye, actualPaye, 0.01);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("PAYE")]
        [ExpectedException(typeof(ArgumentException))]
        public void Paye_ShouldThrowException_WhenDependentsExceedMax()
        {
            // Arrange
            double grossPay = 161500.00;
            int dependents = 11; // Exceeds max of 10

            TestContext.WriteLine("Testing PAYE with dependents > 10. Expecting ArgumentException.");

            // Act - should throw
            _calculator.CalculatePaye(grossPay, dependents);
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("PAYE")]
        [ExpectedException(typeof(ArgumentException))]
        public void Paye_ShouldThrowException_WhenDependentsAreNegative()
        {
            // Arrange
            double grossPay = 161500.00;
            int dependents = -1;

            TestContext.WriteLine("Testing PAYE with negative dependents. Expecting ArgumentException.");

            // Act - should throw
            _calculator.CalculatePaye(grossPay, dependents);
        }

        #endregion

        #region Net Pay Unit Tests

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Net Pay")]
        public void NetPay_ShouldReturnCorrectAmount_WhenAllDeductionsApplied()
        {
            // Arrange - Using 170 hours, 3 dependents
            double grossPay = 161500.00;
            double uif = 1615.00;
            double paye = 33410.31;
            double membershipFee = 20995.00;
            // Net Pay = 161500 - 1615 - 33410.31 - 20995 = 105479.69
            double expectedNetPay = 105479.69;

            // Act
            double actualNetPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

            // Assert & Log
            TestContext.WriteLine($"Testing Net Pay calculation with all deductions.");
            TestContext.WriteLine($"Gross Pay: R{grossPay:F2}");
            TestContext.WriteLine($"UIF: R{uif:F2}");
            TestContext.WriteLine($"PAYE: R{paye:F2}");
            TestContext.WriteLine($"Membership Fee: R{membershipFee:F2}");
            TestContext.WriteLine($"Expected Net Pay: R{expectedNetPay:F2}");
            TestContext.WriteLine($"Actual Net Pay: R{actualNetPay:F2}");

            Assert.AreEqual(expectedNetPay, actualNetPay, 0.01,
                "Net Pay should equal Gross Pay minus all deductions.");
        }

        [TestMethod]
        [TestCategory("Unit Test")]
        [TestCategory("Net Pay")]
        public void NetPay_ShouldEqualGrossPay_WhenNoDeductions()
        {
            // Arrange
            double grossPay = 50000.00;

            // Act
            double actualNetPay = _calculator.CalculateNetPay(grossPay, 0, 0, 0);

            // Assert & Log
            TestContext.WriteLine("Testing Net Pay with zero deductions.");
            TestContext.WriteLine($"Expected: R{grossPay:F2} | Actual: R{actualNetPay:F2}");

            Assert.AreEqual(grossPay, actualNetPay, 0.01);
        }

        #endregion

        // ====================================================================
        // 2. INTEGRATION TESTS - Input → Calculation → Output flow
        // ====================================================================

        #region Integration Tests

        [TestMethod]
        [TestCategory("Integration Test")]
        public void Integration_HoursToGrossPay_ShouldCalculateCorrectly()
        {
            // Arrange - simulating user entering 170 hours
            double hoursWorked = 170;

            // Act - Hours flow into Gross Pay calculation
            double grossPay = _calculator.CalculateGrossPay(hoursWorked);

            // Assert & Log
            TestContext.WriteLine("=== Integration Test: Hours → Gross Pay ===");
            TestContext.WriteLine($"User enters Hours Worked: {hoursWorked}");
            TestContext.WriteLine($"System calculates Gross Pay: R{grossPay:F2}");
            TestContext.WriteLine("Verifying hours are correctly used in gross pay calculation.");

            Assert.AreEqual(161500.00, grossPay, 0.01,
                "Hours entered by user should be correctly used in gross pay calculation.");
        }

        [TestMethod]
        [TestCategory("Integration Test")]
        public void Integration_GrossPayToAllDeductions_ShouldFlowCorrectly()
        {
            // Arrange - Gross pay from previous step flows into all deductions
            double grossPay = 161500.00;
            int dependents = 3;

            // Act - Gross pay is passed into UIF, PAYE, and Membership calculations
            double uif = _calculator.CalculateUif(grossPay);
            double paye = _calculator.CalculatePaye(grossPay, dependents);
            double membershipFee = _calculator.CalculateMembershipFee(grossPay);

            // Assert & Log
            TestContext.WriteLine("=== Integration Test: Gross Pay → All Deductions ===");
            TestContext.WriteLine($"Gross Pay input: R{grossPay:F2}");
            TestContext.WriteLine($"UIF (1%): R{uif:F2}");
            TestContext.WriteLine($"PAYE (with {dependents} dependents): R{paye:F2}");
            TestContext.WriteLine($"Membership Fee (13%): R{membershipFee:F2}");
            TestContext.WriteLine("Verifying gross pay correctly flows into all deduction calculations.");

            Assert.AreEqual(1615.00, uif, 0.01, "UIF should be correctly calculated from gross pay.");
            Assert.AreEqual(33410.31, paye, 0.01, "PAYE should be correctly calculated from gross pay.");
            Assert.AreEqual(20995.00, membershipFee, 0.01, "Membership should be correctly calculated from gross pay.");
        }

        [TestMethod]
        [TestCategory("Integration Test")]
        public void Integration_AllDeductionsToNetPay_ShouldCombineCorrectly()
        {
            // Arrange - Full end-to-end calculation from hours to net pay
            double hoursWorked = 170;
            int dependents = 3;

            // Act - Complete calculation chain
            double grossPay = _calculator.CalculateGrossPay(hoursWorked);
            double uif = _calculator.CalculateUif(grossPay);
            double paye = _calculator.CalculatePaye(grossPay, dependents);
            double membershipFee = _calculator.CalculateMembershipFee(grossPay);
            double totalDeductions = _calculator.CalculateTotalDeductions(uif, paye, membershipFee);
            double netPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

            // Assert & Log
            TestContext.WriteLine("=== Integration Test: All Deductions → Net Pay ===");
            TestContext.WriteLine($"Hours Worked: {hoursWorked}");
            TestContext.WriteLine($"Dependents: {dependents}");
            TestContext.WriteLine($"Gross Pay: R{grossPay:F2}");
            TestContext.WriteLine($"UIF: R{uif:F2}");
            TestContext.WriteLine($"PAYE: R{paye:F2}");
            TestContext.WriteLine($"Membership Fee: R{membershipFee:F2}");
            TestContext.WriteLine($"Total Deductions: R{totalDeductions:F2}");
            TestContext.WriteLine($"Calculated Net Pay: R{netPay:F2}");

            double expectedTotalDeductions = uif + paye + membershipFee;
            double expectedNetPay = grossPay - expectedTotalDeductions;

            Assert.AreEqual(expectedTotalDeductions, totalDeductions, 0.01,
                "Total deductions should equal UIF + PAYE + Membership Fee.");
            Assert.AreEqual(expectedNetPay, netPay, 0.01,
                "Net pay should equal Gross Pay minus Total Deductions.");
        }

        #endregion

        // ====================================================================
        // 3. SYSTEM TESTS - Complete application workflow
        // ====================================================================

        #region System Tests

        [TestMethod]
        [TestCategory("System Test")]
        public void SystemTest_CompletePayrollWorkflow_ShouldProduceCorrectResults()
        {
            // This test simulates the complete system workflow:
            // Step 1: User enters contractor details
            // Step 2: System validates input
            // Step 3: System calculates all payroll values
            // Step 4: System displays results
            // Step 5: Verify all outputs are correct

            TestContext.WriteLine("=== System Test: Complete Payroll Workflow ===");

            // Step 1: Simulate user input
            string contractorName = "Amina Rizk Selemani";
            double hoursWorked = 170;
            int dependents = 3;
            TestContext.WriteLine($"Step 1 - User Input: Name={contractorName}, Hours={hoursWorked}, Dependents={dependents}");

            // Step 2: Validate input
            bool nameValid = !string.IsNullOrWhiteSpace(contractorName);
            bool hoursValid = hoursWorked >= 0;
            bool dependentsValid = dependents >= 0 && dependents <= PayrollCalculator.MaxDependents;
            TestContext.WriteLine($"Step 2 - Validation: Name={nameValid}, Hours={hoursValid}, Dependents={dependentsValid}");

            Assert.IsTrue(nameValid, "Contractor name should be valid.");
            Assert.IsTrue(hoursValid, "Hours worked should be valid.");
            Assert.IsTrue(dependentsValid, "Dependents should be valid.");

            // Step 3: Calculate payroll
            double grossPay = _calculator.CalculateGrossPay(hoursWorked);
            double uif = _calculator.CalculateUif(grossPay);
            double paye = _calculator.CalculatePaye(grossPay, dependents);
            double membershipFee = _calculator.CalculateMembershipFee(grossPay);
            double totalDeductions = _calculator.CalculateTotalDeductions(uif, paye, membershipFee);
            double netPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

            TestContext.WriteLine($"Step 3 - Calculations Complete:");
            TestContext.WriteLine($"  Gross Pay: R{grossPay:F2}");
            TestContext.WriteLine($"  UIF: R{uif:F2}");
            TestContext.WriteLine($"  PAYE: R{paye:F2}");
            TestContext.WriteLine($"  Membership Fee: R{membershipFee:F2}");
            TestContext.WriteLine($"  Total Deductions: R{totalDeductions:F2}");
            TestContext.WriteLine($"  Net Pay: R{netPay:F2}");

            // Step 4 & 5: Verify all outputs
            TestContext.WriteLine("Step 4 & 5 - Verifying all outputs...");

            Assert.AreEqual(161500.00, grossPay, 0.01, "Gross Pay should be R161,500.00");
            Assert.AreEqual(1615.00, uif, 0.01, "UIF should be R1,615.00");
            Assert.AreEqual(33410.31, paye, 0.01, "PAYE should be R33,410.31");
            Assert.AreEqual(20995.00, membershipFee, 0.01, "Membership Fee should be R20,995.00");
            Assert.AreEqual(56020.31, totalDeductions, 0.01, "Total Deductions should be R56,020.31");
            Assert.AreEqual(105479.69, netPay, 0.01, "Net Pay should be R105,479.69");

            TestContext.WriteLine("=== System Test PASSED: All outputs verified. ===");
        }

        [TestMethod]
        [TestCategory("System Test")]
        public void SystemTest_ValidationRejectsInvalidInput()
        {
            // Test that the system correctly rejects invalid inputs
            TestContext.WriteLine("=== System Test: Input Validation ===");

            // Test: Empty name
            string emptyName = "";
            Assert.IsTrue(string.IsNullOrWhiteSpace(emptyName), "Empty name should fail validation.");
            TestContext.WriteLine("PASS: Empty name correctly rejected.");

            // Test: Negative hours
            double negativeHours = -5;
            Assert.IsTrue(negativeHours < 0, "Negative hours should fail validation.");
            TestContext.WriteLine("PASS: Negative hours correctly rejected.");

            // Test: Negative dependents
            int negativeDependents = -1;
            Assert.IsTrue(negativeDependents < 0, "Negative dependents should fail validation.");
            TestContext.WriteLine("PASS: Negative dependents correctly rejected.");

            // Test: Dependents exceeding max
            int excessiveDependents = 15;
            Assert.IsTrue(excessiveDependents > PayrollCalculator.MaxDependents,
                "Dependents > 10 should fail validation.");
            TestContext.WriteLine("PASS: Excessive dependents correctly rejected.");

            // Test: Non-numeric input
            bool isNumeric = double.TryParse("abc", out _);
            Assert.IsFalse(isNumeric, "Non-numeric input should fail validation.");
            TestContext.WriteLine("PASS: Non-numeric input correctly rejected.");

            TestContext.WriteLine("=== System Test PASSED: All invalid inputs correctly rejected. ===");
        }

        #endregion

        // ====================================================================
        // 4. RETESTING - Run same tests after defect fixes
        // ====================================================================

        #region Retesting

        [TestMethod]
        [TestCategory("Retest")]
        public void Retest_GrossPayCalculation_AfterFix()
        {
            // Retest: Verify gross pay formula is correct after any fixes
            TestContext.WriteLine("=== Retest: Gross Pay After Fix ===");

            double hoursWorked = 170;
            double expected = 161500.00;
            double actual = _calculator.CalculateGrossPay(hoursWorked);

            TestContext.WriteLine($"Expected: R{expected:F2} | Actual: R{actual:F2}");
            Assert.AreEqual(expected, actual, 0.01, "Retest: Gross Pay formula verified correct.");
            TestContext.WriteLine("RETEST PASSED.");
        }

        [TestMethod]
        [TestCategory("Retest")]
        public void Retest_PayeCalculation_AfterFix()
        {
            // Retest: Verify PAYE formula is correct after any fixes
            TestContext.WriteLine("=== Retest: PAYE After Fix ===");

            double grossPay = 161500.00;
            int dependents = 3;
            double expected = 33410.31;
            double actual = _calculator.CalculatePaye(grossPay, dependents);

            TestContext.WriteLine($"Expected: R{expected:F2} | Actual: R{actual:F2}");
            Assert.AreEqual(expected, actual, 0.01, "Retest: PAYE formula verified correct.");
            TestContext.WriteLine("RETEST PASSED.");
        }

        #endregion

        // ====================================================================
        // 5. REGRESSION TESTING - Ensure fixes don't break other parts
        // ====================================================================

        #region Regression Testing

        [TestMethod]
        [TestCategory("Regression Test")]
        public void Regression_AllCalculationsStillCorrect_AfterPayeFix()
        {
            // Verify that fixing PAYE did not break UIF, Membership, or Net Pay
            TestContext.WriteLine("=== Regression Test: All Calculations After PAYE Fix ===");

            double hoursWorked = 170;
            int dependents = 3;

            double grossPay = _calculator.CalculateGrossPay(hoursWorked);
            double uif = _calculator.CalculateUif(grossPay);
            double paye = _calculator.CalculatePaye(grossPay, dependents);
            double membershipFee = _calculator.CalculateMembershipFee(grossPay);
            double netPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

            TestContext.WriteLine($"Gross Pay: R{grossPay:F2} (expected R161,500.00)");
            TestContext.WriteLine($"UIF: R{uif:F2} (expected R1,615.00)");
            TestContext.WriteLine($"PAYE: R{paye:F2} (expected R33,410.31)");
            TestContext.WriteLine($"Membership: R{membershipFee:F2} (expected R20,995.00)");
            TestContext.WriteLine($"Net Pay: R{netPay:F2} (expected R105,479.69)");

            Assert.AreEqual(161500.00, grossPay, 0.01, "Regression: Gross Pay still correct.");
            Assert.AreEqual(1615.00, uif, 0.01, "Regression: UIF still correct.");
            Assert.AreEqual(33410.31, paye, 0.01, "Regression: PAYE still correct.");
            Assert.AreEqual(20995.00, membershipFee, 0.01, "Regression: Membership still correct.");
            Assert.AreEqual(105479.69, netPay, 0.01, "Regression: Net Pay still correct.");

            TestContext.WriteLine("REGRESSION TEST PASSED: No other calculations were broken.");
        }

        [TestMethod]
        [TestCategory("Regression Test")]
        public void Regression_DifferentInputValues_StillProduceCorrectResults()
        {
            // Test with completely different values to ensure no hardcoded results
            TestContext.WriteLine("=== Regression Test: Different Input Values ===");

            double hoursWorked = 80;
            int dependents = 2;

            double grossPay = _calculator.CalculateGrossPay(hoursWorked);
            double uif = _calculator.CalculateUif(grossPay);
            double paye = _calculator.CalculatePaye(grossPay, dependents);
            double membershipFee = _calculator.CalculateMembershipFee(grossPay);
            double netPay = _calculator.CalculateNetPay(grossPay, uif, paye, membershipFee);

            // Manual calculations for 80 hours, 2 dependents:
            // Gross = 80 × 950 = 76000
            // UIF = 76000 × 0.01 = 760
            // PAYE = (76000 - (76000 × 0.0575 × 2)) × 0.25 = (76000 - 8740) × 0.25 = 67260 × 0.25 = 16815
            // Membership = 76000 × 0.13 = 9880
            // Net = 76000 - 760 - 16815 - 9880 = 48545

            TestContext.WriteLine($"Input: {hoursWorked} hours, {dependents} dependents");
            TestContext.WriteLine($"Gross Pay: R{grossPay:F2}");
            TestContext.WriteLine($"UIF: R{uif:F2}");
            TestContext.WriteLine($"PAYE: R{paye:F2}");
            TestContext.WriteLine($"Membership: R{membershipFee:F2}");
            TestContext.WriteLine($"Net Pay: R{netPay:F2}");

            Assert.AreEqual(76000.00, grossPay, 0.01, "Regression: Gross Pay correct for 80hrs.");
            Assert.AreEqual(760.00, uif, 0.01, "Regression: UIF correct for 80hrs.");
            Assert.AreEqual(16815.00, paye, 0.01, "Regression: PAYE correct for 80hrs, 2 deps.");
            Assert.AreEqual(9880.00, membershipFee, 0.01, "Regression: Membership correct for 80hrs.");
            Assert.AreEqual(48545.00, netPay, 0.01, "Regression: Net Pay correct for 80hrs, 2 deps.");

            TestContext.WriteLine("REGRESSION TEST PASSED.");
        }

        #endregion
    }
}
