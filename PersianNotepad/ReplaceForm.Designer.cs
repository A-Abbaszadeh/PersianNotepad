
namespace PersianNotepad
{
    partial class ReplaceForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioDown = new System.Windows.Forms.RadioButton();
            this.radioUp = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioWholeWord = new System.Windows.Forms.RadioButton();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.replaceButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.replaceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.replaceAllButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioDown);
            this.groupBox2.Controls.Add(this.radioUp);
            this.groupBox2.Location = new System.Drawing.Point(264, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 80);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "جهت جستجو";
            // 
            // radioDown
            // 
            this.radioDown.AutoSize = true;
            this.radioDown.Checked = true;
            this.radioDown.Location = new System.Drawing.Point(22, 35);
            this.radioDown.Name = "radioDown";
            this.radioDown.Size = new System.Drawing.Size(75, 22);
            this.radioDown.TabIndex = 1;
            this.radioDown.TabStop = true;
            this.radioDown.Text = "به پائین";
            this.radioDown.UseVisualStyleBackColor = true;
            // 
            // radioUp
            // 
            this.radioUp.AutoSize = true;
            this.radioUp.Location = new System.Drawing.Point(114, 35);
            this.radioUp.Name = "radioUp";
            this.radioUp.Size = new System.Drawing.Size(64, 22);
            this.radioUp.TabIndex = 0;
            this.radioUp.Text = "به بالا";
            this.radioUp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioWholeWord);
            this.groupBox1.Controls.Add(this.radioNone);
            this.groupBox1.Location = new System.Drawing.Point(39, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 85);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نحوه جستجو";
            // 
            // radioWholeWord
            // 
            this.radioWholeWord.AutoSize = true;
            this.radioWholeWord.Location = new System.Drawing.Point(41, 57);
            this.radioWholeWord.Name = "radioWholeWord";
            this.radioWholeWord.Size = new System.Drawing.Size(162, 22);
            this.radioWholeWord.TabIndex = 1;
            this.radioWholeWord.Text = "شامل این کلمه باشد";
            this.radioWholeWord.UseVisualStyleBackColor = true;
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Checked = true;
            this.radioNone.Location = new System.Drawing.Point(69, 28);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(134, 22);
            this.radioNone.TabIndex = 0;
            this.radioNone.TabStop = true;
            this.radioNone.Text = "دقیقا همین کلمه";
            this.radioNone.UseVisualStyleBackColor = true;
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(458, 61);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(127, 35);
            this.replaceButton.TabIndex = 33;
            this.replaceButton.Text = "جایگزینی";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.replaceButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(458, 20);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(127, 35);
            this.searchButton.TabIndex = 32;
            this.searchButton.Text = "جستجو";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(105, 25);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(337, 26);
            this.searchTextBox.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "جستجو";
            // 
            // replaceTextBox
            // 
            this.replaceTextBox.Location = new System.Drawing.Point(105, 66);
            this.replaceTextBox.Name = "replaceTextBox";
            this.replaceTextBox.Size = new System.Drawing.Size(337, 26);
            this.replaceTextBox.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 36;
            this.label2.Text = "جایگزین";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(458, 143);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 35);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "لغو";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // replaceAllButton
            // 
            this.replaceAllButton.Location = new System.Drawing.Point(458, 102);
            this.replaceAllButton.Name = "replaceAllButton";
            this.replaceAllButton.Size = new System.Drawing.Size(127, 35);
            this.replaceAllButton.TabIndex = 38;
            this.replaceAllButton.Text = "جایگزینی همه";
            this.replaceAllButton.UseVisualStyleBackColor = true;
            this.replaceAllButton.Click += new System.EventHandler(this.replaceAllButton_Click);
            // 
            // ReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 196);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.replaceAllButton);
            this.Controls.Add(this.replaceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReplaceForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "جایگزینی";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceForm_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioDown;
        private System.Windows.Forms.RadioButton radioUp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioWholeWord;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.Button replaceButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox replaceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button replaceAllButton;
    }
}