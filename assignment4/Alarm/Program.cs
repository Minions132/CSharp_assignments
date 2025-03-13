using System;

namespace Alarm{
    class AlarmClock{
        public delegate void ClockEventHandler(string msg);
        public event ClockEventHandler OnTick;
        public event ClockEventHandler OnAlarm;
        private int current_time;
        private int alarm_time;
        public AlarmClock(int alarm_time){
            this.alarm_time = alarm_time;
            current_time = 0;
        }
        public void Run(){
            while(current_time <= alarm_time + 5){
                OnTick?.Invoke($"闹钟嘀嗒于 {current_time} 秒");
                if(current_time == alarm_time){
                    OnAlarm?.Invoke($"闹钟于 {current_time} 秒响铃");
                }
                current_time++;
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
    class Program{
        static void Main(string[] args){
            AlarmClock clock = new AlarmClock(3);
            clock.OnTick += (msg) => Console.WriteLine(msg);
            clock.OnAlarm += (msg) => Console.WriteLine(msg);
            Console.WriteLine("开始时钟...");
            clock.Run();
            Console.WriteLine("闹钟模拟结束");
            Console.ReadLine();
        }
    }
}