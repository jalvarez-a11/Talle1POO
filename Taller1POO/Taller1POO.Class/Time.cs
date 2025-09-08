using System;
using System.Collections.Generic;
using Taller1POO.Class;

namespace Taller1POO.Class
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;
        private int milliseconds;
        private bool isValid;

        // 1) Sin parámetros
        public Time() : this(0, 0, 0, 0) { }

        // 2) Con horas
        public Time(int h) : this(h, 0, 0, 0) { }

        // 3) Con horas y minutos
        public Time(int h, int m) : this(h, m, 0, 0) { }

        // 4) Con horas, minutos y segundos
        public Time(int h, int m, int s) : this(h, m, s, 0) { }

        // 5) Con horas, minutos, segundos y milisegundos
        public Time(int h, int m, int s, int ms)
        {
            if (h < 0 || h > 23 ||
                m < 0 || m > 59 ||
                s < 0 || s > 59 ||
                ms < 0 || ms > 999)
            {
                isValid = false;
                throw new ArgumentException($"The hour: {h}, is not valid.");
            }

            hours = h;
            minutes = m;
            seconds = s;
            milliseconds = ms;
            isValid = true;
        }

        public override string ToString()
        {
            if (!isValid) return "Invalid Time";

            DateTime dt = new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds);
            return dt.ToString("hh:mm:ss.fff tt");
        }

        public long ToMilliseconds()
        {
            if (!isValid) return 0;
            return (((hours * 60L + minutes) * 60L + seconds) * 1000L + milliseconds);
        }

        public long ToSeconds()
        {
            if (!isValid) return 0;
            return ((hours * 60L + minutes) * 60L + seconds);
        }

        public long ToMinutes()
        {
            if (!isValid) return 0;
            return (hours * 60L + minutes);
        }

        public bool IsOtherDay(Time other)
        {
            if (!isValid || !other.isValid) return false;

            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long oneDay = 24L * 60L * 60L * 1000L;

            return totalMs >= oneDay;
        }

        public Time Add(Time other)
        {
            if (!isValid || !other.isValid) return new Time();

            int newMs = this.milliseconds + other.milliseconds;
            int carrySec = newMs / 1000;
            newMs %= 1000;

            int newSec = this.seconds + other.seconds + carrySec;
            int carryMin = newSec / 60;
            newSec %= 60;

            int newMin = this.minutes + other.minutes + carryMin;
            int carryHour = newMin / 60;
            newMin %= 60;

            int newHour = this.hours + other.hours + carryHour;
            newHour %= 24;

            return new Time(newHour, newMin, newSec, newMs);
        }
    }
}
