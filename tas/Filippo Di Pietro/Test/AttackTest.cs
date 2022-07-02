using NUnit.Framework;
using System.Collections.Generic;
using tas.Gabos;
using tas.Gabos.enemy;

namespace tas.Filippo_Di_Pietro.Test
{
    [TestFixture]
    public class AttackTest
    {
        static int DEFAULTDAMAGE = 50;
        static int DEFAULTHEALTH = DEFAULTDAMAGE * 2;
        [Test]
        public void BasicTowerAttack()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);
            IEnemy e2 = new FakeEnemy(new Position(101, 101), DEFAULTHEALTH);
            
            enemyList.Add(e1);
            enemyList.Add(e2);

            ITower tower = new BasicTower(new Position(70, 70), DEFAULTDAMAGE, 50, 0, 0, "Torre di Prova", enemyList);
            
            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e1.IsDead());

            enemyList.Remove(e1);

            tower.Compute();


            Assert.IsTrue(e2.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e2.Health < DEFAULTHEALTH / 2 + 1);

            tower.Compute();

            Assert.IsTrue(e2.IsDead());

        }

        [Test]
        public void BasicTowerAttackTooFar()
        {
            IList<IEnemy> enemyList = new List<IEnemy>();
            IEnemy e1 = new FakeEnemy(new Position(100, 100), DEFAULTHEALTH);

            enemyList.Add(e1);

            ITower tower = new BasicTower(new Position(70, 70), DEFAULTDAMAGE, 1, 0, 0, "Torre di Prova", enemyList);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            tower.Compute();

            Assert.IsTrue(e1.Health == DEFAULTHEALTH);

            enemyList.Remove(e1);
        }

        [Test]
        public void MultipleTowerAttack()
        {

        }

        [Test]
        public void AreaTowerAttack()
        {

        }
    }
}
