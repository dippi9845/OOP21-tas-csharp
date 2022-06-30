using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos
{
    internal interface IEnemy : IEntity
    {

        void MoveForward();

        void DealDamage(double damage);

        bool IsDead();

        double GetHealth();

        int GetMoney();

        int GetDamage();

        bool IsPathCompleted();

    }
}
