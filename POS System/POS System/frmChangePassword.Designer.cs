﻿namespace POS_System
{
    partial class frmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChangePassword));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOld = new MetroFramework.Controls.MetroTextBox();
            this.txtNew = new MetroFramework.Controls.MetroTextBox();
            this.txtConfNew = new MetroFramework.Controls.MetroTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 40);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(329, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 40);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Change Password";
            // 
            // txtOld
            // 
            // 
            // 
            // 
            this.txtOld.CustomButton.Image = null;
            this.txtOld.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.txtOld.CustomButton.Name = "";
            this.txtOld.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtOld.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtOld.CustomButton.TabIndex = 1;
            this.txtOld.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtOld.CustomButton.UseSelectable = true;
            this.txtOld.CustomButton.Visible = false;
            this.txtOld.DisplayIcon = true;
            this.txtOld.Icon = ((System.Drawing.Image)(resources.GetObject("txtOld.Icon")));
            this.txtOld.Lines = new string[0];
            this.txtOld.Location = new System.Drawing.Point(45, 72);
            this.txtOld.MaxLength = 32767;
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '●';
            this.txtOld.PromptText = "Old Password";
            this.txtOld.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtOld.SelectedText = "";
            this.txtOld.SelectionLength = 0;
            this.txtOld.SelectionStart = 0;
            this.txtOld.ShortcutsEnabled = true;
            this.txtOld.Size = new System.Drawing.Size(274, 26);
            this.txtOld.TabIndex = 4;
            this.txtOld.UseSelectable = true;
            this.txtOld.UseSystemPasswordChar = true;
            this.txtOld.WaterMark = "Old Password";
            this.txtOld.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtOld.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtNew
            // 
            // 
            // 
            // 
            this.txtNew.CustomButton.Image = null;
            this.txtNew.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.txtNew.CustomButton.Name = "";
            this.txtNew.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtNew.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtNew.CustomButton.TabIndex = 1;
            this.txtNew.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtNew.CustomButton.UseSelectable = true;
            this.txtNew.CustomButton.Visible = false;
            this.txtNew.DisplayIcon = true;
            this.txtNew.Icon = ((System.Drawing.Image)(resources.GetObject("txtNew.Icon")));
            this.txtNew.Lines = new string[0];
            this.txtNew.Location = new System.Drawing.Point(45, 104);
            this.txtNew.MaxLength = 32767;
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '●';
            this.txtNew.PromptText = "New Password";
            this.txtNew.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNew.SelectedText = "";
            this.txtNew.SelectionLength = 0;
            this.txtNew.SelectionStart = 0;
            this.txtNew.ShortcutsEnabled = true;
            this.txtNew.Size = new System.Drawing.Size(274, 26);
            this.txtNew.TabIndex = 5;
            this.txtNew.UseSelectable = true;
            this.txtNew.UseSystemPasswordChar = true;
            this.txtNew.WaterMark = "New Password";
            this.txtNew.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtNew.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtConfNew
            // 
            // 
            // 
            // 
            this.txtConfNew.CustomButton.Image = null;
            this.txtConfNew.CustomButton.Location = new System.Drawing.Point(250, 2);
            this.txtConfNew.CustomButton.Name = "";
            this.txtConfNew.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtConfNew.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtConfNew.CustomButton.TabIndex = 1;
            this.txtConfNew.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtConfNew.CustomButton.UseSelectable = true;
            this.txtConfNew.CustomButton.Visible = false;
            this.txtConfNew.DisplayIcon = true;
            this.txtConfNew.Icon = ((System.Drawing.Image)(resources.GetObject("txtConfNew.Icon")));
            this.txtConfNew.Lines = new string[0];
            this.txtConfNew.Location = new System.Drawing.Point(45, 136);
            this.txtConfNew.MaxLength = 32767;
            this.txtConfNew.Name = "txtConfNew";
            this.txtConfNew.PasswordChar = '●';
            this.txtConfNew.PromptText = "Confirm New Password";
            this.txtConfNew.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConfNew.SelectedText = "";
            this.txtConfNew.SelectionLength = 0;
            this.txtConfNew.SelectionStart = 0;
            this.txtConfNew.ShortcutsEnabled = true;
            this.txtConfNew.Size = new System.Drawing.Size(274, 26);
            this.txtConfNew.TabIndex = 6;
            this.txtConfNew.UseSelectable = true;
            this.txtConfNew.UseSystemPasswordChar = true;
            this.txtConfNew.WaterMark = "Confirm New Password";
            this.txtConfNew.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtConfNew.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(45, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(274, 33);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfNew);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtOld;
        private MetroFramework.Controls.MetroTextBox txtNew;
        private MetroFramework.Controls.MetroTextBox txtConfNew;
        private System.Windows.Forms.Button btnSave;
    }
}