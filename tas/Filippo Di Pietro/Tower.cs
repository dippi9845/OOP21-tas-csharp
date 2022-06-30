using System;
using System.Collections.Generic;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro.ITower
{
    public interface ITower : IEntity
    {
        new Tuple<int, int> BodyDimension => new Tuple<int, int>(100, 100);

        Position GetPosition => Pos;

        new string EntityName => TowerName;
        
        public int Damage { get; }

        public int Radius { get; }

        public int Cost { get; }

        public int Delay { get; }

        public string TowerName { get; }

        public Position Pos { get; }
    }

    public abstract class AbstractBasicTower : ITower
    {
        public AbstractBasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, List<IEnemy> enemyList)
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

        public List<IEnemy> VisibleEnemyList { get; }
    }
}
