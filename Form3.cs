using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace I_Need_Your_Help_V2._0
{
    public partial class Form3 : Form
    {
        
         Size Sz;
        private TcpClient cli;
        private TcpListener ser;
        private NetworkStream st;
        private readonly Thread lestining;
        private readonly Thread getImg;
        char Yy = '*';
        private string Order = "";
        public Form3()
        {
            cli = new TcpClient();
            lestining = new Thread(StartListening);
            getImg = new Thread(getImage);

            InitializeComponent();
        }


        private void StartListening()
        {
            while (!cli.Connected)
            {
                ser.Start();
                cli = ser.AcceptTcpClient();

            }
            getImg.Start();

        }

        private void StopListening()
        {
            ser.Stop();
            cli = null;
            if (lestining.IsAlive) lestining.Abort();
            if (getImg.IsAlive) getImg.Abort();
            timer1.Stop();

        }

        private void getImage()
        {
            BinaryFormatter binfor = new BinaryFormatter();
            while (cli.Connected)
            {
                st = cli.GetStream();
                P1.Image = (Image)binfor.Deserialize(st);

            }
        }
           
        
        private void Form3_Load(object sender, EventArgs e)
        {
            ser = new TcpListener(IPAddress.Any, 8989);
            lestining.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void P1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopListening();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!cli.Connected)
            {
                label1.Text = "Waiting For Connection...";
            }
            else
            {
                label1.Visible = false;
            }

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopListening();
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        byte[] ConvertStringToBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        private void P1_MouseDown(object sender, MouseEventArgs e)
        {
           
            if (CheckBox2.Checked)
            {
                var pp = new Point(e.X * (1366 / P1.Width), e.Y * (768 / P1.Height));
                int but = 0;
                if (e.Button == MouseButtons.Right)
                {
                    but = 8;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    but = 2;
                }
                this.Order = "DOWN:" + pp.X + ":" + pp.Y + ":" + but+"$";
                var value = ConvertStringToBytes(Order);
                st.Write(value, 0, value.Length);

            }

        }

        private void P1_MouseUp(object sender, MouseEventArgs e)
        {

            if (CheckBox2.Checked)
            {
                var pp = new Point(e.X * (1366 / P1.Width)-9, e.Y * (768 / P1.Height)-9);
                int but = 0;
                if (e.Button == MouseButtons.Right)
                {
                    but = 16;
                }
                else if (e.Button == MouseButtons.Left)
                {
                    but = 4;
                }
                this.Order = "UP:" + pp.X + ":" + pp.Y + ":" + but+"$";
                var value = ConvertStringToBytes(Order);
                st.Write(value, 0, value.Length);

            }
        }
       
        private void P1_MouseMove(object sender, MouseEventArgs e)
        {
            Point op = new Point(1, 1);
            if (CheckBox2.Checked == true)
            {

                dynamic PP = new Point(e.X * (1366 / P1.Width), e.Y * (768 / P1.Height));
                    if (PP != op)
                    {
                        op = PP;

                        this.Order = "MOVE:" + PP.X + ":" + PP.Y+"$";
                        var value = ConvertStringToBytes(Order);
                        st.Write(value, 0, value.Length);
                       
                    }

                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Pic|*.png";
            if ((s.ShowDialog() == DialogResult.OK))
            {
                P1.Image.Save(s.FileName);
            }
        }

    }
}
