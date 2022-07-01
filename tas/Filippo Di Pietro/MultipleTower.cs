using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro
{
    public abstract class AbstractMultipleTower : AbstractBasicTower
    {
        private List<IEnemy> Targets { get; }

        private int MaxTarget { get; }

        public AbstractMultipleTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, int maxTarget) : base(pos, damage, radius, delay, cost, towerName, enemyList)
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
        public override void Compute()
        {
            throw new System.NotImplementedException();
        }

    }
}
