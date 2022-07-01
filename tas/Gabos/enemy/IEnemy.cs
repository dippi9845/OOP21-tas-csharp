using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos.enemy
{
    internal interface IEnemy : IEntity
    {

        void MoveForward();

        void DealDamage(double damage);

        bool IsDead();

        double Health { get; }

        int Money { get; }

        int Damage { get; }

        bool IsPathCompleted();

    }
}
