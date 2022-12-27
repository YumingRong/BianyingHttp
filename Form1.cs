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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        delegate void updateColorDelegate(Color obj);
        private void updateColorInDelegate(Color c)
        {
            textHttp.BackColor = c;
        }

        private void updateColorInThread(Color c)
        {
            updateColorDelegate d = new updateColorDelegate(updateColorInDelegate);
            this.Invoke(d, c);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
        }

        private static string SendRequest(string url,Encoding encoding)
        {
            url = "http://" + url + ":8080/json";
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "GET";
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), encoding);
            return sr.ReadToEnd();

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


        private void buttonIdentify_Click(object sender, EventArgs e)
        {
            textHttp.Text = SendRequest(comboBox1.Text, Encoding.UTF8);
            string indata = textHttp.Text.Trim();
            if (indata.StartsWith("{"))
            {
                try
                {
                    DetectionResults Result = JsonSerializer.Deserialize<DetectionResults>(indata);
                    if (Result.results.Count() > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        Result.results.Sort(new XComparer());
                        foreach (DetectionObject obj in Result.results)
                            sb.Append(obj.name);
                        labelResult.Text = sb.ToString();
                    }
                }
                catch
                {
                    updateColorInThread(Color.LightPink);
                }

            }
            else if (indata == "~TakePhoto")
            {
                updateColorInThread(Color.LightBlue);
            }

        }

    }
}
