using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tas.Gabos.enemy
{
    /// <summary>
    ///     Interfaces that models ana Enemy.
    /// </summary>
    public interface IEnemy : IEntity
    {

        /// <summary>
        ///     Moves the enemy forward.
        /// </summary>
        void MoveForward();

        /// <summary>
        ///     Deals damage to the enemy.
        /// </summary>
        /// <param name="damage"> The damage that will be dealt
        void DealDamage(double damage);

        /// <summary>
        ///     Check if the enemy is dead.
        /// </summary>
        /// <returns> True if the enemy is dead.</returns>
        bool IsDead();

        /// <summary>
        ///     Return the Health of the enemy.
        /// </summary>
        double Health { get; }

        /// <summary>
        ///     Return The Modey of the enemy.
        /// </summary>
        int Money { get; }

        /// <summary>
        ///     Return The damage of the enemy.
        /// </summary>
        int Damage { get; }

        /// <summary>
        ///     Check if the enemy has completed his path.
        /// </summary>
        /// <returns> True if the enemy has completed his path.</returns>
        bool IsPathCompleted();

    }
}
