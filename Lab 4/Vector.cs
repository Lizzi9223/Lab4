using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Vector
    {
        public int x;
        public int y;

        public Vector (int value1, int value2)
        {
            x = value1;
            y = value2;
        }
        public Vector()
        {
           
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
}
