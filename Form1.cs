using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Threading;
namespace I_Need_Your_Help_V2._0
{
    
    public partial class Form1 : Form
    {
        private readonly Thread GetOrders;
        [DllImport("user32.dll", EntryPoint="mouse_event")]
    static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        private readonly TcpClient cle = new TcpClient();
        private NetworkStream st;
        private static Image GrabDesktop()
            
        {
            Rectangle boun = Screen.PrimaryScreen.Bounds;
            Bitmap screen = new Bitmap(boun.Width, boun.Height, PixelFormat.Format32bppPArgb);
            Graphics graph = Graphics.FromImage(screen);
            graph.CopyFromScreen(boun.X, boun.Y, 0, 0, boun.Size, CopyPixelOperation.SourceCopy);
            return screen;
        }
        private void sendimg()
        {
            try
            {
                BinaryFormatter binf = new BinaryFormatter();
                st = cle.GetStream();
                binf.Serialize(st, GrabDesktop());
            }
            catch
            {
                timer1.Stop();
                MessageBox.Show("Disconnected");
                button1.Enabled = true;
                button2.Text = "Start Asking For Help";
                notifyIcon1.Visible = false;
            }
           

        }
        public Form1()
        {
            GetOrders = new Thread(Order);
            InitializeComponent();
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Form3 f2 = new Form3();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = GetLocalIPAddress();
            MaximizeBox = false;
        }


        byte[] bytesFrom = new byte[10025];
        private void Order()
        {
            while (cle.Connected)
            {
                
                NetworkStream lest = cle.GetStream();
                lest.Read(bytesFrom, 0, 5000);
                string order = System.Text.Encoding.UTF8.GetString(bytesFrom);
                order = order.Substring(0, order.IndexOf("$"));
                if (order.StartsWith("DOWN"))
                {
                    var xpos = order.Split(':')[1];
                    var ypos = order.Split(':')[2];
                    var butt = order.Split(':')[3];
                    Cursor.Position = new Point(int.Parse(xpos), int.Parse(ypos));
                    mouse_event(int.Parse(butt), int.Parse(xpos), int.Parse(ypos), 0, 0);
                }
                if (order.StartsWith("UP"))
                {
                    
                    var xpos = order.Split(':')[1];
                    var ypos = order.Split(':')[2];
                    var butt = order.Split(':')[3];
                    mouse_event(int.Parse(butt), int.Parse(xpos), int.Parse(ypos), 0, 0);
                }
                if (order.StartsWith("MOVE"))
                {
                    
                    var xpos = order.Split(':')[1];
                    var ypos = order.Split(':')[2];
                    Cursor.Position = new Point(int.Parse(xpos), int.Parse(ypos));

                    
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                if (button2.Text == "Start Asking For Help")
                {
                    button1.Enabled = false;
                    button2.Text = "Stop Asking For Help";

                    try
                    {
                        cle.Connect(textBox2.Text, 8989);
                        timer1.Start();
                        string bt = cle.GetStream().ToString();
                        GetOrders.Start();
                        notifyIcon1.Visible = true;
                        notifyIcon1.ShowBalloonTip(99999999, "I Need Your Help", "Conection Is Going...", ToolTipIcon.Info);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
                else
                {
                    timer1.Stop();
                    GetOrders.Abort();
                    button1.Enabled = true;
                    button2.Text = "Start Asking For Help";
                    notifyIcon1.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Your Helper Ip Cannot Left Blank!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cle.Connected)
            {
                sendimg();
            }
           
        }

       
    }
}