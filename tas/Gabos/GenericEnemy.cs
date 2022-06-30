using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    internal class GenericEnemy : IEnemy
    {
        public Position Position { get; }

        public Tuple<int, int> BodyDimension { get; }

        public string EntityName { get; }

        public double Health { get; }

        public int Money { get; }

        public int Damage { get; }

        public GenericEnemy()
        {

        }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }

        public void DealDamage(double damage)
        {
            throw new NotImplementedException();
        }

        public bool IsDead()
        {
            throw new NotImplementedException();
        }

        public bool IsPathCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
