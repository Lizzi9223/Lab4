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
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public sbyte direction;

        public static int quant = 0;
        public static double sum = 0;
        public static double diff = 0;
        public static double max = 0;
        public static double min = Double.MaxValue;

        public Vector (int value1, int value2, int value3, int value4, sbyte d)
        {
            x1 = value1;
            y1 = value2;
            x2 = value3;
            y2 = value4;
            direction = d;
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
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
        }
        public void show()
        {
            Console.WriteLine($"Координаты вектора : x1 = {x1}, y1 = {y1}, x2 = {x2}, y2 = {y2};\nНаправление вектора : {direction}; Длина вектора : {this.length()}\n");
        }

        public static Vector operator + (Vector one, Vector two)
        {
            return new Vector(one.x1 + two.x1, one.y1 + two.y1, one.x2 + two.x2, one.y2 + two.y2, -1);
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
            one.x1 = two.x1;
            one.y1 = two.y1;
            one.x2 = two.x2;
            one.y2 = two.y2;
            one.direction = two.direction;
            return one;
        }
        //копирование вектора two в вектор one:
        public static Vector operator !=(Vector one, Vector two)
        {
            one.x1 = two.x1;
            one.y1 = two.y1;
            one.x2 = two.x2;
            one.y2 = two.y2;
            one.direction = two.direction;
            return one;
        }
        //проверка пустой ли вектор
        //public static bool operator true(Vector one)
        //{
        //    int? check = one.x1;
        //    if (check.HasValue) return true;
        //    else return false;
        //}
        ////проверка вектора на наличие значения
        //public static bool operator false(Vector one)
        //{
        //    int? check = one.x1;
        //    if (check.HasValue) return true;
        //    else return false;
        //}
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
        //усечение строки с начала
        public static void Del_one_from_beg (this string s)
        {
            s = s.Substring(1);
        }
        //удаление положительных элементов из вектора
        //public static void Del_plus (this Vector v)
        //{

        //}
    }
}
