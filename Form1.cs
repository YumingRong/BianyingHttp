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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void updateCountInDelegate(int n)
        {
            labelRespondTimes.Text = n.ToString();
        }

        delegate void updateCountDelegate(int n);
        private void updateCountInInThread(int n)
        {
            this.BeginInvoke(new updateCountDelegate(updateCountInDelegate), n);
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
            string _Name = "";
            double _score = 0;
            public string name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }

            }
            public string label
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                }

            }
            public double confidence
            {
                get
                {
                    return _score;
                }
                set
                {
                    _score = value;
                }

            }
            public double score
            {
                get
                {
                    return _score;
                }
                set
                {
                    _score = value;
                }
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

        private static string SendRequest(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://" + url + ":8080/json?score");
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            Stream readStream = webResponse.GetResponseStream();
            string result = "";
            if (readStream.CanRead)
            {
                StreamReader sr = new StreamReader(readStream, Encoding.UTF8);
                result = sr.ReadToEnd();
                sr.Close();
            }
            webResponse.Close();
            return result;
        }

        private void buttonSingleRead_Click(object sender, EventArgs e)
        {
            buttonSingleRead.Enabled = false;
            textJson.Text = SendRequest(comboBox1.Text);
            string indata = textJson.Text.Trim();
            StringBuilder sb = new StringBuilder();
            StringBuilder dc = new StringBuilder(); //detection confidence

            Stopwatch stopwatch = Stopwatch.StartNew();

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
        }

        private void buttonContinuousRead_Click(object sender, EventArgs e)
        {
            buttonContinuousRead.Enabled = false;
            string target_code = textBoxSetCode.Text.Trim();
            StringBuilder sb = new StringBuilder();
            StringBuilder dc = new StringBuilder(); //detection confidence
            int requestTimes = 0;
            int respondTimes = 0;
            labelGetCode.Text = "";
            textCode.Text = "";
            string indata;
            Stopwatch stopwatch = Stopwatch.StartNew();

            do
            {
                requestTimes++;
                indata = SendRequest(comboBox1.Text);
                if (!indata.StartsWith("{"))
                {
                    labelRequestTimes.Invoke(new Action<int>(i => { labelRequestTimes.Text = i.ToString(); }), requestTimes);
                    labelTestTime.Invoke(new Action<long>(i => { labelTestTime.Text = i.ToString(); }), stopwatch.ElapsedMilliseconds);
                    continue;
                }

                try
                {
                    labelRespondTimes.Invoke(new Action<int>(i => { labelRespondTimes.Text = i.ToString(); }), respondTimes);
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
                        labelGetCode.Invoke(new Action<string>(s => { labelGetCode.Text = s; }), sb.ToString());
                        textCode.Text = dc.ToString();
                    }
                }
                catch
                {
                    labelGetCode.BackColor = Color.Red;
                }
            } while (sb.ToString().Length < target_code.Length && stopwatch.Elapsed.Seconds < Convert.ToInt32(textBoxTimeout.Text));

            stopwatch.Stop();
            labelTestTime.Text = stopwatch.ElapsedMilliseconds.ToString();
            labelRespondTimes.Text = respondTimes.ToString();
            labelRequestTimes.Text = requestTimes.ToString();
            labelAverageTime.Text = Convert.ToString(stopwatch.ElapsedMilliseconds / respondTimes);
            labelGetCode.Text = sb.ToString();
            textJson.Text = indata;
            if (String.Equals(sb.ToString(), target_code))
                labelGetCode.BackColor = Color.LightGreen;
            else
                labelGetCode.BackColor = Color.LightPink;
            buttonContinuousRead.Enabled = true;
        }
    }
}
