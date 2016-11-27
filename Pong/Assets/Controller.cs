using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Assets
{
    class Controller
    {
        private SerialPort sp;
        private bool btnleft;
        private bool btnright;

        public Controller()
        {
            sp = new SerialPort();
            sp.PortName = "COM5";
            sp.ReadBufferSize = 2;
        }

        public void openPort()
        {
            sp.Open();
        }

        public void BlinkRed()
        {
            sp.Write("B");
        }

        public void BlinkGreen()
        {
            sp.Write("A");
        }

        public void BtnState()
        {
            sp.Write("C");
            int x = sp.ReadByte();
        }

        public void closePort()
        {
            sp.Close();
        }

        public bool BtnLeft
        {
            get { return btnleft; }
            private set { btnleft = value; }
        }
    }
}
