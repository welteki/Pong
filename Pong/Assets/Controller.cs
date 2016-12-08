using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Pong.Assets
{
    class StateChangedEventArgs : EventArgs
    {
        private string button;
        public StateChangedEventArgs(string button)
        {
            this.button = button;
        }

        public string Button
        {
            get { return button; }
        }
    }

    class Controller
    {
        private SerialPort sp;
        private DispatcherTimer timer;
        private byte[] btnstate;
        private byte[] prevstate;
        private bool btnleft;
        private bool btnright;

        public delegate void StateChangedEventHandler(object source, StateChangedEventArgs args);

        public event StateChangedEventHandler StateChanged;

        protected virtual void onStateChanged(string button)
        {
            if (StateChanged != null)
                StateChanged(this, new StateChangedEventArgs(button));
        }

        public Controller()
        {
            sp = new SerialPort();
            sp.PortName = "COM5";
            sp.DataReceived += sp_DataRecieved;
            sp.ReadBufferSize = 2;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);      //Find best timing
            timer.Tick += timer_Tick;

            btnstate = new byte[2];
            prevstate = new byte[2];
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            GetBtnState();
        }

        private void sp_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            sp.Read(btnstate, 0, 2);
            CheckChange();
        }

        private void CheckChange()
        {
            if (prevstate[0] != btnstate[0])
                onStateChanged("btnLeft");
            if (prevstate[1] != btnstate[1])
                onStateChanged("btnRight");
            prevstate = btnstate;
        }

        private void GetBtnState()
        {
            sp.Write("C");
        }

        /// <summary>
        /// Opens the serial port the controller is connected on
        /// </summary>
        public void openPort()
        {
            sp.Open();
            timer.Start();
        }

        /// <summary>
        /// Blinks a red led and sounds a buzzer on the controller
        /// </summary>
        public void BlinkRed()
        {
            sp.Write("B");
        }

        /// <summary>
        /// Blinks a green led and sounds a buzzer on the controller
        /// </summary>
        public void BlinkGreen()
        {
            sp.Write("A");
        }

        /// <summary>
        /// Closes the serialport the controller is connected on
        /// </summary>
        public void closePort()
        {
            sp.Close();
            timer.Stop();
        }

        public bool BtnLeft
        {
            get { return btnleft; }
            private set { btnleft = value; }
        }
    }
}
