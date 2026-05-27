namespace MzansiPayrollSystem
{
    partial class FrmPayroll
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Title Label
            this.lblTitle = new Label();
            this.lblTitle.Text = "Mzansi Tech Contractors";
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(12, 15);
            this.lblTitle.Size = new Size(660, 40);

            // --- Input Labels ---
            this.lblContractorName = new Label();
            this.lblContractorName.Text = "Contractor Name";
            this.lblContractorName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblContractorName.ForeColor = Color.White;
            this.lblContractorName.Location = new Point(30, 80);
            this.lblContractorName.Size = new Size(150, 25);

            this.lblHoursWorked = new Label();
            this.lblHoursWorked.Text = "Hours Worked";
            this.lblHoursWorked.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblHoursWorked.ForeColor = Color.White;
            this.lblHoursWorked.Location = new Point(30, 120);
            this.lblHoursWorked.Size = new Size(150, 25);

            this.lblDependents = new Label();
            this.lblDependents.Text = "Number of Dependents";
            this.lblDependents.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDependents.ForeColor = Color.White;
            this.lblDependents.Location = new Point(30, 160);
            this.lblDependents.Size = new Size(180, 25);

            // --- Input TextBoxes ---
            this.txtContractorName = new TextBox();
            this.txtContractorName.Font = new Font("Segoe UI", 10F);
            this.txtContractorName.Location = new Point(220, 78);
            this.txtContractorName.Size = new Size(180, 25);

            this.txtHoursWorked = new TextBox();
            this.txtHoursWorked.Font = new Font("Segoe UI", 10F);
            this.txtHoursWorked.Location = new Point(220, 118);
            this.txtHoursWorked.Size = new Size(180, 25);

            this.txtDependents = new TextBox();
            this.txtDependents.Font = new Font("Segoe UI", 10F);
            this.txtDependents.Location = new Point(220, 158);
            this.txtDependents.Size = new Size(180, 25);

            // --- Output Labels ---
            this.lblGrossPay = new Label();
            this.lblGrossPay.Text = "Gross Pay:";
            this.lblGrossPay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblGrossPay.ForeColor = Color.White;
            this.lblGrossPay.TextAlign = ContentAlignment.MiddleRight;
            this.lblGrossPay.Location = new Point(420, 80);
            this.lblGrossPay.Size = new Size(120, 25);

            this.lblPayeDeduction = new Label();
            this.lblPayeDeduction.Text = "PAYE Deduction:";
            this.lblPayeDeduction.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPayeDeduction.ForeColor = Color.White;
            this.lblPayeDeduction.TextAlign = ContentAlignment.MiddleRight;
            this.lblPayeDeduction.Location = new Point(420, 120);
            this.lblPayeDeduction.Size = new Size(120, 25);

            this.lblUifDeduction = new Label();
            this.lblUifDeduction.Text = "UIF Deduction:";
            this.lblUifDeduction.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblUifDeduction.ForeColor = Color.White;
            this.lblUifDeduction.TextAlign = ContentAlignment.MiddleRight;
            this.lblUifDeduction.Location = new Point(420, 160);
            this.lblUifDeduction.Size = new Size(120, 25);

            this.lblMembershipFee = new Label();
            this.lblMembershipFee.Text = "Membership Fee:";
            this.lblMembershipFee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMembershipFee.ForeColor = Color.White;
            this.lblMembershipFee.TextAlign = ContentAlignment.MiddleRight;
            this.lblMembershipFee.Location = new Point(420, 200);
            this.lblMembershipFee.Size = new Size(120, 25);

            this.lblTotalDeductions = new Label();
            this.lblTotalDeductions.Text = "Total Deductions:";
            this.lblTotalDeductions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTotalDeductions.ForeColor = Color.White;
            this.lblTotalDeductions.TextAlign = ContentAlignment.MiddleRight;
            this.lblTotalDeductions.Location = new Point(410, 240);
            this.lblTotalDeductions.Size = new Size(130, 25);

            this.lblNetPay = new Label();
            this.lblNetPay.Text = "Net Pay:";
            this.lblNetPay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNetPay.ForeColor = Color.White;
            this.lblNetPay.TextAlign = ContentAlignment.MiddleRight;
            this.lblNetPay.Location = new Point(420, 280);
            this.lblNetPay.Size = new Size(120, 25);

            // --- Output TextBoxes (ReadOnly) ---
            this.txtGrossPay = new TextBox();
            this.txtGrossPay.Font = new Font("Segoe UI", 10F);
            this.txtGrossPay.Location = new Point(545, 78);
            this.txtGrossPay.Size = new Size(130, 25);
            this.txtGrossPay.ReadOnly = true;
            this.txtGrossPay.BackColor = Color.White;

            this.txtPayeDeduction = new TextBox();
            this.txtPayeDeduction.Font = new Font("Segoe UI", 10F);
            this.txtPayeDeduction.Location = new Point(545, 118);
            this.txtPayeDeduction.Size = new Size(130, 25);
            this.txtPayeDeduction.ReadOnly = true;
            this.txtPayeDeduction.BackColor = Color.White;

            this.txtUifDeduction = new TextBox();
            this.txtUifDeduction.Font = new Font("Segoe UI", 10F);
            this.txtUifDeduction.Location = new Point(545, 158);
            this.txtUifDeduction.Size = new Size(130, 25);
            this.txtUifDeduction.ReadOnly = true;
            this.txtUifDeduction.BackColor = Color.White;

            this.txtMembershipFee = new TextBox();
            this.txtMembershipFee.Font = new Font("Segoe UI", 10F);
            this.txtMembershipFee.Location = new Point(545, 198);
            this.txtMembershipFee.Size = new Size(130, 25);
            this.txtMembershipFee.ReadOnly = true;
            this.txtMembershipFee.BackColor = Color.White;

            this.txtTotalDeductions = new TextBox();
            this.txtTotalDeductions.Font = new Font("Segoe UI", 10F);
            this.txtTotalDeductions.Location = new Point(545, 238);
            this.txtTotalDeductions.Size = new Size(130, 25);
            this.txtTotalDeductions.ReadOnly = true;
            this.txtTotalDeductions.BackColor = Color.White;

            this.txtNetPay = new TextBox();
            this.txtNetPay.Font = new Font("Segoe UI", 10F);
            this.txtNetPay.Location = new Point(545, 278);
            this.txtNetPay.Size = new Size(130, 25);
            this.txtNetPay.ReadOnly = true;
            this.txtNetPay.BackColor = Color.White;

            // --- Buttons ---
            this.btnCalculate = new Button();
            this.btnCalculate.Text = "Calculate Net Pay";
            this.btnCalculate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCalculate.Location = new Point(30, 210);
            this.btnCalculate.Size = new Size(120, 35);
            this.btnCalculate.BackColor = Color.FromArgb(0, 120, 215);
            this.btnCalculate.ForeColor = Color.White;
            this.btnCalculate.FlatStyle = FlatStyle.Flat;
            this.btnCalculate.FlatAppearance.BorderSize = 0;
            this.btnCalculate.Click += new EventHandler(this.BtnCalculate_Click);

            this.btnReset = new Button();
            this.btnReset.Text = "Reset";
            this.btnReset.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnReset.Location = new Point(165, 210);
            this.btnReset.Size = new Size(100, 35);
            this.btnReset.BackColor = Color.FromArgb(0, 120, 215);
            this.btnReset.ForeColor = Color.White;
            this.btnReset.FlatStyle = FlatStyle.Flat;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.Click += new EventHandler(this.BtnReset_Click);

            this.btnExit = new Button();
            this.btnExit.Text = "Exit";
            this.btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnExit.Location = new Point(280, 210);
            this.btnExit.Size = new Size(100, 35);
            this.btnExit.BackColor = Color.FromArgb(220, 53, 69);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Click += new EventHandler(this.BtnExit_Click);

            // --- Form Setup ---
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(30, 30, 60);
            this.ClientSize = new Size(690, 330);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mzansi Tech Contractors Payroll System";

            // Add controls to the form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblContractorName);
            this.Controls.Add(this.lblHoursWorked);
            this.Controls.Add(this.lblDependents);
            this.Controls.Add(this.txtContractorName);
            this.Controls.Add(this.txtHoursWorked);
            this.Controls.Add(this.txtDependents);
            this.Controls.Add(this.lblGrossPay);
            this.Controls.Add(this.lblPayeDeduction);
            this.Controls.Add(this.lblUifDeduction);
            this.Controls.Add(this.lblMembershipFee);
            this.Controls.Add(this.lblTotalDeductions);
            this.Controls.Add(this.lblNetPay);
            this.Controls.Add(this.txtGrossPay);
            this.Controls.Add(this.txtPayeDeduction);
            this.Controls.Add(this.txtUifDeduction);
            this.Controls.Add(this.txtMembershipFee);
            this.Controls.Add(this.txtTotalDeductions);
            this.Controls.Add(this.txtNetPay);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Input Labels
        private Label lblTitle;
        private Label lblContractorName;
        private Label lblHoursWorked;
        private Label lblDependents;

        // Input TextBoxes
        private TextBox txtContractorName;
        private TextBox txtHoursWorked;
        private TextBox txtDependents;

        // Output Labels
        private Label lblGrossPay;
        private Label lblPayeDeduction;
        private Label lblUifDeduction;
        private Label lblMembershipFee;
        private Label lblTotalDeductions;
        private Label lblNetPay;

        // Output TextBoxes
        private TextBox txtGrossPay;
        private TextBox txtPayeDeduction;
        private TextBox txtUifDeduction;
        private TextBox txtMembershipFee;
        private TextBox txtTotalDeductions;
        private TextBox txtNetPay;

        // Buttons
        private Button btnCalculate;
        private Button btnReset;
        private Button btnExit;
    }
}
