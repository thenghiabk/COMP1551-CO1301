namespace HelloGUI
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnHelloWorld = new Button();
            lblResult = new Label();
            btnGoodbye = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            tbFullName = new TextBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            tbResult = new TextBox();
            btnSubmit = new Button();
            cbbCountry = new ComboBox();
            SuspendLayout();
            // 
            // btnHelloWorld
            // 
            btnHelloWorld.BackColor = SystemColors.MenuHighlight;
            btnHelloWorld.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHelloWorld.ForeColor = Color.Yellow;
            btnHelloWorld.Location = new Point(40, 28);
            btnHelloWorld.Name = "btnHelloWorld";
            btnHelloWorld.Size = new Size(353, 81);
            btnHelloWorld.TabIndex = 0;
            btnHelloWorld.Text = "SAY HELLO WORLD";
            btnHelloWorld.UseVisualStyleBackColor = false;
            btnHelloWorld.Click += btnHelloWorld_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblResult.ForeColor = Color.Red;
            lblResult.Location = new Point(47, 123);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(101, 38);
            lblResult.TabIndex = 1;
            lblResult.Text = "Result:";
            // 
            // btnGoodbye
            // 
            btnGoodbye.Location = new Point(440, 34);
            btnGoodbye.Name = "btnGoodbye";
            btnGoodbye.Size = new Size(212, 81);
            btnGoodbye.TabIndex = 2;
            btnGoodbye.Text = "SAY GOODBYE";
            btnGoodbye.UseVisualStyleBackColor = true;
            btnGoodbye.Click += btnGoodbye_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 240);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 3;
            label1.Text = "Full Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 297);
            label2.Name = "label2";
            label2.Size = new Size(73, 25);
            label2.TabIndex = 4;
            label2.Text = "Gender:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 354);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 5;
            label3.Text = "Country:";
            // 
            // tbFullName
            // 
            tbFullName.Location = new Point(144, 234);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(266, 31);
            tbFullName.TabIndex = 6;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(144, 297);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(75, 29);
            rbMale.TabIndex = 7;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(250, 297);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(93, 29);
            rbFemale.TabIndex = 8;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // tbResult
            // 
            tbResult.Location = new Point(47, 415);
            tbResult.Multiline = true;
            tbResult.Name = "tbResult";
            tbResult.Size = new Size(363, 225);
            tbResult.TabIndex = 9;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(450, 415);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(112, 34);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "SUBMIT";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // cbbCountry
            // 
            cbbCountry.FormattingEnabled = true;
            cbbCountry.Items.AddRange(new object[] { "Australia", "Thailand", "Vietnam", "USA", "UK" });
            cbbCountry.Location = new Point(144, 354);
            cbbCountry.Name = "cbbCountry";
            cbbCountry.Size = new Size(182, 33);
            cbbCountry.TabIndex = 11;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 670);
            Controls.Add(cbbCountry);
            Controls.Add(btnSubmit);
            Controls.Add(tbResult);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(tbFullName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGoodbye);
            Controls.Add(lblResult);
            Controls.Add(btnHelloWorld);
            Name = "frmMain";
            Text = "Personal Info";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHelloWorld;
        private Label lblResult;
        private Button btnGoodbye;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox tbFullName;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private TextBox tbResult;
        private Button btnSubmit;
        private ComboBox cbbCountry;
    }
}
