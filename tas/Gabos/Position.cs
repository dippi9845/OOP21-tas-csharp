using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    internal class Position
    {

        private double X { get; private set; }
        private double Y { get; private set; }

        public Position(double x, double y)
        {
            SetPosition(x, y);
        }

        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void SetPosition(Position pos)
        {
            SetPosition(pos.X, pos.Y);
        }

        public static double FindDistance(Position pos1, Position pos2)
        {
            return Math.Sqrt(Math.Pow((pos2.X - pos1.X), 2) + Math.Pow((pos2.Y - pos1.Y), 2));
        }

        public void PositionConverter(Tuple<int, int> dim, Tuple<int, int> componentDim)
        {
            X = X * dim.Item1 / componentDim.Item1;
            Y = Y * dim.Item2 / componentDim.Item2;
        }

    }
}
