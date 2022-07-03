using System;
using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;
using tas.Gabos.utils;

namespace tas.Filippo_Di_Pietro
{
    /// <summary>
    /// This abstract class model a generic tower
    /// </summary>
    public abstract class AbstractBasicTower : ITower
    {
        public Position Position => Pos;

        Size IEntity.BodyDimension => Towers.DEFAULTDIMENSION;

        public string EntityName => TowerName;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pos">Position of the tower</param>
        /// <param name="damage">Damage of the tower</param>
        /// <param name="radius">Radius of the tower</param>
        /// <param name="delay">Delay of the tower</param>
        /// <param name="cost">Cost of the tower</param>
        /// <param name="towerName">Tower Name of the tower</param>
        /// <param name="enemyList">Current enemy present in the field</param>
        public AbstractBasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList)
        {
            Pos = pos;
            Damage = damage;
            Radius = radius;
            Delay = delay;
            Cost = cost;
            TowerName = towerName;
            VisibleEnemyList = enemyList;
        }

        /// <summary>
        /// Leave to other implementation the way to attack
        /// </summary>
        protected abstract void Attack();

        /// <summary>
        /// Leave the other implementation the behavior
        /// </summary>
        public abstract void Compute();

        /// <summary>
        /// Damage of the tower
        /// </summary>
        public int Damage { get; private set; }

        /// <summary>
        /// Increase the damage if is needed for upgrades
        /// </summary>
        /// <param name="amount">Amounto of damage to increase</param>
        protected void IncreaseDamage(int amount)
        {
            Damage += amount;
        }

        /// <summary>
        /// Radius of the tower
        /// </summary>
        public int Radius { get; }

        /// <summary>
        /// Cost of the tower
        /// </summary>
        public int Cost { get; }

        /// <summary>
        /// Delay of the tower
        /// </summary>
        public int Delay { get; }

        /// <summary>
        /// Name of the tower
        /// </summary>
        public string TowerName { get; }

        /// <summary>
        /// Position of the tower
        /// </summary>
        public Position Pos { get; }

        /// <summary>
        /// Current enemy present in the field
        /// </summary>
        public IList<IEnemy> VisibleEnemyList { get; }
    }

    /// <summary>
    /// This concrete class model a simple Tower with just one target, to attack
    /// </summary>
    public class BasicTower : AbstractBasicTower
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pos">Position of the tower</param>
        /// <param name="damage">Damage of the tower</param>
        /// <param name="radius">Radius of the tower</param>
        /// <param name="delay">Delay of the tower</param>
        /// <param name="cost">Cost of the tower</param>
        /// <param name="towerName">Tower Name of the tower</param>
        /// <param name="enemyList">Current enemy present in the field</param>
        public BasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList)
            : base(pos, damage, radius, delay, cost, towerName, enemyList)
        {
            Target = null;
        }

        /// <summary>
        /// Target to attack
        /// </summary>
        private IEnemy Target { get; set; }

        /// <summary>
        /// Attack the target if is present
        /// </summary>
        protected override void Attack()
        {
            if (Target != null)
            {
                Target.DealDamage(this.Damage);
            }
        }

        /// <summary>
        /// Checks if the stored target is still valid
        /// </summary>
        /// <returns>True if is still valid</returns>
        private bool IsTargetValid() => Towers.IsTargetInRange(this, Target) && !Target.IsDead();

        /// <summary>
        /// The genric behavior is: 
        /// if the enemy was already found attack it, otherwise find him
        /// </summary>
        public override void Compute()
        {
            if (Target != null && IsTargetValid())
            {
                Target.DealDamage(Damage);
            }
            else
            {
                IEnemy target = Towers.FindFisrtInRange(this, VisibleEnemyList);
                if (target != null)
                {
                    Target = target;
                }
            }
        }
    }
}
