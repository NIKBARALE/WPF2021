using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace практика_механика
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        
        private double time;    //наша переменная t
        private double maxWidth; //максимальная ширина грфика
        private double coffWidth;//коэфициаент увеличения/уменьшения графика
        private double maxAB;//максимальное значение по отрезку AB
        private double maxBC;//максимальное значение по отрезку BC
        private double maxCE;//максимальное значение по отрезку CE

        private double _body_mass;  //масса тела
        private double _initial_speed;// начальная скорость
        private double _driving_force;          //принудительная сила
        private double _coefficient_μ; //коэфициент μ
        private double _coefficient_f; //коэфициент f
        private double _height; //высота
        private double C2;//константа 2
        private double C3;//константа 3
        private double C5;//константа 5

        private double xAB;//координата х отрезка АВ 
        private double flipXAB;// измененная координата х отрезка АВ
        private double flipYAB;//измененная координата у отрезка АВ
        private double xBC;//координата х отрезка ВС
        private double xCE;//координата х отрезка СЕ
        private double yCE;//координата х отрезка СЕ

        private bool check = true; //булевое значение для проверок

        const double G = 9.80665;// константа G
        const double A = 0.25*Math.PI;//угол в 45 градусов
        
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(OnTimer);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }
        private void InputData()
        {
            check = true;
            if (body_mass.Text == "" | coefficient_μ.Text == "" | driving_force.Text == "" |
                initial_speed.Text == "" | coefficient_f.Text=="" | height.Text=="")
            {
                MessageBox.Show("Не все поля были заполнены ", "Мы делаем что то не то...",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                check = false;
            }
            
            else if (check)
            {
                _body_mass = Convert.ToDouble(body_mass.Text);
                _coefficient_μ = Convert.ToDouble(coefficient_μ.Text);
                _driving_force = Convert.ToDouble(driving_force.Text);
                _initial_speed = Convert.ToDouble(initial_speed.Text);
                _coefficient_f = Convert.ToDouble(coefficient_f.Text);
                _height = Convert.ToDouble(height.Text);
            }
            if (_body_mass<0 | _coefficient_μ<0 | _driving_force<0 | _initial_speed<0 | _coefficient_f<0 | _height<0 )
            {
                MessageBox.Show("Есть отрицательные значения ", "Мы делаем что то не то...",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                check = false;
            }
        }

        private void Constant()
        {
            C2 = (_driving_force + _body_mass * G * Math.Sin(A)-_initial_speed)*_coefficient_μ;
            C3 = ((_driving_force + _body_mass * G * Math.Sin(A) - (C2 * Math.Exp(-(_coefficient_μ * 3 / _body_mass))))/_coefficient_μ);
            C5 = ((15 / _body_mass) * 4 * 4) - (_coefficient_f * G * time) + C3;
        }
        private void Canvascoff()
        {
            maxAB = (_coefficient_μ * _driving_force * 4 + _coefficient_μ * _body_mass * G * Math.Sin(A) * 4 - C2 * _body_mass * Math.Exp((_coefficient_μ * 4) / _body_mass)) / (_coefficient_μ * _coefficient_μ);
            maxBC = (5 / _body_mass - (_coefficient_f * G * G) / 2) + C3;
            maxCE = C5 * (6);
            maxWidth = Math.Abs(maxAB) + Math.Abs(maxBC) + Math.Abs(maxCE);
            coffWidth =Math.Abs(1000 / maxWidth);
            Canvas.SetLeft(plineAB, Math.Abs(coffWidth* maxAB));
            Canvas.SetTop(plineAB, Math.Abs(coffWidth * maxAB));
            Canvas.SetLeft(plineBC, Math.Abs(coffWidth * maxAB));
            Canvas.SetTop(plineBC, Math.Abs(coffWidth * maxAB));
            Canvas.SetLeft(plineCE, Math.Abs(coffWidth * maxAB));
            Canvas.SetTop(plineCE, Math.Abs(coffWidth * maxAB));
        }


        private void AB()
        {
            xAB = (_coefficient_μ * _driving_force * time + _coefficient_μ * _body_mass * G * Math.Sin(A) * time - C2 * _body_mass * Math.Exp((_coefficient_μ * time) / _body_mass)) / (_coefficient_μ * _coefficient_μ);
            flipXAB = coffWidth* xAB * Math.Cos(-A);
            flipYAB = coffWidth* - xAB * Math.Sin(-A);
            plineAB.Points.Add(new Point(flipXAB,  flipYAB));
            
        }
        private void BC()
        {
            xBC = coffWidth*(((5 * (time-3) * (time-3) * (time-3)) / _body_mass - (_coefficient_f * G * (time-3) * (time-3)) / 2.0) + C3 * (time-3));
            plineBC.Points.Add(new Point(flipXAB + xBC,  flipYAB));
        }

        private void CE()
        {
            xCE = coffWidth * C5 * (time-4);
            yCE = coffWidth *( _height - (G * (time - 4) * (time - 4)) / 2.0);
            plineCE.Points.Add(new Point( flipXAB + xBC+ +xCE, flipYAB -yCE+ (coffWidth*_height)));
            if (yCE < 0)
                timer.Stop();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            
            time += 0.02;

            if (time <= 3)
                AB();
            else if (time <= 4 && time >= 3)
                BC();
            else if (time >= 4)
                CE();   
        }
        private void ButtonStart(object sender, RoutedEventArgs e)
        {
            time = 0;
            plineAB.Points.Clear();
            plineBC.Points.Clear();
            plineCE.Points.Clear();
            InputData();                            
            if (!check) return;
            Constant();
            Canvascoff();               
            timer.Start();                           
        }
    }

}
