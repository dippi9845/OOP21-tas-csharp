using System;
using System.Collections.Generic;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro
{
    public abstract class AbstractBasicTower : ITower
    {
        public Position Position => Pos;

        public Tuple<int, int> BodyDimension => Towers.DEFAULTDIMENSION;

        public string EntityName => TowerName;

        public AbstractBasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList)
        {
            Damage = damage;
            Radius = radius;
            Delay = delay;
            Cost = cost;
            TowerName = towerName;
            VisibleEnemyList = enemyList;
        }

        protected abstract void attack();
        public abstract void Compute();

        public int Damage
        {
            get => Damage;
            protected set => Damage += value;
        }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        public string TowerName { get; }

        public Position Pos { get; }

        public IList<IEnemy> VisibleEnemyList { get; }
    }

    public class BasicTower : AbstractBasicTower
    {
        public BasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList) : base(pos, damage, radius, delay, cost, towerName, enemyList)
        {
        }

        private IEnemy Target { get; set; }

        protected override void attack()
        {
            if (Target != null)
            {
                Target.DealDamage(this.Damage);
            }
        }

        private bool IsTargetValid()
        {
            return Towers.IsTargetInRange(this, Target) && !Target.IsDead();
        }

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
