using System;
using System.Collections.Generic;
using System.Linq;
using tas.Gabos.utils;

namespace tas.Gabos.enemy
{
    /// <summary>
    ///     Class that implements an Enemy
    /// </summary>
    internal class GenericEnemy : IEnemy
    {
        public Position Position { get; }

        public Size BodyDimension { get; }

        public string EntityName { get; }

        public double Health { get; private set; }

        public int Money { get; }

        public int Damage { get; }

        private IList<Position> _nodesPosition;

        private int _reachedNode;

        private double _speed;

        private GameSpecs _gameSpecs = new GameSpecs();

        /// <summary>
        ///     Constructor that creates a GenericEnemy
        /// </summary>
        /// <param name="nodesPosition"> The nodes that the enemy will have to travel.</param>
        /// <param name="health"> The health of the enemy.</param>
        /// <param name="money"> The money that the enemy can drop.</param>
        /// <param name="damage"> The damage that the enemy can deal.</param>
        /// <param name="speed"> The speed of the enemy (pixels/seconds).</param>
        /// <param name="bodyDimension"> The dimension of the enemy.</param>
        /// <param name="enemyName"> The name of the enemy.</param>
        /// <exception cref="ArgumentException">If nodesPosition is empty.</exception>
        public GenericEnemy(IList<Position> nodesPosition, double health, int money, int damage, double speed, Size bodyDimension, string enemyName)
        {
            if (nodesPosition.Count == 0)
            {
                throw new ArgumentException("nodesPosition is empty");
            }

            _nodesPosition = nodesPosition;
            _reachedNode = 0;
            Position = nodesPosition.First();

            BodyDimension = bodyDimension;
            Health = health;
            Money = money;
            Damage = damage;
            _speed = speed / _gameSpecs.TickRate;
            EntityName = enemyName;
        }

        public void MoveForward()
        {
            double distanceToBeTraveled = _speed;
            while (distanceToBeTraveled > 0 && (_nodesPosition.Count - 1 > _reachedNode))
            {
                Position nextPos = _nodesPosition[_reachedNode + 1];

                if (Position.FindDistance(Position, nextPos) > _speed)
                {
                    double angle = Math.Atan2(nextPos.Y - Position.Y, nextPos.X - Position.X);
                    double newX = Position.X + _speed * Math.Cos(angle);
                    double newY = Position.Y + _speed * Math.Sin(angle);

                    Position.SetPosition(newX, newY);
                    distanceToBeTraveled = 0;
                }
                else
                {
                    distanceToBeTraveled -= Position.FindDistance(Position, nextPos);
                    Position.SetPosition(nextPos);
                    _reachedNode++;
                }
            }
        }

        public void DealDamage(double damage)
        {
            Health -= damage;
        }

        public bool IsDead()
        {
            return Health <= 0;
        }

        public bool IsPathCompleted()
        {
            return _reachedNode + 1 >= _nodesPosition.Count;
        }
    }
}
