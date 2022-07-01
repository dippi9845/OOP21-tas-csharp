using System.Collections.Generic;
using NUnit.Framework;
using tas.Gabos.utils;
using tas.Gabos.enemy;

namespace tas.Gabos.test
{
    [TestFixture]
    public class GenericEnemyTest
    {

        [Test]
        public void TestGetPosition()
        {
            Position pos = new Position(10, 10);
            List<Position> lPos = new List<Position>();
            lPos.Add(pos);
            IEnemy enemy = new GenericEnemy(lPos, 1, 50, 10, 60, new Size(100, 100), "redEnemy");

            Assert.AreEqual(pos.ToString(), enemy.Position.ToString());
        }

    }
}
