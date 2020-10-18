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
        public int[] coord = new int[5]; // [x1,y1,x2,y2,direction]
        public int this[int index]
        {
            set
            {
                coord[index] = value;
            }
            get
            {
                return coord[index];
            }
        }

        public static int quant = 0;
        public static double sum = 0;
        public static double diff = 0;
        public static double max = 0;
        public static double min = Double.MaxValue;

        public Vector (int value1, int value2, int value3, int value4, sbyte d)
        {
            coord[0] = value1;
            coord[1] = value2;
            coord[2] = value3;
            coord[3] = value4;
            coord[4] = d;
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
            return Math.Sqrt(Math.Pow(Math.Abs(coord[0] - coord[2]), 2) + Math.Pow(Math.Abs(coord[1] - coord[3]), 2));
        }
        public void show()
        {
            Console.WriteLine($"Координаты вектора : x1 = {coord[0]}, y1 = {coord[1]}, x2 = {coord[2]}, y2 = {coord[3]};\nНаправление вектора : {coord[4]}; Длина вектора : {this.length()}\n");
        }

        public static Vector operator + (Vector one, Vector two)
        {
            return new Vector(one.coord[0] + two.coord[0], one.coord[1] + two.coord[1], one.coord[2] + two.coord[2], one.coord[3] + two.coord[3], -1);
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
            for (byte i=0;i<one.coord.Length;i++)
            {
                one.coord[i] = two.coord[i];
            }
            return one;
        }
        //копирование вектора two в вектор one:
        public static Vector operator !=(Vector one, Vector two)
        {
            for (byte i = 0; i < one.coord.Length; i++)
            {
                one.coord[i] = two.coord[i];
            }
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
    static class StatisticOperation
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
        //обнуление положительных элементов вектора
        public static void Del_plus(this Vector v)
        {
            for (byte i = 0; i < v.coord.Length; i++)
                if (v.coord[i] > 0) v.coord[i] = 0;
        }
    }
}
