using System.Collections.Generic;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro.ITower
{
    public interface ITower
    {
        public int Damage { get; }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        public string TowerName { get; }

        public Position Pos { get; }
    }

    public abstract class AbstractBasicTower : ITower
    {
        AbstractBasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, List<IEnemy> enemyList)
        {
            Damage = damage;
            Radius = radius;
            Delay = delay;
            Cost = cost;
            TowerName = towerName;
            VisibleEnemyList = enemyList;
        }
        public int Damage { get; }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        public string TowerName { get; }

        public Position Pos { get; }

        List<IEnemy> VisibleEnemyList { get; }
    }
}
