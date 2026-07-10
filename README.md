 # Mzansi Payroll Calculator - University Assignment (SDT621)

  ## Disclaimer

  This repository contains a **university assignment** completed as part of the **SDT621 - Software Design and Testing
  C#** module, specifically for **Assessment PM-04: Testing and Debugging Software Systems**.

  **I do not claim full ownership of this system.** The assignment brief, business requirements, and payroll formulas
  were provided by my university. I have no intention of selling, distributing, or claiming this project as an entirely
  original commercial product. This repository exists solely as a **portfolio piece** to demonstrate my skills in C#
  development, Windows Forms UI design, and software testing practices.

  ---

  ## What Was Provided by the University

  The following elements were **specified by the university** as part of the assignment brief:

  - The concept of a payroll system for a fictional company called **"Mzansi Tech Contractors"**
  - The business rules and payroll formulas:
    - Hourly rate of **R950.00**
    - **UIF** (Unemployment Insurance Fund) deduction at **1%** of gross pay
    - **PAYE** (Pay As You Earn) tax at **25%** with **5.75%** dependent relief per dependent
    - **Membership fee** deduction at **13%** of gross pay
  - The requirement to demonstrate **unit testing, integration testing, system testing, retesting, and regression
  testing**
  - The requirement to introduce an **intentional defect**, detect it through testing, fix it, and document the process
  - The overall assessment structure and deliverables expected for PM-04

  ---

  ## What I Created

  The following work is **my own implementation** based on the university-provided requirements:

  ### Application Code
  - **`PayrollCalculator.cs`** - A standalone business logic class implementing all payroll calculations with input
  validation, designed with separation of concerns to enable testability
  - **`FrmPayroll.cs`** - The Windows Forms UI code-behind handling user input validation, calculation triggers, reset
  functionality, and exit confirmation
  - **`FrmPayroll.Designer.cs`** - The complete form layout and UI design, including a custom dark theme (RGB 30, 30,
  60), control positioning, and styling for all input/output fields

  ### Testing
  - **`PayrollCalculatorTests.cs`** - A comprehensive test suite containing **20 test methods** organised into:
    - 11 Unit Tests (individual calculation methods, edge cases, and exception handling)
    - 3 Integration Tests (data flow between calculation components)
    - 2 System Tests (end-to-end workflow and validation rejection)
    - 2 Retests (post-defect-fix verification)
    - 2 Regression Tests (ensuring fixes did not break existing functionality)

  ### Documentation
  - **`TestReport.md`** - A formal test report documenting all test cases, a defect log with two identified defects,
  retesting results, regression results, and a summary of outcomes (20/20 tests passed)

  ### Project Setup
  - Solution structure, project configuration, and .NET 8.0 WinForms setup

  ---

  ## Tech Stack

  | Layer | Technology |
  |-------|------------|
  | Language | C# |
  | Framework | .NET 8.0 |
  | UI | Windows Forms (WinForms) |
  | IDE | Visual Studio 2022 |
  | Testing | MSTest v3 |
  | Coverage | Coverlet |

  ---

  ## Features

  - Gross pay calculation based on hours worked
  - UIF, PAYE (with dependent relief), and membership fee deductions
  - Net pay calculation with full deduction breakdown
  - Input validation (empty fields, non-numeric input, negative values, dependent limits)
  - Currency formatting in South African Rand (ZAR)
  - Dark-themed UI
  - Reset and exit with confirmation

  ---

  ## Purpose of This Repository

  This project is hosted on GitHub **for portfolio and educational purposes only**. It serves to demonstrate:

  - Proficiency in **C# and .NET development**
  - Ability to build **Windows Forms desktop applications**
  - Understanding of **software testing methodologies** (unit, integration, system, regression)
  - Application of **separation of concerns** in code architecture
  - Competency in **test-driven debugging and defect resolution**

  If you are an educator or institution and have concerns about this repository, please feel free to contact me.

  - Gross pay calculation based on hours worked
  - UIF, PAYE (with dependent relief), and membership fee deductions
  - Net pay calculation with full deduction breakdown
  - Input validation (empty fields, non-numeric input, negative values, dependent limits)
  - Currency formatting in South African Rand (ZAR)
  - Dark-themed UI
  - Reset and exit with confirmation

  ---

  ## Purpose of This Repository

  This project is hosted on GitHub **for portfolio and educational purposes only**. It serves to demonstrate:

  - Proficiency in **C# and .NET development**
  - Ability to build **Windows Forms desktop applications**
  - Understanding of **software testing methodologies** (unit, integration, system, regression)
  - Application of **separation of concerns** in code architecture
  - Competency in **test-driven debugging and defect resolution**

  If you are an educator or institution and have concerns about this repository, please feel free to contact me.

  ---

  ## License

  This project is for **educational and portfolio purposes only**. No commercial license is granted.
