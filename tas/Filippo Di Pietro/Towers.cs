using tas.Gabos;
using tas.Filippo_Di_Pietro;
using System.Collections.Generic;
using System;

namespace tas.Filippo_Di_Pietro
{
    public sealed class Towers
    {
        private Towers() { }

        static public Tuple<int, int> DEFAULTDIMENSION = new(100, 100);

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
                if (filter.Invoke(enemy))
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
                if (filter.Invoke(enemy))
                {
                    yield return enemy;
                }
            }    
        }
    }
}
