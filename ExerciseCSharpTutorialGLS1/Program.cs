using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseCSharpTutorialGLS1
{
    class Program
    {
        public class Test
        {
            static void Main()
            {
                aPoint aPt = new aPoint(0,0,0);
                aRectang aRct = new aRectang(1,2);
                aCircle aCir = new aCircle(2.1);
                Console.WriteLine("Test start: ");

                aPt.display();
                aPt.getArea(aPt);
                aRct.getArea(aRct);
                aCir.getArea(aCir);
            }
        }

        public class aPoint
        {
            private double P_lx, P_ly, P_lz;
            public double Area;
            public aPoint(double x , double y, double z)
            {
                P_lx = x;
                P_ly = y;
                P_lz = z;
                Area = 0;
            }
            public aPoint()
            {
                P_lx = 0;
                P_ly = 0;
                P_lz = 0;
                Area = 0;
            }

            public virtual void display()
            {
                Console.WriteLine("Location: {0},{1},{2}",P_lx, P_ly,P_lz);
                Console.Write("Area is ");
            }
            public void getArea(aPoint aB)
            {
                aB.display();
                Console.WriteLine(Area);
            }

        }

        class aRectang : aPoint
        {
            private double P_l, P_w;
            public aRectang(double l, double w)
            {
                P_l = l;
                P_w = w;
                Area = l * w;
            }
            public override void display()
            {
                base.display();
                Console.WriteLine(Area);
            }
        }

        public class aCircle: aPoint
        {
            private double P_r;
            public aCircle(double r)
            {
                P_r = r;
                Area = 3.14 * r * r;
            }
            public override void display()
            {
                base.display();
                Console.WriteLine(Area);
            }
        }
    }
}
