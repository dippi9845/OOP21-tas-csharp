using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro
{
    public abstract class AbstractMultipleTower : AbstractBasicTower
    {
        protected List<IEnemy> Targets { get; }

        protected int MaxTarget { get; }

        public AbstractMultipleTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, IList<IEnemy> enemyList1, int maxTarget)
            : base(pos, damage, radius, delay, cost, towerName, enemyList)
        {
            MaxTarget = maxTarget;
            Targets = new List<IEnemy>();
        }

        protected bool Contains(IEnemy e) => Targets.Contains(e);

        protected bool IsFull() => Targets.Count == MaxTarget;

        protected void Remove(IEnemy e) => Targets.Remove(e);

        protected void Clear() => Targets.Clear();

        protected override void Attack()
        {
            foreach (var enemy in Targets)
            {
                enemy.DealDamage(Damage);
            }
        }

        protected void AddTarget(IEnemy e) => Targets.Add(e);

        protected abstract bool IsValidTarget(IEnemy e);

    }

    public class BasicMultipleTower : AbstractMultipleTower
    {
        public BasicMultipleTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, enemyList, maxTarget)
        {
        }

        public override void Compute()
        {
            IEnumerable<IEnemy> toRemove = Towers.FindAll(x => !Towers.IsTargetInRange(this, x) || x.IsDead(), Targets);
            
            foreach(IEnemy enemy in toRemove)
            {
                Remove(enemy);
            }

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

        protected override bool IsValidTarget(IEnemy e) => Towers.IsTargetInRange(this, e) && !IsFull() && !Contains(e);
    }
}
