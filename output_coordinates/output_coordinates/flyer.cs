/*using System;

namespace input_output
{
    class coordinates_of_flyer
    {
        private const double g = 9.8;
        public double function_for_flyer_x(double t, double a0, double v0, double x0)
        {
            double x;
            double a = a0 * (Math.PI / 180);
            x = x0 + (v0 * t * Math.Cos(a));
            return x;
        }
        public double function_for_flyer_y(double t, double a0, double v0, double y0, double h0)
        {
            double y;
            double a = a0 * (Math.PI / 180);
            y = y0 + (v0 * t * Math.Sin(a) - (0.5 * g * t * t));
            return y;
        }
    }

    struct coordinates
    {
        public double fragmentation;
        public double time;
        public double[] t;
        public double[] x;
        public double[] y;
        public int size;
        public coordinates(double t0, double frag)
        {
            this.time = t0;
            this.fragmentation = frag;
            int siz = (int)(t0 / frag);
            this.size = siz;
            this.x = new double[size];
            this.y = new double[size];
            this.t = new double[size];

        }
        public void fillcoord(int i, double t0, double x0, double y0)
        {
            x[i] = x0;
            y[i] = y0;
            t[i] = t0;
        }
        public void watch()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("time=" + t[i] + " x=" + x[i] + " y=" + y[i] + '\n');
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Введите время");
            double time = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите разбиение");
            double fragmentation = Convert.ToDouble(Console.ReadLine());
            coordinates fly = new coordinates(time, fragmentation);
            Console.WriteLine("Введите начальную скорость");
            double v0 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите угол в градусах");
            double a = Convert.ToDouble(Console.ReadLine());
            coordinates_of_flyer flyer = new coordinates_of_flyer();

            double t = 0;
            for (int i = 0; i < fly.size; i++)
            {
                t += fragmentation;
                double x = flyer.function_for_flyer_x(t, a, v0, 0);
                double y = flyer.function_for_flyer_y(t, a, v0, 0, 0);
                fly.fillcoord(i, t, x, y);
            }
            fly.watch();


        }
    }
}*/

