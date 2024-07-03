using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace NetworkMonitor
{
    public partial class Form1 : Form
    {

        private NetworkInterface selectedInterface;
        private System.Windows.Forms.Timer timer;
        private NetworkInterfaceStatistics initialStats;

        public Form1()
        {
            InitializeComponent();
            InitializeNetworkInterfaceSelection();
            InitializeCharts();
        }

        private void InitializeNetworkInterfaceSelection()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var ni in interfaces)
            {
                comboBoxInterfaces.Items.Add($"{ni.Name} - {ni.Description}");
            }

            if (comboBoxInterfaces.Items.Count > 0)
            {
                comboBoxInterfaces.SelectedIndex = 0;
                selectedInterface = interfaces[0];
            }

            comboBoxInterfaces.SelectedIndexChanged += (s, e) =>
            {
                selectedInterface = interfaces[comboBoxInterfaces.SelectedIndex];
                initialStats = GetNetworkStatistics(selectedInterface);
            };

            initialStats = GetNetworkStatistics(selectedInterface);
        }

        private void InitializeCharts()
        {
            // Inicializando e configurando o chartTraffic
            ChartArea trafficChartArea = new ChartArea();
            trafficChartArea.AxisX.LabelStyle.Format = "hh:mm:ss";
            trafficChartArea.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            trafficChartArea.AxisY.LabelStyle.Format = "{0,0}";
            chartTraffic.ChartAreas.Clear();
            chartTraffic.ChartAreas.Add(trafficChartArea);

            Series seriesSent = new Series("Bytes Sent")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2 // Define a espessura da linha
            };
            Series seriesReceived = new Series("Bytes Received")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2 // Define a espessura da linha
            };

            chartTraffic.Series.Clear();
            chartTraffic.Series.Add(seriesSent);
            chartTraffic.Series.Add(seriesReceived);

            // Inicializando e configurando o chartInternet
            ChartArea internetChartArea = new ChartArea();
            internetChartArea.AxisX.LabelStyle.Format = "hh:mm:ss";
            internetChartArea.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            internetChartArea.AxisY.LabelStyle.Format = "{0,0}";
            chartInternet.ChartAreas.Clear();
            chartInternet.ChartAreas.Add(internetChartArea);

            Series seriesInternet = new Series("Internet Latency (ms)")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2 // Define a espessura da linha
            };

            chartInternet.Series.Clear();
            chartInternet.Series.Add(seriesInternet);

            // Inicializando e configurando o chartDNS
            ChartArea dnsChartArea = new ChartArea();
            dnsChartArea.AxisX.LabelStyle.Format = "hh:mm:ss";
            dnsChartArea.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            dnsChartArea.AxisY.LabelStyle.Format = "{0,0}";
            chartDNS.ChartAreas.Clear();
            chartDNS.ChartAreas.Add(dnsChartArea);

            Series seriesDNS = new Series("DNS Latency (ms)")
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2 // Define a espessura da linha
            };

            chartDNS.Series.Clear();
            chartDNS.Series.Add(seriesDNS);

            // Configurando o timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var finalStats = GetNetworkStatistics(selectedInterface);

            long bytesSent = finalStats.BytesSent - initialStats.BytesSent;
            long bytesReceived = finalStats.BytesReceived - initialStats.BytesReceived;

            initialStats = finalStats;

            chartTraffic.Series["Bytes Sent"].Points.AddXY(DateTime.Now, bytesSent);
            chartTraffic.Series["Bytes Received"].Points.AddXY(DateTime.Now, bytesReceived);

            if (chartTraffic.Series["Bytes Sent"].Points.Count > 60)
            {
                chartTraffic.Series["Bytes Sent"].Points.RemoveAt(0);
                chartTraffic.Series["Bytes Received"].Points.RemoveAt(0);
            }

            long dnsLatency = TestDNSLatency();
            chartInternet.Series["Internet Latency (ms)"].Points.AddXY(DateTime.Now, dnsLatency);
            chartDNS.Series["DNS Latency (ms)"].Points.AddXY(DateTime.Now, dnsLatency);

            if (chartInternet.Series["Internet Latency (ms)"].Points.Count > 60)
            {
                chartInternet.Series["Internet Latency (ms)"].Points.RemoveAt(0);
            }

            if (chartDNS.Series["DNS Latency (ms)"].Points.Count > 60)
            {
                chartDNS.Series["DNS Latency (ms)"].Points.RemoveAt(0);
            }

            chartTraffic.ResetAutoValues();
            chartInternet.ResetAutoValues();
            chartDNS.ResetAutoValues();
        }

        private NetworkInterfaceStatistics GetNetworkStatistics(NetworkInterface networkInterface)
        {
            return new NetworkInterfaceStatistics
            {
                BytesSent = networkInterface.GetIPv4Statistics().BytesSent,
                BytesReceived = networkInterface.GetIPv4Statistics().BytesReceived
            };
        }

        private long TestDNSLatency()
        {
            try
            {
                IPInterfaceProperties properties = selectedInterface.GetIPProperties();
                foreach (IPAddress dns in properties.DnsAddresses)
                {
                    using (var ping = new Ping())
                    {
                        PingReply reply = ping.Send(dns, 1000); // Ping para o servidor DNS configurado
                        if (reply.Status == IPStatus.Success)
                        {
                            return reply.RoundtripTime;
                        }
                    }
                }
                return 1000; // Se falhar, retorna 1000 ms como valor de falha
            }
            catch
            {
                return 1000; // Se ocorrer um erro, retorna 1000 ms como valor de falha
            }
        }

        private void ButtonTestInternet_Click(object sender, EventArgs e)
        {
            long dnsLatency = TestDNSLatency();
            labelInternetStatus.Text = dnsLatency < 1000 ? $"Internet Latency: {dnsLatency} ms" : "Internet: Indisponível";
        }

        private void ButtonTestDNS_Click(object sender, EventArgs e)
        {
            long dnsLatency = TestDNSLatency();
            labelDNSStatus.Text = dnsLatency < 1000 ? $"DNS Latency: {dnsLatency} ms" : "DNS: Não Funcionando";
        }
    }

    public class NetworkInterfaceStatistics
    {
        public long BytesSent { get; set; }
        public long BytesReceived { get; set; }
    }
}

