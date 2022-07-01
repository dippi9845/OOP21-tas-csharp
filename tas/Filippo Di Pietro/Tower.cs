using System;
using System.Collections.Generic;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro.ITower
{
    public interface ITower : IEntity
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
        public Position Position => Pos;

        public Tuple<int, int> BodyDimension => new(100, 100);

        public string EntityName => TowerName;



        public AbstractBasicTower(Position pos, int damage, int radius, int delay, int cost, string towerName, List<IEnemy> enemyList)
        {
            Damage = damage;
            Radius = radius;
            Delay = delay;
            Cost = cost;
            TowerName = towerName;
            VisibleEnemyList = enemyList;
        }

        abstract protected void attack();

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

        public List<IEnemy> VisibleEnemyList { get; }
    }
}
