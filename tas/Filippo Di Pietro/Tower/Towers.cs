using tas.Gabos.enemy;
using System.Collections.Generic;
using System;
using tas.Gabos.utils;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro
{
    public sealed class Towers
    {
        private Towers() { }

        static public Size DEFAULTDIMENSION = new Size(100, 100);

        public static bool IsInRange(Position x, Position y, int radius)
        {
            return Position.FindDistance(x, y) <= radius;
        }

        public static bool IsTargetInRange(ITower t, IEnemy e)
        {
            return IsInRange(t.Pos, e.Position, t.Radius);
        }

        public static IEnemy FindFisrtInRange(ITower t, IList<IEnemy> enemyList)
        {
            return FindFirstEnemyByPredicate(x => IsTargetInRange(t, x), enemyList);
        }

        public static IEnemy FindFirstEnemyByPredicate(Predicate<IEnemy> filter, IList<IEnemy> enemyList)
        {
            foreach (var enemy in enemyList)
            {
                if (filter(enemy))
                {
                    return enemy;
                }
            }
            return null;
        }

        public static IEnumerable<IEnemy> FindAll(Predicate<IEnemy> filter, IList<IEnemy> enemyList)
        {
            foreach(var enemy in enemyList)
            {
                if (filter(enemy))
                {
                    yield return enemy;
                }
            }    
        }
    }
}
