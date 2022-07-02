using System;
using System.Collections.Generic;
using tas.Gabos.utils;

namespace tas.Gabos.enemy
{

    /// <summary>
    ///     Class that implements an IEnemyBuilder.
    /// </summary>
    public class EnemyBuilder : IEnemyBuilder
    {

        private IList<Position> _nodesPosition;

        private Dictionary<string, Dictionary<string, string>> _enemies =
            new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        ///     Constructor that sets up the builder.
        /// </summary>
        /// <param name="nodesPosition"></param>
        /// <exception cref="ArgumentException"> If the nodesPosition is empty.</exception>
        public EnemyBuilder(IList<Position> nodesPosition)
        {
            if (nodesPosition.Count == 0)
            {
                throw new ArgumentException("nodesPosition is empty");
            }

            _nodesPosition = nodesPosition;

            EnemyDictSetup();
        }

        /// <summary>
        ///     Sets up the enemy dictionary.
        /// </summary>
        private void EnemyDictSetup()
        {
            Dictionary<string, string> redEnemy = new Dictionary<string, string>() {
                { "health", "800" },
                { "money", "50" },
                { "damage", "10" },
                { "Speed", "60" },
                { "width", "100" },
                { "height", "100" },
                { "name", "RedEnemy" }
            };
            Dictionary<string, string> greenEnemy = new Dictionary<string, string>() {
                { "health", "8000" },
                { "money", "100" },
                { "damage", "40" },
                { "Speed", "30" },
                { "width", "100" },
                { "height", "100" },
                { "name", "GreenEnemy" }
            };
            Dictionary<string, string> pinkEnemy = new Dictionary<string, string>() {
                { "health", "2200" },
                { "money", "100" },
                { "damage", "20" },
                { "Speed", "90" },
                { "width", "100" },
                { "height", "100" },
                { "name", "PinkEnemy" }
            };
            _enemies.Add("RedEnemy", redEnemy);
            _enemies.Add("GreenEnemy", greenEnemy);
            _enemies.Add("PinkEnemy", pinkEnemy);
        }

        /// <summary>
        ///     Generates an enemy by the given stats
        /// </summary>
        /// <returns> The requested enemy.</returns>
        /// <param name="eStats"></param>
        /// <returns></returns>
        private IEnemy SpawnGenericEnemy(Dictionary<string, string> eStats)
        {
            //get data from the dictionary and create a GenericEnemy
            return new GenericEnemy(
                _nodesPosition,
                double.Parse(eStats["health"]),
                int.Parse(eStats["money"]),
                int.Parse(eStats["damage"]),
                double.Parse(eStats["Speed"]),
                new Size(
                    int.Parse(eStats["width"]),
                    int.Parse(eStats["height"])),
                eStats["name"]
            );
        }

        public IEnemy SpawnRedEnemy()
        {
            // to be implemented
            throw new NotImplementedException();
        }

        public IEnemy SpawnGreenEnemy()
        {
            // to be implemented
            throw new NotImplementedException();
        }

        public IEnemy SpawnPinkEnemy()
        {
            // to be implemented
            throw new NotImplementedException();
        }

    }
}
