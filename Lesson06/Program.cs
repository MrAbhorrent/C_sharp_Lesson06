using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lesson06
{
    class Program
    {
        private static String divider = new String('=', 110);
                
        public class SequenceOfNumber
        {
            private int count;
            private String sequence;

            public SequenceOfNumber()
            {
                this.count = 0;
                this.sequence = "";
            }

            public int getCount()
            {
                return this.count;
            }

            public void incCount()
            {
                this.count++;
            }

            public void setSequence( String str )
            {
                this.sequence = str;
            }

            public String getSequence()
            {
                return this.sequence;
            }
        }        

        private static SequenceOfNumber InputSequence(int _m)
        {
            int value;            
            String tempSring = "";
            SequenceOfNumber seqNumber = new SequenceOfNumber();
            StringBuilder stringBiulder = new StringBuilder();
            for (int i = 0; i < _m; i++)
            {
                Console.Write("Введите число {0}: ", i + 1);
                tempSring = Console.ReadLine();

                if (int.TryParse(tempSring, out value))
                {
                    stringBiulder.Append(tempSring);
                    if (value < 0)
                    {
                        seqNumber.incCount();
                    }
                    if (i != _m -1)
                    {
                        stringBiulder.Append(", ");
                    }
                }
            }
            seqNumber.setSequence(stringBiulder.ToString());
            return seqNumber;
        }

        public class TPoint
        {
            private double x;
            private double y;

            public TPoint(double _x, double _y)
            {
                setX(_x);
                setY(_y);
            }

            public void setX(double _x)
            {
                this.x = _x;
            }

            public void setY( double _y )
            {
                this.y = _y;
            }

            public double getX()
            {
                return this.x;
            }

            public double getY()
            {
                return this.y;
            }

            public String ToString()
            {
                return String.Format("({0:f1}; {1:f1})", this.x, this.y);
            }
        }

        class TLine
        {
            private double k;
            private double b;

            public TLine( double _k, double _b )
            {
                setK(_k);
                setB(_b);
            }

            public void setK( double _k )
            {
                this.k = _k;
            }

            public void setB( double _b )
            {
                this.b = _b;
            }

            public void Compare(TLine line)
            {
                if (this.k == line.k && this.b == line.b)
                {
                    Console.WriteLine("Прямые совпадают");
                }
                else if (this.k == line.k && this.b != line.b)
                {
                    Console.WriteLine("Прямые паралельны. Точки пересечения нет.");
                }
                else
                {
                    double x = (line.b - this.b) / (this.k - line.k);
                    double y = this.k * x + this.b;
                    TPoint point = new TPoint(x, y);
                    Console.WriteLine("Точка пересечения имеет координаты {0}", point.ToString());
                }
            }
        }

        static void Main( string[] args )
        {
            //Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
            //0, 7, 8, -2, -2 -> 2
            //1, -7, 567, 89, 223-> 3
            Console.WriteLine("Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.");
            Console.Write("Введите число M: ");
            int m = Convert.ToInt32(Console.ReadLine());
            SequenceOfNumber sequenceofNumber = new SequenceOfNumber();
            sequenceofNumber = InputSequence(m);
            Console.WriteLine("{0} -> {1}", sequenceofNumber.getSequence(), sequenceofNumber.getCount());
            Console.WriteLine(divider);
            //Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
            //b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
            Console.WriteLine("Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.");
            Console.WriteLine("Первая прямая");
            Console.Write("Введите k1: ");
            double k1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b1: ");
            double b1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вторая  прямая");
            Console.Write("Введите k2: ");
            double k2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b2: ");
            double b2 = Convert.ToDouble(Console.ReadLine());            
            TLine line1 = new TLine(k1, b1);
            TLine line2 = new TLine(k2, b2);
            line1.Compare(line: line2);
            Console.WriteLine(divider);
            Console.ReadKey();
        }
    }
}
