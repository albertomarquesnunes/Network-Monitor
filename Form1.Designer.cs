namespace NetworkMonitor
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTraffic;
        private System.Windows.Forms.ComboBox comboBoxInterfaces;
        private System.Windows.Forms.Button buttonTestInternet;
        private System.Windows.Forms.Button buttonTestDNS;
        private System.Windows.Forms.Label labelInternetStatus;
        private System.Windows.Forms.Label labelDNSStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartInternet;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDNS;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chartTraffic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxInterfaces = new System.Windows.Forms.ComboBox();
            this.buttonTestInternet = new System.Windows.Forms.Button();
            this.buttonTestDNS = new System.Windows.Forms.Button();
            this.labelInternetStatus = new System.Windows.Forms.Label();
            this.labelDNSStatus = new System.Windows.Forms.Label();
            this.chartInternet = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartDNS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartTraffic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInternet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDNS)).BeginInit();
            this.SuspendLayout();
            // 
            // chartTraffic
            // 
            this.chartTraffic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartTraffic.Location = new System.Drawing.Point(10, 81);
            this.chartTraffic.Name = "chartTraffic";
            this.chartTraffic.Size = new System.Drawing.Size(999, 162);
            this.chartTraffic.TabIndex = 0;
            this.chartTraffic.Text = "chart1";
            // 
            // comboBoxInterfaces
            // 
            this.comboBoxInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterfaces.FormattingEnabled = true;
            this.comboBoxInterfaces.Location = new System.Drawing.Point(10, 10);
            this.comboBoxInterfaces.Name = "comboBoxInterfaces";
            this.comboBoxInterfaces.Size = new System.Drawing.Size(666, 21);
            this.comboBoxInterfaces.TabIndex = 1;
            // 
            // buttonTestInternet
            // 
            this.buttonTestInternet.Location = new System.Drawing.Point(10, 36);
            this.buttonTestInternet.Name = "buttonTestInternet";
            this.buttonTestInternet.Size = new System.Drawing.Size(120, 20);
            this.buttonTestInternet.TabIndex = 2;
            this.buttonTestInternet.Text = "Testar Conexão Internet";
            this.buttonTestInternet.UseVisualStyleBackColor = true;
            this.buttonTestInternet.Click += new System.EventHandler(this.ButtonTestInternet_Click);
            // 
            // buttonTestDNS
            // 
            this.buttonTestDNS.Location = new System.Drawing.Point(135, 36);
            this.buttonTestDNS.Name = "buttonTestDNS";
            this.buttonTestDNS.Size = new System.Drawing.Size(120, 20);
            this.buttonTestDNS.TabIndex = 3;
            this.buttonTestDNS.Text = "Testar DNS";
            this.buttonTestDNS.UseVisualStyleBackColor = true;
            this.buttonTestDNS.Click += new System.EventHandler(this.ButtonTestDNS_Click);
            // 
            // labelInternetStatus
            // 
            this.labelInternetStatus.AutoSize = true;
            this.labelInternetStatus.Location = new System.Drawing.Point(309, 39);
            this.labelInternetStatus.Name = "labelInternetStatus";
            this.labelInternetStatus.Size = new System.Drawing.Size(69, 13);
            this.labelInternetStatus.TabIndex = 4;
            this.labelInternetStatus.Text = "Internet: N/A";
            // 
            // labelDNSStatus
            // 
            this.labelDNSStatus.AutoSize = true;
            this.labelDNSStatus.Location = new System.Drawing.Point(484, 39);
            this.labelDNSStatus.Name = "labelDNSStatus";
            this.labelDNSStatus.Size = new System.Drawing.Size(56, 13);
            this.labelDNSStatus.TabIndex = 5;
            this.labelDNSStatus.Text = "DNS: N/A";
            // 
            // chartInternet
            // 
            this.chartInternet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartInternet.Location = new System.Drawing.Point(12, 266);
            this.chartInternet.Name = "chartInternet";
            this.chartInternet.Size = new System.Drawing.Size(997, 164);
            this.chartInternet.TabIndex = 6;
            this.chartInternet.Text = "chart2";
            // 
            // chartDNS
            // 
            this.chartDNS.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chartDNS.Location = new System.Drawing.Point(12, 465);
            this.chartDNS.Name = "chartDNS";
            this.chartDNS.Size = new System.Drawing.Size(997, 165);
            this.chartDNS.TabIndex = 7;
            this.chartDNS.Text = "chart3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Dns Latency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Internet Latency";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Network Traffic";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1031, 642);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartDNS);
            this.Controls.Add(this.chartInternet);
            this.Controls.Add(this.labelDNSStatus);
            this.Controls.Add(this.labelInternetStatus);
            this.Controls.Add(this.buttonTestDNS);
            this.Controls.Add(this.buttonTestInternet);
            this.Controls.Add(this.comboBoxInterfaces);
            this.Controls.Add(this.chartTraffic);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Traffic Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.chartTraffic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartInternet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDNS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}