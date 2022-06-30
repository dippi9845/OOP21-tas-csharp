using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    public class Position
    {

        private double _x;
        private double _y;

        public Position(double x, double y)
        {
            SetPosition(x, y);
        }

        public void SetPosition(double x, double y)
        {
            this._x = x;
            this._y = y;
        }

        public void SetPosition(Position pos)
        {
            SetPosition(pos.GetX(), pos.GetY());
        }

        public double GetX() => _x;

        public double GetY() => _y;

        public static double FindDistance(Position pos1, Position pos2)
        {
            return Math.Sqrt(Math.Pow((pos2.GetX() - pos1.GetX()), 2) + Math.Pow((pos2.GetY() - pos1.GetY()), 2));
        }

        public void PositionConverter(Tuple<int, int> dim, Tuple<int, int> componentDim)
        {
            this._x = GetX() * dim.Item1 / componentDim.Item1;
            this._y = GetY() * dim.Item2 / componentDim.Item2;
        }

    }
}
