using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab_4
{
    class Vector
    {
        public int x;
        public int y;
        public static int quant = 0;
        public static double sum = 0;
        public static double diff = 0;
        public static double max = 0;
        public static double min = Double.MaxValue;

        public Vector (int value1, int value2)
        {
            x = value1;
            y = value2;
            StatisticOperation.Count(ref quant);
            StatisticOperation.Sum(ref sum, this.length());
            StatisticOperation.Diff(ref diff, ref min, ref max, this.length());
        }
        public class Owner
        {
            public long id;
            public string name;
            public string organization;

            public Owner(long i, string n, string o)
            {
                id = i;
                name = n;
                organization = o;
            }
        }
        public class Date
        {
            DateTime date;
            public Date(int year, int month, int day)
            {
                date = new DateTime(year, month, day);
            }
        }
        public double length()
        {
            return Math.Sqrt(x * x + y * y);
        }
        public void show()
        {
            Console.WriteLine($"Координаты вектора : x = {x}, y = {y}; Длина вектора : {this.length()}\n");
        }

        public static Vector operator + (Vector one, Vector two)
        {
            return new Vector(one.x + two.x, one.y + two.y);
        }

        public static bool operator >(Vector one, Vector two)
        {
            return one.length() > two.length();
        }
        public static bool operator <(Vector one, Vector two)
        {
            return one.length() < two.length();
        }
        //копирование вектора two в вектор one:
        public static Vector operator == (Vector one, Vector two)
        {
            one.x = two.x;
            one.y = two.y;
            return one;
        }
        //копирование вектора two в вектор one:
        public static Vector operator !=(Vector one, Vector two)
        {
            one.x = two.x;
            one.y = two.y;
            return one;
        }
        //проверка пустой ли вектор
        public static bool operator true(Vector one)
        {
            int? check = one.x;
            if (check.HasValue) return true;
            else return false;
        }
        //проверка вектора на наличие значения
        public static bool operator false(Vector one)
        {
            int? check = one.x;
            if (check.HasValue) return true;
            else return false;
        }
    }
    public static class StatisticOperation
    {
        public static void Count(ref int q)
        {
            q++;
        }
        public static void Sum(ref double sum, double l)
        {
            sum += l;
        }
        public static void Diff(ref double diff, ref double min, ref double max, double l)
        {
            if (l > max)
            {
                max = l;
                diff = max - min;
            }
            if (l < min)
            {
                min = l;
                diff = max - min;
            }

        }
    }
}
