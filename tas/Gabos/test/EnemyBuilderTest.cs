using System.Collections.Generic;
using NUnit.Framework;
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
                if (!method.IsPublic)
                {
                    continue;
                }
                if (!method.Name.StartsWith("Spawn"))
                {
                    continue;
                }
                
                for (int i = 0; i < enemiesNumber; i++)
                {
                    IEnemy e = (IEnemy)method.Invoke(enemyBuilder, null);
                    enemiesList.Add(e);
                }
                enemiesTypeNumber++;
            }

            Assert.AreEqual(enemiesList.Count, enemiesNumber * enemiesTypeNumber);

        }


    }
}
