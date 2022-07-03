using tas.Gabos.enemy;
using System.Collections.Generic;
using System;
using tas.Gabos.utils;
using tas.Gabos;

namespace tas.Filippo_Di_Pietro
{
    /// <summary>
    /// Class not instatiable containig all static methods
    /// </summary>
    public sealed class Towers
    {
        private Towers() { }

        /// <summary>
        /// Default dimension of a tower
        /// </summary>
        static public Size DEFAULTDIMENSION = new Size(100, 100);

        /// <summary>
        /// Check if two position are enouth near
        /// </summary>
        /// <param name="x">First position</param>
        /// <param name="y">Second position</param>
        /// <param name="radius">Radius</param>
        /// <returns>True if they are under radius as distance</returns>
        public static bool IsInRange(Position x, Position y, int radius)
        {
            return Position.FindDistance(x, y) <= radius;
        }

        /// <summary>
        /// Check if an emey is near to a tower
        /// </summary>
        /// <param name="t">Tower</param>
        /// <param name="e">Enemy to be checked</param>
        /// <returns>True if the enemy is near to the tower</returns>
        public static bool IsTargetInRange(ITower t, IEnemy e)
        {
            return IsInRange(t.Pos, e.Position, t.Radius);
        }

        /// <summary>
        /// Find the first enemy in range
        /// </summary>
        /// <param name="t">Tower</param>
        /// <param name="enemyList">List of enemy in the field</param>
        /// <returns>Actual enemy if found, null otherwise</returns>
        public static IEnemy FindFisrtInRange(ITower t, IList<IEnemy> enemyList)
        {
            return FindFirstEnemyByPredicate(x => IsTargetInRange(t, x), enemyList);
        }

        /// <summary>
        /// Find an enemy by the predicate given, in enemylist
        /// </summary>
        /// <param name="filter">Filter method</param>
        /// <param name="enemyList">list of enemy to be filtered</param>
        /// <returns>Actual enemy if found, null otherwises</returns>
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

        /// <summary>
        /// Find all enemy filtered by the method given
        /// </summary>
        /// <param name="filter">Filter method</param>
        /// <param name="enemyList">list of enemy to be filtered</param>
        /// <returns>Returns a list of filtered enemy</returns>
        public static IList<IEnemy> FindAll(Predicate<IEnemy> filter, IList<IEnemy> enemyList)
        {
            IList<IEnemy> filtered = new List<IEnemy>();

            foreach(var enemy in enemyList)
            {
                if (filter(enemy))
                {
                    filtered.Add(enemy);
                }
            }
            return filtered;
        }
    }
}
