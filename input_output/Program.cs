using System;

namespace input_output
{

    struct coordinates
    {
        public double fragmentation;
        public double time;
        public double[] t;
        public double[] x;
        public double[] y;
        public int size;
        public coordinates (double t0, double frag)
        {
            this.time = t0;
            this.fragmentation = frag;
            int siz = (int)(t0 / frag);
            this.size = siz;
            this.x = new double [size];
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
            for(int i=0; i < size; i++)
            {
                Console.WriteLine("time="+t[i]+" x="+x[i]+" y="+y[i]+'\n' );
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            Console.WriteLine("Введите время");
            double time =Convert.ToDouble( Console.ReadLine());
            Console.WriteLine("Введите разбиение");
            double fragmentation = Convert.ToDouble(Console.ReadLine());
            coordinates fly = new coordinates(time, fragmentation);
            
            for(int i=0; i < fly.size;i++)
            { double t = 0;
                fly.fillcoord(i, t += fragmentation, rnd.NextDouble(), rnd.NextDouble());
            }
            fly.watch();


        }
    }
}
