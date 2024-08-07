﻿namespace ArduinoGuiProject
{
    partial class HomeMonitoring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeMonitoring));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CheckMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DATAMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtMotionDetected = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CameraBox = new System.Windows.Forms.PictureBox();
            this.BtnLockUnlock = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckMenu,
            this.DATAMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(5280, 150);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CheckMenu
            // 
            this.CheckMenu.Name = "CheckMenu";
            this.CheckMenu.Size = new System.Drawing.Size(123, 140);
            this.CheckMenu.Text = "Check";
            this.CheckMenu.Click += new System.EventHandler(this.CheckMenu_Click);
            // 
            // DATAMenu
            // 
            this.DATAMenu.Name = "DATAMenu";
            this.DATAMenu.Size = new System.Drawing.Size(112, 140);
            this.DATAMenu.Text = "DATA";
            this.DATAMenu.Click += new System.EventHandler(this.DATAMenu_Click);
            // 
            // TxtMotionDetected
            // 
            this.TxtMotionDetected.Location = new System.Drawing.Point(1131, 250);
            this.TxtMotionDetected.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.TxtMotionDetected.Name = "TxtMotionDetected";
            this.TxtMotionDetected.ReadOnly = true;
            this.TxtMotionDetected.Size = new System.Drawing.Size(468, 38);
            this.TxtMotionDetected.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1123, 212);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Motion Detected";
            // 
            // CameraBox
            // 
            this.CameraBox.Location = new System.Drawing.Point(32, 479);
            this.CameraBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.CameraBox.Name = "CameraBox";
            this.CameraBox.Size = new System.Drawing.Size(2048, 1061);
            this.CameraBox.TabIndex = 5;
            this.CameraBox.TabStop = false;
            // 
            // BtnLockUnlock
            // 
            this.BtnLockUnlock.BackColor = System.Drawing.Color.LimeGreen;
            this.BtnLockUnlock.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLockUnlock.Image = global::ArduinoGuiProject.Properties.Resources.Key;
            this.BtnLockUnlock.Location = new System.Drawing.Point(32, 64);
            this.BtnLockUnlock.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnLockUnlock.Name = "BtnLockUnlock";
            this.BtnLockUnlock.Size = new System.Drawing.Size(723, 401);
            this.BtnLockUnlock.TabIndex = 0;
            this.BtnLockUnlock.Text = "UNLOCKED";
            this.BtnLockUnlock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLockUnlock.UseVisualStyleBackColor = false;
            this.BtnLockUnlock.Click += new System.EventHandler(this.BtnLockUnlock_Click);
            // 
            // HomeMonitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2112, 1569);
            this.Controls.Add(this.CameraBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtMotionDetected);
            this.Controls.Add(this.BtnLockUnlock);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "HomeMonitoring";
            this.Text = "Home Monitoring";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HomeMonitoring_FormClosed);
            this.Load += new System.EventHandler(this.HomeMonitoring_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CameraBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLockUnlock;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CheckMenu;
        private System.Windows.Forms.TextBox TxtMotionDetected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem DATAMenu;
        private System.Windows.Forms.PictureBox CameraBox;
    }
}
