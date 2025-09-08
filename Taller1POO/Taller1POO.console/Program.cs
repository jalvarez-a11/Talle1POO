﻿using System;
using System.Collections.Generic;
using Taller1POO.Class;

namespace Taller1POO.console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var t1 = new Time();
                var t2 = new Time(14);
                var t3 = new Time(9, 34);
                var t4 = new Time(19, 45, 56);
                var t5 = new Time(23, 3, 45, 678);

                var times = new List<Time> { t1, t2, t3, t4, t5 };

                foreach (Time time in times)
                {
                    Console.WriteLine($"Time: {time}");
                    Console.WriteLine($"\tMilliseconds: {time.ToMilliseconds(),15:N0}");
                    Console.WriteLine($"\tSeconds: {time.ToSeconds(),15:N0}");
                    Console.WriteLine($"\tMinutes: {time.ToMinutes(),15:N0}");
                    Console.WriteLine($"\tAdd: {time.Add(t3),15}");
                    Console.WriteLine($"\tIts Other day: {time.IsOtherDay(t4)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

