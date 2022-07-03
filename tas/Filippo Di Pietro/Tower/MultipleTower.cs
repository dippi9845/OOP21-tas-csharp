using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro
{
    /// <summary>
    /// An abstract class that model a Tower with an undefined number of enemies targeted.
    /// </summary>
    public abstract class AbstractMultipleTower : AbstractBasicTower
    {
        /// <summary>
        /// List of Targets
        /// </summary>
        protected List<IEnemy> Targets { get; }

        /// <summary>
        /// max number of possible target
        /// </summary>
        protected int MaxTarget { get; }

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
        /// <param name="maxTarget">Max number of target that this tower can handle at the time</param>
        public AbstractMultipleTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget)
            : base(pos, damage, radius, delay, cost, towerName, enemyList)
        {
            MaxTarget = maxTarget;
            Targets = new List<IEnemy>();
        }

        /// <summary>
        /// Checks if an enemy is already targeted
        /// </summary>
        /// <param name="e">Enemy to be checked</param>
        /// <returns>True if the enemy was already targeted, false otherwise</returns>
        protected bool Contains(IEnemy e) => Targets.Contains(e);

        /// <summary>
        /// Checks if the list of targets is full
        /// </summary>
        /// <returns>True if the list is full</returns>
        protected bool IsFull() => Targets.Count == MaxTarget;

        /// <summary>
        /// Remove an enemy from the list
        /// </summary>
        /// <param name="e">Enemy to be removed</param>
        protected void Remove(IEnemy e) => Targets.Remove(e);

        /// <summary>
        /// Clear the list of enemy
        /// </summary>
        protected void Clear() => Targets.Clear();

        /// <summary>
        /// Attack all the targets
        /// </summary>
        protected override void Attack()
        {
            foreach (var enemy in Targets)
            {
                enemy.DealDamage(Damage);
            }
        }

        /// <summary>
        /// Add target to the list
        /// </summary>
        /// <param name="e">enemy to be added</param>
        protected void AddTarget(IEnemy e) => Targets.Add(e);

        /// <summary>
        /// Checks if the enemy passed is valid to be added
        /// </summary>
        /// <param name="e">Enemy to be checked</param>
        /// <returns>True if the enemy is valid to be added</returns>
        protected abstract bool IsValidTarget(IEnemy e);

    }

    /// <summary>
    /// This class is a basic implementation of AbstractMultipleTower, this BasicMultipleTower model a tower that attack the first maxTarget in the range
    /// </summary>
    public class BasicMultipleTower : AbstractMultipleTower
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
        /// <param name="maxTarget">Max number of target that this tower can handle at the time</param>
        public BasicMultipleTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, maxTarget)
        {
        }
        /// <summary>
        /// The genirc behavior of the tower is:
        /// First remove all targets that are no more valid
        /// Second find all target that are valid
        /// Third attack
        /// </summary>
        public override void Compute()
        {

            Targets.RemoveAll(x => !Towers.IsTargetInRange(this, x) || x.IsDead());

            if (!IsFull())
            {
                IEnumerable<IEnemy> toAdd = Towers.FindAll(IsValidTarget, VisibleEnemyList);

                foreach(IEnemy enemy in toAdd)
                {
                    if (!IsFull())
                    {
                        AddTarget(enemy);
                    }
                }
            }
            
            this.Attack();

        }

        /// <summary>
        /// Checks if the enemy passed is valid to be added, must be in range, targets list must be not full, the enemy must not be already in the list
        /// </summary>
        /// <param name="e">Enemy to be checked</param>
        /// <returns>True if the enemy is valid to be added</returns>
        protected override bool IsValidTarget(IEnemy e) => Towers.IsTargetInRange(this, e) && !IsFull() && !Contains(e);
    }
}
