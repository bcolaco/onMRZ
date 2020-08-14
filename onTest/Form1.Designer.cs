namespace onTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dfsFirstName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dfsLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dfsDocumentNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dfsNationality = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dfdDOB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dfsGender = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dfdExpireDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dfsIssuingCountry = new System.Windows.Forms.TextBox();
            this.btnMake = new System.Windows.Forms.Button();
            this.dfsMRZ = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dfsDocumentType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(639, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Parse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dfsFirstName
            // 
            this.dfsFirstName.Location = new System.Drawing.Point(134, 56);
            this.dfsFirstName.Name = "dfsFirstName";
            this.dfsFirstName.Size = new System.Drawing.Size(207, 20);
            this.dfsFirstName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last Name";
            // 
            // dfsLastName
            // 
            this.dfsLastName.Location = new System.Drawing.Point(134, 82);
            this.dfsLastName.Name = "dfsLastName";
            this.dfsLastName.Size = new System.Drawing.Size(207, 20);
            this.dfsLastName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Document Number";
            // 
            // dfsDocumentNumber
            // 
            this.dfsDocumentNumber.Location = new System.Drawing.Point(134, 108);
            this.dfsDocumentNumber.Name = "dfsDocumentNumber";
            this.dfsDocumentNumber.Size = new System.Drawing.Size(207, 20);
            this.dfsDocumentNumber.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Nationality";
            // 
            // dfsNationality
            // 
            this.dfsNationality.Location = new System.Drawing.Point(134, 134);
            this.dfsNationality.Name = "dfsNationality";
            this.dfsNationality.Size = new System.Drawing.Size(207, 20);
            this.dfsNationality.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date Of Birth";
            // 
            // dfdDOB
            // 
            this.dfdDOB.Location = new System.Drawing.Point(134, 160);
            this.dfdDOB.Name = "dfdDOB";
            this.dfdDOB.Size = new System.Drawing.Size(207, 20);
            this.dfdDOB.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Gender";
            // 
            // dfsGender
            // 
            this.dfsGender.Location = new System.Drawing.Point(134, 186);
            this.dfsGender.Name = "dfsGender";
            this.dfsGender.Size = new System.Drawing.Size(207, 20);
            this.dfsGender.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Expire Date";
            // 
            // dfdExpireDate
            // 
            this.dfdExpireDate.Location = new System.Drawing.Point(134, 212);
            this.dfdExpireDate.Name = "dfdExpireDate";
            this.dfdExpireDate.Size = new System.Drawing.Size(207, 20);
            this.dfdExpireDate.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Issuing Country";
            // 
            // dfsIssuingCountry
            // 
            this.dfsIssuingCountry.Location = new System.Drawing.Point(134, 30);
            this.dfsIssuingCountry.Name = "dfsIssuingCountry";
            this.dfsIssuingCountry.Size = new System.Drawing.Size(207, 20);
            this.dfsIssuingCountry.TabIndex = 15;
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(639, 215);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(75, 23);
            this.btnMake.TabIndex = 17;
            this.btnMake.Text = "Make";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // dfsMRZ
            // 
            this.dfsMRZ.Location = new System.Drawing.Point(12, 292);
            this.dfsMRZ.Name = "dfsMRZ";
            this.dfsMRZ.Size = new System.Drawing.Size(713, 20);
            this.dfsMRZ.TabIndex = 18;
            this.dfsMRZ.Text = "P<GBRMALIK<<MUSSARAT<ZARIN<<<<<<<<<<<<<<<<<<5119237240GBR4612078F2212119<<<<<<<<<" +
    "<<<<<04";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Document Type";
            // 
            // dfsDocumentType
            // 
            this.dfsDocumentType.Location = new System.Drawing.Point(134, 4);
            this.dfsDocumentType.Name = "dfsDocumentType";
            this.dfsDocumentType.Size = new System.Drawing.Size(207, 20);
            this.dfsDocumentType.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 605);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dfsDocumentType);
            this.Controls.Add(this.dfsMRZ);
            this.Controls.Add(this.btnMake);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dfsIssuingCountry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dfdExpireDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dfsGender);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dfdDOB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dfsNationality);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dfsDocumentNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dfsLastName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dfsFirstName);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox dfsFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dfsLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dfsDocumentNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dfsNationality;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dfdDOB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox dfsGender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox dfdExpireDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox dfsIssuingCountry;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.TextBox dfsMRZ;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox dfsDocumentType;
    }
}

