using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro.Tower
{
    public abstract class AbstractAreaTower : AbstractMultipleTower
    {
        private int AttackRadius { get; }

        public AbstractAreaTower(Position pos, int damage, int radius, int delay, int cost, string towerName, IList<IEnemy> enemyList, IList<IEnemy> enemyList1, int maxTarget, int attackRadius)
            : base(pos, damage, radius, delay, cost, towerName, enemyList, enemyList, maxTarget)
        {

        }
    }
}
