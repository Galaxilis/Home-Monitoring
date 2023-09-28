namespace ArduinoGuiProject
{
    partial class FormCheck
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
            this.components = new System.ComponentModel.Container();
            this.GrpCheck = new System.Windows.Forms.GroupBox();
            this.BtnCheckConnection = new System.Windows.Forms.Button();
            this.TxtCheckConnection = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.GrpCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpCheck
            // 
            this.GrpCheck.Controls.Add(this.TxtCheckConnection);
            this.GrpCheck.Controls.Add(this.BtnCheckConnection);
            this.GrpCheck.Location = new System.Drawing.Point(12, 12);
            this.GrpCheck.Name = "GrpCheck";
            this.GrpCheck.Size = new System.Drawing.Size(339, 151);
            this.GrpCheck.TabIndex = 0;
            this.GrpCheck.TabStop = false;
            this.GrpCheck.Text = "Check";
            // 
            // BtnCheckConnection
            // 
            this.BtnCheckConnection.Location = new System.Drawing.Point(117, 29);
            this.BtnCheckConnection.Name = "BtnCheckConnection";
            this.BtnCheckConnection.Size = new System.Drawing.Size(104, 28);
            this.BtnCheckConnection.TabIndex = 0;
            this.BtnCheckConnection.Text = "Check";
            this.BtnCheckConnection.UseVisualStyleBackColor = true;
            this.BtnCheckConnection.Click += new System.EventHandler(this.BtnCheckConnection_Click);
            // 
            // TxtCheckConnection
            // 
            this.TxtCheckConnection.Location = new System.Drawing.Point(6, 63);
            this.TxtCheckConnection.Multiline = true;
            this.TxtCheckConnection.Name = "TxtCheckConnection";
            this.TxtCheckConnection.Size = new System.Drawing.Size(327, 82);
            this.TxtCheckConnection.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 175);
            this.Controls.Add(this.GrpCheck);
            this.Name = "FormCheck";
            this.Text = "Check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCheck_FormClosed);
            this.Load += new System.EventHandler(this.FormCheck_Load);
            this.GrpCheck.ResumeLayout(false);
            this.GrpCheck.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox GrpCheck;
        private System.Windows.Forms.Button BtnCheckConnection;
        private System.Windows.Forms.TextBox TxtCheckConnection;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}