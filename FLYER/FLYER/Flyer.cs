
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace nikbarale.graph
{
    class setup_page : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new setup_page());
        }


        enum Side
        {
            Left, Right, Top, Bottom
        }

        TextBox[] txtbox = new TextBox[4];
        Label[] lbl = new Label[4];
        Button btnOk;
        public string setup_time
        {
            set
            {
                txtbox[0].Text = value;
                txtbox[0].SelectionStart = txtbox[0].Text.Length;
            }
            get
            {
                return txtbox[0].Text;
            }
        }
        public string setup_frag
        {
            set
            {
                txtbox[1].Text = value;
                txtbox[1].SelectionStart = txtbox[1].Text.Length;
            }
            get
            {
                return txtbox[1].Text;
            }
        }
        public string setup_angle
        {
            set
            {
                txtbox[2].Text = value;
                txtbox[2].SelectionStart = txtbox[2].Text.Length;
            }
            get
            {
                return txtbox[2].Text;
            }
        }
        public string setup_speed
        {
            set
            {
                txtbox[3].Text = value;
                txtbox[3].SelectionStart = txtbox[3].Text.Length;
            }
            get
            {
                return txtbox[3].Text;
            }
        }

        public setup_page()
        {
            Title = "Page Setup";
            ShowInTaskbar = true;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanResize;
            StackPanel stack = new StackPanel();
            Content = stack;
            GroupBox grpbox = new GroupBox();
            grpbox.Header = "setup";
            grpbox.Margin = new Thickness(12);
            stack.Children.Add(grpbox);
            Grid grid = new Grid();
            grid.Margin = new Thickness(6);
            grpbox.Content = grid;
            for (int i = 0; i < 2; i++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = GridLength.Auto;
                grid.RowDefinitions.Add(rowdef);
            }
            for (int i = 0; i < 4; i++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = GridLength.Auto;
                grid.ColumnDefinitions.Add(coldef);
            }
            Label l = new Label();
            l.Content = "time:";
            l.Margin = new Thickness(6);
            l.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(l);
            Grid.SetRow(l, 0 / 2);
            Grid.SetColumn(l, 2 * (0 % 2));
            txtbox[0] = new TextBox();
            txtbox[0].MinWidth = 48;
            txtbox[0].Margin = new Thickness(6);
            grid.Children.Add(txtbox[0]);
            Grid.SetRow(txtbox[0], 0 / 2);
            Grid.SetColumn(txtbox[0], 2 * (0 % 2) + 1);

            Label l1 = new Label();
            l1.Content = "frag:";
            l1.Margin = new Thickness(6);
            l1.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(l1);
            Grid.SetRow(l1, 1 / 2);
            Grid.SetColumn(l1, 2 * (1 % 2));
            txtbox[1] = new TextBox();
            txtbox[1].MinWidth = 48;
            txtbox[1].Margin = new Thickness(6);
            grid.Children.Add(txtbox[1]);
            Grid.SetRow(txtbox[1], 1 / 2);
            Grid.SetColumn(txtbox[1], 2 * (1 % 2) + 1);

            Label l2 = new Label();
            l2.Content = "angle:";
            l2.Margin = new Thickness(6);
            l2.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(l2);
            Grid.SetRow(l2, 2 / 2);
            Grid.SetColumn(l2, 2 * (2 % 2));
            txtbox[2] = new TextBox();
            txtbox[2].MinWidth = 48;
            txtbox[2].Margin = new Thickness(6);
            grid.Children.Add(txtbox[2]);
            Grid.SetRow(txtbox[2], 2 / 2);
            Grid.SetColumn(txtbox[2], 2 * (2 % 2) + 1);

            Label l3 = new Label();
            l3.Content = "speed:";
            l3.Margin = new Thickness(6);
            l3.VerticalAlignment = VerticalAlignment.Center;
            grid.Children.Add(l3);
            Grid.SetRow(l3, 3 / 2);
            Grid.SetColumn(l3, 2 * (3 % 2));
            txtbox[3] = new TextBox();
            txtbox[3].MinWidth = 48;
            txtbox[3].Margin = new Thickness(6);
            grid.Children.Add(txtbox[3]);
            Grid.SetRow(txtbox[3], 3 / 2);
            Grid.SetColumn(txtbox[3], 2 * (3 % 2) + 1);

            UniformGrid unigrid = new UniformGrid();
            unigrid.Rows = 1;
            unigrid.Columns = 1;
            stack.Children.Add(unigrid);
            btnOk = new Button();
            btnOk.Content = "OK";
            btnOk.IsDefault = true;
            btnOk.MinWidth = 60;
            btnOk.Margin = new Thickness(12);
            btnOk.HorizontalAlignment = HorizontalAlignment.Center;
            btnOk.Click += OkButtonOnClick;
            unigrid.Children.Add(btnOk);
        }
        void OkButtonOnClick(object sender, RoutedEventArgs args)
        {
            double t = Convert.ToDouble(txtbox[0].Text);
            double a = Convert.ToDouble(txtbox[2].Text);
            double v = Convert.ToDouble(txtbox[3].Text);
            double f = Convert.ToDouble(txtbox[1].Text);

            Print_page dlg = new Print_page(t, a, v, f);
            dlg.ShowDialog();

        }
    }
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
    class Print_page : Window
    {
        public Print_page(double time, double a, double v, double f)
        {

            Title = "Print Graphic";
            ShowInTaskbar = true;
            WindowStyle = WindowStyle.ToolWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            SizeToContent = SizeToContent.WidthAndHeight;
            ResizeMode = ResizeMode.CanResize;
            Canvas myCanvas = new Canvas();
            myCanvas.HorizontalAlignment = HorizontalAlignment.Center;
            myCanvas.VerticalAlignment = VerticalAlignment.Center;
            myCanvas.Width = 500;
            myCanvas.Height = 500;
            myCanvas.Background = Brushes.White;
            Content = myCanvas;
            coordinates fly = new coordinates(time, f);
            coordinates_of_flyer flyer = new coordinates_of_flyer();
            double t = 0;
            for (int i = 0; i < fly.size; i++)
            {

                double x = flyer.function_for_flyer_x(t, a, v, 0);
                double y = flyer.function_for_flyer_y(t, a, v, 0, 0);
                fly.fillcoord(i, t, x, y);
                t += f;
            }
            for (int i = 1; i < fly.size; i++)
            {
                Line line = new Line();
                line.X1 = fly.x[i - 1];
                line.Y1 = fly.y[i - 1];
                line.X2 = fly.x[i];
                line.Y2 = fly.y[i];
                line.Stroke = Brushes.Black;
                myCanvas.Children.Add(line);
            }
        }
    }
}


