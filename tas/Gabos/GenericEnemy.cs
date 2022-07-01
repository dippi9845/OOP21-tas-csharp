using System;
using System.Collections.Generic;
using System.Linq;

namespace tas.Gabos
{
    internal class GenericEnemy : IEnemy
    {
        public Position Position { get; }

        public Tuple<int, int> BodyDimension { get; }

        public string EntityName { get; }

        public double Health { get; private set; }

        public int Money { get; }

        public int Damage { get; }

        private List<Position> _nodesPosition;

        private int _reachedNode;

        private double _speed;

        private GameSpecs _gameSpecs = new GameSpecs();

        public GenericEnemy(List<Position> nodesPosition, double health, int money, int damage, double speed, Tuple<int, int> bodyDimension, string enemyName)
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
            _speed = speed / _gameSpecs.GetTickRate();
            EntityName = enemyName;
            
            

        }

        public void MoveForward()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
