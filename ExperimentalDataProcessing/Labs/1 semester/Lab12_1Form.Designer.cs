﻿
namespace ExperimentalDataProcessing.Labs._1_semester
{
	partial class Lab12_1Form
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(1120, 304);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(163, 20);
			this.label2.TabIndex = 49;
			this.label2.Text = "2 * m + 1 Potter LPF";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(647, 304);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 20);
			this.label1.TabIndex = 48;
			this.label1.Text = "m + 1 Potter LPF";
			// 
			// chart2
			// 
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.CursorY.IsUserEnabled = true;
			chartArea1.CursorY.IsUserSelectionEnabled = true;
			chartArea1.Name = "ChartArea1";
			this.chart2.ChartAreas.Add(chartArea1);
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.chart2.Legends.Add(legend1);
			this.chart2.Location = new System.Drawing.Point(998, 352);
			this.chart2.Name = "chart2";
			series1.BorderWidth = 2;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Data";
			this.chart2.Series.Add(series1);
			this.chart2.Size = new System.Drawing.Size(413, 399);
			this.chart2.TabIndex = 47;
			// 
			// chart1
			// 
			chartArea2.AxisX.MajorGrid.Enabled = false;
			chartArea2.AxisY.MajorGrid.Enabled = false;
			chartArea2.CursorX.IsUserEnabled = true;
			chartArea2.CursorX.IsUserSelectionEnabled = true;
			chartArea2.CursorY.IsUserEnabled = true;
			chartArea2.CursorY.IsUserSelectionEnabled = true;
			chartArea2.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea2);
			legend2.Enabled = false;
			legend2.Name = "Legend1";
			this.chart1.Legends.Add(legend2);
			this.chart1.Location = new System.Drawing.Point(514, 352);
			this.chart1.Name = "chart1";
			series2.BorderWidth = 2;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Legend = "Legend1";
			series2.Name = "Data";
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(413, 399);
			this.chart1.TabIndex = 46;
			// 
			// Lab12_1Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chart2);
			this.Controls.Add(this.chart1);
			this.Name = "Lab12_1Form";
			this.Text = "Lab12_1Form";
			this.Load += new System.EventHandler(this.Lab12_1Form_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}