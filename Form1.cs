using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Net;
using System.Diagnostics;
using System.Xml.Linq;
using System.Net.Http;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly static HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        public class DetectionResults
        {

            public int error_code { get; set; }
            public string log_image { get; set; }
            public List<DetectionObject> results { get; set; }
        }

        public class DetectionObject
        {
            public string name
            {
                get; set;

            }
            public double score
            {
                get; set;
            }
            public double left { get; set; }
            public double top { get; set; }
            public double right { get; set; }
            public double bottom { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public double centerX { get; set; }
            public double centerY { get; set; }
        }

        // X坐标比较器
        class XComparer : IComparer<DetectionObject>
        {
            //实现升序

            public int Compare(DetectionObject x, DetectionObject y)
            {
                return x.centerX.CompareTo(y.centerX);
            }


        }

        private static async Task<string> SendRequestAsync(string url)
        {
            string stringData;
            try
            {
                stringData = await _httpClient.GetStringAsync($"http://{url}:8080/json?score");
            }
            catch (InvalidOperationException)
            {
                return "The requestUri must be an absoute URI or BaseAddress must be set";
            }
            catch (HttpRequestException)
            {
                return "The request failed due to an underlying issue such as network connectivity DNS failure, server certificate validation.";
            }
            catch (TaskCanceledException)
            {
                return "The request fialed due to timeout";
            }
            return stringData;
        }

        private async void buttonSingleRead_Click(object sender, EventArgs e)
        {
            buttonSingleRead.Enabled = false;
            buttonContinuousRead.Enabled = false;
            Stopwatch stopwatch = Stopwatch.StartNew();
            textJson.Text = await SendRequestAsync(comboBox1.Text);
            string indata = textJson.Text.Trim();
            StringBuilder sb = new StringBuilder();
            StringBuilder dc = new StringBuilder(); //detection confidence


            try
            {
                DetectionResults Result = JsonSerializer.Deserialize<DetectionResults>(indata);
                if (Result.results.Count() > 0)
                {
                    Result.results.Sort(new XComparer());
                    foreach (DetectionObject obj in Result.results)
                    {
                        sb.Append(obj.name);
                        dc.Append(obj.name);
                        dc.Append('\t');
                        dc.Append(obj.score);
                        dc.Append("\r\n");
                    }
                    labelGetCode.Text = sb.ToString();
                    textCode.Text = dc.ToString();
                }
            }
            catch
            {
                labelGetCode.BackColor = Color.Red;
            }

            stopwatch.Stop();
            labelTestTime.Text = stopwatch.ElapsedMilliseconds.ToString();
            string target_code = textBoxSetCode.Text.Trim();
            if (target_code.Length == 0)
                labelGetCode.BackColor = Color.LightGray;
            if (String.Equals(sb.ToString(), target_code))
                labelGetCode.BackColor = Color.LightGreen;
            else
                labelGetCode.BackColor = Color.LightPink;
            labelRespondTimes.Text = "1";
            buttonSingleRead.Enabled = true;
            buttonContinuousRead.Enabled = true;
        }


        private async void buttonContinuousRead_Click(object sender, EventArgs e)
        {
            buttonContinuousRead.Enabled = false;
            buttonSingleRead.Enabled = false;
            labelGetCode.BackColor= Color.LightGray;
            Stopwatch stopwatch = Stopwatch.StartNew();
            string target_code = textBoxSetCode.Text.Trim();
            StringBuilder sb = new StringBuilder();
            StringBuilder dc = new StringBuilder(); //detection confidence
            int requestTimes = 0;
            int respondTimes = 0;
            labelGetCode.Text = "";
            textCode.Text = "";
            string indata;
            List<DetectionResults> results = new List<DetectionResults>();

            do
            {
                requestTimes++;
                indata = await SendRequestAsync(comboBox1.Text);
                textJson.Text = indata;
                if (!indata.StartsWith("{"))
                {

                    labelRequestTimes.Text = respondTimes.ToString();
                    labelTestTime.Text = stopwatch.ElapsedMilliseconds.ToString();
                    continue;
                }

                try
                {
                    labelRespondTimes.Text = respondTimes.ToString();
                    DetectionResults Result = JsonSerializer.Deserialize<DetectionResults>(indata);
                    if (Result.results.Count() > 0)
                    {
                        respondTimes++;
                        sb.Clear();
                        dc.Clear();
                        Result.results.Sort(new XComparer());
                        foreach (DetectionObject obj in Result.results)
                        {
                            sb.Append(obj.name);
                            dc.Append(obj.name);
                            dc.Append('\t');
                            dc.Append(obj.score);
                            dc.Append("\r\n");
                        }
                        labelGetCode.Text = sb.ToString();
                        textCode.Text = dc.ToString();
                        results.Add(Result);
                    }
                }
                catch
                {
                    labelGetCode.BackColor = Color.Red;
                }
            } while (!String.Equals(sb.ToString(), target_code) && stopwatch.Elapsed.Seconds < Convert.ToInt32(textBoxTimeout.Text));

            stopwatch.Stop();
            labelTestTime.Text = stopwatch.ElapsedMilliseconds.ToString();
            labelRespondTimes.Text = respondTimes.ToString();
            labelRequestTimes.Text = requestTimes.ToString();
            if (respondTimes > 0)
                labelAverageTime.Text = Convert.ToString(stopwatch.ElapsedMilliseconds / respondTimes);
            else
                labelAverageTime.Text = "N/A";
            if (String.Equals(sb.ToString(), target_code))
            {
                labelGetCode.BackColor = Color.LightGreen;
                labelGetCode.Text = sb.ToString();
            }
            else
            {
                labelGetCode.BackColor = Color.LightPink;
                DetectionResults minR = null;
                double minminC = 0;
                foreach (DetectionResults r in results)
                {
                    double minC = 0;
                    foreach (DetectionObject o in r.results)
                    {
                        if (o.score > minC)
                            minC = o.score;
                    }
                    if (minC > minminC)
                    {
                        minminC = minC;
                        minR = r;
                    }
                }

                sb.Clear();
                dc.Clear();
                if (minR != null)
                {
                    minR.results.Sort(new XComparer());
                    foreach (DetectionObject obj in minR.results)
                    {
                        sb.Append(obj.name);
                        dc.Append(obj.name);
                        dc.Append('\t');
                        dc.Append(obj.score);
                        dc.Append("\r\n");
                    }
                    labelGetCode.Text = sb.ToString();
                    textCode.Text = dc.ToString();
                }
            }
            buttonContinuousRead.Enabled = true;
            buttonSingleRead.Enabled = true;
        }
    }
}
