using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Управление_машинкой
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UdpClient client = new UdpClient("192.168.4.1", 100);
        bool bF, bL, bR, bB, speedChanged;

        private void trackBarSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            Form1_KeyPress(sender, e);
        }

        private void trackBarSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            Form1_KeyUp(sender, e);
        }

        private void trackBarSpeed_KeyDown(object sender, KeyEventArgs e)
        {
            Form1_KeyDown(sender, e);
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            speedChanged = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            if (e.KeyChar == 'w')
            {
                panelW.BackColor = Color.LimeGreen;
                bF = true;
            }
            if (e.KeyChar == 'a')
            {
                panelA.BackColor = Color.LimeGreen;
                bL = true;
            }
            if (e.KeyChar == 's')
            {
                panelS.BackColor = Color.LimeGreen;
                bB = true;
            }
            if (e.KeyChar == 'd')
            {
                panelD.BackColor = Color.LimeGreen;
                bR = true;
            }

            UpdateRobot();
            */
        }

        private void SetSpeed(char motor, int speed)
        {
            var data = Encoding.ASCII.GetBytes("_S_");
            data[2] = (byte)(speed);
            data[0] = (byte)motor;
            client.Send(data, 3);
            listBox1.Items.Add(motor + "S(" + speed + ")");
            if (listBox1.Items.Count > 13)
                listBox1.Items.RemoveAt(0);
        }

        private void SetMode(char motor, char mode)
        {
            var data = Encoding.ASCII.GetBytes(motor + "M" + mode);
            client.Send(data, 3);
            listBox1.Items.Add(Encoding.ASCII.GetString(data));
            if (listBox1.Items.Count > 13)
                listBox1.Items.RemoveAt(0);
        }

        private void Beep()
        {
            client.Send(Encoding.ASCII.GetBytes("BEP"), 3);
            listBox1.Items.Add("BEP");
            if (listBox1.Items.Count > 13)
                listBox1.Items.RemoveAt(0);
        }



        private void UpdateRobot()
        {
            if (speedChanged)
            {
                SetSpeed('A', trackBarSpeed.Value);
                speedChanged = false;
                Task.Delay(250).Wait();
                Beep(); Beep(); Beep();
                Task.Delay(250).Wait();
            }
            if (bF)
            {
                if (bB)
                {
                    Beep();
                    SetMode('A', 'R');
                }
                else if (!bL && !bR)
                    SetMode('A', 'F');
                else if (bL && bR)
                    Beep();
                /*else if (bL)
                {
                    var data = Encoding.ASCII.GetBytes("LS ");
                    data[2] = (byte)(trackBarSpeed.Value + 5);
                    client.Send(data, 3);
                    data[0] = (byte)'R';
                    data[2] = (byte)(trackBarSpeed.Value - 70);
                    client.Send(data, 3);
                    client.Send(Encoding.ASCII.GetBytes("AMF"), 3);
                    //speedChanged = true;
                }
                else
                {
                    var data = Encoding.ASCII.GetBytes("RS ");
                    data[2] = (byte)(trackBarSpeed.Value + 5);
                    client.Send(data, 3);
                    data[0] = (byte)'L';
                    data[2] = (byte)(trackBarSpeed.Value - 70);
                    client.Send(data, 3);
                    client.Send(Encoding.ASCII.GetBytes("AMF"), 3);
                    //speedChanged = true;
                }*/
            }
            else
            {
                if (bB)
                {
                    SetMode('A', 'B');
                }
                else if (bL && bR)
                {
                    Beep();
                }
                else if (bL)
                {
                    SetMode('R', 'F');
                    SetMode('L', 'B');
                }
                else if (bR)
                {
                    SetMode('L', 'F');
                    SetMode('R', 'B');
                }
                else
                {
                    SetMode('A', 'R');
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                panelW.BackColor = Color.DarkGreen;
                bF = false;
            }
            if (e.KeyCode == Keys.A)
            {
                panelA.BackColor = Color.DarkGreen;
                bL = false;
            }
            if (e.KeyCode == Keys.S)
            {
                panelS.BackColor = Color.DarkGreen;
                bB = false;
            }
            if (e.KeyCode == Keys.D)
            {
                panelD.BackColor = Color.DarkGreen;
                bR = false;
            }
            if (e.KeyCode != Keys.W && e.KeyCode != Keys.A && e.KeyCode != Keys.S && e.KeyCode != Keys.D)
                return;

            UpdateRobot();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                if (bF)
                    return;
                panelW.BackColor = Color.LimeGreen;
                bF = true;
            }
            if (e.KeyCode == Keys.A)
            {
                if (bL)
                    return;
                panelA.BackColor = Color.LimeGreen;
                bL = true;
            }
            if (e.KeyCode == Keys.S)
            {
                if (bB)
                    return;
                panelS.BackColor = Color.LimeGreen;
                bB = true;
            }
            if (e.KeyCode == Keys.D)
            {
                if (bR)
                    return;
                panelD.BackColor = Color.LimeGreen;
                bR = true;
            }
            if (e.KeyCode != Keys.W && e.KeyCode != Keys.A && e.KeyCode != Keys.S && e.KeyCode != Keys.D)
                return;

            UpdateRobot();
        }
    }
}
