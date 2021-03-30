using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overload_Interfaces
{
    class Angle
    {
        private int degree, minutes, seconds;

        public Angle(int degree, int minutes, int seconds)
        {
            if ((minutes < 60 && minutes>=0) && (seconds < 60 && seconds >=0))
            {
                this.degree = degree;
                this.minutes = minutes;
                this.seconds = seconds;
            }
            else
            {
                Console.WriteLine("Your angle value is incorrect!");
            }
        }
        public override string ToString()
        {
            return $"({degree}° {minutes}' {seconds}\")";
        }

        public static Angle operator +(Angle a1, Angle a2) //adding 2 angles
        {
            int d = 0;
            int m = 0;
            int s = 0;
            if (a1.seconds + a2.seconds > 59)
            {
                s = (a1.seconds + a2.seconds) % 60;
                m = a1.minutes + a2.minutes + (a1.seconds + a2.seconds) / 60;
            }
            else
            {
                s = a1.seconds + a2.seconds;
            }
            if (m > 59)
            {
                m %= 60;
                d = a1.degree + a2.degree + (a1.minutes + a2.minutes) / 60;
            }
            else
            {
                m = a1.minutes + a2.minutes;
                d = a1.degree + a2.degree;
            }

            return new Angle(d, m, s);
        }

        public static Angle operator -(Angle a1, Angle a2) //substraction operation with 2 angles
        {
            int d = 0;
            int m = 0;
            int s = 0;
            int temp = a1.minutes;
            if (a1.seconds < a2.seconds)
            {
                s = (a1.seconds + 60) - a2.seconds;
                temp = temp - 1;
            }
            else
            {
                s = a1.seconds - a2.seconds;
            }
            if (temp < a2.minutes)
            {
                m = (temp + 60 - a2.minutes); ;
                d = a1.degree - a2.degree - 1;
            }
            else
            {
                m = temp - a2.minutes;
                d = a1.degree - a2.degree;
            }

            return new Angle(d, m, s);
        }

        public static bool operator ==(Angle a1, Angle a2) //compare 2 angles
        {
            return a1.degree == a2.degree && a1.minutes == a2.minutes && a1.seconds == a2.seconds;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }
    }
}
