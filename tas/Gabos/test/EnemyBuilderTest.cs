using System;
using System.Collections.Generic;
using NUnit.Framework;
using tas.Gabos.utils;
using tas.Gabos.enemy;

namespace tas.Gabos.test
{
    [TestFixture]
    public class EnemyBuilderTest
    {

        [Test]
        public void TestSpawnMultipleEnemies()
        {
            IEnemyBuilder enemyBuilder = new EnemyBuilder(new List<Position>() { new Position(0, 0), new Position(10, 10) });
            IList<IEnemy> enemiesList = new List<IEnemy>();
            int enemiesNumber = 1000;
            int enemiesTypeNumber = 0;

            // get all EnemyBuilder class public methods
            foreach (var method in typeof(EnemyBuilder).GetMethods())
            {
                if (method.IsPublic)
                {
                    if (method.Name.StartsWith("Spawn"))
                    {
                        for (int i = 0; i < enemiesNumber; i++)
                        {
                            enemiesList.Add((IEnemy)method.Invoke(enemyBuilder, new object[] { enemiesTypeNumber }));
                        }
                        enemiesList.Add();
                        enemiesTypeNumber++;
                        Console.WriteLine(enemiesTypeNumber);
                    }
                }
            }

            Assert.Equals(enemiesList.Count, enemiesNumber * enemiesTypeNumber);

        }


    }
}
