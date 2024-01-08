
namespace ExperimentalDataProcessing.Labs._1_semester
{
	partial class Lab3_1Form
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
			this.label3 = new System.Windows.Forms.Label();
			this.txtN1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtN2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtC = new System.Windows.Forms.TextBox();
			this.btnPlot = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(1147, 513);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 18);
			this.label3.TabIndex = 23;
			this.label3.Text = "N1 =";
			// 
			// txtN1
			// 
			this.txtN1.Location = new System.Drawing.Point(1204, 509);
			this.txtN1.Name = "txtN1";
			this.txtN1.Size = new System.Drawing.Size(100, 22);
			this.txtN1.TabIndex = 22;
			this.txtN1.Text = "300";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(1147, 541);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 18);
			this.label2.TabIndex = 21;
			this.label2.Text = "N2 =";
			// 
			// txtN2
			// 
			this.txtN2.Location = new System.Drawing.Point(1204, 537);
			this.txtN2.Name = "txtN2";
			this.txtN2.Size = new System.Drawing.Size(100, 22);
			this.txtN2.TabIndex = 20;
			this.txtN2.Text = "500";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(1147, 569);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 18);
			this.label1.TabIndex = 19;
			this.label1.Text = "C =";
			// 
			// txtC
			// 
			this.txtC.Location = new System.Drawing.Point(1204, 566);
			this.txtC.Name = "txtC";
			this.txtC.Size = new System.Drawing.Size(100, 22);
			this.txtC.TabIndex = 18;
			this.txtC.Text = "0,5";
			// 
			// btnPlot
			// 
			this.btnPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnPlot.Location = new System.Drawing.Point(1150, 626);
			this.btnPlot.Name = "btnPlot";
			this.btnPlot.Size = new System.Drawing.Size(205, 41);
			this.btnPlot.TabIndex = 17;
			this.btnPlot.Text = "Рассчитать данные";
			this.btnPlot.UseVisualStyleBackColor = true;
			this.btnPlot.Click += new System.EventHandler(this.btnPlot_Click);
			// 
			// chart1
			// 
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Enabled = false;
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(570, 387);
			this.chart1.Name = "chart1";
			series1.BorderWidth = 2;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Data";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(484, 280);
			this.chart1.TabIndex = 16;
			// 
			// Lab3_1Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtN1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtN2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtC);
			this.Controls.Add(this.btnPlot);
			this.Controls.Add(this.chart1);
			this.Name = "Lab3_1Form";
			this.Text = "Lab3_1Form";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtN1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtN2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtC;
		private System.Windows.Forms.Button btnPlot;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}