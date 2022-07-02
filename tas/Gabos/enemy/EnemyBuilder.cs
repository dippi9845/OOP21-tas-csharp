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
        }

        /// <summary>
        ///     Generates an enemy by the given stats
        /// </summary>
        /// <returns> The requested enemy.</returns>
        private IEnemy SpawnGenericEnemy()
        {
            // to be implemented
            throw new NotImplementedException();
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
