using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Pkcs;
using System.Windows.Forms;

namespace Simulation_Infinite_Sierpinski_Triangle
{
    public partial class Form1 : Form
    {
        int numOfPoint = 10000;
        int timeSleep = 0;
        int radius = 4;
        Point p12, p34, p56;
        Random rand = new Random();

        struct Point
        {
            public int x = 0;
            public int y = 0;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public Form1()
        {
            this.Text = "Рисование точки в Windows Forms";
            this.WindowState = FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(StartSimulation);
        }

        private void StartSimulation(object sender, PaintEventArgs e)
        {
            p12.x = this.Width / 2; p12.y = 50;
            p34.x = this.Width / 2 - 475; p34.y = 950;
            p56.x = this.Width / 2 + 475; p56.y = 950;
            
            Graphics g = e.Graphics;

            g.FillEllipse(Brushes.Black, p12.x - radius, p12.y - radius, radius, radius);
            g.FillEllipse(Brushes.Black, p34.x - radius, p34.y - radius, radius, radius);
            g.FillEllipse(Brushes.Black, p56.x - radius, p56.y - radius, radius, radius);
            
            Point startPoint = new Point((p12.x + p56.x) / 2, (p56.y + p12.y) / 2);
            g.FillEllipse(Brushes.Black, startPoint.x, startPoint.y, radius, radius);

            while (numOfPoint != 100000)
            {
                Thread.Sleep(timeSleep);
                startPoint = RandomNewPoint(startPoint);
                g.FillEllipse(Brushes.Black, startPoint.x - radius, startPoint.y - radius, radius, radius);
                numOfPoint++;
            }
        }

        private int max(int x, int y) { return x > y ? x : y; }

        private int min(int x, int y) { return x < y ? x : y; }

        private Point RandomNewPoint(Point nowPoint)
        {
            int randomPoint = rand.Next(1, 7);

            switch (randomPoint)
            {
                case 1: {
                        nowPoint.x = (nowPoint.x + p12.x) / 2;
                        nowPoint.y = (nowPoint.y + p12.y) / 2;
                    }
                    break;
                case 2: {
                        nowPoint.x = (nowPoint.x + p12.x) / 2;
                        nowPoint.y = (nowPoint.y + p12.y) / 2;
                    }
                    break;
                case 3: {
                        nowPoint.x = (nowPoint.x + p34.x) / 2;
                        nowPoint.y = (nowPoint.y + p34.y) / 2;
                    }
                    break;
                case 4:
                    {
                        nowPoint.x = (nowPoint.x + p34.x) / 2;
                        nowPoint.y = (nowPoint.y + p34.y) / 2;
                    }
                    break;
                case 5:
                    {
                        nowPoint.x = (nowPoint.x + p56.x) / 2;
                        nowPoint.y = (nowPoint.y + p56.y) / 2;
                    }
                    break;
                case 6:
                    {
                        nowPoint.x = (nowPoint.x + p56.x) / 2;
                        nowPoint.y = (nowPoint.y + p56.y) / 2;
                     }
                    break;
                default:
                    Console.WriteLine("a");
                    break;
            }

            return nowPoint;
        }
    }
}