using System;

namespace Program1
{
    public delegate void Clock(object sender);
    public class SetClock
    {
        public string hour;
        public string minute;
        public string second;
    }
    public class MyClock
    {
        public event Clock eClock;
        public string hour;
        public string minute;
        public string second;
        public bool alarm = false;

        public void RingOrShow(string a, string b, string c)
        {
            SetClock args = new SetClock();
            args.hour = a;
            args.minute = b;
            args.second = c;
            while (true)
            {
                string nHour = DateTime.Now.Hour.ToString();
                string nMinute = DateTime.Now.Minute.ToString();
                string nSecord = DateTime.Now.Second.ToString();

                if (nHour.Equals(a) && nMinute.Equals(b))
                {
                    break;
                }
            }
            eClock(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClock mC = new MyClock();
            Console.WriteLine("请设置闹钟时间：");           
            Console.WriteLine("时：");
            mC.hour = Console.ReadLine();
            Console.WriteLine("分：");
            mC.minute = Console.ReadLine();
            Console.WriteLine("秒：");
            mC.second = Console.ReadLine(); ;
            mC.eClock += new Clock(ClockShow);
            mC.RingOrShow(mC.hour, mC.minute, mC.second);
        }

        static void ClockShow(object sender)
        {
            Console.WriteLine("\n时间到！\n");
        }
    }
}
