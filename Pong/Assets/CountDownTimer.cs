using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Timers
{
    class CountDownTimer
    {
        private DispatcherTimer timer;
        private int startvalue;
        private int stopvalue = 0;
        private int count;
        private TimeSpan interval = new TimeSpan(0, 0, 1);

        public delegate void TickEventHandler(object source, EventArgs args);

        public event TickEventHandler Tick;

        protected virtual void onTick()
        {
            if (Tick != null)
                Tick(this, EventArgs.Empty);
        }

        private void CountDown(int StartValue, int StopValue, TimeSpan Interval)
        {
            count = StartValue;
            timer = new DispatcherTimer();
            timer.Interval = Interval;
            timer.Tick += TimerTick;
            timer.Start();

        }

        private void TimerTick (object sender, EventArgs e)
        {
            count--;
            if (count == StopValue) timer.Stop();
            onTick();
        }

        public void Start()
        {
            CountDown(StartValue, StopValue, Interval);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public int StartValue
        {
            get { return startvalue; }
            set { startvalue = value; }
        }

        public int StopValue
        {
            get { return stopvalue; }
            set { stopvalue = value; }
        }

        public int Value
        {
            get { return count; }
        }

        public TimeSpan Interval
        {
            get { return interval; }
            set { interval = value; }
        }
    }
}
