using System;
using System.Diagnostics;
using System.Threading;

namespace Pigalev_Watch
{
    internal class Program
    {
        static int hour = 0;
        static int minute = 0;
        static int second = 0;

		static int hour4 = 0;
		static int minute4 = 0;
		static int second4 = 0;
		static int milesecond4 = 0;

		public static void WorkHours() // Поток имитирующий работу часов
		{
			while (true)
			{
				second++;
				if (second == 60)
				{
					minute += 1;
					second = 0;
				}
				if (minute == 60)
				{
					minute = 0;
					hour += 1;
				}
				if (hour == 24)
				{
					hour = 0;
				}
				Thread.Sleep(1000);
			}
		}
		public static void WorkHoursSecondomer() // Поток имитирующий работу часов с милисекундами
		{
			while (true)
			{
				milesecond4++;
				if (milesecond4 == 10)
				{
					second4++;
					milesecond4 = 0;
				}
				if (second4 == 60)
				{
					minute4 += 1;
					second4 = 0;
				}
				if (minute4 == 60)
				{
					minute4 = 0;
					hour4 += 1;
				}
				if (hour4 == 24)
				{
					hour4 = 0;
				}
				Thread.Sleep(94);
			}
		}

		public static void ShowHours()
        {
			while (true)
			{
				Stopwatch stopwatch = new Stopwatch();
				//Console.Clear();
				stopwatch.Start();
				Console.WriteLine("{0}:{1}:{2}", hour, minute, second);
				stopwatch.Stop();
				Thread.Sleep(1000 - (int)stopwatch.ElapsedMilliseconds);
			}
        }
		public static void ShowHoursMileSecond() // Вывод часов в милисекундах
		{
			while (true)
			{
				Stopwatch stopwatch = new Stopwatch();
				Console.Clear();
				stopwatch.Start();
				Console.WriteLine("{0}:{1}:{2}:{3}", hour4, minute4, second4, milesecond4);
				stopwatch.Stop();
				Thread.Sleep(1000 - (int)stopwatch.ElapsedMilliseconds);
			}
		}
		static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(WorkHours));
			Thread t1 = new Thread(new ThreadStart(ShowHours));
			//Thread t2 = new Thread(new ThreadStart(WorkHoursSecondomer));
			//Thread t3 = new Thread(new ThreadStart(ShowHoursMileSecond));
			t.Start();
			t1.Start();
			int command;
			while (true)
			{
				command = Convert.ToInt32(Console.ReadLine());
				switch (command)
				{
					case (1):
						if (t.IsAlive != true)
						{
							Console.WriteLine("Пауза выключена\n");
							t.Resume();
							t1.Resume();
						}
						else
						{
							Console.WriteLine("Включена пауза\n");
							t.Abort();
							t1.Abort();
						}
						break;
					
					default:
						return;
						break;
				}
			}
		}
	}
}