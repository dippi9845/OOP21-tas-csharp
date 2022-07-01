using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    /// <summary>
    ///     Class that models a Position.
    /// </summary>
    public class Position
    {

        public double X { get; private set; }
        public double Y { get; private set; }

        /// <summary>
        ///     Constructor of the Position class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public Position(double x, double y)
        {
            SetPosition(x, y);
        }

        /// <summary>
        ///     Set the position for the object.
        /// </summary>
        /// <param name="x">The new x coordinate.</param>
        /// <param name="y">The new y coordinate.</param>
        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///    Set the position for the object.
        /// </summary>
        /// <param name="pos"> The new Position of the object.</param>
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
