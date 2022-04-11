using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.VisualBasic.PowerPacks;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        UdpClient U;
        Thread Th;

        ShapeContainer C; //畫布物件
        ShapeContainer D;//畫布物件
        Point stP;//繪畫起點
        string p;//筆畫座標字串

        public Form1()
        {
            InitializeComponent();
        }
        private void Listen()
        {
            int port = int.Parse(textBox_listenPort.Text);
            U = new UdpClient(Port);

            IPEndPoint EP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);

            while (true)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Th = new Thread(listen);//建立監聽執行續
            Th.Start();
            button1.Enabled;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            C = new ShapeContainer(); //建立畫布
            this.Controls.Add(C);//加入畫布C 到 form1
            D = new ShapeContainer();
            this.Controls.Add(D);//加速畫布D 到 form1
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            stP = e.Location;
            p = stP.X.ToString() + "." + stP.Y.ToString();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                LineShape L = new LineShape(); //建立線段物件
                L.StartPoint = stP; //線段起點
                L.EndPoint = e.Location;//線段終點
                L.Parent = C; //線段加入C畫布
                stP = e.Location; //終點變起點
                p += "/" + stP.X.ToString() + "." + stP.Y.ToString(); //持續記錄座標
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
