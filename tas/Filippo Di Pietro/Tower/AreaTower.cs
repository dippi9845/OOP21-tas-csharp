using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro.Tower
{
    /// <summary>
    /// An abstract tower that need only a method to be instanced, FindFirstTarget() This class model a tower that one it found an enemy, all the other near will be attacked
    /// </summary>
    public abstract class AbstractAreaTower : AbstractMultipleTower
    {
        /// <summary>
        /// Radius of the attack
        /// </summary>
        private int AttackRadius { get; }

        /// <summary>
        /// Position of the first target
        /// </summary>
        protected Position TargetPosition { get; set; }

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
        /// <param name="attackRadius">Range of attack given by the first target</param>
        public AbstractAreaTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget, int attackRadius)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, maxTarget)
        {
            AttackRadius = attackRadius;
        }

        /// <summary>
        /// Checks if the enemy e is near to the target choose by the tower
        /// </summary>
        /// <param name="e">enemy to be checked</param>
        /// <returns>True if the enemy is near to the choosen target</returns>
        protected override bool IsValidTarget(IEnemy e) => Towers.IsInRange(e.Position, TargetPosition, AttackRadius);

        /// <summary>
        /// Abstract method, delegate to concrete class the decision to choose the first target
        /// </summary>
        /// <returns>null if no enemy was found, otherwise the actual enemy</returns>
        abstract protected IEnemy FindFirstTarget();

        /// <summary>
        /// Add all near enemy to the target
        /// </summary>
        private void AddNearbyTarget()
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

        /// <summary>
        /// Generic behavior:
        /// Find fisrt enemy
        /// Second, add all enemy in the nearby
        /// Third, attack them
        /// </summary>
        public override void Compute()
        {
            IEnemy target = FindFirstTarget();
            if (target != null)
            {
                TargetPosition = target.Position;
                AddNearbyTarget();
                Attack();
                Clear();
            }
        }
    }

    /// <summary>
    /// this calss model a simple area tower
    /// </summary>
    public class BasicAreaTower : AbstractAreaTower
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
        /// <param name="attackRadius">Range of attack given by the first target</param>
        public BasicAreaTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget, int attackRadius)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, maxTarget, attackRadius)
        {
        }

        /// <summary>
        /// Find first enemy in range
        /// </summary>
        /// <returns>null if no enemy was found, otherwise the actual enemy</returns>
        protected override IEnemy FindFirstTarget() => Towers.FindFisrtInRange(this, VisibleEnemyList);
    }
}
