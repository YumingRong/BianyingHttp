using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int app = 0;
        public Form1()
        {
            InitializeComponent();
        }

        delegate void updateStatusStripDelegate(String obj);
        private void updateStatusWordInDelegate(string text)
        {
            textResult.Text = text;
        }

        private void updateStatusWordInThread(string text)
        {
            updateStatusStripDelegate d = new updateStatusStripDelegate(updateStatusWordInDelegate);
            this.Invoke(d, text);
        }

        delegate void updateColorDelegate(Color obj);
        private void updateColorInDelegate(Color c)
        {
            textResult.BackColor = c;
        }

        private void updateColorInThread(Color c)
        {
            updateColorDelegate d = new updateColorDelegate(updateColorInDelegate);
            this.Invoke(d, c);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
            serialPort1.Open();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
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
                return x.centerX.CompareTo(y.centerX) * -1;
            }


        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while (serialPort1.BytesToRead > 0)
            {

                string indata = serialPort1.ReadLine().Trim();
                if (indata.StartsWith("{"))
                {
                    updateColorInThread(buttonConnect.BackColor);
                    updateStatusWordInThread("");
                    try
                    {
                        DetectionResults Result = JsonSerializer.Deserialize<DetectionResults>(indata);
                        if (Result.results.Count() > 0)
                        {
                            string S = "";
                            switch (app)
                            {
                                
                                case 1:
                                    DetectionObject Angle_Start= null, Angle_End = null;
                                    foreach (DetectionObject obj in Result.results)
                                    {
                                        if (obj.name.StartsWith("定位")) {
                                            Angle_Start = obj;
                                        } else if (obj.name.EndsWith("齿轮"))
                                        {
                                            Angle_End = obj;
                                        }
                                    }
                                    if (Angle_Start != null && Angle_End != null)
                                    {
                                        double x = Angle_Start.centerX - Angle_End.centerX;
                                        double y = Angle_Start.centerY - Angle_End.centerY;
                                        if( Angle_Start.centerX==0  && Angle_End.centerX==0 && Angle_Start.centerY ==0 &&  Angle_End.centerY == 0)
                                        {
                                            x = Angle_Start.left - Angle_End.left;
                                            y = Angle_Start.top - Angle_End.top;
                                        }
                                        double a = Math.Atan2(y, x);
                                        a = -Math.Round(a / Math.PI * 180,1);
                                        S = a.ToString();
                                    }
                                    break;
                                default:
                                    
                                    Result.results.Sort(new XComparer());
                                    foreach (DetectionObject obj in Result.results)
                                    {
                                        S += obj.name;
                                    }
                                    
                                    break;
                            }
                            updateStatusWordInThread(S);
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

        private void buttonIdentify_Click(object sender, EventArgs e)
        {
            //textBox1.Text = "DHB3022";
            if (serialPort1.IsOpen)
            {
                buttonIdentify.BackColor = Color.LightGreen;
                serialPort1.WriteLine("p\r\n");
                serialPort1.WriteLine("b0");
            }
            else
            {
                buttonIdentify.BackColor = buttonConnect.BackColor;
            }
        }

        private void radioSort_CheckedChanged(object sender, EventArgs e)
        {
            app = 0;
        }

        private void radioAngle_CheckedChanged(object sender, EventArgs e)
        {
            app = 1;
        }
    }
}
