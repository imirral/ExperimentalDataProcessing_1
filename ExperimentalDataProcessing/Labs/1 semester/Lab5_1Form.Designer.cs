
namespace ExperimentalDataProcessing.Labs._1_semester
{
	partial class Lab5_1Form
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtDt = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtf0 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label5 = new System.Windows.Forms.Label();
			this.txtA0 = new System.Windows.Forms.TextBox();
			this.btnPlot = new System.Windows.Forms.Button();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(542, 642);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 18);
			this.label2.TabIndex = 46;
			this.label2.Text = "Δt =";
			// 
			// txtDt
			// 
			this.txtDt.Location = new System.Drawing.Point(598, 638);
			this.txtDt.Name = "txtDt";
			this.txtDt.Size = new System.Drawing.Size(100, 22);
			this.txtDt.TabIndex = 45;
			this.txtDt.Text = "0,001";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(542, 598);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 18);
			this.label1.TabIndex = 44;
			this.label1.Text = "f₀ =";
			// 
			// txtf0
			// 
			this.txtf0.Location = new System.Drawing.Point(598, 594);
			this.txtf0.Name = "txtf0";
			this.txtf0.Size = new System.Drawing.Size(100, 22);
			this.txtf0.TabIndex = 43;
			this.txtf0.Text = "15";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Location = new System.Drawing.Point(545, 354);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(349, 172);
			this.groupBox1.TabIndex = 42;
			this.groupBox1.TabStop = false;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton2.Location = new System.Drawing.Point(34, 98);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(170, 24);
			this.radioButton2.TabIndex = 1;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "x(t) = polyHarm(f₀)";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.radioButton1.Location = new System.Drawing.Point(34, 46);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(136, 24);
			this.radioButton1.TabIndex = 0;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "x(t) = harm(f₀)";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(542, 557);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 18);
			this.label5.TabIndex = 41;
			this.label5.Text = "A₀ =";
			// 
			// txtA0
			// 
			this.txtA0.Location = new System.Drawing.Point(598, 553);
			this.txtA0.Name = "txtA0";
			this.txtA0.Size = new System.Drawing.Size(100, 22);
			this.txtA0.TabIndex = 40;
			this.txtA0.Text = "100";
			// 
			// btnPlot
			// 
			this.btnPlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnPlot.Location = new System.Drawing.Point(979, 659);
			this.btnPlot.Name = "btnPlot";
			this.btnPlot.Size = new System.Drawing.Size(205, 41);
			this.btnPlot.TabIndex = 39;
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
			this.chart1.Location = new System.Drawing.Point(979, 354);
			this.chart1.Name = "chart1";
			series1.BorderWidth = 2;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Legend = "Legend1";
			series1.Name = "Data";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(404, 262);
			this.chart1.TabIndex = 38;
			// 
			// Lab5_1Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1924, 1055);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDt);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtf0);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtA0);
			this.Controls.Add(this.btnPlot);
			this.Controls.Add(this.chart1);
			this.Name = "Lab5_1Form";
			this.Text = "Lab5_1Form";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtDt;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtf0;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtA0;
		private System.Windows.Forms.Button btnPlot;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
	}
}