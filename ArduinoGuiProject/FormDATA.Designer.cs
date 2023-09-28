namespace ArduinoGuiProject
{
    partial class FormDATA
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartTemp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TxtChartTemp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ChartTemp)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartTemp
            // 
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 80F;
            chartArea2.InnerPlotPosition.Width = 87.5F;
            chartArea2.InnerPlotPosition.X = 7F;
            chartArea2.InnerPlotPosition.Y = 5F;
            chartArea2.Name = "ChartArea1";
            this.ChartTemp.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartTemp.Legends.Add(legend2);
            this.ChartTemp.Location = new System.Drawing.Point(12, 12);
            this.ChartTemp.Name = "ChartTemp";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Temperature";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Humidity";
            this.ChartTemp.Series.Add(series3);
            this.ChartTemp.Series.Add(series4);
            this.ChartTemp.Size = new System.Drawing.Size(889, 456);
            this.ChartTemp.TabIndex = 1;
            this.ChartTemp.Click += new System.EventHandler(this.ChartTemp_Click);
            // 
            // TxtChartTemp
            // 
            this.TxtChartTemp.Location = new System.Drawing.Point(731, 80);
            this.TxtChartTemp.Multiline = true;
            this.TxtChartTemp.Name = "TxtChartTemp";
            this.TxtChartTemp.ReadOnly = true;
            this.TxtChartTemp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtChartTemp.Size = new System.Drawing.Size(144, 327);
            this.TxtChartTemp.TabIndex = 2;
            // 
            // FormDATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 480);
            this.Controls.Add(this.TxtChartTemp);
            this.Controls.Add(this.ChartTemp);
            this.Name = "FormDATA";
            this.Text = "DATA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDATA_FormClosed);
            this.Load += new System.EventHandler(this.FormDATA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartTemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.DataVisualization.Charting.Chart ChartTemp;
        private System.Windows.Forms.TextBox TxtChartTemp;
    }
}