using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro.Tower
{
    public abstract class AbstractAreaTower : AbstractMultipleTower
    {
        private int AttackRadius { get; }

        protected Position TargetPosition { get; set; }

        public AbstractAreaTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget, int attackRadius)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, maxTarget)
        {
            AttackRadius = attackRadius;
        }

        protected override bool IsValidTarget(IEnemy e) => Towers.IsInRange(e.Position, TargetPosition, AttackRadius);

        abstract protected IEnemy FindFirstTarget();

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

    public class BasicAreaTower : AbstractAreaTower
    {
        public BasicAreaTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget, int attackRadius)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, maxTarget, attackRadius)
        {
        }

        protected override IEnemy FindFirstTarget() => Towers.FindFisrtInRange(this, VisibleEnemyList);
    }
}
