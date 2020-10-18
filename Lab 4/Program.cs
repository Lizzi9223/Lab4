using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vect1 = new Vector(123,-56);
            Vector vect2 = new Vector(2, 4);
            //Vector empt_vect = new Vector();

            Console.Write("vect1\t");
            vect1.show();
            Console.Write("vect2\t");
            vect2.show();
            //Console.Write("empt_vect\t");
            //empt_vect.show();

            Vector sum = vect1 + vect2;
            Console.Write("sum = vect1 + vect2\t");
            sum.show();
            bool compare = vect1 > vect2;
            if (compare) Console.WriteLine("vect1 > vect2 ");
            else Console.WriteLine("vect1 > vect2 ");
            vect1 = (vect1 == vect2);
            Console.Write("\nvect2 скопирован в vect1\t");
            vect1.show();
            //if (empt_vect) Console.WriteLine("Вектор empt_vect НЕ пустой");
            //else Console.WriteLine("Вектор empt_vect пустой");

            Vector.Owner owner1 = new Vector.Owner(125478989763, "Егор", "ООО Компания" );
            Vector.Date date1 = new Vector.Date(2020, 10, 18);

            Console.WriteLine($"sum = {Vector.sum}; quant = {Vector.quant}; diff = {Vector.diff}");
        }
    }
}
